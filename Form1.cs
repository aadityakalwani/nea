using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// ReSharper disable All

namespace bobFinal
{
    public partial class Form1 : Form
    {
        private CustomPictureBox[,] grid;
        private Point selectedPosition;
        private const int gridSize = 15;
        private const int tileSize = 40;
        private string selectedBuilding;
        private Resource dollars;
        private Resource gold;
        private Resource lumber;
        private Resource diamond;
        private Resource selectedResource;
        private string currentAction;
        private DateTime currentDate = new DateTime(2021, 1, 1);
        private Timer newDayTimer;

        private List<Property> listOfAllProperties = new List<Property>
        {
            new House(0, 0), new Farm(0, 0), new Sawmill(0, 0), new Mine(0, 0), new Cafe(0, 0)
        };

        private List<Property> properties = new List<Property>();
        private List<Resource> resources;

        public Form1()
        {
            InitializeComponent();
            initializeGrid();
            initializeLoot();
            initializeStartingProperties();
            initializePrices();
            initializeMarketPrices();
            initializeNewDayTimer();

            // open in full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void initializeMarketPrices()
        {
            listViewMarket.Items.Clear();
            foreach (var resource in resources)
            {
                if (resource.Name != "Dollars")
                {
                    string conversionRate = $"{Math.Round(resource.ConversionRate, 2)} dollars";
                    listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, resource.Name }));
                }
            }
        }

        private void initializeGrid()
        {
            // create a new grid of PictureBox objects
            grid = new CustomPictureBox[gridSize, gridSize];
            int panelWidth = gridSize * tileSize;
            int panelHeight = gridSize * tileSize;

            // set the size of the grid panel
            gridPanel.Size = new Size(panelWidth, panelHeight);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    // initialize each PictureBox in the grid
                    grid[i, j] = new CustomPictureBox
                    {
                        Width = tileSize,
                        Height = tileSize,
                        Location = new Point(i * tileSize, j * tileSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        Image = Image.FromFile("Images/empty.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BuiltUpon = false,
                        Tag = new Point(i, j) // store the position in the tag property
                    };
                    // add click event handler to each PictureBox
                    grid[i, j].Click += GridPictureBox_Click;
                    // add the PictureBox to the grid panel
                    gridPanel.Controls.Add(grid[i, j]);
                }
            }
        }

        private void initializeLoot()
        {
            dollars = new Resource("Dollars", 100, 10000, progressBarDollars, textBoxDollarsAmount, 1);
            lumber = new Resource("Lumber", 100, 200, progressBarLumber, textBoxLumberAmount, 3);
            gold = new Resource("Gold", 100, 200, progressBarGold, textBoxGoldAmount, 2);
            diamond = new Resource("Diamond", 5, 50, progressBarDiamond, textBoxDiamondAmount, 10);

            resources = new List<Resource> { dollars, lumber, gold, diamond };
        }

        private void initializePrices()
        {
            listViewPrices.Items.Clear();
            foreach (Property property in listOfAllProperties)
            {
                string cost = $"{property.GoldCost} Gold, {property.LumberCost} Lumber";
                string gain = string.Empty;

                if (property.DailyGoldGain > 0)
                {
                    gain += $"{property.DailyGoldGain} Gold, ";
                }
                if (property.DailyLumberGain > 0)
                {
                    gain += $"{property.DailyLumberGain} Lumber, ";
                }
                if (property.DailyDiamondGain > 0)
                {
                    gain += $"{property.DailyDiamondGain} Diamond, ";
                }

                // remove the trailing comma and space (if any)
                if (gain.EndsWith(", "))
                {
                    gain = gain.Substring(0, gain.Length - 2);
                }

                listViewPrices.Items.Add(new ListViewItem(new[] { property.GetType().Name, cost, gain }));
            }
        }

        private void initializeStartingProperties()
        {
            int initialCoordinate = 1;

            // create and place the initial Town Hall
            grid[initialCoordinate + 1, initialCoordinate + 1].Image = Image.FromFile("Images/TownHallTopLeft.jpg");
            grid[initialCoordinate + 1, initialCoordinate + 1].BuiltUpon = true;
            grid[initialCoordinate + 1, initialCoordinate + 2].Image = Image.FromFile("Images/TownHallBottomLeft.jpg");
            grid[initialCoordinate + 2, initialCoordinate + 2].BuiltUpon = true;
            grid[initialCoordinate + 2, initialCoordinate + 1].Image = Image.FromFile("Images/TownHallTopRight.jpg");
            grid[initialCoordinate + 2, initialCoordinate + 1].BuiltUpon = true;
            grid[initialCoordinate + 2, initialCoordinate + 2].Image = Image.FromFile("Images/TownHallBottomRight.jpg");
            grid[initialCoordinate + 2, initialCoordinate + 2].BuiltUpon = true;

            // create and place the initial sawmill
            Property sawmill = new Sawmill(initialCoordinate + 4, initialCoordinate + 4);
            grid[sawmill.XCoordinate, sawmill.YCoordinate].Image = Image.FromFile(sawmill.ImageFileName);
            grid[sawmill.XCoordinate, sawmill.YCoordinate].BuiltUpon = true;
            properties.Add(sawmill);

            // create and place the initial house
            Property house = new House(initialCoordinate + 5, initialCoordinate + 5);
            grid[house.XCoordinate, house.YCoordinate].Image = Image.FromFile(house.ImageFileName);
            grid[house.XCoordinate, house.YCoordinate].BuiltUpon = true;
            properties.Add(house);
        }

        private void initializeNewDayTimer()
        {
            lblNextDayTimer.Text = "";
            newDayTimer = new Timer();
            newDayTimer.Interval = 2000; // set the interval to 2 seconds
            newDayTimer.Tick += newDayTimer_Tick;
        }

        private void newDayTimer_Tick(object sender, EventArgs e)
        {
            // enable the button and stop the timer
            lblNextDayTimer.Text = "";
            btnNextDay.Enabled = true;
            newDayTimer.Stop();
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

            // Determine the type of property to build based on selectedBuilding
            switch (selectedBuilding)
            {
                case "House":
                    property = new House(selectedPosition.X, selectedPosition.Y);
                    break;
                case "Farm":
                    property = new Farm(selectedPosition.X, selectedPosition.Y);
                    break;
                case "Sawmill":
                    property = new Sawmill(selectedPosition.X, selectedPosition.Y);
                    break;
                case "Mine":
                    property = new Mine(selectedPosition.X, selectedPosition.Y);
                    break;
                case "Cafe":
                    property = new Cafe(selectedPosition.X, selectedPosition.Y);
                    break;
            }

            if (property != null)
            {
                var selectedTile = grid[selectedPosition.X, selectedPosition.Y];

                // Check if the selected tile is empty by verifying the image and BuiltUpon status
                if (selectedTile.BuiltUpon || (selectedTile.ImageLocation != null && !selectedTile.ImageLocation.Contains("empty.jpg")))
                {
                    MessageBox.Show("You can only build on an empty tile!");
                    return;
                }

                // Check if there are enough resources to build the property
                if (gold.Value >= property.GoldCost && lumber.Value >= property.LumberCost)
                {
                    // Deduct the cost of the property from the resources
                    gold.ChangeQuantity(-property.GoldCost);
                    lumber.ChangeQuantity(-property.LumberCost);

                    // Set the image of the selected grid position to the property image
                    selectedTile.Image = Image.FromFile(property.ImageFileName);
                    selectedTile.BuiltUpon = true;
                    properties.Add(property);
                }
                else
                {
                    MessageBox.Show("Not enough resources!");
                }
            }
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            // Disable the button and start the timer
            lblNextDayTimer.Text = "Next day available in 2 seconds...";
            btnNextDay.Enabled = false;
            newDayTimer.Start();

            currentDate = currentDate.AddDays(1);
            lblDate.Text = "Today's Date: " + currentDate.ToString("dd MMMM yyyy");

            int totalGoldGain = 0;
            int totalLumberGain = 0;
            int totalDiamondGain = 0;

            // calculate the total resource gain from all properties
            foreach (var property in properties)
            {
                totalGoldGain += property.DailyGoldGain;
                totalLumberGain += property.DailyLumberGain;
                totalDiamondGain += property.DailyDiamondGain;
            }

            // update the resource quantities with the total gains
            gold.ChangeQuantity(totalGoldGain);
            lumber.ChangeQuantity(totalLumberGain);
            diamond.ChangeQuantity(totalDiamondGain);

            // update market prices
            Market.UpdateConversionRates(resources);
            updateMarketPrices();
            UpdateMarketPanel();
        }

        private void updateMarketPrices()
        {
            listViewMarket.Items.Clear();
            foreach (var resource in resources)
            {
                if (resource.Name != "Dollars")
                {
                    string conversionRate = $"{Math.Round(resource.ConversionRate, 2)} dollars";
                    listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, resource.Name }));
                }
            }
        }

        private void UpdateMarketPanel()
        {
            if (selectedResource != null)
            {
                int amount = (int)numericUpDownAmount.Value;
                float cost = amount * selectedResource.ConversionRate;

                if (currentAction == "buy")
                {
                    label1.Text = $"Enter amount of {selectedResource.Name.ToLower()} to buy";
                    lblCost.Text = $"Cost: {Math.Round(cost, 2)} dollars";
                }
                else
                {
                    label1.Text = $"Enter amount of {selectedResource.Name.ToLower()} to sell";
                    lblCost.Text = $"Value: {Math.Round(cost, 2)} dollars";
                }
            }
        }

        private void UpdateCost(string buyOrSell)
        {
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * selectedResource.ConversionRate;

            if (buyOrSell == "buy")
            {
                lblCost.Text = $"Cost: {Math.Round(cost, 2)} dollars";
            }
            else
            {
                lblCost.Text = $"Value: {Math.Round(cost, 2)} dollars";
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
            currentAction = buyOrSell;

            // check if a resource is selected in the market list view
            if (listViewMarket.SelectedItems.Count > 0)
            {
                string selectedItem = listViewMarket.SelectedItems[0].SubItems[1].Text;
                // find the selected resource from the list of resources
                selectedResource = resources.Find(r => r.Name == selectedItem);

                if (selectedResource != null)
                {
                    UpdateCost(buyOrSell);

                    // update label1 text based on the action and selected resource
                    if (buyOrSell == "buy")
                    {
                        label1.Text = $"Enter amount of {selectedResource.Name.ToLower()} to buy";
                    }
                    else
                    {
                        label1.Text = $"Enter amount of {selectedResource.Name.ToLower()} to sell";
                    }
                }
                else
                {
                    // show a message if the resource is not found
                    MessageBox.Show("Resource not found!");
                }
            }
            else
            {
                // show a message if no resource is selected
                MessageBox.Show($"Please select a resource to {buyOrSell}.");
            }
        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdateCost(currentAction); // using the stored action type
        }

        private void btnConfirmMarketAction_Click(object sender, EventArgs e)
        {
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * selectedResource.ConversionRate;

            if (selectedResource != null)
            {
                if (currentAction == "buy")
                {
                    if (dollars.Value >= cost)
                    {
                        dollars.ChangeQuantity(-cost);
                        selectedResource.ChangeQuantity(amount);
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
                        dollars.ChangeQuantity(cost);
                        selectedResource.ChangeQuantity(-amount);
                    }
                    else
                    {
                        MessageBox.Show("Not enough resources!");
                    }
                }
            }
        }

        private void btnCancelMarketAction_Click(object sender, EventArgs e)
        {
            selectedResource = null;
            lblCost.Text = "Buy / Sell Panel";
            label1.Text = "Select a resource to buy or sell";
        }

        private void btnUpgradeLumberStorage_Click_1(object sender, EventArgs e)
        {
            UpgradeStorage(lumber, 100);
        }

        private void btnUpgradeGoldStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(gold, 100);
        }

        private void btnUpgradeDiamondStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(diamond, 100);
        }

        private void UpgradeStorage(Resource resource, int cost)
        {
            if (dollars.Value >= cost)
            {
                dollars.ChangeQuantity(-cost);
                resource.IncreaseCapacity(100);
                MessageBox.Show($"{resource.Name} storage upgraded!");
            }
            else
            {
                MessageBox.Show("Not enough dollars to upgrade storage!");
            }
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            SetNumericUpDownValue(0.25);
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            SetNumericUpDownValue(0.5);
        }

        private void btn75_Click(object sender, EventArgs e)
        {
            SetNumericUpDownValue(0.75);
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            SetNumericUpDownValue(1.00);
        }

        private void SetNumericUpDownValue(double percentage)
        {
            if (selectedResource != null)
            {
                numericUpDownAmount.Value = (decimal)(selectedResource.Value * percentage);

                UpdateMarketPanel();
            }
            else
            {
                MessageBox.Show("No resource selected!");
            }
        }
    }
}