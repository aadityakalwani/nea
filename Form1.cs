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
    private Resource dollars;
    private Resource gold;
    private Resource lumber;
    private Resource diamond;
    private List<Property> properties = new List<Property>();
    private Market market;

    private ListView listViewMarket;
    private Button btnBuy;
    private Button btnSell;

    private void InitializeMarketUI()
    {
        listViewMarket = new ListView
        {
            Location = new Point(20, 400),
            Size = new Size(400, 200),
            View = View.Details
        };
        listViewMarket.Columns.Add("Item", 100);
        listViewMarket.Columns.Add("Price", 100);

        btnBuy = new Button
        {
            Text = "Buy",
            Location = new Point(430, 400)
        };
        btnBuy.Click += BtnBuy_Click;

        btnSell = new Button
        {
            Text = "Sell",
            Location = new Point(430, 450)
        };
        btnSell.Click += BtnSell_Click;

        Controls.Add(listViewMarket);
        Controls.Add(btnBuy);
        Controls.Add(btnSell);
    }

    private void BtnBuy_Click(object sender, EventArgs e)
    {
        if (listViewMarket.SelectedItems.Count > 0)
        {
            string itemName = listViewMarket.SelectedItems[0].Text;
            if (market.BuyItem(itemName, 1, dollars))
            {
                MessageBox.Show($"Bought 1 {itemName}");
            }
            else
            {
                MessageBox.Show("Not enough dollars!");
            }
        }
    }

    private void BtnSell_Click(object sender, EventArgs e)
    {
        if (listViewMarket.SelectedItems.Count > 0)
        {
            string itemName = listViewMarket.SelectedItems[0].Text;
            if (market.SellItem(itemName, 1, dollars))
            {
                MessageBox.Show($"Sold 1 {itemName}");
            }
        }
    }

    public Form1()
    {
        InitializeComponent();
        InitializeGrid();
        InitialiseLoot();
        InitialisePrices();
        InitialiseStartingProperties();
        InitializeMarketUI();
        market = new Market();
        UpdateMarketUI();
    }

    private void UpdateMarketUI()
    {
        listViewMarket.Items.Clear();
        foreach (var item in market.GetItems())
        {
            listViewMarket.Items.Add(new ListViewItem(new[] { item.Name, item.Price.ToString() }));
        }
    }
// tmepa
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
        dollars = new Resource("Dollars", 100, 1000, progressBarDollars, textBoxDollarsAmount);
        gold = new Resource("Gold", 100, 1000, progressBarGold, textBoxGoldAmount);
        lumber = new Resource("Lumber", 100, 1000, progressBarLumber, textBoxLumberAmount);
        diamond = new Resource("Diamond", 50, 1000, progressBarDiamond, textBoxDiamondAmount);
    }

    private void InitialisePrices()
    {

        listViewPrices.Items.Add(new ListViewItem(new[] { "House", "100 Gold, 50 Lumber", "+30 Gold" }));
        listViewPrices.Items.Add(new ListViewItem(new[] { "Farm", "100 Gold, 100 Lumber", "+60 Gold" }));
        listViewPrices.Items.Add(new ListViewItem(new[] { "Sawmill", "300 Gold, 150 Lumber", "+400 Lumber" }));
        listViewPrices.Items.Add(new ListViewItem(new[] { "Mine", "400 Gold, 200 Lumber", "+200 Gold" }));
        listViewPrices.Items.Add(new ListViewItem(new[] { "Cafe", "500 Gold, 250 Lumber", "+250 Gold" }));


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
    }
}
}