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
            this.listViewPrices = new System.Windows.Forms.ListView();
            this.columnHeaderBuilding = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCost = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGain = new System.Windows.Forms.ColumnHeader();
            this.btnBuild = new System.Windows.Forms.Button();
            this.progressBarGold = new System.Windows.Forms.ProgressBar();
            this.progressBarLumber = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxGoldAmount = new System.Windows.Forms.TextBox();
            this.textBoxLumberAmount = new System.Windows.Forms.TextBox();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.textBoxDiamondAmount = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.progressBarDiamond = new System.Windows.Forms.ProgressBar();
            this.textBoxDollarsAmount = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.progressBarDollars = new System.Windows.Forms.ProgressBar();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // gridPanel
            //
            this.gridPanel.Location = new System.Drawing.Point(41, 53);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(800, 800);
            this.gridPanel.TabIndex = 1;
            //
            // listViewPrices
            //
            this.listViewPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPrices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeaderBuilding, this.columnHeaderCost, this.columnHeaderGain });
            this.listViewPrices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewPrices.FullRowSelect = true;
            this.listViewPrices.GridLines = true;
            this.listViewPrices.HideSelection = false;
            this.listViewPrices.Location = new System.Drawing.Point(939, 612);
            this.listViewPrices.Name = "listViewPrices";
            this.listViewPrices.Size = new System.Drawing.Size(1075, 315);
            this.listViewPrices.TabIndex = 2;
            this.listViewPrices.UseCompatibleStateImageBehavior = false;
            this.listViewPrices.View = System.Windows.Forms.View.Details;
            this.listViewPrices.SelectedIndexChanged += new System.EventHandler(this.listViewPrices_SelectedIndexChanged);
            //
            // columnHeaderBuilding
            //
            this.columnHeaderBuilding.Text = "Building";
            this.columnHeaderBuilding.Width = 200;
            //
            // columnHeaderCost
            //
            this.columnHeaderCost.Text = "Cost";
            this.columnHeaderCost.Width = 300;
            //
            // columnHeaderGain
            //
            this.columnHeaderGain.Text = "Daily Gain";
            this.columnHeaderGain.Width = 200;
            //
            // btnBuild
            //
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuild.Location = new System.Drawing.Point(939, 500);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(149, 75);
            this.btnBuild.TabIndex = 3;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            //
            // progressBarGold
            //
            this.progressBarGold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarGold.Location = new System.Drawing.Point(1645, 180);
            this.progressBarGold.Name = "progressBarGold";
            this.progressBarGold.Size = new System.Drawing.Size(380, 47);
            this.progressBarGold.TabIndex = 5;
            //
            // progressBarLumber
            //
            this.progressBarLumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLumber.Location = new System.Drawing.Point(1645, 278);
            this.progressBarLumber.Name = "progressBarLumber";
            this.progressBarLumber.Size = new System.Drawing.Size(380, 35);
            this.progressBarLumber.TabIndex = 6;
            //
            // textBox1
            //
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox1.Location = new System.Drawing.Point(1438, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 47);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Gold:";
            //
            // textBox2
            //
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox2.Location = new System.Drawing.Point(1438, 278);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 47);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Lumber:";
            //
            // textBoxGoldAmount
            //
            this.textBoxGoldAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoldAmount.Location = new System.Drawing.Point(1774, 143);
            this.textBoxGoldAmount.Name = "textBoxGoldAmount";
            this.textBoxGoldAmount.Size = new System.Drawing.Size(123, 31);
            this.textBoxGoldAmount.TabIndex = 9;
            this.textBoxGoldAmount.Text = "0/1000";
            //
            // textBoxLumberAmount
            //
            this.textBoxLumberAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLumberAmount.Location = new System.Drawing.Point(1774, 241);
            this.textBoxLumberAmount.Name = "textBoxLumberAmount";
            this.textBoxLumberAmount.Size = new System.Drawing.Size(123, 31);
            this.textBoxLumberAmount.TabIndex = 10;
            this.textBoxLumberAmount.Text = "0/1000";
            //
            // btnNextDay
            //
            this.btnNextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextDay.Location = new System.Drawing.Point(984, 110);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(403, 92);
            this.btnNextDay.TabIndex = 11;
            this.btnNextDay.Text = "Next Day";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            //
            // textBoxDiamondAmount
            //
            this.textBoxDiamondAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDiamondAmount.Location = new System.Drawing.Point(1774, 335);
            this.textBoxDiamondAmount.Name = "textBoxDiamondAmount";
            this.textBoxDiamondAmount.Size = new System.Drawing.Size(123, 31);
            this.textBoxDiamondAmount.TabIndex = 14;
            this.textBoxDiamondAmount.Text = "0/1000";
            //
            // textBox4
            //
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox4.Location = new System.Drawing.Point(1438, 372);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(158, 47);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "Diamond";
            //
            // progressBarDiamond
            //
            this.progressBarDiamond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDiamond.Location = new System.Drawing.Point(1645, 372);
            this.progressBarDiamond.Name = "progressBarDiamond";
            this.progressBarDiamond.Size = new System.Drawing.Size(380, 47);
            this.progressBarDiamond.TabIndex = 12;
            //
            // textBoxDollarsAmount
            //
            this.textBoxDollarsAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDollarsAmount.Location = new System.Drawing.Point(1774, 53);
            this.textBoxDollarsAmount.Name = "textBoxDollarsAmount";
            this.textBoxDollarsAmount.Size = new System.Drawing.Size(123, 31);
            this.textBoxDollarsAmount.TabIndex = 17;
            this.textBoxDollarsAmount.Text = "0/1000";
            //
            // textBox5
            //
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox5.Location = new System.Drawing.Point(1438, 90);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(158, 47);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "Dollars";
            //
            // progressBarDollars
            //
            this.progressBarDollars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDollars.Location = new System.Drawing.Point(1645, 90);
            this.progressBarDollars.Name = "progressBarDollars";
            this.progressBarDollars.Size = new System.Drawing.Size(380, 47);
            this.progressBarDollars.TabIndex = 15;
            //
            // btnSell
            //
            this.btnSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.Location = new System.Drawing.Point(1170, 984);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(149, 75);
            this.btnSell.TabIndex = 18;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            //
            // btnBuy
            //
            this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(939, 984);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(149, 75);
            this.btnBuy.TabIndex = 19;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2162, 1417);
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
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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