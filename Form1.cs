using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace bobFinal
{
    public partial class Form1 : Form
{
    private PictureBox[,] grid;
    private Point selectedPosition;
    private const int gridSize = 30;
    private const int tileSize = 32;
    private string selectedBuilding;
    private Resource gold;
    private Resource lumber;
    private List<Property> properties = new List<Property>();

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
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = new Point(i, j) // store the position in the Tag property
                };
                grid[i, j].Click += GridPictureBox_Click; // add Click event handler
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
        gold = new Resource("Gold", 100, 1000, progressBarGold, textBoxGoldAmount);
        lumber = new Resource("Lumber", 100, 1000, progressBarLumber, textBoxLumberAmount);
    }

    private void InitialisePrices()
    {
        listBoxPrices.Items.Add("House:   100 Gold, 50 Lumber    |  Daily Gain: +30 Gold");
        listBoxPrices.Items.Add("Farm:    100 Gold, 100 Lumber   |  Daily Gain: +60 Gold");
        listBoxPrices.Items.Add("Sawmill: 300 Gold, 150 Lumber   |  Daily Gain: +400 Lumber");
        listBoxPrices.Items.Add("Mine:    400 Gold, 200 Lumber   |  Daily Gain: +200 Gold");
        listBoxPrices.Items.Add("Cafe:    500 Gold, 250 Lumber   |  Daily Gain: +250 Gold");
    }

    private void listBoxPrices_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedItem = listBoxPrices.SelectedItem.ToString();
        selectedBuilding = selectedItem.Split(':')[0].Trim();
    }

    private void GridPictureBox_Click(object sender, EventArgs e)
    {
        if (sender is PictureBox pictureBox)
        {
            selectedPosition = (Point)pictureBox.Tag;
            MessageBox.Show($"Selected position: {selectedPosition.X}, {selectedPosition.Y}");
        }
    }

    private void btnBuild_Click(object sender, EventArgs e)
    {
        Property property = null;

        switch (selectedBuilding)
        {
            case "House":
                property = new House();
                break;
            case "Farm":
                property = new Farm();
                break;
            // Add cases for other buildings
        }

        if (property != null)
        {
            if (gold.Value >= property.GoldCost && lumber.Value >= property.LumberCost)
            {
                gold.ChangeQuantity(-property.GoldCost);
                lumber.ChangeQuantity(-property.LumberCost);

                grid[selectedPosition.X, selectedPosition.Y].Image = Image.FromFile(selectedBuilding.ToLower() + "Tile.jpg");
                properties.Add(property); // Add the property to the list
            }
            else
            {
                MessageBox.Show("Not enough resources!");
            }
        }
    }

    private void btnNextDay_Click(object sender, EventArgs e)
    {
        int totalGoldGain = 0;
        int totalLumberGain = 0;

        foreach (var property in properties)
        {
            totalGoldGain += property.DailyGoldGain;
            totalLumberGain += property.DailyLumberGain;
        }

        gold.ChangeQuantity(totalGoldGain);
        lumber.ChangeQuantity(totalLumberGain);
    }
}
}