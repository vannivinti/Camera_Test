namespace CameraTest
{
    partial class CameraTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.RichTextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRegAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxDataWrite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxI2CSensAddress = new System.Windows.Forms.TextBox();
            this.radioButtonDes = new System.Windows.Forms.RadioButton();
            this.radioButtonSens = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sensorCameraSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set768x576ModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRESOLUTION768576DOWNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION768576YVYUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1280720ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1280800ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1280800p30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION768576p30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1280800p30DWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION800600p30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION800600p30DWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1024768p30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1024768p30DWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1024576p25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1024576p30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESOLUTION1280800p30testpatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(536, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Init SER-DES and Host Adapter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(26, 498);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(681, 316);
            this.textBoxLog.TabIndex = 1;
            this.textBoxLog.Text = "";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(36, 41);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 22);
            this.textBoxPort.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "AARDVARK PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "I2C DES ADDRESS";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(36, 74);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(100, 22);
            this.textBoxAddress.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(36, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 51);
            this.button2.TabIndex = 6;
            this.button2.Text = "Send file to I2C";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(36, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 51);
            this.button3.TabIndex = 7;
            this.button3.Text = "Read Register from I2C";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(410, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "REGISTER ADDRESS";
            // 
            // textBoxRegAddress
            // 
            this.textBoxRegAddress.Location = new System.Drawing.Point(292, 303);
            this.textBoxRegAddress.Name = "textBoxRegAddress";
            this.textBoxRegAddress.Size = new System.Drawing.Size(100, 22);
            this.textBoxRegAddress.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(410, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "READ LENGTH";
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(292, 340);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(100, 22);
            this.textBoxLength.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(36, 369);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(187, 51);
            this.button4.TabIndex = 12;
            this.button4.Text = "Write Register to I2C";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxDataWrite
            // 
            this.textBoxDataWrite.Location = new System.Drawing.Point(36, 442);
            this.textBoxDataWrite.Name = "textBoxDataWrite";
            this.textBoxDataWrite.Size = new System.Drawing.Size(415, 22);
            this.textBoxDataWrite.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(482, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "DATA TO BE WRITTEN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(153, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "I2C SENSOR ADDRESS";
            // 
            // textBoxI2CSensAddress
            // 
            this.textBoxI2CSensAddress.Location = new System.Drawing.Point(36, 110);
            this.textBoxI2CSensAddress.Name = "textBoxI2CSensAddress";
            this.textBoxI2CSensAddress.Size = new System.Drawing.Size(100, 22);
            this.textBoxI2CSensAddress.TabIndex = 15;
            // 
            // radioButtonDes
            // 
            this.radioButtonDes.AutoSize = true;
            this.radioButtonDes.Checked = true;
            this.radioButtonDes.Location = new System.Drawing.Point(411, 144);
            this.radioButtonDes.Name = "radioButtonDes";
            this.radioButtonDes.Size = new System.Drawing.Size(125, 21);
            this.radioButtonDes.TabIndex = 17;
            this.radioButtonDes.TabStop = true;
            this.radioButtonDes.Text = "TO/FROM DES";
            this.radioButtonDes.UseVisualStyleBackColor = true;
            // 
            // radioButtonSens
            // 
            this.radioButtonSens.AutoSize = true;
            this.radioButtonSens.Location = new System.Drawing.Point(552, 145);
            this.radioButtonSens.Name = "radioButtonSens";
            this.radioButtonSens.Size = new System.Drawing.Size(155, 21);
            this.radioButtonSens.TabIndex = 18;
            this.radioButtonSens.Text = "TO/FROM SENSOR";
            this.radioButtonSens.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sensorCameraSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 28);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sensorCameraSettingsToolStripMenuItem
            // 
            this.sensorCameraSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.set768x576ModeToolStripMenuItem,
            this.setRESOLUTION768576DOWNToolStripMenuItem,
            this.rESOLUTION768576YVYUToolStripMenuItem,
            this.rESOLUTION1280720ToolStripMenuItem,
            this.rESOLUTION1280800ToolStripMenuItem,
            this.rESOLUTION1280800p30ToolStripMenuItem,
            this.rESOLUTION768576p30ToolStripMenuItem,
            this.rESOLUTION1280800p30DWToolStripMenuItem,
            this.rESOLUTION800600p30ToolStripMenuItem,
            this.rESOLUTION800600p30DWToolStripMenuItem,
            this.rESOLUTION1024768p30ToolStripMenuItem,
            this.rESOLUTION1024768p30DWToolStripMenuItem,
            this.rESOLUTION1024576p25ToolStripMenuItem,
            this.rESOLUTION1024576p30ToolStripMenuItem,
            this.rESOLUTION1280800p30testpatternToolStripMenuItem});
            this.sensorCameraSettingsToolStripMenuItem.Name = "sensorCameraSettingsToolStripMenuItem";
            this.sensorCameraSettingsToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.sensorCameraSettingsToolStripMenuItem.Text = "Sensor camera resolution";
            // 
            // set768x576ModeToolStripMenuItem
            // 
            this.set768x576ModeToolStripMenuItem.Name = "set768x576ModeToolStripMenuItem";
            this.set768x576ModeToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.set768x576ModeToolStripMenuItem.Text = "RESOLUTION_768_576";
            this.set768x576ModeToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // setRESOLUTION768576DOWNToolStripMenuItem
            // 
            this.setRESOLUTION768576DOWNToolStripMenuItem.Name = "setRESOLUTION768576DOWNToolStripMenuItem";
            this.setRESOLUTION768576DOWNToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.setRESOLUTION768576DOWNToolStripMenuItem.Text = "RESOLUTION_768_576_DOWN";
            this.setRESOLUTION768576DOWNToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION768576YVYUToolStripMenuItem
            // 
            this.rESOLUTION768576YVYUToolStripMenuItem.Name = "rESOLUTION768576YVYUToolStripMenuItem";
            this.rESOLUTION768576YVYUToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION768576YVYUToolStripMenuItem.Text = "RESOLUTION_768_576_YVYU";
            this.rESOLUTION768576YVYUToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1280720ToolStripMenuItem
            // 
            this.rESOLUTION1280720ToolStripMenuItem.Name = "rESOLUTION1280720ToolStripMenuItem";
            this.rESOLUTION1280720ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1280720ToolStripMenuItem.Text = "RESOLUTION_1280_720";
            this.rESOLUTION1280720ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1280800ToolStripMenuItem
            // 
            this.rESOLUTION1280800ToolStripMenuItem.Name = "rESOLUTION1280800ToolStripMenuItem";
            this.rESOLUTION1280800ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1280800ToolStripMenuItem.Text = "RESOLUTION_1280_800";
            this.rESOLUTION1280800ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1280800p30ToolStripMenuItem
            // 
            this.rESOLUTION1280800p30ToolStripMenuItem.Name = "rESOLUTION1280800p30ToolStripMenuItem";
            this.rESOLUTION1280800p30ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1280800p30ToolStripMenuItem.Text = "RESOLUTION_1280_800p30";
            this.rESOLUTION1280800p30ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION768576p30ToolStripMenuItem
            // 
            this.rESOLUTION768576p30ToolStripMenuItem.Name = "rESOLUTION768576p30ToolStripMenuItem";
            this.rESOLUTION768576p30ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION768576p30ToolStripMenuItem.Text = "RESOLUTION_768_576p30";
            this.rESOLUTION768576p30ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1280800p30DWToolStripMenuItem
            // 
            this.rESOLUTION1280800p30DWToolStripMenuItem.Name = "rESOLUTION1280800p30DWToolStripMenuItem";
            this.rESOLUTION1280800p30DWToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1280800p30DWToolStripMenuItem.Text = "RESOLUTION_1280_800p30_DW";
            this.rESOLUTION1280800p30DWToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION800600p30ToolStripMenuItem
            // 
            this.rESOLUTION800600p30ToolStripMenuItem.Name = "rESOLUTION800600p30ToolStripMenuItem";
            this.rESOLUTION800600p30ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION800600p30ToolStripMenuItem.Text = "RESOLUTION_800_600p30";
            this.rESOLUTION800600p30ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION800600p30DWToolStripMenuItem
            // 
            this.rESOLUTION800600p30DWToolStripMenuItem.Name = "rESOLUTION800600p30DWToolStripMenuItem";
            this.rESOLUTION800600p30DWToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION800600p30DWToolStripMenuItem.Text = "RESOLUTION_800_600p30_DW";
            this.rESOLUTION800600p30DWToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1024768p30ToolStripMenuItem
            // 
            this.rESOLUTION1024768p30ToolStripMenuItem.Name = "rESOLUTION1024768p30ToolStripMenuItem";
            this.rESOLUTION1024768p30ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1024768p30ToolStripMenuItem.Text = "RESOLUTION_1024_768p30";
            this.rESOLUTION1024768p30ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1024768p30DWToolStripMenuItem
            // 
            this.rESOLUTION1024768p30DWToolStripMenuItem.Name = "rESOLUTION1024768p30DWToolStripMenuItem";
            this.rESOLUTION1024768p30DWToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1024768p30DWToolStripMenuItem.Text = "RESOLUTION_1024_768p30_DW";
            this.rESOLUTION1024768p30DWToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1024576p25ToolStripMenuItem
            // 
            this.rESOLUTION1024576p25ToolStripMenuItem.Name = "rESOLUTION1024576p25ToolStripMenuItem";
            this.rESOLUTION1024576p25ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1024576p25ToolStripMenuItem.Text = "RESOLUTION_1024_576p25";
            this.rESOLUTION1024576p25ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1024576p30ToolStripMenuItem
            // 
            this.rESOLUTION1024576p30ToolStripMenuItem.Name = "rESOLUTION1024576p30ToolStripMenuItem";
            this.rESOLUTION1024576p30ToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1024576p30ToolStripMenuItem.Text = "RESOLUTION_1024_576p30";
            this.rESOLUTION1024576p30ToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rESOLUTION1280800p30testpatternToolStripMenuItem
            // 
            this.rESOLUTION1280800p30testpatternToolStripMenuItem.Name = "rESOLUTION1280800p30testpatternToolStripMenuItem";
            this.rESOLUTION1280800p30testpatternToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
            this.rESOLUTION1280800p30testpatternToolStripMenuItem.Text = "RESOLUTION_1280_800_p30_test_pattern";
            this.rESOLUTION1280800p30testpatternToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(307, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(187, 51);
            this.button5.TabIndex = 20;
            this.button5.Text = "Send Camera Settings";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // CameraTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 838);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.radioButtonSens);
            this.Controls.Add(this.radioButtonDes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxI2CSensAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDataWrite);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRegAddress);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CameraTestForm";
            this.Text = "Camera Test";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRegAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxDataWrite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxI2CSensAddress;
        private System.Windows.Forms.RadioButton radioButtonDes;
        private System.Windows.Forms.RadioButton radioButtonSens;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sensorCameraSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem set768x576ModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setRESOLUTION768576DOWNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION768576YVYUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1280720ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1280800ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1280800p30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION768576p30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1280800p30DWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION800600p30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION800600p30DWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1024768p30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1024768p30DWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1024576p25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1024576p30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESOLUTION1280800p30testpatternToolStripMenuItem;
        private System.Windows.Forms.Button button5;
    }
}

