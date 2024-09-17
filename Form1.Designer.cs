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
            this.listBoxPrices = new System.Windows.Forms.ListBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.progressBarGold = new System.Windows.Forms.ProgressBar();
            this.progressBarLumber = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxGoldAmount = new System.Windows.Forms.TextBox();
            this.textBoxLumberAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // gridPanel
            //
            this.gridPanel.Location = new System.Drawing.Point(41, 53);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(800, 800);
            this.gridPanel.TabIndex = 1;
            //
            // listBoxPrices
            //
            this.listBoxPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPrices.FormattingEnabled = true;
            this.listBoxPrices.ItemHeight = 25;
            this.listBoxPrices.Location = new System.Drawing.Point(1145, 356);
            this.listBoxPrices.Name = "listBoxPrices";
            this.listBoxPrices.Size = new System.Drawing.Size(653, 404);
            this.listBoxPrices.TabIndex = 2;
            //
            // btnBuild
            //
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Location = new System.Drawing.Point(1145, 209);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(150, 75);
            this.btnBuild.TabIndex = 3;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            //
            // btnSell
            //
            this.btnSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSell.Location = new System.Drawing.Point(1364, 209);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(172, 75);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell Resource";
            this.btnSell.UseVisualStyleBackColor = true;
            //
            // progressBarGold
            //
            this.progressBarGold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarGold.Location = new System.Drawing.Point(1520, 53);
            this.progressBarGold.Name = "progressBarGold";
            this.progressBarGold.Size = new System.Drawing.Size(290, 35);
            this.progressBarGold.TabIndex = 5;
            //
            // progressBarLumber
            //
            this.progressBarLumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLumber.Location = new System.Drawing.Point(1520, 127);
            this.progressBarLumber.Name = "progressBarLumber";
            this.progressBarLumber.Size = new System.Drawing.Size(290, 35);
            this.progressBarLumber.TabIndex = 6;
            //
            // textBox1
            //
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(1394, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 31);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Gold:";
            //
            // textBox2
            //
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(1394, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 31);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Lumber:";
            //
            // textBoxGoldAmount
            //
            this.textBoxGoldAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoldAmount.Location = new System.Drawing.Point(1660, 53);
            this.textBoxGoldAmount.Name = "textBoxGoldAmount";
            this.textBoxGoldAmount.Size = new System.Drawing.Size(150, 31);
            this.textBoxGoldAmount.TabIndex = 9;
            this.textBoxGoldAmount.Text = "0/1000";
            //
            // textBoxLumberAmount
            //
            this.textBoxLumberAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLumberAmount.Location = new System.Drawing.Point(1660, 131);
            this.textBoxLumberAmount.Name = "textBoxLumberAmount";
            this.textBoxLumberAmount.Size = new System.Drawing.Size(150, 31);
            this.textBoxLumberAmount.TabIndex = 10;
            this.textBoxLumberAmount.Text = "0/1000";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2053, 932);
            this.Controls.Add(this.textBoxLumberAmount);
            this.Controls.Add(this.textBoxGoldAmount);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBarLumber);
            this.Controls.Add(this.progressBarGold);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.listBoxPrices);
            this.Controls.Add(this.gridPanel);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxGoldAmount;

        private System.Windows.Forms.TextBox textBoxLumberAmount;

        private System.Windows.Forms.ProgressBar progressBarLumber;
        private System.Windows.Forms.ProgressBar progressBarGold;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;

        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnSell;

        private System.Windows.Forms.ListBox listBoxPrices;

        private System.Windows.Forms.Panel gridPanel;

        #endregion
    }
}