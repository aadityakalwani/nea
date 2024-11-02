namespace bobFinal
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelMarketAction = new System.Windows.Forms.Button();
            this.btnConfirmMarketAction = new System.Windows.Forms.Button();
            this.lblCost = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.lblMarket = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlBuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            //
            // gridPanel
            //
            this.gridPanel.Location = new System.Drawing.Point(20, 28);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(2);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(121, 113);
            this.gridPanel.TabIndex = 1;
            //
            // columnHeaderBuilding
            //
            this.columnHeaderBuilding.Text = "Building";
            this.columnHeaderBuilding.Width = 123;
            //
            // columnHeaderCost
            //
            this.columnHeaderCost.Text = "Cost";
            this.columnHeaderCost.Width = 198;
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
            this.listViewPrices.Location = new System.Drawing.Point(304, 299);
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
            this.btnBuild.Location = new System.Drawing.Point(524, 231);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(74, 39);
            this.btnBuild.TabIndex = 3;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            //
            // progressBarGold
            //
            this.progressBarGold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarGold.Location = new System.Drawing.Point(731, 103);
            this.progressBarGold.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarGold.Name = "progressBarGold";
            this.progressBarGold.Size = new System.Drawing.Size(190, 24);
            this.progressBarGold.TabIndex = 5;
            //
            // progressBarLumber
            //
            this.progressBarLumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLumber.Location = new System.Drawing.Point(731, 160);
            this.progressBarLumber.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarLumber.Name = "progressBarLumber";
            this.progressBarLumber.Size = new System.Drawing.Size(190, 18);
            this.progressBarLumber.TabIndex = 6;
            //
            // textBox1
            //
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox1.Location = new System.Drawing.Point(628, 103);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 27);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Gold:";
            //
            // textBox2
            //
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox2.Location = new System.Drawing.Point(628, 160);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(81, 27);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Lumber:";
            //
            // textBoxGoldAmount
            //
            this.textBoxGoldAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoldAmount.Location = new System.Drawing.Point(796, 83);
            this.textBoxGoldAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxGoldAmount.Name = "textBoxGoldAmount";
            this.textBoxGoldAmount.Size = new System.Drawing.Size(64, 20);
            this.textBoxGoldAmount.TabIndex = 9;
            this.textBoxGoldAmount.Text = "0/1000";
            //
            // textBoxLumberAmount
            //
            this.textBoxLumberAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLumberAmount.Location = new System.Drawing.Point(796, 140);
            this.textBoxLumberAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLumberAmount.Name = "textBoxLumberAmount";
            this.textBoxLumberAmount.Size = new System.Drawing.Size(64, 20);
            this.textBoxLumberAmount.TabIndex = 10;
            this.textBoxLumberAmount.Text = "0/1000";
            //
            // btnNextDay
            //
            this.btnNextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextDay.Location = new System.Drawing.Point(304, 20);
            this.btnNextDay.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(405, 55);
            this.btnNextDay.TabIndex = 11;
            this.btnNextDay.Text = "Next Day";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            //
            // progressBarDiamond
            //
            this.progressBarDiamond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDiamond.Location = new System.Drawing.Point(407, 163);
            this.progressBarDiamond.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarDiamond.Name = "progressBarDiamond";
            this.progressBarDiamond.Size = new System.Drawing.Size(190, 24);
            this.progressBarDiamond.TabIndex = 12;
            //
            // textBox4
            //
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox4.Location = new System.Drawing.Point(304, 163);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(81, 27);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "Diamond";
            //
            // textBoxDiamondAmount
            //
            this.textBoxDiamondAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDiamondAmount.Location = new System.Drawing.Point(472, 144);
            this.textBoxDiamondAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDiamondAmount.Name = "textBoxDiamondAmount";
            this.textBoxDiamondAmount.Size = new System.Drawing.Size(64, 20);
            this.textBoxDiamondAmount.TabIndex = 14;
            this.textBoxDiamondAmount.Text = "0/1000";
            //
            // progressBarDollars
            //
            this.progressBarDollars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDollars.Location = new System.Drawing.Point(407, 103);
            this.progressBarDollars.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarDollars.Name = "progressBarDollars";
            this.progressBarDollars.Size = new System.Drawing.Size(190, 24);
            this.progressBarDollars.TabIndex = 15;
            //
            // textBox5
            //
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox5.Location = new System.Drawing.Point(304, 103);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(81, 27);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "Dollars";
            //
            // textBoxDollarsAmount
            //
            this.textBoxDollarsAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDollarsAmount.Location = new System.Drawing.Point(472, 84);
            this.textBoxDollarsAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDollarsAmount.Name = "textBoxDollarsAmount";
            this.textBoxDollarsAmount.Size = new System.Drawing.Size(64, 20);
            this.textBoxDollarsAmount.TabIndex = 17;
            this.textBoxDollarsAmount.Text = "0/1000";
            //
            // btnSell
            //
            this.btnSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.Location = new System.Drawing.Point(419, 598);
            this.btnSell.Margin = new System.Windows.Forms.Padding(2);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(74, 39);
            this.btnSell.TabIndex = 18;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            //
            // btnBuy
            //
            this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(304, 598);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(74, 39);
            this.btnBuy.TabIndex = 19;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            //
            // Item
            //
            this.Item.DisplayIndex = 1;
            this.Item.Text = "Dollar Conversion Rate";
            this.Item.Width = 487;
            //
            // Price
            //
            this.Price.DisplayIndex = 0;
            this.Price.Text = "Item";
            this.Price.Width = 124;
            //
            // listViewMarket
            //
            this.listViewMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMarket.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.Item, this.Price });
            this.listViewMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.listViewMarket.FullRowSelect = true;
            this.listViewMarket.GridLines = true;
            this.listViewMarket.HideSelection = false;
            this.listViewMarket.Location = new System.Drawing.Point(304, 655);
            this.listViewMarket.Margin = new System.Windows.Forms.Padding(2);
            this.listViewMarket.Name = "listViewMarket";
            this.listViewMarket.Size = new System.Drawing.Size(340, 171);
            this.listViewMarket.TabIndex = 20;
            this.listViewMarket.UseCompatibleStateImageBehavior = false;
            this.listViewMarket.View = System.Windows.Forms.View.Details;
            //
            // lblSelectedPosition
            //
            this.lblSelectedPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPosition.Location = new System.Drawing.Point(304, 239);
            this.lblSelectedPosition.Name = "lblSelectedPosition";
            this.lblSelectedPosition.Size = new System.Drawing.Size(215, 35);
            this.lblSelectedPosition.TabIndex = 21;
            this.lblSelectedPosition.Text = "Selected Tile: (1,1)";
            //
            // pnlBuy
            //
            this.pnlBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuy.Controls.Add(this.label1);
            this.pnlBuy.Controls.Add(this.btnCancelMarketAction);
            this.pnlBuy.Controls.Add(this.btnConfirmMarketAction);
            this.pnlBuy.Controls.Add(this.lblCost);
            this.pnlBuy.Controls.Add(this.numericUpDownAmount);
            this.pnlBuy.Location = new System.Drawing.Point(664, 655);
            this.pnlBuy.Name = "pnlBuy";
            this.pnlBuy.Size = new System.Drawing.Size(283, 171);
            this.pnlBuy.TabIndex = 22;
            this.pnlBuy.Visible = false;
            //
            // label1
            //
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 27);
            this.label1.TabIndex = 27;
            this.label1.Text = "enter amount to buy/sell";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // btnCancelMarketAction
            //
            this.btnCancelMarketAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelMarketAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancelMarketAction.Location = new System.Drawing.Point(34, 133);
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
            this.btnConfirmMarketAction.Location = new System.Drawing.Point(149, 133);
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
            this.lblCost.Location = new System.Drawing.Point(20, 10);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(223, 27);
            this.lblCost.TabIndex = 24;
            this.lblCost.Text = "buy/sell panel";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // numericUpDownAmount
            //
            this.numericUpDownAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.numericUpDownAmount.Location = new System.Drawing.Point(83, 86);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(137, 30);
            this.numericUpDownAmount.TabIndex = 23;
            this.numericUpDownAmount.ValueChanged += new System.EventHandler(this.numericUpDownAmount_ValueChanged);
            //
            // lblMarket
            //
            this.lblMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarket.Location = new System.Drawing.Point(304, 544);
            this.lblMarket.Name = "lblMarket";
            this.lblMarket.Size = new System.Drawing.Size(535, 37);
            this.lblMarket.TabIndex = 23;
            this.lblMarket.Text = "Market - Convert $ and Resources";
            //
            // lblDate
            //
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(731, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(192, 59);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Today\'s Date:\r\nJanuary 1st, 2024\r\n";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(959, 911);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblMarket);
            this.Controls.Add(this.pnlBuy);
            this.Controls.Add(this.lblSelectedPosition);
            this.Controls.Add(this.listViewMarket);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.textBoxDollarsAmount);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.progressBarDollars);
            this.Controls.Add(this.textBoxDiamondAmount);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.progressBarDiamond);
            this.Controls.Add(this.btnNextDay);
            this.Controls.Add(this.textBoxLumberAmount);
            this.Controls.Add(this.textBoxGoldAmount);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBarLumber);
            this.Controls.Add(this.progressBarGold);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.listViewPrices);
            this.Controls.Add(this.gridPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.pnlBuy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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