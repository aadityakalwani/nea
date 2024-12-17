using System.ComponentModel;

namespace bobFinal
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.gridPanel = new System.Windows.Forms.Panel();
            this.columnHeaderBuilding = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCost = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGain = new System.Windows.Forms.ColumnHeader();
            this.listViewPrices = new System.Windows.Forms.ListView();
            this.btnBuild = new System.Windows.Forms.Button();
            this.progressBarGold = new System.Windows.Forms.ProgressBar();
            this.progressBarLumber = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxGoldAmount = new System.Windows.Forms.TextBox();
            this.textBoxLumberAmount = new System.Windows.Forms.TextBox();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.progressBarDiamond = new System.Windows.Forms.ProgressBar();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxDiamondAmount = new System.Windows.Forms.TextBox();
            this.progressBarDollars = new System.Windows.Forms.ProgressBar();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBoxDollarsAmount = new System.Windows.Forms.TextBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.Item = new System.Windows.Forms.ColumnHeader();
            this.Price = new System.Windows.Forms.ColumnHeader();
            this.listViewMarket = new System.Windows.Forms.ListView();
            this.lblSelectedPosition = new System.Windows.Forms.Label();
            this.pnlBuy = new System.Windows.Forms.Panel();
            this.btn75 = new System.Windows.Forms.Button();
            this.btn50 = new System.Windows.Forms.Button();
            this.btn25 = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelMarketAction = new System.Windows.Forms.Button();
            this.btnConfirmMarketAction = new System.Windows.Forms.Button();
            this.lblCost = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.lblMarket = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSellBuilding = new System.Windows.Forms.Button();
            this.lblNextDayTimer = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnUpgradeDiamondStorage = new System.Windows.Forms.Button();
            this.btnUpgradeGoldStorage = new System.Windows.Forms.Button();
            this.btnUpgradeLumberStorage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControlDatabases = new System.Windows.Forms.TabControl();
            this.tabPage500 = new System.Windows.Forms.TabPage();
            this.btnSortByID = new System.Windows.Forms.Button();
            this.dataGridViewPropertiesList = new System.Windows.Forms.DataGridView();
            this.btnSortByLumberIncome = new System.Windows.Forms.Button();
            this.btnSortByGoldIncome = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridViewIncomeHistory = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.dataGridViewLessons = new System.Windows.Forms.DataGridView();
            this.btnLesson1 = new System.Windows.Forms.Button();
            this.btnApplyPrims = new System.Windows.Forms.Button();
            this.lblTabs = new System.Windows.Forms.Label();
            this.btnApplicationExit = new System.Windows.Forms.Button();
            this.pnlBuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControlDatabases.SuspendLayout();
            this.tabPage500.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropertiesList)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncomeHistory)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLessons)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            this.gridPanel.Location = new System.Drawing.Point(18, 17);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(2);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(121, 113);
            this.gridPanel.TabIndex = 1;
            // 
            // columnHeaderBuilding
            // 
            this.columnHeaderBuilding.Text = "Building";
            this.columnHeaderBuilding.Width = 198;
            // 
            // columnHeaderCost
            // 
            this.columnHeaderCost.Text = "Cost";
            this.columnHeaderCost.Width = 267;
            // 
            // columnHeaderGain
            // 
            this.columnHeaderGain.Text = "Daily Gain";
            this.columnHeaderGain.Width = 267;
            // 
            // listViewPrices
            // 
            this.listViewPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPrices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeaderBuilding, this.columnHeaderCost, this.columnHeaderGain });
            this.listViewPrices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewPrices.FullRowSelect = true;
            this.listViewPrices.GridLines = true;
            this.listViewPrices.HideSelection = false;
            this.listViewPrices.Location = new System.Drawing.Point(784, 257);
            this.listViewPrices.Margin = new System.Windows.Forms.Padding(2);
            this.listViewPrices.Name = "listViewPrices";
            this.listViewPrices.Size = new System.Drawing.Size(610, 248);
            this.listViewPrices.TabIndex = 2;
            this.listViewPrices.UseCompatibleStateImageBehavior = false;
            this.listViewPrices.View = System.Windows.Forms.View.Details;
            this.listViewPrices.SelectedIndexChanged += new System.EventHandler(this.listViewPrices_SelectedIndexChanged);
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuild.Location = new System.Drawing.Point(991, 193);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(198, 39);
            this.btnBuild.TabIndex = 3;
            this.btnBuild.Text = "Build Property";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // progressBarGold
            // 
            this.progressBarGold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarGold.Location = new System.Drawing.Point(1569, 293);
            this.progressBarGold.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarGold.Name = "progressBarGold";
            this.progressBarGold.Size = new System.Drawing.Size(190, 24);
            this.progressBarGold.TabIndex = 5;
            // 
            // progressBarLumber
            // 
            this.progressBarLumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLumber.Location = new System.Drawing.Point(1569, 214);
            this.progressBarLumber.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarLumber.Name = "progressBarLumber";
            this.progressBarLumber.Size = new System.Drawing.Size(190, 18);
            this.progressBarLumber.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox1.Location = new System.Drawing.Point(1455, 293);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(90, 30);
            this.textBox1.TabIndex = 7;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Gold:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox2.Location = new System.Drawing.Point(1455, 214);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(90, 30);
            this.textBox2.TabIndex = 8;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Lumber:";
            // 
            // textBoxGoldAmount
            // 
            this.textBoxGoldAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoldAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxGoldAmount.Location = new System.Drawing.Point(1602, 259);
            this.textBoxGoldAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxGoldAmount.Name = "textBoxGoldAmount";
            this.textBoxGoldAmount.ReadOnly = true;
            this.textBoxGoldAmount.Size = new System.Drawing.Size(126, 30);
            this.textBoxGoldAmount.TabIndex = 9;
            this.textBoxGoldAmount.TabStop = false;
            this.textBoxGoldAmount.Text = "0/1000";
            this.textBoxGoldAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLumberAmount
            // 
            this.textBoxLumberAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLumberAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxLumberAmount.Location = new System.Drawing.Point(1602, 180);
            this.textBoxLumberAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLumberAmount.Name = "textBoxLumberAmount";
            this.textBoxLumberAmount.ReadOnly = true;
            this.textBoxLumberAmount.Size = new System.Drawing.Size(126, 30);
            this.textBoxLumberAmount.TabIndex = 10;
            this.textBoxLumberAmount.TabStop = false;
            this.textBoxLumberAmount.Text = "0/1000";
            this.textBoxLumberAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNextDay
            // 
            this.btnNextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextDay.Location = new System.Drawing.Point(784, 17);
            this.btnNextDay.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(610, 67);
            this.btnNextDay.TabIndex = 11;
            this.btnNextDay.Text = "Next Day";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // progressBarDiamond
            // 
            this.progressBarDiamond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDiamond.Location = new System.Drawing.Point(1569, 374);
            this.progressBarDiamond.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarDiamond.Name = "progressBarDiamond";
            this.progressBarDiamond.Size = new System.Drawing.Size(190, 24);
            this.progressBarDiamond.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox4.Location = new System.Drawing.Point(1455, 374);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(90, 30);
            this.textBox4.TabIndex = 13;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Diamond";
            // 
            // textBoxDiamondAmount
            // 
            this.textBoxDiamondAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDiamondAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxDiamondAmount.Location = new System.Drawing.Point(1602, 340);
            this.textBoxDiamondAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDiamondAmount.Name = "textBoxDiamondAmount";
            this.textBoxDiamondAmount.ReadOnly = true;
            this.textBoxDiamondAmount.Size = new System.Drawing.Size(116, 30);
            this.textBoxDiamondAmount.TabIndex = 14;
            this.textBoxDiamondAmount.TabStop = false;
            this.textBoxDiamondAmount.Text = "0/1000";
            this.textBoxDiamondAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBarDollars
            // 
            this.progressBarDollars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDollars.Location = new System.Drawing.Point(1569, 131);
            this.progressBarDollars.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarDollars.Name = "progressBarDollars";
            this.progressBarDollars.Size = new System.Drawing.Size(190, 24);
            this.progressBarDollars.TabIndex = 15;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox5.Location = new System.Drawing.Point(1455, 131);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(90, 30);
            this.textBox5.TabIndex = 16;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Dollars:\r\n";
            // 
            // textBoxDollarsAmount
            // 
            this.textBoxDollarsAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDollarsAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxDollarsAmount.Location = new System.Drawing.Point(1602, 97);
            this.textBoxDollarsAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDollarsAmount.Name = "textBoxDollarsAmount";
            this.textBoxDollarsAmount.ReadOnly = true;
            this.textBoxDollarsAmount.Size = new System.Drawing.Size(126, 30);
            this.textBoxDollarsAmount.TabIndex = 17;
            this.textBoxDollarsAmount.TabStop = false;
            this.textBoxDollarsAmount.Text = "0/1000";
            this.textBoxDollarsAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSell
            // 
            this.btnSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.Location = new System.Drawing.Point(552, 340);
            this.btnSell.Margin = new System.Windows.Forms.Padding(2);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(180, 75);
            this.btnSell.TabIndex = 18;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(552, 219);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(180, 75);
            this.btnBuy.TabIndex = 19;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // Item
            // 
            this.Item.DisplayIndex = 1;
            this.Item.Text = "Dollar Conversion Rate";
            this.Item.Width = 254;
            // 
            // Price
            // 
            this.Price.DisplayIndex = 0;
            this.Price.Text = "Item";
            this.Price.Width = 159;
            // 
            // listViewMarket
            // 
            this.listViewMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMarket.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.Item, this.Price });
            this.listViewMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.listViewMarket.FullRowSelect = true;
            this.listViewMarket.GridLines = true;
            this.listViewMarket.HideSelection = false;
            this.listViewMarket.Location = new System.Drawing.Point(42, 219);
            this.listViewMarket.Margin = new System.Windows.Forms.Padding(2);
            this.listViewMarket.Name = "listViewMarket";
            this.listViewMarket.Size = new System.Drawing.Size(417, 196);
            this.listViewMarket.TabIndex = 20;
            this.listViewMarket.UseCompatibleStateImageBehavior = false;
            this.listViewMarket.View = System.Windows.Forms.View.Details;
            // 
            // lblSelectedPosition
            // 
            this.lblSelectedPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPosition.Location = new System.Drawing.Point(784, 197);
            this.lblSelectedPosition.Name = "lblSelectedPosition";
            this.lblSelectedPosition.Size = new System.Drawing.Size(193, 35);
            this.lblSelectedPosition.TabIndex = 21;
            this.lblSelectedPosition.Text = "Selected Tile: (1,1)";
            // 
            // pnlBuy
            // 
            this.pnlBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBuy.Controls.Add(this.btn75);
            this.pnlBuy.Controls.Add(this.btn50);
            this.pnlBuy.Controls.Add(this.btn25);
            this.pnlBuy.Controls.Add(this.btn100);
            this.pnlBuy.Controls.Add(this.label1);
            this.pnlBuy.Controls.Add(this.btnCancelMarketAction);
            this.pnlBuy.Controls.Add(this.btnConfirmMarketAction);
            this.pnlBuy.Controls.Add(this.lblCost);
            this.pnlBuy.Controls.Add(this.numericUpDownAmount);
            this.pnlBuy.Location = new System.Drawing.Point(830, 186);
            this.pnlBuy.Name = "pnlBuy";
            this.pnlBuy.Size = new System.Drawing.Size(426, 296);
            this.pnlBuy.TabIndex = 22;
            // 
            // btn75
            // 
            this.btn75.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn75.Location = new System.Drawing.Point(255, 164);
            this.btn75.Name = "btn75";
            this.btn75.Size = new System.Drawing.Size(76, 29);
            this.btn75.TabIndex = 31;
            this.btn75.Text = "75%";
            this.btn75.UseVisualStyleBackColor = true;
            this.btn75.Click += new System.EventHandler(this.btn75_Click);
            // 
            // btn50
            // 
            this.btn50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn50.Location = new System.Drawing.Point(170, 164);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(76, 29);
            this.btn50.TabIndex = 30;
            this.btn50.Text = "50%";
            this.btn50.UseVisualStyleBackColor = true;
            this.btn50.Click += new System.EventHandler(this.btn50_Click);
            // 
            // btn25
            // 
            this.btn25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn25.Location = new System.Drawing.Point(88, 164);
            this.btn25.Name = "btn25";
            this.btn25.Size = new System.Drawing.Size(76, 29);
            this.btn25.TabIndex = 29;
            this.btn25.Text = "25%";
            this.btn25.UseVisualStyleBackColor = true;
            this.btn25.Click += new System.EventHandler(this.btn25_Click);
            // 
            // btn100
            // 
            this.btn100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn100.Location = new System.Drawing.Point(255, 112);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(75, 29);
            this.btn100.TabIndex = 28;
            this.btn100.Text = "100%";
            this.btn100.UseVisualStyleBackColor = true;
            this.btn100.Click += new System.EventHandler(this.btn100_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 27);
            this.label1.TabIndex = 27;
            this.label1.Text = "to enable this menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancelMarketAction
            // 
            this.btnCancelMarketAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelMarketAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancelMarketAction.Location = new System.Drawing.Point(88, 220);
            this.btnCancelMarketAction.Name = "btnCancelMarketAction";
            this.btnCancelMarketAction.Size = new System.Drawing.Size(112, 35);
            this.btnCancelMarketAction.TabIndex = 26;
            this.btnCancelMarketAction.Text = "Cancel";
            this.btnCancelMarketAction.UseVisualStyleBackColor = true;
            this.btnCancelMarketAction.Click += new System.EventHandler(this.btnCancelMarketAction_Click);
            // 
            // btnConfirmMarketAction
            // 
            this.btnConfirmMarketAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmMarketAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnConfirmMarketAction.Location = new System.Drawing.Point(221, 220);
            this.btnConfirmMarketAction.Name = "btnConfirmMarketAction";
            this.btnConfirmMarketAction.Size = new System.Drawing.Size(110, 35);
            this.btnConfirmMarketAction.TabIndex = 25;
            this.btnConfirmMarketAction.Text = "Confirm";
            this.btnConfirmMarketAction.UseVisualStyleBackColor = true;
            this.btnConfirmMarketAction.Click += new System.EventHandler(this.btnConfirmMarketAction_Click);
            // 
            // lblCost
            // 
            this.lblCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(66, 32);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(305, 27);
            this.lblCost.TabIndex = 24;
            this.lblCost.Text = "Choose an resource and an action";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.numericUpDownAmount.Location = new System.Drawing.Point(88, 112);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(158, 30);
            this.numericUpDownAmount.TabIndex = 23;
            this.numericUpDownAmount.ValueChanged += new System.EventHandler(this.numericUpDownAmount_ValueChanged);
            // 
            // lblMarket
            // 
            this.lblMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarket.Location = new System.Drawing.Point(42, 46);
            this.lblMarket.Name = "lblMarket";
            this.lblMarket.Size = new System.Drawing.Size(659, 42);
            this.lblMarket.TabIndex = 23;
            this.lblMarket.Text = "Welcome to the market!\r\n";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(1466, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(326, 35);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Today\'s Date: January 1st, 2024";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1424, 903);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSellBuilding);
            this.tabPage1.Controls.Add(this.lblNextDayTimer);
            this.tabPage1.Controls.Add(this.btnNextDay);
            this.tabPage1.Controls.Add(this.gridPanel);
            this.tabPage1.Controls.Add(this.lblSelectedPosition);
            this.tabPage1.Controls.Add(this.listViewPrices);
            this.tabPage1.Controls.Add(this.btnBuild);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1416, 865);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Village Grid";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSellBuilding
            // 
            this.btnSellBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSellBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellBuilding.Location = new System.Drawing.Point(1196, 193);
            this.btnSellBuilding.Margin = new System.Windows.Forms.Padding(2);
            this.btnSellBuilding.Name = "btnSellBuilding";
            this.btnSellBuilding.Size = new System.Drawing.Size(198, 39);
            this.btnSellBuilding.TabIndex = 23;
            this.btnSellBuilding.Text = "Sell Property";
            this.btnSellBuilding.UseVisualStyleBackColor = true;
            this.btnSellBuilding.Click += new System.EventHandler(this.btnSellBuilding_Click);
            // 
            // lblNextDayTimer
            // 
            this.lblNextDayTimer.Location = new System.Drawing.Point(936, 95);
            this.lblNextDayTimer.Name = "lblNextDayTimer";
            this.lblNextDayTimer.Size = new System.Drawing.Size(301, 30);
            this.lblNextDayTimer.TabIndex = 22;
            this.lblNextDayTimer.Text = "Next day available in 2 seconds...";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnUpgradeDiamondStorage);
            this.tabPage2.Controls.Add(this.btnUpgradeGoldStorage);
            this.tabPage2.Controls.Add(this.btnUpgradeLumberStorage);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.lblMarket);
            this.tabPage2.Controls.Add(this.btnSell);
            this.tabPage2.Controls.Add(this.btnBuy);
            this.tabPage2.Controls.Add(this.pnlBuy);
            this.tabPage2.Controls.Add(this.listViewMarket);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1416, 865);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Market";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnUpgradeDiamondStorage
            // 
            this.btnUpgradeDiamondStorage.Location = new System.Drawing.Point(42, 717);
            this.btnUpgradeDiamondStorage.Name = "btnUpgradeDiamondStorage";
            this.btnUpgradeDiamondStorage.Size = new System.Drawing.Size(427, 42);
            this.btnUpgradeDiamondStorage.TabIndex = 28;
            this.btnUpgradeDiamondStorage.Text = "Upgrade Diamond Storage (Cost: 5 diamonds)\r\n\r\n";
            this.btnUpgradeDiamondStorage.UseVisualStyleBackColor = true;
            this.btnUpgradeDiamondStorage.Click += new System.EventHandler(this.btnUpgradeDiamondStorage_Click);
            // 
            // btnUpgradeGoldStorage
            // 
            this.btnUpgradeGoldStorage.Location = new System.Drawing.Point(42, 644);
            this.btnUpgradeGoldStorage.Name = "btnUpgradeGoldStorage";
            this.btnUpgradeGoldStorage.Size = new System.Drawing.Size(427, 42);
            this.btnUpgradeGoldStorage.TabIndex = 27;
            this.btnUpgradeGoldStorage.Text = "Upgrade Gold Storage (Cost: 5 diamonds)";
            this.btnUpgradeGoldStorage.UseVisualStyleBackColor = true;
            this.btnUpgradeGoldStorage.Click += new System.EventHandler(this.btnUpgradeGoldStorage_Click);
            // 
            // btnUpgradeLumberStorage
            // 
            this.btnUpgradeLumberStorage.Location = new System.Drawing.Point(42, 579);
            this.btnUpgradeLumberStorage.Name = "btnUpgradeLumberStorage";
            this.btnUpgradeLumberStorage.Size = new System.Drawing.Size(427, 42);
            this.btnUpgradeLumberStorage.TabIndex = 26;
            this.btnUpgradeLumberStorage.Text = "Upgrade Lumber Storage (Cost: 5 diamonds)";
            this.btnUpgradeLumberStorage.UseVisualStyleBackColor = true;
            this.btnUpgradeLumberStorage.Click += new System.EventHandler(this.btnUpgradeLumberStorage_Click_1);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 42);
            this.label3.TabIndex = 25;
            this.label3.Text = "To purchase upgrades:\r\n";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 42);
            this.label2.TabIndex = 24;
            this.label2.Text = "To convert between resources and $:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControlDatabases);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1416, 865);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Properties & Trackers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControlDatabases
            // 
            this.tabControlDatabases.Controls.Add(this.tabPage500);
            this.tabControlDatabases.Controls.Add(this.tabPage6);
            this.tabControlDatabases.Location = new System.Drawing.Point(21, 25);
            this.tabControlDatabases.Name = "tabControlDatabases";
            this.tabControlDatabases.SelectedIndex = 0;
            this.tabControlDatabases.Size = new System.Drawing.Size(1369, 834);
            this.tabControlDatabases.TabIndex = 1;
            // 
            // tabPage500
            // 
            this.tabPage500.Controls.Add(this.btnSortByID);
            this.tabPage500.Controls.Add(this.dataGridViewPropertiesList);
            this.tabPage500.Controls.Add(this.btnSortByLumberIncome);
            this.tabPage500.Controls.Add(this.btnSortByGoldIncome);
            this.tabPage500.Location = new System.Drawing.Point(4, 34);
            this.tabPage500.Name = "tabPage500";
            this.tabPage500.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage500.Size = new System.Drawing.Size(1361, 796);
            this.tabPage500.TabIndex = 0;
            this.tabPage500.Text = "Properties Tracker";
            this.tabPage500.UseVisualStyleBackColor = true;
            // 
            // btnSortByID
            // 
            this.btnSortByID.Location = new System.Drawing.Point(919, 27);
            this.btnSortByID.Name = "btnSortByID";
            this.btnSortByID.Size = new System.Drawing.Size(296, 49);
            this.btnSortByID.TabIndex = 4;
            this.btnSortByID.Text = "Sort by Property ID";
            this.btnSortByID.UseVisualStyleBackColor = true;
            this.btnSortByID.Click += new System.EventHandler(this.btnSortByID_Click);
            // 
            // dataGridViewPropertiesList
            // 
            this.dataGridViewPropertiesList.AllowUserToAddRows = false;
            this.dataGridViewPropertiesList.AllowUserToDeleteRows = false;
            this.dataGridViewPropertiesList.AllowUserToResizeColumns = false;
            this.dataGridViewPropertiesList.AllowUserToResizeRows = false;
            this.dataGridViewPropertiesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPropertiesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPropertiesList.Location = new System.Drawing.Point(6, 115);
            this.dataGridViewPropertiesList.Name = "dataGridViewPropertiesList";
            this.dataGridViewPropertiesList.ReadOnly = true;
            this.dataGridViewPropertiesList.RowHeadersWidth = 55;
            this.dataGridViewPropertiesList.Size = new System.Drawing.Size(1349, 675);
            this.dataGridViewPropertiesList.TabIndex = 0;
            // 
            // btnSortByLumberIncome
            // 
            this.btnSortByLumberIncome.Location = new System.Drawing.Point(498, 26);
            this.btnSortByLumberIncome.Name = "btnSortByLumberIncome";
            this.btnSortByLumberIncome.Size = new System.Drawing.Size(306, 52);
            this.btnSortByLumberIncome.TabIndex = 3;
            this.btnSortByLumberIncome.Text = "Sort by total lumber income";
            this.btnSortByLumberIncome.UseVisualStyleBackColor = true;
            this.btnSortByLumberIncome.Click += new System.EventHandler(this.btnSortByLumberIncome_Click);
            // 
            // btnSortByGoldIncome
            // 
            this.btnSortByGoldIncome.Location = new System.Drawing.Point(60, 25);
            this.btnSortByGoldIncome.Name = "btnSortByGoldIncome";
            this.btnSortByGoldIncome.Size = new System.Drawing.Size(342, 53);
            this.btnSortByGoldIncome.TabIndex = 2;
            this.btnSortByGoldIncome.Text = "Sort by total gold gain";
            this.btnSortByGoldIncome.UseVisualStyleBackColor = true;
            this.btnSortByGoldIncome.Click += new System.EventHandler(this.btnSortByGoldIncome_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridViewIncomeHistory);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1361, 796);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Daily Income Tracker";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridViewIncomeHistory
            // 
            this.dataGridViewIncomeHistory.AllowUserToAddRows = false;
            this.dataGridViewIncomeHistory.AllowUserToDeleteRows = false;
            this.dataGridViewIncomeHistory.AllowUserToResizeColumns = false;
            this.dataGridViewIncomeHistory.AllowUserToResizeRows = false;
            this.dataGridViewIncomeHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewIncomeHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncomeHistory.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewIncomeHistory.Name = "dataGridViewIncomeHistory";
            this.dataGridViewIncomeHistory.ReadOnly = true;
            this.dataGridViewIncomeHistory.RowHeadersWidth = 55;
            this.dataGridViewIncomeHistory.Size = new System.Drawing.Size(1349, 784);
            this.dataGridViewIncomeHistory.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox);
            this.tabPage4.Controls.Add(this.lblQuestion);
            this.tabPage4.Controls.Add(this.dataGridViewLessons);
            this.tabPage4.Controls.Add(this.btnLesson1);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1416, 865);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Lessons";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnSubmit);
            this.groupBox.Controls.Add(this.radioButton4);
            this.groupBox.Controls.Add(this.radioButton3);
            this.groupBox.Controls.Add(this.radioButton2);
            this.groupBox.Controls.Add(this.radioButton1);
            this.groupBox.Location = new System.Drawing.Point(24, 174);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1357, 274);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Select An Answer And Click \'Submit\'";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(1137, 101);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(194, 103);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit Answer";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(621, 159);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(523, 92);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Choice 4 will show here";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(621, 34);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(523, 105);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Choice 3 will show here";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(18, 159);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(549, 92);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Choice 2 will show here";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(18, 34);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(549, 105);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Choice 1 will show here";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(341, 24);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(1040, 101);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "Click \'Perform Lesson\' to load an incomplete lesson\r\nThe question will then show " + "up in this box";
            // 
            // dataGridViewLessons
            // 
            this.dataGridViewLessons.AllowUserToAddRows = false;
            this.dataGridViewLessons.AllowUserToDeleteRows = false;
            this.dataGridViewLessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLessons.Location = new System.Drawing.Point(6, 462);
            this.dataGridViewLessons.Name = "dataGridViewLessons";
            this.dataGridViewLessons.ReadOnly = true;
            this.dataGridViewLessons.Size = new System.Drawing.Size(1404, 397);
            this.dataGridViewLessons.TabIndex = 1;
            // 
            // btnLesson1
            // 
            this.btnLesson1.Location = new System.Drawing.Point(24, 24);
            this.btnLesson1.Name = "btnLesson1";
            this.btnLesson1.Size = new System.Drawing.Size(254, 101);
            this.btnLesson1.TabIndex = 0;
            this.btnLesson1.Text = "Perform Lesson";
            this.btnLesson1.UseVisualStyleBackColor = true;
            this.btnLesson1.Click += new System.EventHandler(this.btnLesson1_Click_1);
            // 
            // btnApplyPrims
            // 
            this.btnApplyPrims.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyPrims.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnApplyPrims.Location = new System.Drawing.Point(1455, 470);
            this.btnApplyPrims.Name = "btnApplyPrims";
            this.btnApplyPrims.Size = new System.Drawing.Size(312, 63);
            this.btnApplyPrims.TabIndex = 28;
            this.btnApplyPrims.Text = "Apply Prim\'s";
            this.btnApplyPrims.UseVisualStyleBackColor = true;
            this.btnApplyPrims.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTabs
            // 
            this.lblTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTabs.Location = new System.Drawing.Point(12, 9);
            this.lblTabs.Name = "lblTabs";
            this.lblTabs.Size = new System.Drawing.Size(583, 34);
            this.lblTabs.TabIndex = 26;
            this.lblTabs.Text = "Welcome! Use these tabs to toggle across different game views";
            // 
            // btnApplicationExit
            // 
            this.btnApplicationExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplicationExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplicationExit.Location = new System.Drawing.Point(1455, 591);
            this.btnApplicationExit.Name = "btnApplicationExit";
            this.btnApplicationExit.Size = new System.Drawing.Size(312, 65);
            this.btnApplicationExit.TabIndex = 27;
            this.btnApplicationExit.Text = "Exit Application";
            this.btnApplicationExit.UseVisualStyleBackColor = true;
            this.btnApplicationExit.Click += new System.EventHandler(this.btnApplicationExit_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1804, 966);
            this.Controls.Add(this.btnApplyPrims);
            this.Controls.Add(this.btnApplicationExit);
            this.Controls.Add(this.lblTabs);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.textBoxDollarsAmount);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.progressBarDollars);
            this.Controls.Add(this.textBoxDiamondAmount);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.progressBarDiamond);
            this.Controls.Add(this.textBoxLumberAmount);
            this.Controls.Add(this.textBoxGoldAmount);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBarLumber);
            this.Controls.Add(this.progressBarGold);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.pnlBuy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControlDatabases.ResumeLayout(false);
            this.tabPage500.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropertiesList)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncomeHistory)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLessons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnSubmit;

        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;

        private System.Windows.Forms.RadioButton radioButton1;

        private System.Windows.Forms.GroupBox groupBox;

        private System.Windows.Forms.Label lblQuestion;

        private System.Windows.Forms.DataGridView dataGridViewLessons;

        private System.Windows.Forms.Button btnSortByLumberIncome;

        private System.Windows.Forms.Button btnSortByID;

        private System.Windows.Forms.Button btnSortByGoldIncome;

        private System.Windows.Forms.Button btnLesson1;

        private System.Windows.Forms.DataGridView dataGridViewIncomeHistory;

        private System.Windows.Forms.TabControl tabControlDatabases;
        private System.Windows.Forms.TabPage tabPage500;
        private System.Windows.Forms.TabPage tabPage6;

        private System.Windows.Forms.Button btnApplyPrims;

        private System.Windows.Forms.DataGridView dataGridViewPropertiesList;

        private System.Windows.Forms.Button btnApplicationExit;

        private System.Windows.Forms.Button btnSellBuilding;

        private System.Windows.Forms.Button btn25;
        private System.Windows.Forms.Button btn50;
        private System.Windows.Forms.Button btn75;

        private System.Windows.Forms.Button btn100;

        private System.Windows.Forms.Button btnUpgradeDiamondStorage;

        private System.Windows.Forms.Button btnUpgradeGoldStorage;

        private System.Windows.Forms.Button btnUpgradeLumberStorage;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label lblNextDayTimer;

        private System.Windows.Forms.Label lblTabs;

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        private System.Windows.Forms.Label lblDate;

        private System.Windows.Forms.Label lblMarket;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel pnlBuy;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Button btnConfirmMarketAction;
        private System.Windows.Forms.Button btnCancelMarketAction;

        private System.Windows.Forms.Label lblSelectedPosition;

        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Price;

        private System.Windows.Forms.ListView listViewMarket;

        private System.Windows.Forms.Button btnBuy;

        private System.Windows.Forms.TextBox textBoxDollarsAmount;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ProgressBar progressBarDollars;

        private System.Windows.Forms.TextBox textBoxDiamondAmount;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ProgressBar progressBarDiamond;

        private System.Windows.Forms.Button btnNextDay;

        private System.Windows.Forms.TextBox textBoxGoldAmount;
        private System.Windows.Forms.TextBox textBoxLumberAmount;
        private System.Windows.Forms.ProgressBar progressBarLumber;
        private System.Windows.Forms.ProgressBar progressBarGold;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;

        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnSell;

        private System.Windows.Forms.ListView listViewPrices;
        private System.Windows.Forms.ColumnHeader columnHeaderBuilding;
        private System.Windows.Forms.ColumnHeader columnHeaderCost;
        private System.Windows.Forms.ColumnHeader columnHeaderGain;

        private System.Windows.Forms.Panel gridPanel;

        #endregion
    }
}