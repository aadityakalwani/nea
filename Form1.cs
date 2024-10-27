using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
// ReSharper disable All

namespace bobFinal
{
    public partial class Form1 : Form
{
    private PictureBox[,] grid;
    private Point selectedPosition;
    private const int gridSize = 30;
    private const int tileSize = 32;
    private string selectedBuilding;
    private Resource dollars;
    private Resource gold;
    private Resource lumber;
    private Resource diamond;
    private Resource selectedResource;
    private List<Property> properties = new List<Property>
    {
        new House(),
        new Farm(),
        new Sawmill(),
        new Mine(),
        new Cafe()
    };

    private List<Resource> resources;


    public Form1()
    {
        InitializeComponent();
        InitializeGrid();
        InitialiseLoot();
        InitialisePrices();
        InitialiseMarketPrices();
        InitialiseStartingProperties();
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
        dollars = new Resource("Dollars", 100, 1000, progressBarDollars, textBoxDollarsAmount, 1);
        gold = new Resource("Gold", 100, 1000, progressBarGold, textBoxGoldAmount, 2);
        lumber = new Resource("Lumber", 100, 1000, progressBarLumber, textBoxLumberAmount, 3);
        diamond = new Resource("Diamond", 50, 1000, progressBarDiamond, textBoxDiamondAmount, 10);
    }

    private void InitialisePrices()
    {
        foreach (var property in properties)
        {
            string cost = $"{property.GoldCost} Gold, {property.LumberCost} Lumber";
            string gain = $"+{property.DailyGoldGain} Gold, +{property.DailyLumberGain} Lumber, +{property.DailyDiamondGain} Diamond";
            listViewPrices.Items.Add(new ListViewItem(new[] { property.GetType().Name, cost, gain }));
        }
    }

    private void InitialiseMarketPrices()
    {
        resources = new List<Resource> { gold, lumber, diamond };

        foreach (var resource in resources)
        {
            string conversionRate = $"{resource.ConversionRate} dollars";
            listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, resource.Name }));
        }
        RefreshMarketPrices();
    }

    private void InitialiseStartingProperties()
    {
        // Create and place the initial sawmill
        Property sawmill = new Sawmill();
        grid[10, 10].Image = Image.FromFile(sawmill.ImageFileName);
        properties.Add(sawmill);

        // Create and place the initial house
        Property house = new House();
        grid[15, 15].Image = Image.FromFile(house.ImageFileName);
        properties.Add(house);
    }

    private void listViewPrices_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listViewPrices.SelectedItems.Count > 0)
        {
            string selectedItem = listViewPrices.SelectedItems[0].Text;
            selectedBuilding = selectedItem.Split(':')[0].Trim();
        }
    }

    private void GridPictureBox_Click(object sender, EventArgs e)
    {
        if (sender is PictureBox pictureBox)
        {
            selectedPosition = (Point)pictureBox.Tag;
            lblSelectedPosition.Text = $"Selected Tile: ({selectedPosition.X}, {selectedPosition.Y})";
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
            case "Sawmill":
                property = new Sawmill();
                break;
            case "Mine":
                property = new Mine();
                break;
            case "Cafe":
                property = new Cafe();
                break;
            // Add cases for other buildings
        }

        if (property != null)
        {
            if (gold.Value >= property.GoldCost && lumber.Value >= property.LumberCost)
            {
                gold.ChangeQuantity(-property.GoldCost);
                lumber.ChangeQuantity(-property.LumberCost);

                grid[selectedPosition.X, selectedPosition.Y].Image = Image.FromFile(property.ImageFileName);
                properties.Add(property); // add the property to the list
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
        int totalDiamondGain = 0;

        foreach (var property in properties)
        {
            totalGoldGain += property.DailyGoldGain;
            totalLumberGain += property.DailyLumberGain;
            totalDiamondGain += property.DailyDiamondGain;
        }

        gold.ChangeQuantity(totalGoldGain);
        lumber.ChangeQuantity(totalLumberGain);
        diamond.ChangeQuantity(totalDiamondGain);
        RefreshMarketPrices();
    }

    public void RefreshMarketPrices()
    {
        listViewMarket.Items.Clear();
        foreach (var resource in resources)
        {
            string conversionRate = $"{resource.ConversionRate} dollars";
            listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, $"{resource.Name}"} ));
        }
    }

    private void UpdateCost(string buyOrSell)
    {
        int amount = (int)numericUpDownAmount.Value;
        int cost = amount * selectedResource.ConversionRate;

        if (buyOrSell == "buy")
        {
            lblCost.Text = $"Cost: {cost} dollars";
        }
        else
        {
            lblCost.Text = $"Value: {cost} dollars";
        }
    }

    private void btnBuy_Click(object sender, EventArgs e)
    {
        performMarketAction("buy");
    }

    private void btnSell_Click(object sender, EventArgs e)
    {
        performMarketAction("sell");
    }

    private void performMarketAction(string buyOrSell)
    {
        if (listViewMarket.SelectedItems.Count > 0)
        {
            string selectedItem = listViewMarket.SelectedItems[0].SubItems[1].Text;
            selectedResource = resources.Find(r => r.Name == selectedItem);

            if (selectedResource != null)
            {
                pnlBuy.Visible = true;
                UpdateCost(buyOrSell);
            }
            else
            {
                MessageBox.Show("Resource not found.");
            }
        }
        else
        {
            MessageBox.Show($"Please select a resource to {buyOrSell}.");
        }
    }

    private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
    {
        // not sure what the correct argument here is
        UpdateCost("buy");
    }

    private void btnConfirmMarketAction_Click(object sender, EventArgs e)
    {
        int amount = (int)numericUpDownAmount.Value;
        int cost = amount * selectedResource.ConversionRate;

        if (selectedResource != null)
        {
            if (selectedResource.Name == "Dollars")
            {
                if (dollars.Value >= cost)
                {
                    dollars.ChangeQuantity(-cost);
                    selectedResource.ChangeQuantity(amount);
                    pnlBuy.Visible = false;
                }
                else
                {
                    MessageBox.Show("Not enough dollars!");
                }
            }
            else
            {
                if (selectedResource.Value >= amount)
                {
                    selectedResource.ChangeQuantity(-amount);
                    dollars.ChangeQuantity(cost);
                    pnlBuy.Visible = false;
                }
                else
                {
                    MessageBox.Show($"Not enough {selectedResource.Name}!");
                }
            }
        }
    }

    private void btnCancelMarketAction_Click(object sender, EventArgs e)
    {
        pnlBuy.Visible = false;
    }
}
}