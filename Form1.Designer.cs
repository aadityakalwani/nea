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
            this.dataGridViewfinal = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblTabs = new System.Windows.Forms.Label();
            this.btnApplicationExit = new System.Windows.Forms.Button();
            this.btnApplyPrims = new System.Windows.Forms.Button();
            this.pnlBuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfinal)).BeginInit();
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
            this.listViewPrices.Size = new System.Drawing.Size(610, 201);
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
            this.btnSell.Location = new System.Drawing.Point(243, 401);
            this.btnSell.Margin = new System.Windows.Forms.Padding(2);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(216, 56);
            this.btnSell.TabIndex = 18;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            //
            // btnBuy
            //
            this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(42, 401);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(180, 56);
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
            this.listViewMarket.Location = new System.Drawing.Point(42, 176);
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
            this.pnlBuy.Location = new System.Drawing.Point(42, 480);
            this.pnlBuy.Name = "pnlBuy";
            this.pnlBuy.Size = new System.Drawing.Size(417, 321);
            this.pnlBuy.TabIndex = 22;
            //
            // btn75
            //
            this.btn75.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn75.Location = new System.Drawing.Point(233, 166);
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
            this.btn50.Location = new System.Drawing.Point(148, 166);
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
            this.btn25.Location = new System.Drawing.Point(66, 166);
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
            this.btn100.Location = new System.Drawing.Point(233, 114);
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
            this.label1.Location = new System.Drawing.Point(70, 61);
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
            this.btnCancelMarketAction.Location = new System.Drawing.Point(66, 221);
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
            this.btnConfirmMarketAction.Location = new System.Drawing.Point(199, 221);
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
            this.lblCost.Location = new System.Drawing.Point(44, 34);
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
            this.numericUpDownAmount.Location = new System.Drawing.Point(66, 114);
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
            this.tabControl1.Size = new System.Drawing.Size(1424, 888);
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
            this.tabPage1.Size = new System.Drawing.Size(1416, 850);
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
            this.tabPage2.Size = new System.Drawing.Size(1416, 850);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Market";
            this.tabPage2.UseVisualStyleBackColor = true;
            //
            // btnUpgradeDiamondStorage
            //
            this.btnUpgradeDiamondStorage.Location = new System.Drawing.Point(701, 330);
            this.btnUpgradeDiamondStorage.Name = "btnUpgradeDiamondStorage";
            this.btnUpgradeDiamondStorage.Size = new System.Drawing.Size(257, 42);
            this.btnUpgradeDiamondStorage.TabIndex = 28;
            this.btnUpgradeDiamondStorage.Text = "Upgrade Diamond Storage";
            this.btnUpgradeDiamondStorage.UseVisualStyleBackColor = true;
            this.btnUpgradeDiamondStorage.Click += new System.EventHandler(this.btnUpgradeDiamondStorage_Click);
            //
            // btnUpgradeGoldStorage
            //
            this.btnUpgradeGoldStorage.Location = new System.Drawing.Point(701, 257);
            this.btnUpgradeGoldStorage.Name = "btnUpgradeGoldStorage";
            this.btnUpgradeGoldStorage.Size = new System.Drawing.Size(257, 42);
            this.btnUpgradeGoldStorage.TabIndex = 27;
            this.btnUpgradeGoldStorage.Text = "Upgrade Gold Storage";
            this.btnUpgradeGoldStorage.UseVisualStyleBackColor = true;
            this.btnUpgradeGoldStorage.Click += new System.EventHandler(this.btnUpgradeGoldStorage_Click);
            //
            // btnUpgradeLumberStorage
            //
            this.btnUpgradeLumberStorage.Location = new System.Drawing.Point(701, 192);
            this.btnUpgradeLumberStorage.Name = "btnUpgradeLumberStorage";
            this.btnUpgradeLumberStorage.Size = new System.Drawing.Size(257, 42);
            this.btnUpgradeLumberStorage.TabIndex = 26;
            this.btnUpgradeLumberStorage.Text = "Upgrade Lumber Storage";
            this.btnUpgradeLumberStorage.UseVisualStyleBackColor = true;
            this.btnUpgradeLumberStorage.Click += new System.EventHandler(this.btnUpgradeLumberStorage_Click_1);
            //
            // label3
            //
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(618, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 42);
            this.label3.TabIndex = 25;
            this.label3.Text = "To purchase upgrades:\r\n";
            //
            // label2
            //
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 42);
            this.label2.TabIndex = 24;
            this.label2.Text = "To convert between resources and $:";
            //
            // tabPage3
            //
            this.tabPage3.Controls.Add(this.dataGridViewfinal);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1416, 850);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Properties";
            this.tabPage3.UseVisualStyleBackColor = true;
            //
            // dataGridViewfinal
            //
            this.dataGridViewfinal.AllowUserToOrderColumns = true;
            this.dataGridViewfinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewfinal.Location = new System.Drawing.Point(28, 35);
            this.dataGridViewfinal.Name = "dataGridViewfinal";
            this.dataGridViewfinal.ReadOnly = true;
            this.dataGridViewfinal.RowHeadersWidth = 55;
            this.dataGridViewfinal.Size = new System.Drawing.Size(1356, 554);
            this.dataGridViewfinal.TabIndex = 0;
            //
            // tabPage4
            //
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1416, 850);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.btnApplicationExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplicationExit.Location = new System.Drawing.Point(1455, 432);
            this.btnApplicationExit.Name = "btnApplicationExit";
            this.btnApplicationExit.Size = new System.Drawing.Size(312, 65);
            this.btnApplicationExit.TabIndex = 27;
            this.btnApplicationExit.Text = "Exit Application";
            this.btnApplicationExit.UseVisualStyleBackColor = true;
            this.btnApplicationExit.Click += new System.EventHandler(this.btnApplicationExit_Click_1);
            //
            // btnApplyPrims
            //
            this.btnApplyPrims.Location = new System.Drawing.Point(1469, 535);
            this.btnApplyPrims.Name = "btnApplyPrims";
            this.btnApplyPrims.Size = new System.Drawing.Size(178, 55);
            this.btnApplyPrims.TabIndex = 28;
            this.btnApplyPrims.Text = "prim";
            this.btnApplyPrims.UseVisualStyleBackColor = true;
            this.btnApplyPrims.Click += new System.EventHandler(this.button1_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfinal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnApplyPrims;

        private System.Windows.Forms.DataGridView dataGridViewfinal;

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