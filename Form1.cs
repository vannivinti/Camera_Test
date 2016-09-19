using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using TotalPhase;
using System.IO;


namespace CameraTest
{
    public partial class CameraTestForm : Form
    {
        /*=====================================================================
        | CONSTANTS
        ====================================================================*/
        public const int BUFFER_SIZE = 2048;
        public const int I2C_BITRATE = 100;

        enum CameraResolution
        {
            RESOLUTION_768_576,
            RESOLUTION_768_576_DOWN,
            RESOLUTION_768_576_YVYU,
            RESOLUTION_1280_720,
            RESOLUTION_1280_800,
            RESOLUTION_1280_800p30,
            RESOLUTION_768_576p30,
            RESOLUTION_1280_800p30_DW,
            RESOLUTION_800_600p30,
            RESOLUTION_800_600p30_DW,
            RESOLUTION_1024_768p30,
            RESOLUTION_1024_768p30_DW,
            RESOLUTION_1024_576p25,
            RESOLUTION_1024_576p30,
            RESOLUTION_1280_800_p30_test_pattern,
            RESOLUTION_NONE
        }


        private static readonly ILog logger = LogManager.GetLogger(typeof(CameraTestForm));
        private int deviceHandle;
        private int devicePort;
        private CameraResolution cameraRes = CameraResolution.RESOLUTION_NONE;
        FileStream file;

        public CameraTestForm()
        {
            XmlConfigurator.Configure();
            InitializeComponent();
            textBoxPort.Text = "0";
            textBoxAddress.Text = "0x2C";
            textBoxI2CSensAddress.Text = "0x30";

            EnableControls(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Close Host Adapter")
            {
                AardvarkApi.aa_close(deviceHandle);
                button1.Text = "Init SER-DES and Host Adapter";
                logger.Info("Port closed");
                EnableControls(false);
                return;
            }

            ushort[] ports = new ushort[16];
            uint[] uniqueIds = new uint[16];
            int numElem = 16;
            byte[] Sreg = new byte[4];
            byte[] Cmd = new byte[4];
            string info;
            byte i2cDesAddr, 
                 i2cSensAddr;

            // Find all the attached devices
            int count = AardvarkApi.aa_find_devices_ext(numElem,
                                                        ports,
                                                        numElem,
                                                        uniqueIds);

            if (count != 0)
            {
                info = String.Format("Found {0} devices", count);
                logger.Info(info);
            }
            else
            {
                logger.Fatal("Device not found");
                return;
            }

            // Parse the port argument
            try
            {
                devicePort = Convert.ToInt32(textBoxPort.Text);
            }
            catch (Exception)
            {
                logger.Error("ERROR: invalid port");
                return;
            }

            // Parse the Deserialyzer address argument
            try
            {
                if (textBoxAddress.Text.StartsWith("0x"))
                {
                    i2cDesAddr = Convert.ToByte(textBoxAddress.Text.Substring(2), 16);
                }
                else
                {
                    i2cDesAddr = Convert.ToByte(textBoxAddress.Text);
                }
            }
            catch (Exception)
            {
                logger.Error("Error: invalid DES address");
                return;
            }

            // Parse the Sensor address argument
            try
            {
                if (textBoxI2CSensAddress.Text.StartsWith("0x"))
                {
                    i2cSensAddr = Convert.ToByte(textBoxI2CSensAddress.Text.Substring(2), 16);
                }
                else
                {
                    i2cSensAddr = Convert.ToByte(textBoxAddress.Text);
                }
            }
            catch (Exception)
            {
                logger.Error("Error: invalid Sensor address");
                return;
            }

            // Open the device
            deviceHandle = AardvarkApi.aa_open(devicePort);
            if (deviceHandle <= 0)
            {
                info = String.Format("Unable to open Aardvark device on port {0}", devicePort);
                logger.Error(info);

                info = String.Format("ERROR: {0}", AardvarkApi.aa_status_string(deviceHandle));
                logger.Error(info);
                return;
            }

            // Ensure that the I2C subsystem is enabled
            AardvarkApi.aa_configure(deviceHandle, AardvarkConfig.AA_CONFIG_SPI_I2C);

            // Enable the I2C bus pullup resistors (2.2k resistors).
            // This command is only effective on v2.0 hardware or greater.
            // The pullup resistors on the v1.02 hardware are enabled by default.
            AardvarkApi.aa_i2c_pullup(deviceHandle, AardvarkApi.AA_I2C_PULLUP_BOTH);

            // Enable the Aardvark adapter's power pins.
            // This command is only effective on v2.0 hardware or greater.
            // The power pins on the v1.02 hardware are not enabled by default.
            AardvarkApi.aa_target_power(deviceHandle, AardvarkApi.AA_TARGET_POWER_BOTH);

            // Setup the bitrate
            int bitrate = AardvarkApi.aa_i2c_bitrate(deviceHandle, I2C_BITRATE);
            info = String.Format("Bitrate set to {0} kHz", bitrate);
            logger.Info(info);

            byte[] dataOut = new byte[2];
            dataOut[0] = 0x03;
            dataOut[1] = 0xF8;
            count = AardvarkApi.aa_i2c_write(deviceHandle,
                                            i2cDesAddr,
                                            AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                            2,
                                            dataOut);
            if (count != 2)
            {
                info = String.Format("ERROR: error: only a partial number of bytes written - ({0}) instead of full (2)", count);
                logger.Error(info);
                return;
            }

            dataOut[0] = 0x05;
            dataOut[1] = 0xAE;
            count = AardvarkApi.aa_i2c_write(deviceHandle,
                                            i2cDesAddr,
                                            AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                            2,
                                            dataOut);
            if (count != 2)
            {
                info = String.Format("ERROR: error: only a partial number of bytes written - ({0}) instead of full (2)", count);
                logger.Error(info);
                return;
            }

            dataOut[0] = 0x08;
            dataOut[1] = 0x60;
            count = AardvarkApi.aa_i2c_write(deviceHandle,
                                            i2cDesAddr,
                                            AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                            2,
                                            dataOut);
            if (count != 2)
            {
                info = String.Format("ERROR: error: only a partial number of bytes written - ({0}) instead of full (2)", count);
                logger.Error(info);
                return;
            }

            dataOut[0] = 0x10;
            dataOut[1] = 0x60;
            count = AardvarkApi.aa_i2c_write(deviceHandle,
                                            i2cDesAddr,
                                            AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                            2,
                                            dataOut);
            if (count != 2)
            {
                info = String.Format("ERROR: error: only a partial number of bytes written - ({0}) instead of full (2)", count);
                logger.Error(info);
                return;
            }

            logger.Info("SER-DES chain initialized");
            button1.Text = "Close Host Adapter";
            EnableControls(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte i2cAddr;
            int trans_num = 0;
            string info;
            byte[] dataOut = new byte[BUFFER_SIZE];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    // Read from the file
                    file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                }
                catch (Exception)
                {
                    info = String.Format("Unable to open file '{0}'", openFileDialog.FileName);
                    logger.Error(info);
                    return;
                }

                // Parse the I2C address argument
                try
                {
                    if (radioButtonDes.Checked == true)
                    {
                        if (textBoxAddress.Text.StartsWith("0x"))
                        {
                            i2cAddr = Convert.ToByte(textBoxAddress.Text.Substring(2), 16);
                        }
                        else
                        {
                            i2cAddr = Convert.ToByte(textBoxAddress.Text);
                        }
                    }
                    else
                    {
                        if (textBoxI2CSensAddress.Text.StartsWith("0x"))
                        {
                            i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text.Substring(2), 16);
                        }
                        else
                        {
                            i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text);
                        }
                    }
                }
                catch (Exception)
                {
                    logger.Error("Error: invalid I2C address");
                    return;
                }

                while (file.Length != file.Position)
                {
                    int numWrite, count;
                    int i;

                    numWrite = file.Read(dataOut, 0, BUFFER_SIZE);
                    if (numWrite == 0)
                    {
                        break;
                    }
          
                    if (numWrite < BUFFER_SIZE)
                    {
                        byte[] temp = new byte[numWrite];
                        for (i = 0; i < numWrite; i++)
                        {
                            temp[i] = dataOut[i];
                        }
                        dataOut = temp;
                    }

                    // Write the data to the bus
                    count = AardvarkApi.aa_i2c_write(deviceHandle,
                                                     i2cAddr,
                                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                                     BUFFER_SIZE, dataOut);
                    if (count < 0)
                    {
                        info = String.Format("ERROR: {0}", AardvarkApi.aa_status_string(count));
                        logger.Error(info);
                        break;
                    }
                    else if (count == 0)
                    {
                        info = String.Format("ERROR: no bytes written, are you sure you have the right slave address?");
                        logger.Error(info);
                        break;
                    }
                    else if (count != numWrite)
                    {
                        info = String.Format("ERROR: error: only a partial number of bytes written - ({0}) instead of full ({1})",
                                             count, numWrite);
                        logger.Error(info);
                        break;
                    }

                    info = String.Format("*** Transaction #{0:d2}", trans_num);
                    logger.Info(info);

                    // Dump the data to the screen
                    info =String.Format("Data written to device:");
                    logger.Info(info);

                    for (i = 0; i < count; ++i)
                    {
                        if ((i & 0x0f) == 0)
                        {
                            Console.Write("\n{0:x4}:  ", i);
                        }
                           
                        Console.Write("{0:x2} ", dataOut[i] & 0xff);
                        if (((i + 1) & 0x07) == 0)
                        {
                            Console.Write(" ");
                        }
                    }

                    logger.Info("");
                    logger.Info("");
                    ++trans_num;

                    // Sleep a tad to make sure slave has time to process this request
                    AardvarkApi.aa_sleep_ms(10);
                }

                file.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ushort regAddress;
            ushort length;
            string info;
            byte i2cAddr;

            try
            {
                if (textBoxRegAddress.Text.StartsWith("0x"))
                {
                    regAddress = Convert.ToUInt16(textBoxRegAddress.Text.Substring(2), 16);
                }
                else
                {
                    regAddress = Convert.ToUInt16(textBoxRegAddress.Text);
                }
            }
            catch (Exception)
            {
                logger.Error("ERROR: invalid regAddress addr");
                return;
            }

            try
            {
                if (textBoxLength.Text.StartsWith("0x"))
                {
                    length = Convert.ToUInt16(textBoxLength.Text.Substring(2), 16);
                }
                else
                {
                    length = Convert.ToUInt16(textBoxLength.Text);
                }
            }
            catch (Exception)
            {
                logger.Error("ERROR: invalid length");
                return;
            }

            // Parse the I2C address argument
            try
            {
                if (radioButtonDes.Checked == true)
                {
                    if (textBoxAddress.Text.StartsWith("0x"))
                    {
                        i2cAddr = Convert.ToByte(textBoxAddress.Text.Substring(2), 16);
                    }
                    else
                    {
                        i2cAddr = Convert.ToByte(textBoxAddress.Text);
                    }
                }
                else
                {
                    if (textBoxI2CSensAddress.Text.StartsWith("0x"))
                    {
                        i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text.Substring(2), 16);
                    }
                    else
                    {
                        i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text);
                    }
                }
            }
            catch (Exception)
            {
                logger.Error("Error: invalid I2C address");
                return;
            }

            int count, i;
            byte[] dataOut = new byte[2];
            byte[] dataIn = new byte[length];
            ushort addrLength = 1;

            if(regAddress>255)
            {
                dataOut[0] = (byte)(regAddress >> 8);
                dataOut[1] = (byte)(regAddress & 0xFF);
                addrLength = 2;
            }
            else
            {
                dataOut[0] = (byte)(regAddress & 0xFF);
            }
            

            // Write the address
            AardvarkApi.aa_i2c_write(deviceHandle,
                                     i2cAddr,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     addrLength, 
                                     dataOut);

            count = AardvarkApi.aa_i2c_read(deviceHandle,
                                            i2cAddr,
                                            AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                            length, 
                                            dataIn);
            if (count < 0)
            {
                info = String.Format("ERROR: {0}\n", AardvarkApi.aa_status_string(count));
                logger.Error(info);
                return;
            }
            if (count == 0)
            {
                logger.Error("error: no bytes read");
                logger.Error("  are you sure you have the right slave address?");
                return;
            }
            else if (count != length)
            {
                info = String.Format("ERROR: read {0} bytes (expected {1})", count, 1);
                logger.Error(info);
            }

            // Dump the data to the screen
            logger.Info("\nData read from device:");
            for (i = 0; i < count; ++i)
            {
                if ((i & 0x0f) == 0)
                {
                    info = String.Format("0x{0:x4}:  ", regAddress + i);
                    logger.Info(info);
                }

                info = String.Format("0x{0:x2} ", dataIn[i] & 0xff);
                logger.Info(info);
                if (((i + 1) & 0x07) == 0)
                {
                    logger.Error(" ");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte regAddress;
            ushort length;
            string info;
            byte i2cAddr;


            // Parse the I2C address argument
            try
            {
                if (radioButtonDes.Checked == true)
                {
                    if (textBoxAddress.Text.StartsWith("0x"))
                    {
                        i2cAddr = Convert.ToByte(textBoxAddress.Text.Substring(2), 16);
                    }
                    else
                    {
                        i2cAddr = Convert.ToByte(textBoxAddress.Text);
                    }
                }
                else
                {
                    if (textBoxI2CSensAddress.Text.StartsWith("0x"))
                    {
                        i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text.Substring(2), 16);
                    }
                    else
                    {
                        i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text);
                    }
                }
            }
            catch (Exception)
            {
                logger.Error("Error: invalid I2C address");
                return;
            }

            try
            {
                if (textBoxRegAddress.Text.StartsWith("0x"))
                {
                    regAddress = Convert.ToByte(textBoxRegAddress.Text.Substring(2), 16);
                }
                else
                {
                    regAddress = Convert.ToByte(textBoxRegAddress.Text);
                }
            }
            catch (Exception)
            {
                logger.Error("ERROR: invalid regAddress addr");
                return;
            }

            string[] values = textBoxDataWrite.Text.Split(',').Select(sValue => sValue.Trim()).ToArray();

            // Write address and data
            int count, i = 1;
            byte[] dataOut = new byte[values.Length+1];
            dataOut[0] = regAddress;
            length = (ushort)(values.Length + 1);

            foreach (string svalue in values)
            {
                try
                {
                    if (svalue.StartsWith("0x"))
                    {
                        dataOut[i++] = Convert.ToByte(svalue.Substring(2), 16);
                    }
                    else
                    {
                        dataOut[i++] = Convert.ToByte(svalue);
                    }
                }
                catch (Exception)
                {
                    logger.Error("ERROR: data value");
                    return;
                }
            }

            count = AardvarkApi.aa_i2c_write(deviceHandle,
                                             i2cAddr,
                                             AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                             length,
                                             dataOut);
            if (count < 0)
            {
                info = String.Format("ERROR: {0}\n", AardvarkApi.aa_status_string(count));
                logger.Error(info);
                return;
            }
            if (count == 0)
            {
                logger.Error("error: no bytes written");
                logger.Error("  are you sure you have the right slave address?");
                return;
            }
            else if (count != length)
            {
                info = String.Format("ERROR: written {0} bytes (expected {1})", count, length);
                logger.Error(info);
            }
        }

        private void EnableControls(bool isTrue)
        {
            button2.Enabled = isTrue;
            button3.Enabled = isTrue;
            button4.Enabled = isTrue;
            button5.Enabled = isTrue;
        }

        private void MenuClick(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in sensorCameraSettingsToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
                cameraRes = CameraResolution.RESOLUTION_NONE;
            }

            ToolStripMenuItem item2 = (ToolStripMenuItem)sender;
            if(item2.Text == "RESOLUTION_768_576")
            {
                item2.Checked = true;
                cameraRes = CameraResolution.RESOLUTION_768_576;
            }
            else if (item2.Text == "RESOLUTION_768_576p30") 
            {
                item2.Checked = true;
                cameraRes = CameraResolution.RESOLUTION_768_576p30;
            }
            else if (item2.Text == "RESOLUTION_768_576_DOWN")
            {
                item2.Checked = true;
                cameraRes = CameraResolution.RESOLUTION_768_576_DOWN;
            }
            else if (item2.Text == "RESOLUTION_1280_800_p30_test_pattern")
            {
                item2.Checked = true;
                cameraRes = CameraResolution.RESOLUTION_1280_800_p30_test_pattern;
            }
            else
            {
                logger.Info("Configuration table not available");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte    i2cAddr;
            int     count;
            byte[]  dataOut = new byte[3];
            string  info;

            if(cameraRes == CameraResolution.RESOLUTION_NONE)
            {
                logger.Error("Configuration table not selected");
                return;
            }

            // Parse the I2C address argument
            try
            {
                if (textBoxI2CSensAddress.Text.StartsWith("0x"))
                {
                    i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text.Substring(2), 16);
                }
                else
                {
                    i2cAddr = Convert.ToByte(textBoxI2CSensAddress.Text);
                }
            }
            catch (Exception)
            {
                logger.Error("ERROR: wrong Camera sensor address");
                return;
            }

            if (cameraRes == CameraResolution.RESOLUTION_768_576)
            {
                for (int i = 0; i < CameraSettings.table_reg_ov_768_576.Length / 2; i++)
                {
                    dataOut[0] = (byte)((CameraSettings.table_reg_ov_768_576[i, 0] >> 8) & 0xFF);
                    dataOut[1] = (byte)(CameraSettings.table_reg_ov_768_576[i, 0] & 0xFF);
                    dataOut[2] = (byte)(CameraSettings.table_reg_ov_768_576[i, 1] & 0xFF);

                    count = AardvarkApi.aa_i2c_write(deviceHandle,
                                                     i2cAddr,
                                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                                     3,
                                                     dataOut);
                    if (count < 0)
                    {
                        info = String.Format("ERROR: {0}\n", AardvarkApi.aa_status_string(count));
                        logger.Error(info);
                        return;
                    }
                    if (count == 0)
                    {
                        logger.Error("error: no bytes written");
                        logger.Error("  are you sure you have the right slave address?");
                        return;
                    }
                    else if (count != 3)
                    {
                        info = String.Format("ERROR: written {0} bytes (expected 3)", count);
                        logger.Error(info);
                        return;
                    }
                }
            }
            else if (cameraRes == CameraResolution.RESOLUTION_768_576p30)
            {
                for (int i = 0; i < CameraSettings.table_reg_ov_768_576_p30.Length / 2; i++)
                {
                    dataOut[0] = (byte)((CameraSettings.table_reg_ov_768_576_p30[i, 0] >> 8) & 0xFF);
                    dataOut[1] = (byte)(CameraSettings.table_reg_ov_768_576_p30[i, 0] & 0xFF);
                    dataOut[2] = (byte)(CameraSettings.table_reg_ov_768_576_p30[i, 1] & 0xFF);

                    count = AardvarkApi.aa_i2c_write(deviceHandle,
                                                     i2cAddr,
                                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                                     3,
                                                     dataOut);
                    if (count < 0)
                    {
                        info = String.Format("ERROR: {0}\n", AardvarkApi.aa_status_string(count));
                        logger.Error(info);
                        return;
                    }
                    if (count == 0)
                    {
                        logger.Error("error: no bytes written");
                        logger.Error("  are you sure you have the right slave address?");
                        return;
                    }
                    else if (count != 3)
                    {
                        info = String.Format("ERROR: written {0} bytes (expected 3)", count);
                        logger.Error(info);
                        return;
                    }
                }
            }
            else if (cameraRes == CameraResolution.RESOLUTION_768_576_DOWN)
            {
                for (int i = 0; i < CameraSettings.table_reg_ov_768_576_down.Length / 2; i++)
                {
                    dataOut[0] = (byte)((CameraSettings.table_reg_ov_768_576_down[i, 0] >> 8) & 0xFF);
                    dataOut[1] = (byte)(CameraSettings.table_reg_ov_768_576_down[i, 0] & 0xFF);
                    dataOut[2] = (byte)(CameraSettings.table_reg_ov_768_576_down[i, 1] & 0xFF);

                    count = AardvarkApi.aa_i2c_write(deviceHandle,
                                                     i2cAddr,
                                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                                     3,
                                                     dataOut);
                    if (count < 0)
                    {
                        info = String.Format("ERROR: {0}\n", AardvarkApi.aa_status_string(count));
                        logger.Error(info);
                        return;
                    }
                    if (count == 0)
                    {
                        logger.Error("error: no bytes written");
                        logger.Error("  are you sure you have the right slave address?");
                        return;
                    }
                    else if (count != 3)
                    {
                        info = String.Format("ERROR: written {0} bytes (expected 3)", count);
                        logger.Error(info);
                        return;
                    }
                }
            }
            else if (cameraRes == CameraResolution.RESOLUTION_1280_800_p30_test_pattern)
            {
                for (int i = 0; i < CameraSettings.table_reg_ov_1280_800_p30_test_pattern.Length / 2; i++)
                {
                    dataOut[0] = (byte)((CameraSettings.table_reg_ov_1280_800_p30_test_pattern[i, 0] >> 8) & 0xFF);
                    dataOut[1] = (byte)(CameraSettings.table_reg_ov_1280_800_p30_test_pattern[i, 0] & 0xFF);
                    dataOut[2] = (byte)(CameraSettings.table_reg_ov_1280_800_p30_test_pattern[i, 1] & 0xFF);

                    count = AardvarkApi.aa_i2c_write(deviceHandle,
                                                     i2cAddr,
                                                     AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                                     3,
                                                     dataOut);
                    if (count < 0)
                    {
                        info = String.Format("ERROR: {0}\n", AardvarkApi.aa_status_string(count));
                        logger.Error(info);
                        return;
                    }
                    if (count == 0)
                    {
                        logger.Error("error: no bytes written");
                        logger.Error("  are you sure you have the right slave address?");
                        return;
                    }
                    else if (count != 3)
                    {
                        info = String.Format("ERROR: written {0} bytes (expected 3)", count);
                        logger.Error(info);
                        return;
                    }
                }
            }

            logger.Info("New camera setting applied");
        }

    }

}
