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


        private static readonly ILog logger = LogManager.GetLogger(typeof(CameraTestForm));
        private int deviceHandle;
        private int devicePort;
        byte deviceAddress;
        FileStream file;

        public CameraTestForm()
        {
            XmlConfigurator.Configure();
            InitializeComponent();
            //textboxAppender = new TextBoxAppender();
            //textboxAppender.FormName = "MainForm";
            //textboxAppender.TextBoxName = "textBoxLog";
            textBoxPort.Text = "0";
            textBoxAddress.Text = "0x2C";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Close I2C Host Adapter")
            {
                AardvarkApi.aa_close(deviceHandle);
                button1.Text = "Init I2C Host Adapter";
                return;
            }

            ushort[] ports = new ushort[16];
            uint[] uniqueIds = new uint[16];
            int numElem = 16;
            byte[] Sreg = new byte[4];
            byte[] Cmd = new byte[4];
            string info;

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

            // Parse the device address argument
            try
            {
                if (textBoxAddress.Text.StartsWith("0x"))
                {
                    deviceAddress = Convert.ToByte(textBoxAddress.Text.Substring(2), 16);
                }
                else
                {
                    deviceAddress = Convert.ToByte(textBoxAddress.Text);
                }
            }
            catch (Exception)
            {
                logger.Error("Error: invalid device addr");
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

            //blastBytes(deviceHandle, deviceAddress, filename);
            button1.Text = "Close I2C Host Adapter";
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                                                     deviceAddress,
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
                                     deviceAddress,
                                     AardvarkI2cFlags.AA_I2C_NO_STOP,
                                     addrLength, 
                                     dataOut);

            count = AardvarkApi.aa_i2c_read(deviceHandle,
                                            deviceAddress,
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
                                            deviceAddress,
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

    }

}
