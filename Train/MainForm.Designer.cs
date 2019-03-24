﻿namespace Train
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
            this.components = new System.ComponentModel.Container();
            this.gbDriverConsoler = new System.Windows.Forms.GroupBox();
            this.gbWorkMode = new System.Windows.Forms.GroupBox();
            this.rbCO = new System.Windows.Forms.RadioButton();
            this.rbOS = new System.Windows.Forms.RadioButton();
            this.rbSB = new System.Windows.Forms.RadioButton();
            this.rbSL = new System.Windows.Forms.RadioButton();
            this.rbPT = new System.Windows.Forms.RadioButton();
            this.rbTR = new System.Windows.Forms.RadioButton();
            this.rbIS = new System.Windows.Forms.RadioButton();
            this.rbSH = new System.Windows.Forms.RadioButton();
            this.rbFS = new System.Windows.Forms.RadioButton();
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
            this.gbControlLevel = new System.Windows.Forms.GroupBox();
            this.rbCTCS_2 = new System.Windows.Forms.RadioButton();
            this.rbCTCS_3 = new System.Windows.Forms.RadioButton();
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrainRightLoc = new System.Windows.Forms.Label();
            this.lblTrainLeftLoc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.初始化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通信初始化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列车初始化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立通信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nRBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开通信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disRBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disNRBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列车位置设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.故障注入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列车打滑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无应答器故障ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.倒溜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列车空转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.零速设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.零速ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.非零速ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_RBC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_NRBC = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerConnStatus = new System.Windows.Forms.Timer(this.components);
            this.lvRecvMsg = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.发送消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Message129ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Message155ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Message156ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Message157ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Message159ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg157Packet4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg157Packet44ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg157NoPacketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg159Packet3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg159NoPacketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Message132ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Message136ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg136NoPacketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg132NoPacketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Msg132Packet9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvSendMsg = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbDriverConsoler.SuspendLayout();
            this.gbWorkMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSteer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSteer)).BeginInit();
            this.gbControlLevel.SuspendLayout();
            this.gbDriveDirection.SuspendLayout();
            this.gbTrainState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.gbTrainLocation.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDriverConsoler
            // 
            this.gbDriverConsoler.Controls.Add(this.gbWorkMode);
            this.gbDriverConsoler.Controls.Add(this.groupBox1);
            this.gbDriverConsoler.Controls.Add(this.gbSteer);
            this.gbDriverConsoler.Controls.Add(this.gbControlLevel);
            this.gbDriverConsoler.Controls.Add(this.gbDriveDirection);
            this.gbDriverConsoler.Controls.Add(this.btnEBButton);
            this.gbDriverConsoler.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbDriverConsoler.Location = new System.Drawing.Point(50, 53);
            this.gbDriverConsoler.Name = "gbDriverConsoler";
            this.gbDriverConsoler.Size = new System.Drawing.Size(458, 356);
            this.gbDriverConsoler.TabIndex = 2;
            this.gbDriverConsoler.TabStop = false;
            this.gbDriverConsoler.Text = "驾驶室";
            // 
            // gbWorkMode
            // 
            this.gbWorkMode.Controls.Add(this.rbCO);
            this.gbWorkMode.Controls.Add(this.rbOS);
            this.gbWorkMode.Controls.Add(this.rbSB);
            this.gbWorkMode.Controls.Add(this.rbSL);
            this.gbWorkMode.Controls.Add(this.rbPT);
            this.gbWorkMode.Controls.Add(this.rbTR);
            this.gbWorkMode.Controls.Add(this.rbIS);
            this.gbWorkMode.Controls.Add(this.rbSH);
            this.gbWorkMode.Controls.Add(this.rbFS);
            this.gbWorkMode.Location = new System.Drawing.Point(22, 151);
            this.gbWorkMode.Name = "gbWorkMode";
            this.gbWorkMode.Size = new System.Drawing.Size(188, 96);
            this.gbWorkMode.TabIndex = 43;
            this.gbWorkMode.TabStop = false;
            this.gbWorkMode.Text = "工作模式";
            // 
            // rbCO
            // 
            this.rbCO.AutoSize = true;
            this.rbCO.Location = new System.Drawing.Point(22, 44);
            this.rbCO.Name = "rbCO";
            this.rbCO.Size = new System.Drawing.Size(35, 16);
            this.rbCO.TabIndex = 0;
            this.rbCO.Text = "CO";
            this.rbCO.UseVisualStyleBackColor = true;
            this.rbCO.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbOS
            // 
            this.rbOS.AutoSize = true;
            this.rbOS.Location = new System.Drawing.Point(23, 66);
            this.rbOS.Name = "rbOS";
            this.rbOS.Size = new System.Drawing.Size(35, 16);
            this.rbOS.TabIndex = 0;
            this.rbOS.Text = "OS";
            this.rbOS.UseVisualStyleBackColor = true;
            this.rbOS.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbSB
            // 
            this.rbSB.AutoSize = true;
            this.rbSB.Location = new System.Drawing.Point(75, 66);
            this.rbSB.Name = "rbSB";
            this.rbSB.Size = new System.Drawing.Size(35, 16);
            this.rbSB.TabIndex = 0;
            this.rbSB.Text = "SB";
            this.rbSB.UseVisualStyleBackColor = true;
            this.rbSB.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbSL
            // 
            this.rbSL.AutoSize = true;
            this.rbSL.Location = new System.Drawing.Point(75, 44);
            this.rbSL.Name = "rbSL";
            this.rbSL.Size = new System.Drawing.Size(35, 16);
            this.rbSL.TabIndex = 0;
            this.rbSL.Text = "SL";
            this.rbSL.UseVisualStyleBackColor = true;
            this.rbSL.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbPT
            // 
            this.rbPT.AutoSize = true;
            this.rbPT.Location = new System.Drawing.Point(131, 64);
            this.rbPT.Name = "rbPT";
            this.rbPT.Size = new System.Drawing.Size(35, 16);
            this.rbPT.TabIndex = 0;
            this.rbPT.Text = "PT";
            this.rbPT.UseVisualStyleBackColor = true;
            this.rbPT.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbTR
            // 
            this.rbTR.AutoSize = true;
            this.rbTR.Location = new System.Drawing.Point(129, 42);
            this.rbTR.Name = "rbTR";
            this.rbTR.Size = new System.Drawing.Size(35, 16);
            this.rbTR.TabIndex = 0;
            this.rbTR.Text = "TR";
            this.rbTR.UseVisualStyleBackColor = true;
            this.rbTR.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbIS
            // 
            this.rbIS.AutoSize = true;
            this.rbIS.Location = new System.Drawing.Point(129, 20);
            this.rbIS.Name = "rbIS";
            this.rbIS.Size = new System.Drawing.Size(35, 16);
            this.rbIS.TabIndex = 0;
            this.rbIS.Text = "IS";
            this.rbIS.UseVisualStyleBackColor = true;
            this.rbIS.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbSH
            // 
            this.rbSH.AutoSize = true;
            this.rbSH.Location = new System.Drawing.Point(76, 22);
            this.rbSH.Name = "rbSH";
            this.rbSH.Size = new System.Drawing.Size(35, 16);
            this.rbSH.TabIndex = 0;
            this.rbSH.Text = "SH";
            this.rbSH.UseVisualStyleBackColor = true;
            this.rbSH.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
            // 
            // rbFS
            // 
            this.rbFS.AutoSize = true;
            this.rbFS.Location = new System.Drawing.Point(23, 22);
            this.rbFS.Name = "rbFS";
            this.rbFS.Size = new System.Drawing.Size(35, 16);
            this.rbFS.TabIndex = 0;
            this.rbFS.Text = "FS";
            this.rbFS.UseVisualStyleBackColor = true;
            this.rbFS.CheckedChanged += new System.EventHandler(this.rbWorkMode_CheckedChanged);
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
            this.gbSteer.Location = new System.Drawing.Point(319, 31);
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
            // gbControlLevel
            // 
            this.gbControlLevel.Controls.Add(this.rbCTCS_2);
            this.gbControlLevel.Controls.Add(this.rbCTCS_3);
            this.gbControlLevel.Location = new System.Drawing.Point(22, 253);
            this.gbControlLevel.Name = "gbControlLevel";
            this.gbControlLevel.Size = new System.Drawing.Size(99, 87);
            this.gbControlLevel.TabIndex = 38;
            this.gbControlLevel.TabStop = false;
            this.gbControlLevel.Text = "控车等级";
            // 
            // rbCTCS_2
            // 
            this.rbCTCS_2.AutoSize = true;
            this.rbCTCS_2.Location = new System.Drawing.Point(28, 53);
            this.rbCTCS_2.Name = "rbCTCS_2";
            this.rbCTCS_2.Size = new System.Drawing.Size(59, 16);
            this.rbCTCS_2.TabIndex = 0;
            this.rbCTCS_2.Text = "CTCS-2";
            this.rbCTCS_2.UseVisualStyleBackColor = true;
            this.rbCTCS_2.CheckedChanged += new System.EventHandler(this.rbControlLevel_CheckedChanged);
            // 
            // rbCTCS_3
            // 
            this.rbCTCS_3.AutoSize = true;
            this.rbCTCS_3.Location = new System.Drawing.Point(28, 22);
            this.rbCTCS_3.Name = "rbCTCS_3";
            this.rbCTCS_3.Size = new System.Drawing.Size(59, 16);
            this.rbCTCS_3.TabIndex = 0;
            this.rbCTCS_3.Text = "CTCS-3";
            this.rbCTCS_3.UseVisualStyleBackColor = true;
            this.rbCTCS_3.CheckedChanged += new System.EventHandler(this.rbControlLevel_CheckedChanged);
            // 
            // gbDriveDirection
            // 
            this.gbDriveDirection.Controls.Add(this.rbDirectionBackward);
            this.gbDriveDirection.Controls.Add(this.rbDirectionZero);
            this.gbDriveDirection.Controls.Add(this.rbDirectionForward);
            this.gbDriveDirection.Location = new System.Drawing.Point(158, 31);
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
            this.btnEBButton.Location = new System.Drawing.Point(212, 287);
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
            this.gbTrainState.Location = new System.Drawing.Point(50, 427);
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
            this.gbTrainLocation.Location = new System.Drawing.Point(369, 427);
            this.gbTrainLocation.Name = "gbTrainLocation";
            this.gbTrainLocation.Size = new System.Drawing.Size(192, 173);
            this.gbTrainLocation.TabIndex = 10;
            this.gbTrainLocation.TabStop = false;
            this.gbTrainLocation.Text = "位置信息：";
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
            // lblTrainRightLoc
            // 
            this.lblTrainRightLoc.AutoSize = true;
            this.lblTrainRightLoc.Location = new System.Drawing.Point(92, 70);
            this.lblTrainRightLoc.Name = "lblTrainRightLoc";
            this.lblTrainRightLoc.Size = new System.Drawing.Size(11, 12);
            this.lblTrainRightLoc.TabIndex = 0;
            this.lblTrainRightLoc.Text = "0";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "A端：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初始化ToolStripMenuItem,
            this.通信ToolStripMenuItem,
            this.状态设置ToolStripMenuItem,
            this.故障注入ToolStripMenuItem,
            this.ToolStripMenuItem,
            this.发送消息ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 初始化ToolStripMenuItem
            // 
            this.初始化ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通信初始化ToolStripMenuItem,
            this.列车初始化ToolStripMenuItem});
            this.初始化ToolStripMenuItem.Name = "初始化ToolStripMenuItem";
            this.初始化ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.初始化ToolStripMenuItem.Text = "初始化";
            // 
            // 通信初始化ToolStripMenuItem
            // 
            this.通信初始化ToolStripMenuItem.Name = "通信初始化ToolStripMenuItem";
            this.通信初始化ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.通信初始化ToolStripMenuItem.Text = "通信初始化";
            // 
            // 列车初始化ToolStripMenuItem
            // 
            this.列车初始化ToolStripMenuItem.Name = "列车初始化ToolStripMenuItem";
            this.列车初始化ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.列车初始化ToolStripMenuItem.Text = "列车初始化";
            // 
            // 通信ToolStripMenuItem
            // 
            this.通信ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.建立通信ToolStripMenuItem,
            this.断开通信ToolStripMenuItem});
            this.通信ToolStripMenuItem.Name = "通信ToolStripMenuItem";
            this.通信ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.通信ToolStripMenuItem.Text = "通信";
            // 
            // 建立通信ToolStripMenuItem
            // 
            this.建立通信ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rBCToolStripMenuItem,
            this.nRBCToolStripMenuItem});
            this.建立通信ToolStripMenuItem.Name = "建立通信ToolStripMenuItem";
            this.建立通信ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.建立通信ToolStripMenuItem.Text = "建立通信";
            // 
            // rBCToolStripMenuItem
            // 
            this.rBCToolStripMenuItem.Name = "rBCToolStripMenuItem";
            this.rBCToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.rBCToolStripMenuItem.Text = "RBC";
            this.rBCToolStripMenuItem.Click += new System.EventHandler(this.ConnectTSMI_Click);
            // 
            // nRBCToolStripMenuItem
            // 
            this.nRBCToolStripMenuItem.Name = "nRBCToolStripMenuItem";
            this.nRBCToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.nRBCToolStripMenuItem.Text = "NRBC";
            this.nRBCToolStripMenuItem.Click += new System.EventHandler(this.ConnectTSMI_Click);
            // 
            // 断开通信ToolStripMenuItem
            // 
            this.断开通信ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disRBCToolStripMenuItem,
            this.disNRBCToolStripMenuItem});
            this.断开通信ToolStripMenuItem.Name = "断开通信ToolStripMenuItem";
            this.断开通信ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.断开通信ToolStripMenuItem.Text = "断开通信";
            // 
            // disRBCToolStripMenuItem
            // 
            this.disRBCToolStripMenuItem.Name = "disRBCToolStripMenuItem";
            this.disRBCToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.disRBCToolStripMenuItem.Text = "RBC";
            this.disRBCToolStripMenuItem.Click += new System.EventHandler(this.DisconnectTSMI_Click);
            // 
            // disNRBCToolStripMenuItem
            // 
            this.disNRBCToolStripMenuItem.Name = "disNRBCToolStripMenuItem";
            this.disNRBCToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.disNRBCToolStripMenuItem.Text = "NRBC";
            this.disNRBCToolStripMenuItem.Click += new System.EventHandler(this.DisconnectTSMI_Click);
            // 
            // 状态设置ToolStripMenuItem
            // 
            this.状态设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.列车位置设置ToolStripMenuItem});
            this.状态设置ToolStripMenuItem.Name = "状态设置ToolStripMenuItem";
            this.状态设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.状态设置ToolStripMenuItem.Text = "状态设置";
            // 
            // 列车位置设置ToolStripMenuItem
            // 
            this.列车位置设置ToolStripMenuItem.Name = "列车位置设置ToolStripMenuItem";
            this.列车位置设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.列车位置设置ToolStripMenuItem.Text = "列车位置设置";
            // 
            // 故障注入ToolStripMenuItem
            // 
            this.故障注入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.列车打滑ToolStripMenuItem,
            this.无应答器故障ToolStripMenuItem,
            this.倒溜ToolStripMenuItem,
            this.列车空转ToolStripMenuItem,
            this.零速设置ToolStripMenuItem});
            this.故障注入ToolStripMenuItem.Name = "故障注入ToolStripMenuItem";
            this.故障注入ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.故障注入ToolStripMenuItem.Text = "故障注入";
            // 
            // 列车打滑ToolStripMenuItem
            // 
            this.列车打滑ToolStripMenuItem.Name = "列车打滑ToolStripMenuItem";
            this.列车打滑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.列车打滑ToolStripMenuItem.Text = "列车打滑";
            // 
            // 无应答器故障ToolStripMenuItem
            // 
            this.无应答器故障ToolStripMenuItem.Name = "无应答器故障ToolStripMenuItem";
            this.无应答器故障ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.无应答器故障ToolStripMenuItem.Text = "无应答器故障";
            // 
            // 倒溜ToolStripMenuItem
            // 
            this.倒溜ToolStripMenuItem.Name = "倒溜ToolStripMenuItem";
            this.倒溜ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.倒溜ToolStripMenuItem.Text = "倒溜";
            // 
            // 列车空转ToolStripMenuItem
            // 
            this.列车空转ToolStripMenuItem.Name = "列车空转ToolStripMenuItem";
            this.列车空转ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.列车空转ToolStripMenuItem.Text = "列车空转";
            // 
            // 零速设置ToolStripMenuItem
            // 
            this.零速设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.零速ToolStripMenuItem,
            this.非零速ToolStripMenuItem});
            this.零速设置ToolStripMenuItem.Name = "零速设置ToolStripMenuItem";
            this.零速设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.零速设置ToolStripMenuItem.Text = "零速设置";
            // 
            // 零速ToolStripMenuItem
            // 
            this.零速ToolStripMenuItem.Name = "零速ToolStripMenuItem";
            this.零速ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.零速ToolStripMenuItem.Text = "零速";
            // 
            // 非零速ToolStripMenuItem
            // 
            this.非零速ToolStripMenuItem.Name = "非零速ToolStripMenuItem";
            this.非零速ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.非零速ToolStripMenuItem.Text = "非零速";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItem.Text = "报文信息";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_RBC,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_NRBC});
            this.statusStrip1.Location = new System.Drawing.Point(0, 656);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(820, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel1.Text = "与RBC通信状态：";
            // 
            // toolStripStatusLabel_RBC
            // 
            this.toolStripStatusLabel_RBC.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel_RBC.Name = "toolStripStatusLabel_RBC";
            this.toolStripStatusLabel_RBC.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel_RBC.Text = "通信断开";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(114, 17);
            this.toolStripStatusLabel2.Text = "与NRBC通信状态：";
            // 
            // toolStripStatusLabel_NRBC
            // 
            this.toolStripStatusLabel_NRBC.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel_NRBC.Name = "toolStripStatusLabel_NRBC";
            this.toolStripStatusLabel_NRBC.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel_NRBC.Text = "通信断开";
            // 
            // timerConnStatus
            // 
            this.timerConnStatus.Enabled = true;
            this.timerConnStatus.Tick += new System.EventHandler(this.timerConnStatus_Tick);
            // 
            // lvRecvMsg
            // 
            this.lvRecvMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRecvMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvRecvMsg.FullRowSelect = true;
            this.lvRecvMsg.GridLines = true;
            this.lvRecvMsg.Location = new System.Drawing.Point(523, 71);
            this.lvRecvMsg.Name = "lvRecvMsg";
            this.lvRecvMsg.Size = new System.Drawing.Size(256, 154);
            this.lvRecvMsg.TabIndex = 15;
            this.lvRecvMsg.UseCompatibleStateImageBehavior = false;
            this.lvRecvMsg.View = System.Windows.Forms.View.Details;
            this.lvRecvMsg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "消息编号";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "发送者";
            // 
            // 发送消息ToolStripMenuItem
            // 
            this.发送消息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Message129ToolStripMenuItem,
            this.Message132ToolStripMenuItem,
            this.Message136ToolStripMenuItem,
            this.Message155ToolStripMenuItem,
            this.Message156ToolStripMenuItem,
            this.Message157ToolStripMenuItem,
            this.Message159ToolStripMenuItem});
            this.发送消息ToolStripMenuItem.Name = "发送消息ToolStripMenuItem";
            this.发送消息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.发送消息ToolStripMenuItem.Text = "发送消息";
            // 
            // Message129ToolStripMenuItem
            // 
            this.Message129ToolStripMenuItem.Name = "Message129ToolStripMenuItem";
            this.Message129ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Message129ToolStripMenuItem.Text = "消息129";
            this.Message129ToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Message155ToolStripMenuItem
            // 
            this.Message155ToolStripMenuItem.Name = "Message155ToolStripMenuItem";
            this.Message155ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Message155ToolStripMenuItem.Text = "消息155";
            this.Message155ToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Message156ToolStripMenuItem
            // 
            this.Message156ToolStripMenuItem.Name = "Message156ToolStripMenuItem";
            this.Message156ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Message156ToolStripMenuItem.Text = "消息156";
            this.Message156ToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Message157ToolStripMenuItem
            // 
            this.Message157ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Msg157Packet4ToolStripMenuItem,
            this.Msg157Packet44ToolStripMenuItem,
            this.Msg157NoPacketToolStripMenuItem});
            this.Message157ToolStripMenuItem.Name = "Message157ToolStripMenuItem";
            this.Message157ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Message157ToolStripMenuItem.Text = "消息157";
            // 
            // Message159ToolStripMenuItem
            // 
            this.Message159ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Msg159Packet3ToolStripMenuItem,
            this.Msg159NoPacketToolStripMenuItem});
            this.Message159ToolStripMenuItem.Name = "Message159ToolStripMenuItem";
            this.Message159ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Message159ToolStripMenuItem.Text = "消息159";
            // 
            // Msg157Packet4ToolStripMenuItem
            // 
            this.Msg157Packet4ToolStripMenuItem.Name = "Msg157Packet4ToolStripMenuItem";
            this.Msg157Packet4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg157Packet4ToolStripMenuItem.Text = "信息包4";
            this.Msg157Packet4ToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Msg157Packet44ToolStripMenuItem
            // 
            this.Msg157Packet44ToolStripMenuItem.Name = "Msg157Packet44ToolStripMenuItem";
            this.Msg157Packet44ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg157Packet44ToolStripMenuItem.Text = "信息包44";
            this.Msg157Packet44ToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Msg157NoPacketToolStripMenuItem
            // 
            this.Msg157NoPacketToolStripMenuItem.Name = "Msg157NoPacketToolStripMenuItem";
            this.Msg157NoPacketToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg157NoPacketToolStripMenuItem.Text = "不选择";
            this.Msg157NoPacketToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Msg159Packet3ToolStripMenuItem
            // 
            this.Msg159Packet3ToolStripMenuItem.Name = "Msg159Packet3ToolStripMenuItem";
            this.Msg159Packet3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg159Packet3ToolStripMenuItem.Text = "信息包3";
            this.Msg159Packet3ToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Msg159NoPacketToolStripMenuItem
            // 
            this.Msg159NoPacketToolStripMenuItem.Name = "Msg159NoPacketToolStripMenuItem";
            this.Msg159NoPacketToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg159NoPacketToolStripMenuItem.Text = "不选择";
            this.Msg159NoPacketToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Message132ToolStripMenuItem
            // 
            this.Message132ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Msg132NoPacketToolStripMenuItem,
            this.Msg132Packet9ToolStripMenuItem});
            this.Message132ToolStripMenuItem.Name = "Message132ToolStripMenuItem";
            this.Message132ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Message132ToolStripMenuItem.Text = "消息132";
            // 
            // Message136ToolStripMenuItem
            // 
            this.Message136ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Msg136NoPacketToolStripMenuItem});
            this.Message136ToolStripMenuItem.Name = "Message136ToolStripMenuItem";
            this.Message136ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Message136ToolStripMenuItem.Text = "消息136";
            // 
            // Msg136NoPacketToolStripMenuItem
            // 
            this.Msg136NoPacketToolStripMenuItem.Name = "Msg136NoPacketToolStripMenuItem";
            this.Msg136NoPacketToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg136NoPacketToolStripMenuItem.Text = "不选择";
            this.Msg136NoPacketToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Msg132NoPacketToolStripMenuItem
            // 
            this.Msg132NoPacketToolStripMenuItem.Name = "Msg132NoPacketToolStripMenuItem";
            this.Msg132NoPacketToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg132NoPacketToolStripMenuItem.Text = "不选择";
            this.Msg132NoPacketToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // Msg132Packet9ToolStripMenuItem
            // 
            this.Msg132Packet9ToolStripMenuItem.Name = "Msg132Packet9ToolStripMenuItem";
            this.Msg132Packet9ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Msg132Packet9ToolStripMenuItem.Text = "信息包9";
            this.Msg132Packet9ToolStripMenuItem.Click += new System.EventHandler(this.SendMessagetTSMI_Click);
            // 
            // lvSendMsg
            // 
            this.lvSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSendMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvSendMsg.FullRowSelect = true;
            this.lvSendMsg.GridLines = true;
            this.lvSendMsg.Location = new System.Drawing.Point(523, 239);
            this.lvSendMsg.Name = "lvSendMsg";
            this.lvSendMsg.Size = new System.Drawing.Size(256, 154);
            this.lvSendMsg.TabIndex = 15;
            this.lvSendMsg.UseCompatibleStateImageBehavior = false;
            this.lvSendMsg.View = System.Windows.Forms.View.Details;
            this.lvSendMsg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseDoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "时间";
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "消息编号";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "发送给";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 678);
            this.Controls.Add(this.lvSendMsg);
            this.Controls.Add(this.lvRecvMsg);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbTrainLocation);
            this.Controls.Add(this.gbTrainState);
            this.Controls.Add(this.gbDriverConsoler);
            this.Name = "MainForm";
            this.Text = "Train";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbDriverConsoler.ResumeLayout(false);
            this.gbWorkMode.ResumeLayout(false);
            this.gbWorkMode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSteer.ResumeLayout(false);
            this.gbSteer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSteer)).EndInit();
            this.gbControlLevel.ResumeLayout(false);
            this.gbControlLevel.PerformLayout();
            this.gbDriveDirection.ResumeLayout(false);
            this.gbDriveDirection.PerformLayout();
            this.gbTrainState.ResumeLayout(false);
            this.gbTrainState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.gbTrainLocation.ResumeLayout(false);
            this.gbTrainLocation.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrainRightLoc;
        private System.Windows.Forms.Label lblTrainLeftLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 初始化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通信初始化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列车初始化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立通信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开通信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disRBCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disNRBCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 状态设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列车位置设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 故障注入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列车打滑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无应答器故障ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 倒溜ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列车空转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 零速设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 零速ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 非零速ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_RBC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_NRBC;
        private System.Windows.Forms.Timer timerConnStatus;
        private System.Windows.Forms.ToolStripMenuItem rBCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nRBCToolStripMenuItem;
        private System.Windows.Forms.ListView lvRecvMsg;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox gbWorkMode;
        private System.Windows.Forms.RadioButton rbCO;
        private System.Windows.Forms.RadioButton rbOS;
        private System.Windows.Forms.RadioButton rbSB;
        private System.Windows.Forms.RadioButton rbSL;
        private System.Windows.Forms.RadioButton rbPT;
        private System.Windows.Forms.RadioButton rbTR;
        private System.Windows.Forms.RadioButton rbIS;
        private System.Windows.Forms.RadioButton rbSH;
        private System.Windows.Forms.RadioButton rbFS;
        private System.Windows.Forms.GroupBox gbControlLevel;
        private System.Windows.Forms.RadioButton rbCTCS_2;
        private System.Windows.Forms.RadioButton rbCTCS_3;
        private System.Windows.Forms.ToolStripMenuItem 发送消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Message129ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Message155ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Message156ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Message157ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Message159ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg157Packet4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg157Packet44ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg157NoPacketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg159Packet3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg159NoPacketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Message132ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg132NoPacketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Message136ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg136NoPacketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Msg132Packet9ToolStripMenuItem;
        private System.Windows.Forms.ListView lvSendMsg;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

