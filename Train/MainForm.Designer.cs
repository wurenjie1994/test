namespace Train
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDriverConsoler = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCabNone = new System.Windows.Forms.RadioButton();
            this.rbCabB = new System.Windows.Forms.RadioButton();
            this.rbCabA = new System.Windows.Forms.RadioButton();
            this.gbSteer = new System.Windows.Forms.GroupBox();
            this.lblEB_EndB = new System.Windows.Forms.Label();
            this.lblBrake_EndB = new System.Windows.Forms.Label();
            this.lblOFF_EndB = new System.Windows.Forms.Label();
            this.lblTraction_EndB = new System.Windows.Forms.Label();
            this.lblTen_EndB = new System.Windows.Forms.Label();
            this.lblZero_EndB = new System.Windows.Forms.Label();
            this.lblNegTen_EndB = new System.Windows.Forms.Label();
            this.trackBarSteer = new System.Windows.Forms.TrackBar();
            this.lblSteerValue_EndB = new System.Windows.Forms.Label();
            this.gbDriveDirection = new System.Windows.Forms.GroupBox();
            this.rbDirectionBackward = new System.Windows.Forms.RadioButton();
            this.rbDirectionZero = new System.Windows.Forms.RadioButton();
            this.rbDirectionForward = new System.Windows.Forms.RadioButton();
            this.btnEBButton = new System.Windows.Forms.Button();
            this.gbTrainState = new System.Windows.Forms.GroupBox();
            this.cbManualAccSpeed = new System.Windows.Forms.CheckBox();
            this.cbManualSpeed = new System.Windows.Forms.CheckBox();
            this.chkBoxTrainIntegrity = new System.Windows.Forms.CheckBox();
            this.nudAccSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblBrakeStatus = new System.Windows.Forms.Label();
            this.lblEBStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gbTrainLocation = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrainLeftLoc = new System.Windows.Forms.Label();
            this.lblTrainRightLoc = new System.Windows.Forms.Label();
            this.gbDriverConsoler.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSteer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSteer)).BeginInit();
            this.gbDriveDirection.SuspendLayout();
            this.gbTrainState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.gbTrainLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDriverConsoler
            // 
            this.gbDriverConsoler.Controls.Add(this.groupBox1);
            this.gbDriverConsoler.Controls.Add(this.gbSteer);
            this.gbDriverConsoler.Controls.Add(this.gbDriveDirection);
            this.gbDriverConsoler.Controls.Add(this.btnEBButton);
            this.gbDriverConsoler.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbDriverConsoler.Location = new System.Drawing.Point(50, 32);
            this.gbDriverConsoler.Name = "gbDriverConsoler";
            this.gbDriverConsoler.Size = new System.Drawing.Size(285, 356);
            this.gbDriverConsoler.TabIndex = 2;
            this.gbDriverConsoler.TabStop = false;
            this.gbDriverConsoler.Text = "驾驶室";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCabNone);
            this.groupBox1.Controls.Add(this.rbCabB);
            this.groupBox1.Controls.Add(this.rbCabA);
            this.groupBox1.Location = new System.Drawing.Point(21, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 102);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "驾驶室选择";
            // 
            // rbCabNone
            // 
            this.rbCabNone.AutoSize = true;
            this.rbCabNone.Checked = true;
            this.rbCabNone.Location = new System.Drawing.Point(29, 49);
            this.rbCabNone.Name = "rbCabNone";
            this.rbCabNone.Size = new System.Drawing.Size(29, 16);
            this.rbCabNone.TabIndex = 1;
            this.rbCabNone.TabStop = true;
            this.rbCabNone.Text = "0";
            this.rbCabNone.UseVisualStyleBackColor = true;
            this.rbCabNone.CheckedChanged += new System.EventHandler(this.rbCabChoose_CheckedChanged);
            // 
            // rbCabB
            // 
            this.rbCabB.AutoSize = true;
            this.rbCabB.Location = new System.Drawing.Point(28, 71);
            this.rbCabB.Name = "rbCabB";
            this.rbCabB.Size = new System.Drawing.Size(47, 16);
            this.rbCabB.TabIndex = 0;
            this.rbCabB.Text = "CabB";
            this.rbCabB.UseVisualStyleBackColor = true;
            this.rbCabB.CheckedChanged += new System.EventHandler(this.rbCabChoose_CheckedChanged);
            // 
            // rbCabA
            // 
            this.rbCabA.AutoSize = true;
            this.rbCabA.Location = new System.Drawing.Point(28, 29);
            this.rbCabA.Name = "rbCabA";
            this.rbCabA.Size = new System.Drawing.Size(47, 16);
            this.rbCabA.TabIndex = 0;
            this.rbCabA.Text = "CabA";
            this.rbCabA.UseVisualStyleBackColor = true;
            this.rbCabA.CheckedChanged += new System.EventHandler(this.rbCabChoose_CheckedChanged);
            // 
            // gbSteer
            // 
            this.gbSteer.Controls.Add(this.lblEB_EndB);
            this.gbSteer.Controls.Add(this.lblBrake_EndB);
            this.gbSteer.Controls.Add(this.lblOFF_EndB);
            this.gbSteer.Controls.Add(this.lblTraction_EndB);
            this.gbSteer.Controls.Add(this.lblTen_EndB);
            this.gbSteer.Controls.Add(this.lblZero_EndB);
            this.gbSteer.Controls.Add(this.lblNegTen_EndB);
            this.gbSteer.Controls.Add(this.trackBarSteer);
            this.gbSteer.Controls.Add(this.lblSteerValue_EndB);
            this.gbSteer.Location = new System.Drawing.Point(144, 20);
            this.gbSteer.Name = "gbSteer";
            this.gbSteer.Size = new System.Drawing.Size(127, 305);
            this.gbSteer.TabIndex = 41;
            this.gbSteer.TabStop = false;
            this.gbSteer.Text = "司控器";
            // 
            // lblEB_EndB
            // 
            this.lblEB_EndB.AutoSize = true;
            this.lblEB_EndB.Location = new System.Drawing.Point(80, 256);
            this.lblEB_EndB.Name = "lblEB_EndB";
            this.lblEB_EndB.Size = new System.Drawing.Size(29, 12);
            this.lblEB_EndB.TabIndex = 54;
            this.lblEB_EndB.Text = "快制";
            // 
            // lblBrake_EndB
            // 
            this.lblBrake_EndB.AutoSize = true;
            this.lblBrake_EndB.Location = new System.Drawing.Point(80, 200);
            this.lblBrake_EndB.Name = "lblBrake_EndB";
            this.lblBrake_EndB.Size = new System.Drawing.Size(29, 12);
            this.lblBrake_EndB.TabIndex = 53;
            this.lblBrake_EndB.Text = "制动";
            // 
            // lblOFF_EndB
            // 
            this.lblOFF_EndB.AutoSize = true;
            this.lblOFF_EndB.Location = new System.Drawing.Point(80, 142);
            this.lblOFF_EndB.Name = "lblOFF_EndB";
            this.lblOFF_EndB.Size = new System.Drawing.Size(23, 12);
            this.lblOFF_EndB.TabIndex = 52;
            this.lblOFF_EndB.Text = "OFF";
            // 
            // lblTraction_EndB
            // 
            this.lblTraction_EndB.AutoSize = true;
            this.lblTraction_EndB.Location = new System.Drawing.Point(80, 64);
            this.lblTraction_EndB.Name = "lblTraction_EndB";
            this.lblTraction_EndB.Size = new System.Drawing.Size(29, 12);
            this.lblTraction_EndB.TabIndex = 52;
            this.lblTraction_EndB.Text = "牵引";
            // 
            // lblTen_EndB
            // 
            this.lblTen_EndB.AutoSize = true;
            this.lblTen_EndB.Location = new System.Drawing.Point(6, 24);
            this.lblTen_EndB.Name = "lblTen_EndB";
            this.lblTen_EndB.Size = new System.Drawing.Size(17, 12);
            this.lblTen_EndB.TabIndex = 51;
            this.lblTen_EndB.Text = "10";
            // 
            // lblZero_EndB
            // 
            this.lblZero_EndB.AutoSize = true;
            this.lblZero_EndB.Location = new System.Drawing.Point(6, 140);
            this.lblZero_EndB.Name = "lblZero_EndB";
            this.lblZero_EndB.Size = new System.Drawing.Size(11, 12);
            this.lblZero_EndB.TabIndex = 51;
            this.lblZero_EndB.Text = "0";
            // 
            // lblNegTen_EndB
            // 
            this.lblNegTen_EndB.AutoSize = true;
            this.lblNegTen_EndB.Location = new System.Drawing.Point(0, 256);
            this.lblNegTen_EndB.Name = "lblNegTen_EndB";
            this.lblNegTen_EndB.Size = new System.Drawing.Size(23, 12);
            this.lblNegTen_EndB.TabIndex = 51;
            this.lblNegTen_EndB.Text = "-10";
            // 
            // trackBarSteer
            // 
            this.trackBarSteer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.trackBarSteer.LargeChange = 1;
            this.trackBarSteer.Location = new System.Drawing.Point(27, 20);
            this.trackBarSteer.Maximum = 20;
            this.trackBarSteer.Name = "trackBarSteer";
            this.trackBarSteer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarSteer.Size = new System.Drawing.Size(45, 258);
            this.trackBarSteer.TabIndex = 3;
            this.trackBarSteer.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSteer.Value = 10;
            this.trackBarSteer.Scroll += new System.EventHandler(this.trackBarSteer_Scroll);
            // 
            // lblSteerValue_EndB
            // 
            this.lblSteerValue_EndB.AutoSize = true;
            this.lblSteerValue_EndB.Location = new System.Drawing.Point(45, 281);
            this.lblSteerValue_EndB.Name = "lblSteerValue_EndB";
            this.lblSteerValue_EndB.Size = new System.Drawing.Size(11, 12);
            this.lblSteerValue_EndB.TabIndex = 50;
            this.lblSteerValue_EndB.Text = "0";
            // 
            // gbDriveDirection
            // 
            this.gbDriveDirection.Controls.Add(this.rbDirectionBackward);
            this.gbDriveDirection.Controls.Add(this.rbDirectionZero);
            this.gbDriveDirection.Controls.Add(this.rbDirectionForward);
            this.gbDriveDirection.Location = new System.Drawing.Point(22, 160);
            this.gbDriveDirection.Name = "gbDriveDirection";
            this.gbDriveDirection.Size = new System.Drawing.Size(99, 87);
            this.gbDriveDirection.TabIndex = 38;
            this.gbDriveDirection.TabStop = false;
            this.gbDriveDirection.Text = "驾驶方向";
            // 
            // rbDirectionBackward
            // 
            this.rbDirectionBackward.AutoSize = true;
            this.rbDirectionBackward.Location = new System.Drawing.Point(28, 64);
            this.rbDirectionBackward.Name = "rbDirectionBackward";
            this.rbDirectionBackward.Size = new System.Drawing.Size(47, 16);
            this.rbDirectionBackward.TabIndex = 0;
            this.rbDirectionBackward.Text = "向后";
            this.rbDirectionBackward.UseVisualStyleBackColor = true;
            this.rbDirectionBackward.CheckedChanged += new System.EventHandler(this.rbDirectionChoose_CheckedChanged);
            // 
            // rbDirectionZero
            // 
            this.rbDirectionZero.AutoSize = true;
            this.rbDirectionZero.Checked = true;
            this.rbDirectionZero.Location = new System.Drawing.Point(28, 42);
            this.rbDirectionZero.Name = "rbDirectionZero";
            this.rbDirectionZero.Size = new System.Drawing.Size(29, 16);
            this.rbDirectionZero.TabIndex = 0;
            this.rbDirectionZero.TabStop = true;
            this.rbDirectionZero.Text = "0";
            this.rbDirectionZero.UseVisualStyleBackColor = true;
            this.rbDirectionZero.CheckedChanged += new System.EventHandler(this.rbDirectionChoose_CheckedChanged);
            // 
            // rbDirectionForward
            // 
            this.rbDirectionForward.AutoSize = true;
            this.rbDirectionForward.Location = new System.Drawing.Point(28, 20);
            this.rbDirectionForward.Name = "rbDirectionForward";
            this.rbDirectionForward.Size = new System.Drawing.Size(47, 16);
            this.rbDirectionForward.TabIndex = 0;
            this.rbDirectionForward.Text = "向前";
            this.rbDirectionForward.UseVisualStyleBackColor = true;
            this.rbDirectionForward.CheckedChanged += new System.EventHandler(this.rbDirectionChoose_CheckedChanged);
            // 
            // btnEBButton
            // 
            this.btnEBButton.Location = new System.Drawing.Point(30, 293);
            this.btnEBButton.Name = "btnEBButton";
            this.btnEBButton.Size = new System.Drawing.Size(75, 23);
            this.btnEBButton.TabIndex = 6;
            this.btnEBButton.Text = "EB";
            this.btnEBButton.UseVisualStyleBackColor = true;
            this.btnEBButton.Click += new System.EventHandler(this.btnEBButton_Click);
            // 
            // gbTrainState
            // 
            this.gbTrainState.Controls.Add(this.cbManualAccSpeed);
            this.gbTrainState.Controls.Add(this.cbManualSpeed);
            this.gbTrainState.Controls.Add(this.chkBoxTrainIntegrity);
            this.gbTrainState.Controls.Add(this.nudAccSpeed);
            this.gbTrainState.Controls.Add(this.nudSpeed);
            this.gbTrainState.Controls.Add(this.lblBrakeStatus);
            this.gbTrainState.Controls.Add(this.lblEBStatus);
            this.gbTrainState.Controls.Add(this.label8);
            this.gbTrainState.Controls.Add(this.label18);
            this.gbTrainState.Controls.Add(this.label16);
            this.gbTrainState.Controls.Add(this.label17);
            this.gbTrainState.Location = new System.Drawing.Point(50, 394);
            this.gbTrainState.Name = "gbTrainState";
            this.gbTrainState.Size = new System.Drawing.Size(271, 173);
            this.gbTrainState.TabIndex = 4;
            this.gbTrainState.TabStop = false;
            this.gbTrainState.Text = "列车状态";
            // 
            // cbManualAccSpeed
            // 
            this.cbManualAccSpeed.AutoSize = true;
            this.cbManualAccSpeed.Location = new System.Drawing.Point(198, 66);
            this.cbManualAccSpeed.Name = "cbManualAccSpeed";
            this.cbManualAccSpeed.Size = new System.Drawing.Size(48, 16);
            this.cbManualAccSpeed.TabIndex = 12;
            this.cbManualAccSpeed.Text = "手动";
            this.cbManualAccSpeed.UseVisualStyleBackColor = true;
            // 
            // cbManualSpeed
            // 
            this.cbManualSpeed.AutoSize = true;
            this.cbManualSpeed.Location = new System.Drawing.Point(198, 43);
            this.cbManualSpeed.Name = "cbManualSpeed";
            this.cbManualSpeed.Size = new System.Drawing.Size(48, 16);
            this.cbManualSpeed.TabIndex = 12;
            this.cbManualSpeed.Text = "手动";
            this.cbManualSpeed.UseVisualStyleBackColor = true;
            // 
            // chkBoxTrainIntegrity
            // 
            this.chkBoxTrainIntegrity.AutoSize = true;
            this.chkBoxTrainIntegrity.Checked = true;
            this.chkBoxTrainIntegrity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxTrainIntegrity.Location = new System.Drawing.Point(21, 139);
            this.chkBoxTrainIntegrity.Name = "chkBoxTrainIntegrity";
            this.chkBoxTrainIntegrity.Size = new System.Drawing.Size(84, 16);
            this.chkBoxTrainIntegrity.TabIndex = 5;
            this.chkBoxTrainIntegrity.Text = "列车完整性";
            this.chkBoxTrainIntegrity.UseVisualStyleBackColor = true;
            // 
            // nudAccSpeed
            // 
            this.nudAccSpeed.DecimalPlaces = 3;
            this.nudAccSpeed.Enabled = false;
            this.nudAccSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudAccSpeed.Location = new System.Drawing.Point(126, 66);
            this.nudAccSpeed.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudAccSpeed.Name = "nudAccSpeed";
            this.nudAccSpeed.ReadOnly = true;
            this.nudAccSpeed.Size = new System.Drawing.Size(66, 21);
            this.nudAccSpeed.TabIndex = 11;
            // 
            // nudSpeed
            // 
            this.nudSpeed.DecimalPlaces = 3;
            this.nudSpeed.Enabled = false;
            this.nudSpeed.Location = new System.Drawing.Point(125, 38);
            this.nudSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.ReadOnly = true;
            this.nudSpeed.Size = new System.Drawing.Size(67, 21);
            this.nudSpeed.TabIndex = 11;
            // 
            // lblBrakeStatus
            // 
            this.lblBrakeStatus.AutoSize = true;
            this.lblBrakeStatus.Location = new System.Drawing.Point(108, 120);
            this.lblBrakeStatus.Name = "lblBrakeStatus";
            this.lblBrakeStatus.Size = new System.Drawing.Size(41, 12);
            this.lblBrakeStatus.TabIndex = 4;
            this.lblBrakeStatus.Text = "label5";
            // 
            // lblEBStatus
            // 
            this.lblEBStatus.AutoSize = true;
            this.lblEBStatus.Location = new System.Drawing.Point(108, 101);
            this.lblEBStatus.Name = "lblEBStatus";
            this.lblEBStatus.Size = new System.Drawing.Size(41, 12);
            this.lblEBStatus.TabIndex = 4;
            this.lblEBStatus.Text = "label5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "制动状态：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 3;
            this.label18.Text = "EB状态：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 3;
            this.label16.Text = "加速度(m/s2)：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "列车速度(km/h)：";
            // 
            // gbTrainLocation
            // 
            this.gbTrainLocation.Controls.Add(this.label2);
            this.gbTrainLocation.Controls.Add(this.lblTrainRightLoc);
            this.gbTrainLocation.Controls.Add(this.lblTrainLeftLoc);
            this.gbTrainLocation.Controls.Add(this.label1);
            this.gbTrainLocation.Location = new System.Drawing.Point(355, 394);
            this.gbTrainLocation.Name = "gbTrainLocation";
            this.gbTrainLocation.Size = new System.Drawing.Size(192, 173);
            this.gbTrainLocation.TabIndex = 10;
            this.gbTrainLocation.TabStop = false;
            this.gbTrainLocation.Text = "位置信息：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(470, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "A端：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "B端：";
            // 
            // lblTrainLeftLoc
            // 
            this.lblTrainLeftLoc.AutoSize = true;
            this.lblTrainLeftLoc.Location = new System.Drawing.Point(92, 47);
            this.lblTrainLeftLoc.Name = "lblTrainLeftLoc";
            this.lblTrainLeftLoc.Size = new System.Drawing.Size(11, 12);
            this.lblTrainLeftLoc.TabIndex = 0;
            this.lblTrainLeftLoc.Text = "0";
            // 
            // lblTrainRightLoc
            // 
            this.lblTrainRightLoc.AutoSize = true;
            this.lblTrainRightLoc.Location = new System.Drawing.Point(92, 70);
            this.lblTrainRightLoc.Name = "lblTrainRightLoc";
            this.lblTrainRightLoc.Size = new System.Drawing.Size(11, 12);
            this.lblTrainRightLoc.TabIndex = 0;
            this.lblTrainRightLoc.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 626);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gbTrainLocation);
            this.Controls.Add(this.gbTrainState);
            this.Controls.Add(this.gbDriverConsoler);
            this.Name = "MainForm";
            this.Text = "Train";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbDriverConsoler.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSteer.ResumeLayout(false);
            this.gbSteer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSteer)).EndInit();
            this.gbDriveDirection.ResumeLayout(false);
            this.gbDriveDirection.PerformLayout();
            this.gbTrainState.ResumeLayout(false);
            this.gbTrainState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.gbTrainLocation.ResumeLayout(false);
            this.gbTrainLocation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriverConsoler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCabB;
        private System.Windows.Forms.RadioButton rbCabA;
        private System.Windows.Forms.GroupBox gbSteer;
        private System.Windows.Forms.Label lblEB_EndB;
        private System.Windows.Forms.Label lblBrake_EndB;
        private System.Windows.Forms.Label lblOFF_EndB;
        private System.Windows.Forms.Label lblTraction_EndB;
        private System.Windows.Forms.Label lblTen_EndB;
        private System.Windows.Forms.Label lblZero_EndB;
        private System.Windows.Forms.Label lblNegTen_EndB;
        private System.Windows.Forms.TrackBar trackBarSteer;
        private System.Windows.Forms.Label lblSteerValue_EndB;
        private System.Windows.Forms.GroupBox gbDriveDirection;
        private System.Windows.Forms.RadioButton rbDirectionBackward;
        private System.Windows.Forms.RadioButton rbDirectionZero;
        private System.Windows.Forms.RadioButton rbDirectionForward;
        private System.Windows.Forms.Button btnEBButton;
        private System.Windows.Forms.GroupBox gbTrainState;
        private System.Windows.Forms.CheckBox cbManualAccSpeed;
        private System.Windows.Forms.CheckBox cbManualSpeed;
        private System.Windows.Forms.CheckBox chkBoxTrainIntegrity;
        private System.Windows.Forms.NumericUpDown nudAccSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label lblBrakeStatus;
        private System.Windows.Forms.Label lblEBStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox gbTrainLocation;
        private System.Windows.Forms.RadioButton rbCabNone;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrainRightLoc;
        private System.Windows.Forms.Label lblTrainLeftLoc;
        private System.Windows.Forms.Label label1;
    }
}

