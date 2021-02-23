
namespace ChemHazardCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MphKphLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WindspeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.TSTButtonSea = new System.Windows.Forms.RadioButton();
            this.TSTButtonLand = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AtmosphericStability = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LCT50UpDown = new System.Windows.Forms.NumericUpDown();
            this.ICT50UpDown = new System.Windows.Forms.NumericUpDown();
            this.ThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.FillWeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AgentNameTextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.WeaponNameTextbox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.ResultsRichText = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindspeedUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LCT50UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ICT50UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillWeightUpDown)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(1299, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "ATP45 Chemical Area Coverage: Explosive Release";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1299, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            //this.printToolStripMenuItem,
            //this.printPreviewToolStripMenuItem,
            //this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fileToolStripMenuItem_DropDownItemClicked);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(220, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // printToolStripMenuItem
            // 
            //this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            //this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            //this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            //this.printToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            //this.printToolStripMenuItem.Text = "&Print";
            //// 
            //// printPreviewToolStripMenuItem
            //// 
            //this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            //this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            //this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            //this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            //// 
            //// toolStripSeparator2
            //// 
            //this.toolStripSeparator2.Name = "toolStripSeparator2";
            //this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.contentsToolStripMenuItem,
            //this.indexToolStripMenuItem,
            //this.searchToolStripMenuItem,
            //this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            //this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            //this.contentsToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            //this.contentsToolStripMenuItem.Text = "&Contents";
            //// 
            //// indexToolStripMenuItem
            //// 
            //this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            //this.indexToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            //this.indexToolStripMenuItem.Text = "&Index";
            //// 
            //// searchToolStripMenuItem
            //// 
            //this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            //this.searchToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            //this.searchToolStripMenuItem.Text = "&Search";
            //// 
            //// toolStripSeparator5
            //// 
            //this.toolStripSeparator5.Name = "toolStripSeparator5";
            //this.toolStripSeparator5.Size = new System.Drawing.Size(182, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MphKphLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.WindspeedUpDown);
            this.groupBox1.Controls.Add(this.TSTButtonSea);
            this.groupBox1.Controls.Add(this.TSTButtonLand);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AtmosphericStability);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(46, 147);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(359, 560);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Environment";
            // 
            // MphKphLabel
            // 
            this.MphKphLabel.AutoSize = true;
            this.MphKphLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MphKphLabel.Location = new System.Drawing.Point(14, 492);
            this.MphKphLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MphKphLabel.Name = "MphKphLabel";
            this.MphKphLabel.Size = new System.Drawing.Size(122, 32);
            this.MphKphLabel.TabIndex = 7;
            this.MphKphLabel.Text = "KPH, MPH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 347);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Windspeed (Knots)";
            // 
            // WindspeedUpDown
            // 
            this.WindspeedUpDown.DecimalPlaces = 1;
            this.WindspeedUpDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WindspeedUpDown.Location = new System.Drawing.Point(30, 405);
            this.WindspeedUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WindspeedUpDown.Name = "WindspeedUpDown";
            this.WindspeedUpDown.Size = new System.Drawing.Size(171, 39);
            this.WindspeedUpDown.TabIndex = 4;
            this.WindspeedUpDown.ValueChanged += new System.EventHandler(this.WindspeedUpDown_ValueChanged);
            // 
            // TSTButtonSea
            // 
            this.TSTButtonSea.AutoSize = true;
            this.TSTButtonSea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TSTButtonSea.Location = new System.Drawing.Point(30, 285);
            this.TSTButtonSea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TSTButtonSea.Name = "TSTButtonSea";
            this.TSTButtonSea.Size = new System.Drawing.Size(77, 36);
            this.TSTButtonSea.TabIndex = 3;
            this.TSTButtonSea.TabStop = true;
            this.TSTButtonSea.Text = "Sea";
            this.TSTButtonSea.UseVisualStyleBackColor = true;
            // 
            // TSTButtonLand
            // 
            this.TSTButtonLand.AutoSize = true;
            this.TSTButtonLand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TSTButtonLand.Location = new System.Drawing.Point(30, 247);
            this.TSTButtonLand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TSTButtonLand.Name = "TSTButtonLand";
            this.TSTButtonLand.Size = new System.Drawing.Size(90, 36);
            this.TSTButtonLand.TabIndex = 2;
            this.TSTButtonLand.TabStop = true;
            this.TSTButtonLand.Text = "Land";
            this.TSTButtonLand.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 207);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Target Surface Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Atmospheric Stability";
            // 
            // AtmosphericStability
            // 
            this.AtmosphericStability.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AtmosphericStability.FormattingEnabled = true;
            this.AtmosphericStability.Location = new System.Drawing.Point(30, 125);
            this.AtmosphericStability.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AtmosphericStability.Name = "AtmosphericStability";
            this.AtmosphericStability.Size = new System.Drawing.Size(223, 40);
            this.AtmosphericStability.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LCT50UpDown);
            this.groupBox2.Controls.Add(this.ICT50UpDown);
            this.groupBox2.Controls.Add(this.ThresholdUpDown);
            this.groupBox2.Controls.Add(this.FillWeightUpDown);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.AgentNameTextbox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.WeaponNameTextbox);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(460, 147);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(787, 430);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Parameters";
            // 
            // LCT50UpDown
            // 
            this.LCT50UpDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LCT50UpDown.Location = new System.Drawing.Point(552, 324);
            this.LCT50UpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.LCT50UpDown.Name = "LCT50UpDown";
            this.LCT50UpDown.Size = new System.Drawing.Size(180, 39);
            this.LCT50UpDown.TabIndex = 10;
            // 
            // ICT50UpDown
            // 
            this.ICT50UpDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ICT50UpDown.Location = new System.Drawing.Point(303, 324);
            this.ICT50UpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ICT50UpDown.Name = "ICT50UpDown";
            this.ICT50UpDown.Size = new System.Drawing.Size(180, 39);
            this.ICT50UpDown.TabIndex = 9;
            // 
            // ThresholdUpDown
            // 
            this.ThresholdUpDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ThresholdUpDown.Location = new System.Drawing.Point(31, 324);
            this.ThresholdUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ThresholdUpDown.Name = "ThresholdUpDown";
            this.ThresholdUpDown.Size = new System.Drawing.Size(180, 39);
            this.ThresholdUpDown.TabIndex = 8;
            // 
            // FillWeightUpDown
            // 
            this.FillWeightUpDown.DecimalPlaces = 1;
            this.FillWeightUpDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FillWeightUpDown.Location = new System.Drawing.Point(552, 125);
            this.FillWeightUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.FillWeightUpDown.Name = "FillWeightUpDown";
            this.FillWeightUpDown.Size = new System.Drawing.Size(180, 39);
            this.FillWeightUpDown.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(553, 70);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 32);
            this.label12.TabIndex = 11;
            this.label12.Text = "Fill Weight (kg)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(247, 223);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(270, 32);
            this.label11.TabIndex = 7;
            this.label11.Text = "Dosages (mg.min/m3)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(584, 275);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 32);
            this.label10.TabIndex = 6;
            this.label10.Text = "LCT 50";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(342, 275);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 32);
            this.label9.TabIndex = 5;
            this.label9.Text = "ICT 50";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(55, 272);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 32);
            this.label8.TabIndex = 4;
            this.label8.Text = "Threshold";
            // 
            // AgentNameTextbox
            // 
            this.AgentNameTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AgentNameTextbox.Location = new System.Drawing.Point(303, 125);
            this.AgentNameTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AgentNameTextbox.Name = "AgentNameTextbox";
            this.AgentNameTextbox.Size = new System.Drawing.Size(201, 39);
            this.AgentNameTextbox.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(303, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 32);
            this.label7.TabIndex = 2;
            this.label7.Text = "Agent Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(31, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Weapon Name";
            // 
            // WeaponNameTextbox
            // 
            this.WeaponNameTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WeaponNameTextbox.Location = new System.Drawing.Point(31, 125);
            this.WeaponNameTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WeaponNameTextbox.Name = "WeaponNameTextbox";
            this.WeaponNameTextbox.Size = new System.Drawing.Size(201, 39);
            this.WeaponNameTextbox.TabIndex = 5;
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClearButton.Location = new System.Drawing.Point(617, 627);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(159, 57);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CalculateButton.Location = new System.Drawing.Point(863, 627);
            this.CalculateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(159, 57);
            this.CalculateButton.TabIndex = 12;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ResultsRichText
            // 
            this.ResultsRichText.Location = new System.Drawing.Point(61, 742);
            this.ResultsRichText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResultsRichText.Name = "ResultsRichText";
            this.ResultsRichText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ResultsRichText.Size = new System.Drawing.Size(1184, 339);
            this.ResultsRichText.TabIndex = 14;
            this.ResultsRichText.Text = "Results appear here...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1091);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1299, 32);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 1123);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ResultsRichText);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Chemical Hazard Area Coverage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindspeedUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LCT50UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ICT50UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillWeightUpDown)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox AtmosphericStability;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton TSTButtonSea;
        private System.Windows.Forms.RadioButton TSTButtonLand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown WindspeedUpDown;
        private System.Windows.Forms.Label MphKphLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox WeaponNameTextbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AgentNameTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.RichTextBox ResultsRichText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown FillWeightUpDown;
        private System.Windows.Forms.NumericUpDown ThresholdUpDown;
        private System.Windows.Forms.NumericUpDown LCT50UpDown;
        private System.Windows.Forms.NumericUpDown ICT50UpDown;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

