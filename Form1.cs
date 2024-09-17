using System;
using System.Drawing;
using System.Windows.Forms;

namespace bobFinal
{
    public partial class Form1 : Form
    {
        private PictureBox[,] grid;
        private const int gridSize = 20;
        private const int tileSize = 32;
        private string selectedBuilding;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitialiseLoot();
            InitialisePrices();
        }

        private void InitializeGrid()
        {
            grid = new PictureBox[gridSize, gridSize];
            int panelWidth = gridSize * tileSize;
            int panelHeight = gridSize * tileSize;

            // Set the size of the gridPanel
            gridPanel.Size = new Size(panelWidth, panelHeight);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid[i, j] = new PictureBox
                    {
                        Width = tileSize,
                        Height = tileSize,
                        Location = new Point(i * tileSize, j * tileSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        Image = Image.FromFile("empty.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    gridPanel.Controls.Add(grid[i, j]);
                }
            }

            grid[4, 4].Image = Image.FromFile("TownHallTopLeft.jpg");
            grid[4, 5].Image = Image.FromFile("TownHallBottomLeft.jpg");
            grid[5, 4].Image = Image.FromFile("TownHallTopRight.jpg");
            grid[5, 5].Image = Image.FromFile("TownHallBottomRight.jpg");

        }

        private void InitialiseLoot()
        {
            progressBarGold.Maximum = 1000;
            progressBarGold.Value += 100;
            textBoxGoldAmount.Text = progressBarGold.Value + "/" + progressBarGold.Maximum;

            progressBarLumber.Maximum = 1000;
            progressBarLumber.Value = 100;
            textBoxLumberAmount.Text = progressBarLumber.Value + "/" + progressBarLumber.Maximum;
        }

        private void InitialisePrices()
        {
            listBoxPrices.Items.Add("House:   100 Gold, 50 Lumber    |  Weekly Gain: +30 Gold");
            listBoxPrices.Items.Add("Farm:    100 Gold, 100 Lumber   |  Weekly Gain: +60 Gold");
            listBoxPrices.Items.Add("Sawmill: 300 Gold, 150 Lumber   |  Weekly Gain: +400 Lumber");
            listBoxPrices.Items.Add("Mine:    400 Gold, 200 Lumber   |  Weekly Gain: +200 Gold");
            listBoxPrices.Items.Add("Cafe:    500 Gold, 250 Lumber   |  Weekly Gain: +250 Gold");
        }

    }
}