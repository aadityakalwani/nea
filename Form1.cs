using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

// ReSharper disable All

namespace bobFinal
{
    public partial class Form1 : Form
    {
        private const int gridSize = 15;
        private const int tileSize = 40;
        private const int newDayInterval = 2000;
        private string currentAction;
        private DateTime currentDate = new DateTime(2021, 1, 1);
        private Resource diamond;
        int diamondStorageUpgradeCost = 5;
        int goldStorageUpgradeCost = 5;
        int lumberStorageUpgradeCost = 5;
        private Resource dollars;
        private Resource gold;
        private CustomPictureBox[,] grid;

        private List<Property> listOfAllProperties = new List<Property>
            { new House(0, 0), new Farm(0, 0), new Sawmill(0, 0), new Mine(0, 0), new Cafe(0, 0) };

        private Resource lumber;

        private Timer newDayTimer;

        private List<Property> properties = new List<Property>();
        private List<Resource> resources;
        private string selectedBuilding;
        private Point selectedPosition;
        private Resource selectedResource;

        public Form1()
        {
            InitializeComponent();

            DatabaseUtils.InitializeDatabase();
            // bind the DataTable to a DataGridView to display the data
            dataGridViewPropertiesList.DataSource = DatabaseUtils.LoadDatabaseData("Properties");
            dataGridViewIncomeHistory.DataSource = DatabaseUtils.LoadDatabaseData("incomeHistoryTable");

            initializeGrid();
            initializeLoot();
            initializeStartingProperties();
            initializePrices();
            initializeMarketPrices();
            initializeNewDayTimer();

            numericUpDownAmount.Maximum = 9999999;

            // open in full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void initializeMarketPrices()
        {
            listViewMarket.Items.Clear();
            foreach (Resource resource in resources)
            {
                if (resource.getName() != "Dollars")
                {
                    string conversionRate = $"{Math.Round(resource.getConversionRate(), 2)} dollars";
                    listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, resource.getName() }));
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
                string gain = "";

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
            DatabaseUtils.AddNewProperty(sawmill.GetType().Name, sawmill.XCoordinate, sawmill.YCoordinate, sawmill.GoldCost, sawmill.LumberCost, sawmill.DailyGoldGain, sawmill.DailyLumberGain, sawmill.DailyDiamondGain);

            // create and place the initial house
            Property house = new House(initialCoordinate + 5, initialCoordinate + 5);
            grid[house.XCoordinate, house.YCoordinate].Image = Image.FromFile(house.ImageFileName);
            grid[house.XCoordinate, house.YCoordinate].BuiltUpon = true;
            properties.Add(house);
            DatabaseUtils.AddNewProperty(house.GetType().Name, house.XCoordinate, house.YCoordinate, house.GoldCost, house.LumberCost, house.DailyGoldGain, house.DailyLumberGain, house.DailyDiamondGain);
        }

        private void initializeNewDayTimer()
        {
            lblNextDayTimer.Text = "";
            newDayTimer = new Timer();
            newDayTimer.Interval = newDayInterval; // set the interval to 2 seconds
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
                CustomPictureBox selectedTile = grid[selectedPosition.X, selectedPosition.Y];

                // Check if the selected tile is empty by verifying the image and BuiltUpon status
                if (selectedTile.BuiltUpon || (selectedTile.ImageLocation != null && !selectedTile.ImageLocation.Contains("empty.jpg")))
                {
                    ShowAutoClosingMessageBox("You can only build on an empty tile!", "Error", 2500);
                    return;
                }

                // Check if there are enough resources to build the property
                if (gold.getValue() >= property.GoldCost && lumber.getValue() >= property.LumberCost)
                {
                    // Deduct the cost of the property from the resources
                    gold.ChangeQuantity(-property.GoldCost);
                    lumber.ChangeQuantity(-property.LumberCost);

                    // Set the image of the selected grid position to the property image
                    selectedTile.Image = Image.FromFile(property.ImageFileName);
                    selectedTile.BuiltUpon = true;
                    properties.Add(property);

                    // Add the property to the database and update the DataGridView
                    DatabaseUtils.AddNewProperty(property.GetType().Name, property.XCoordinate, property.YCoordinate, property.GoldCost, property.LumberCost, property.DailyGoldGain, property.DailyLumberGain, property.DailyDiamondGain);
                    dataGridViewPropertiesList.DataSource = DatabaseUtils.LoadDatabaseData("Properties");
                }

                else
                {
                    ShowAutoClosingMessageBox("Not enough resources!", "Error", 2500);
                }
            }
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            // Disable the button and start the timer
            lblNextDayTimer.Text = "Next day available in 2 seconds...";
            btnNextDay.Enabled = false;
            newDayTimer.Start();

            int totalGoldGain = 0;
            int totalLumberGain = 0;
            int totalDiamondGain = 0;

            // calculate the total resource gain from all properties
            foreach (Property property in properties)
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

            // update databases and their dataGridViews
            DatabaseUtils.AddNewDayOfIncome(currentDate, totalGoldGain, totalLumberGain, totalDiamondGain);
            dataGridViewPropertiesList.DataSource = DatabaseUtils.LoadDatabaseData("Properties");
            dataGridViewIncomeHistory.DataSource = DatabaseUtils.LoadDatabaseData("incomeHistoryTable");

            currentDate = currentDate.AddDays(1);
            lblDate.Text = "Today's Date: " + currentDate.ToString("dd MMMM yyyy");
        }

        private void updateMarketPrices()
        {
            listViewMarket.Items.Clear();
            foreach (Resource resource in resources)
            {
                if (resource.getName() != "Dollars")
                {
                    string conversionRate = $"{Math.Round(resource.getConversionRate(), 2)} dollars";
                    listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, resource.getName() }));
                }
            }
        }

        private void UpdateMarketPanel()
        {
            if (selectedResource != null)
            {
                int amount = (int)numericUpDownAmount.Value;
                float cost = amount * selectedResource.getConversionRate();

                if (currentAction == "buy")
                {
                    label1.Text = $"Enter amount of {selectedResource.getName().ToLower()} to buy";
                    lblCost.Text = $"Cost: {Math.Round(cost, 2)} dollars";
                }
                else
                {
                    label1.Text = $"Enter amount of {selectedResource.getName().ToLower()} to sell";
                    lblCost.Text = $"Value: {Math.Round(cost, 2)} dollars";
                }
            }
        }

        private void UpdateCost(string buyOrSell)
        {
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * selectedResource.getConversionRate();

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
            if (listViewMarket.SelectedItems.Count == 1)
            {
                string selectedItem = listViewMarket.SelectedItems[0].SubItems[1].Text;
                // find the selected resource from the list of resources using regex
                selectedResource = resources.Find(r => r.Name == selectedItem);

                if (selectedResource != null)
                {
                    UpdateCost(buyOrSell);
                    UpdateMarketPanel();
                }
                else
                {
                    // show a message if the resource is not found
                    ShowAutoClosingMessageBox("Resource not found!", "Error", 2500);
                }
            }
            else
            {
                // show a message if no resource is selected
                ShowAutoClosingMessageBox($"Please select a resource to {buyOrSell}.", "Error", 2500);
            }
        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdateCost(currentAction); // using the stored action type
        }

        private void btnConfirmMarketAction_Click(object sender, EventArgs e)
        {
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * selectedResource.getConversionRate();

            if (selectedResource != null)
            {
                if (currentAction == "buy")
                {
                    if (dollars.getValue() >= cost)
                    {
                        dollars.ChangeQuantity(-cost);
                        selectedResource.ChangeQuantity(amount);
                    }
                    else
                    {
                        ShowAutoClosingMessageBox("Not enough dollars!", "Error", 2500);
                    }
                }
                else
                {
                    if (selectedResource.getValue() >= amount)
                    {
                        dollars.ChangeQuantity(cost);
                        selectedResource.ChangeQuantity(-amount);
                    }
                    else
                    {
                        ShowAutoClosingMessageBox("Not enough resources!", "Error", 2500);
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
            UpgradeStorage(lumber, lumberStorageUpgradeCost);
            lumberStorageUpgradeCost *= 2;
            btnUpgradeLumberStorage.Text = $"Upgrade Lumber Storage (Cost: {lumberStorageUpgradeCost} diamonds)";
        }

        private void btnUpgradeGoldStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(gold, goldStorageUpgradeCost);
            goldStorageUpgradeCost *= 2;
            btnUpgradeGoldStorage.Text = $"Upgrade Gold Storage (Cost: {goldStorageUpgradeCost} diamonds)";
        }

        private void btnUpgradeDiamondStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(diamond, diamondStorageUpgradeCost);
            diamondStorageUpgradeCost *= 2;
            btnUpgradeDiamondStorage.Text = $"Upgrade Diamond Storage (Cost: {diamondStorageUpgradeCost} diamonds)";
        }

        private void UpgradeStorage(Resource resource, int cost)
        {
            if (diamond.getValue() >= cost)
            {
                diamond.ChangeQuantity(-cost);
                resource.IncreaseCapacity(100);
                ShowAutoClosingMessageBox($"{resource.getName()} storage upgraded!", "Success", 2500);
            }
            else
            {
                ShowAutoClosingMessageBox("Not enough diamonds to upgrade storage!", "Error", 2500);
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
                numericUpDownAmount.Value = (decimal)(selectedResource.getValue() * percentage);

                UpdateMarketPanel();
            }
            else
            {
                ShowAutoClosingMessageBox("No resource selected!", "Error", 2500);
            }
        }

        private void btnSellBuilding_Click(object sender, EventArgs e)
        {
            CustomPictureBox selectedTile = grid[selectedPosition.X, selectedPosition.Y];
            Property property = properties.Find(p => p.XCoordinate == selectedPosition.X && p.YCoordinate == selectedPosition.Y);

            if (property != null)
            {
                // calculate the sell price (80% of the original cost)
                int sellPriceGold = (int)(property.GoldCost * 0.8);
                int sellPriceLumber = (int)(property.LumberCost * 0.8);

                // remove the property from the list and update the grid
                properties.Remove(property);
                selectedTile.Image = Image.FromFile("Images/empty.jpg");
                selectedTile.BuiltUpon = false;

                // Add the sell price to the resources
                gold.ChangeQuantity(sellPriceGold);
                lumber.ChangeQuantity(sellPriceLumber);

                ShowAutoClosingMessageBox($"{property.GetType().Name} sold for {sellPriceGold} Gold and {sellPriceLumber} Lumber!", "Success", 2500);
            }
            else
            {
                ShowAutoClosingMessageBox("No property found on the selected tile!", "Error", 2500);
            }
        }

        private void btnApplicationExit_Click_1(object sender, EventArgs e)
        {
            DatabaseUtils.DeleteDatabase();
            Application.Exit();
        }

        private List<(Property, Property)> FindMST(List<Property> properties)
        {
            // List to store the edges of the MST
            List<(Property, Property)> mstEdges = new List<(Property, Property)>();

            // If there are no properties, return an empty list
            if (properties == null || properties.Count == 0)
            {
                return mstEdges;
            }

            // List to keep track of visited properties
            List<Property> visited = new List<Property>();

            // Start with the first property
            Property start = properties[0];
            visited.Add(start);

            // While not all properties are visited
            while (visited.Count < properties.Count)
            {
                double minDistance = double.MaxValue;
                Property minProperty1 = null;
                Property minProperty2 = null;

                // Find the smallest edge connecting a visited property to an unvisited property
                foreach (Property property1 in visited)
                {
                    foreach (Property property2 in properties)
                    {
                        if (!visited.Contains(property2)) // property2 is unvisited
                        {
                            double distance = CalculateDistance(property1, property2);
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                minProperty1 = property1;
                                minProperty2 = property2;
                            }
                        }
                    }
                }

                // Add the smallest edge to the MST
                if (minProperty1 != null && minProperty2 != null)
                {
                    mstEdges.Add((minProperty1, minProperty2));
                    visited.Add(minProperty2);
                }
            }

            return mstEdges;
        }

        // Method to calculate the Euclidean distance between two properties
        private double CalculateDistance(Property a, Property b)
        {
            int deltaX = a.XCoordinate - b.XCoordinate;
            int deltaY = a.YCoordinate - b.YCoordinate;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<(Property, Property)> mstEdges = FindMST(properties);

            // Display the edges of the MST in a message box
            string message = "Minimum Spanning Tree (MST) Edges:\n";
            foreach ((Property, Property) edge in mstEdges)
            {
                message += $"({edge.Item1.XCoordinate}, {edge.Item1.YCoordinate}) -> ({edge.Item2.XCoordinate}, {edge.Item2.YCoordinate})\n";
            }

            ShowAutoClosingMessageBox(message, "MST Edges", 5000);
        }

        public static async void ShowAutoClosingMessageBox(string message, string title, int timeout)
        {
            Task task = Task.Run(() => MessageBox.Show(message, title));
            await Task.Delay(timeout);
            if (!task.IsCompleted)
            {
                SendKeys.SendWait("{ENTER}"); // Simulates pressing "OK"
            }
        }

        private void btnLesson1_Click_1(object sender, EventArgs e)
        {
            ShowAutoClosingMessageBox("you chose lesson 1", "Lesson 1", 2250);
        }


        private void btnLesson2_Click(object sender, EventArgs e)
        {
            ShowAutoClosingMessageBox("you chose lesson 2", "Lesson 2", 2250);
        }
    }
}