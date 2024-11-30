using System;
using System.Collections.Generic;
using System.Drawing;
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
        private DateTime currentDate = new DateTime(2024, 1, 1);
        private Resource diamond;
        int diamondStorageUpgradeCost = 5;
        int goldStorageUpgradeCost = 5;
        int lumberStorageUpgradeCost = 5;
        private Resource dollars;
        private Resource gold;
        private CustomPictureBox[,] grid;
        private MergeSort mergeSort = new MergeSort();

        private List<Property> listOfAllProperties = new List<Property>
            { new House(0, 0), new Farm(0, 0), new Sawmill(0, 0), new Mine(0, 0), new Cafe(0, 0) };

        private Resource lumber;

        private Timer newDayTimer;

        private List<Property> properties = new List<Property>();
        private List<Resource> resources;
        private string selectedBuilding;
        private Point selectedPosition;
        private Resource selectedResource;
        private Lesson currentLesson;

        public Form1()
        {
            InitializeComponent();

            DatabaseUtils.InitializeDatabase();

            // bind the DataTable to a DataGridView to display the data
            RefreshDataGridView("Properties");
            RefreshDataGridView("incomeHistoryTable");
            RefreshDataGridViewLessons();

            initializeGrid();
            initializeLoot();
            initializeStartingProperties();
            initializePrices();
            initializeMarketPrices();
            initializeNewDayTimer();
            initializeLessons();

            numericUpDownAmount.Maximum = 9999999;

            // open in full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            // set the size of the tables to the size of the screen
            dataGridViewIncomeHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPropertiesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLessons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void initializeLessons()
        {
            Lesson lesson1 = new Lesson(1, "Business", "Business Ownership", "Which of the following is a characteristic of a sole proprietorship?", 0, 50, "Owner has full control", "Limited liability", "Separate legal entity", "Ownership shared with partners", false);
            Lesson lesson2 = new Lesson(2, "Business", "Supply and Demand", "What happens to price when demand increases?", 1, 50, "Increases", "Decreases", "Stays the same", "No effect", false);
            Lesson lesson3 = new Lesson(3, "Business", "Economics", "What is the main goal of a business?", 0, 50, "Profit", "Charity", "Sustainability", "Growth", false);
            Lesson lesson4 = new Lesson(4, "Economics", "Opportunity Cost", "What is the cost of the next best alternative?", 2, 50, "Sunk cost", "Fixed cost", "Opportunity cost", "Variable cost", false);
            Lesson lesson5 = new Lesson(5, "Economics", "Scarcity", "What is the fundamental economic problem?", 3, 50, "Scarcity", "Opportunity cost", "Supply and demand", "Inflation", false);
            Lesson lesson6 = new Lesson(6, "Economics", "Trade-offs", "What is the concept of giving up one thing for another?", 0, 50, "Trade-off", "Opportunity cost", "Scarcity", "Inflation", false);
            Lesson lesson7 = new Lesson(7, "Economics", "Supply and Demand", "What is the law that states price increases as demand increases?", 1, 50, "Law of demand", "Law of supply", "Law of equilibrium", "Law of scarcity", false);
            Lesson lesson8 = new Lesson(8, "Economics", "Elasticity", "What is the measure of how responsive quantity demanded is to a change in price?", 2, 50, "Inelastic", "Elastic", "Elasticity", "Demand", false);
            Lesson lesson9 = new Lesson(9, "Economics", "Monopoly", "What is the market structure with only one seller?", 0, 50, "Monopoly", "Oligopoly", "Monopolistic competition", "Perfect competition", false);
            Lesson lesson10 = new Lesson(10, "Economics", "Oligopoly", "What is the market structure with a few sellers?", 1, 50, "Monopoly", "Oligopoly", "Monopolistic competition", "Perfect competition", false);
            Lesson lesson11 = new Lesson(11, "Economics", "Price Discrimination", "What is the practice of charging different prices for the same product?", 2, 50, "Market segmentation", "Economies of scale", "Price discrimination", "Price elasticity", false);
            Lesson lesson12 = new Lesson(12, "Business", "Entrepreneurship", "Which of the following is most associated with entrepreneurship?", 0, 50, "Innovation", "Risk aversion", "Routine tasks", "Large-scale production", false);
            Lesson lesson13 = new Lesson(13, "Economics", "Market Failure", "What occurs when the allocation of goods and services is not efficient?", 3, 50, "Public goods", "Externalities", "Monopolies", "Market failure", false);
            Lesson lesson14 = new Lesson(14, "Business", "Business Objectives", "Which of the following is NOT typically a business objective?", 3, 50, "Maximizing profits", "Market share growth", "Customer satisfaction", "Public welfare", false);
            Lesson lesson15 = new Lesson(15, "Economics", "Government Intervention", "What is a common form of government intervention to correct market failure?", 1, 50, "Price controls", "Subsidies", "Taxes", "Free market", false);
            Lesson lesson16 = new Lesson(16, "Business", "Marketing", "What is the main goal of marketing in a business?", 0, 50, "To attract and retain customers", "To increase production", "To lower costs", "To avoid competition", false);
            Lesson lesson17 = new Lesson(17, "Economics", "Inflation", "What does inflation cause to the purchasing power of money?", 0, 50, "Decrease", "Increase", "Stay the same", "Fluctuate", false);
            Lesson lesson18 = new Lesson(18, "Business", "Financial Management", "What is the primary purpose of financial management in a business?", 1, 50, "To ensure profitability", "To ensure liquidity", "To manage workforce", "To increase market share", false);
            Lesson lesson19 = new Lesson(19, "Economics", "GDP", "Which of the following is NOT included in the calculation of GDP?", 2, 50, "Consumer spending", "Government spending", "Exports", "Black market transactions", false);
            Lesson lesson20 = new Lesson(20, "Economics", "Labour Market", "Which factor primarily affects wages in the labour market?", 3, 50, "Demand for labour", "Supply of capital", "Profit margins", "Technological advancements", false);
            Lesson lesson21 = new Lesson(21, "Economics", "Unemployment", "What type of unemployment occurs when workers' skills do not match job requirements?", 2, 50, "Frictional unemployment", "Seasonal unemployment", "Structural unemployment", "Cyclical unemployment", false);
            Lesson lesson22 = new Lesson(22, "Business", "Corporate Social Responsibility", "What is the main focus of Corporate Social Responsibility (CSR)?", 1, 50, "Profit maximization", "Ethical business practices", "Expansion into new markets", "Product innovation", false);
            Lesson lesson23 = new Lesson(23, "Economics", "Externalities", "What is an example of a negative externality?", 3, 50, "Education", "Healthcare", "Public transportation", "Pollution", false);
            Lesson lesson24 = new Lesson(24, "Business", "Business Cycle", "What phase of the business cycle is characterized by high levels of unemployment and low consumer spending?", 2, 50, "Expansion", "Recovery", "Recession", "Peak", false);
            Lesson lesson25 = new Lesson(25, "Economics", "Inflation", "What is the primary cause of demand-pull inflation?", 0, 50, "Increase in aggregate demand", "Increase in aggregate supply", "Reduction in government spending", "Decrease in production costs", false);
            Lesson lesson26 = new Lesson(26, "Business", "Competition", "What is the result of a perfectly competitive market?", 3, 50, "One large firm dominates the market", "Firms set prices above market equilibrium", "Barriers to entry are very high", "Firms produce at the lowest possible cost", false);
            Lesson lesson27 = new Lesson(27, "Economics", "Taxes", "What type of tax is levied on a specific good or service?", 1, 50, "Income tax", "Excise tax", "Corporate tax", "Value-added tax (VAT)", false);
            Lesson lesson28 = new Lesson(28, "Business", "Branding", "What is the primary purpose of branding for a company?", 0, 50, "To distinguish its products from competitors", "To reduce production costs", "To increase supply", "To lower prices", false);
            Lesson lesson29 = new Lesson(29, "Economics", "Monetary Policy", "What is the goal of expansionary monetary policy?", 2, 50, "Increase taxes", "Decrease government spending", "Increase the money supply", "Decrease interest rates", false);
            Lesson lesson30 = new Lesson(30, "Business", "E-commerce", "What is the main benefit of e-commerce for businesses?", 1, 50, "Lower overhead costs", "Access to a global market", "Higher product quality", "Increased competition", false);


            DatabaseUtils.AddLesson(lesson1);
            DatabaseUtils.AddLesson(lesson2);
            DatabaseUtils.AddLesson(lesson3);
            DatabaseUtils.AddLesson(lesson4);
            DatabaseUtils.AddLesson(lesson5);
            DatabaseUtils.AddLesson(lesson6);
            DatabaseUtils.AddLesson(lesson7);
            DatabaseUtils.AddLesson(lesson8);
            DatabaseUtils.AddLesson(lesson9);
            DatabaseUtils.AddLesson(lesson10);
            DatabaseUtils.AddLesson(lesson11);
            DatabaseUtils.AddLesson(lesson12);
            DatabaseUtils.AddLesson(lesson13);
            DatabaseUtils.AddLesson(lesson14);
            DatabaseUtils.AddLesson(lesson15);
            DatabaseUtils.AddLesson(lesson16);
            DatabaseUtils.AddLesson(lesson17);
            DatabaseUtils.AddLesson(lesson18);
            DatabaseUtils.AddLesson(lesson19);
            DatabaseUtils.AddLesson(lesson20);
            DatabaseUtils.AddLesson(lesson21);
            DatabaseUtils.AddLesson(lesson22);
            DatabaseUtils.AddLesson(lesson23);
            DatabaseUtils.AddLesson(lesson24);
            DatabaseUtils.AddLesson(lesson25);
            DatabaseUtils.AddLesson(lesson26);
            DatabaseUtils.AddLesson(lesson27);
            DatabaseUtils.AddLesson(lesson28);
            DatabaseUtils.AddLesson(lesson29);
            DatabaseUtils.AddLesson(lesson30);
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
                    Program.ShowAutoClosingMessageBox("You can only build on an empty tile!", "Error", 2500);
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
                    RefreshDataGridView("Properties");
                }

                else
                {
                    Program.ShowAutoClosingMessageBox("Not enough resources!", "Error", 2500);
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
            DatabaseUtils.AddNewDayOfIncome(currentDate, totalGoldGain, totalLumberGain, totalDiamondGain, properties.Count);
            RefreshDataGridView("Properties");
            RefreshDataGridView("incomeHistoryTable");
            RefreshDataGridViewLessons();

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
                    Program.ShowAutoClosingMessageBox("Resource not found!", "Error", 2500);
                }
            }
            else
            {
                // show a message if no resource is selected
                Program.ShowAutoClosingMessageBox($"Please select a resource to {buyOrSell}.", "Error", 2500);
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
                        Program.ShowAutoClosingMessageBox("Not enough dollars!", "Error", 2500);
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
                        Program.ShowAutoClosingMessageBox("Not enough resources!", "Error", 2500);
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
                Program.ShowAutoClosingMessageBox($"{resource.getName()} storage upgraded!", "Success", 2500);
            }
            else
            {
                Program.ShowAutoClosingMessageBox("Not enough diamonds to upgrade storage!", "Error", 2500);
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
                Program.ShowAutoClosingMessageBox("No resource selected!", "Error", 2500);
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

                Program.ShowAutoClosingMessageBox($"{property.GetType().Name} sold for {sellPriceGold} Gold and {sellPriceLumber} Lumber!", "Success", 2500);
            }
            else
            {
                Program.ShowAutoClosingMessageBox("No property found on the selected tile!", "Error", 2500);
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

        private double CalculateDistance(Property a, Property b)
        {
            int deltaX = a.XCoordinate - b.XCoordinate;
            int deltaY = a.YCoordinate - b.YCoordinate;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<(Property, Property)> mstEdges = FindMST(properties);

            // display the edges of the MST in a message box
            string message = "Edges in the Minimum Spanning Tree (MST):\n";
            foreach ((Property, Property) edge in mstEdges)
            {
                message += $"({edge.Item1.XCoordinate}, {edge.Item1.YCoordinate}) -> ({edge.Item2.XCoordinate}, {edge.Item2.YCoordinate})\n";
            }

            Program.ShowAutoClosingMessageBox(message, "MST Edges", 5000);
        }

        private void btnLesson1_Click_1(object sender, EventArgs e)
        {
            // Program.ShowAutoClosingMessageBox("you chose lesson 1", "Lesson 1", 2250);

            // Get the selected lesson from the DataGridView

            currentLesson = DatabaseUtils.GetRandomIncompleteLesson();
            // this function is not returning a list of choices, hence why the whole choices thing isnt working

            List<string> choicesForThisQuestion = new List<string> { currentLesson.ChoiceOne, currentLesson.ChoiceTwo, currentLesson.ChoiceThree, currentLesson.ChoiceFour };

            Program.ShowAutoClosingMessageBox($"Choices for this question: {choicesForThisQuestion[0]}, {choicesForThisQuestion[1]}, {choicesForThisQuestion[2]}, {choicesForThisQuestion[3]}", "Choices", 2250);

            if (currentLesson != null)
            {
                // Display the question
                lblQuestion.Text = currentLesson.Question;

                // Populate choices
                radioButton1.Text = currentLesson.ChoiceOne;
                radioButton2.Text = currentLesson.ChoiceTwo;
                radioButton3.Text = currentLesson.ChoiceThree;
                radioButton4.Text = currentLesson.ChoiceFour;
            }
            else
            {
                Program.ShowAutoClosingMessageBox("No lessons found!", "Error", 2500);
            }
        }

        private void btnSortByGoldIncome_Click(object sender, EventArgs e)
        {
            Program.ShowAutoClosingMessageBox("you chose to sort by gold income", "Sort by Gold Income", 2250);
            mergeSort.Sort(properties.ToArray(), "Gold");
            RefreshDataGridView("Properties");
        }

        private void btnSortByLumberIncome_Click(object sender, EventArgs e)
        {
            Program.ShowAutoClosingMessageBox("you chose to sort by lumber income", "Sort by Lumber Income", 2250);
            mergeSort.Sort(properties.ToArray(), "Lumber");
            RefreshDataGridView("Properties");
        }

        private void btnSortByID_Click(object sender, EventArgs e)
        {
            Program.ShowAutoClosingMessageBox("THIS DOESNT WORK YET IDIOT", "Sort by ID", 2250);
            // mergeSort.Sort(properties.ToArray(), "ID");
            // RefreshDataGridView("Properties");
            // temp fix
        }

        private void RefreshDataGridView(string tableName)
        {
            switch (tableName)
            {
                case "Properties":
                    dataGridViewPropertiesList.DataSource = DatabaseUtils.LoadDatabaseData(tableName);
                    break;
                case "incomeHistoryTable":
                    dataGridViewIncomeHistory.DataSource = DatabaseUtils.LoadDatabaseData(tableName);
                    dataGridViewIncomeHistory.Columns[0].HeaderText = "Date";
                    dataGridViewIncomeHistory.Columns[1].HeaderText = "Gold Income";
                    dataGridViewIncomeHistory.Columns[2].HeaderText = "Lumber Income";
                    break;
            }
        }

        private void RefreshDataGridViewLessons()
        {
            dataGridViewLessons.DataSource = DatabaseUtils.LoadLessonStatus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int selectedAnswerIndex = -1;

            // Determine which answer was selected
            if (radioButton1.Checked)
                selectedAnswerIndex = 0;
            else if (radioButton2.Checked)
                selectedAnswerIndex = 1;
            else if (radioButton3.Checked)
                selectedAnswerIndex = 2;
            else if (radioButton4.Checked)
                selectedAnswerIndex = 3;

            // Check if the answer is correct
            if (currentLesson.IsCorrectAnswer(selectedAnswerIndex))
            {
                Program.ShowAutoClosingMessageBox("Correct Answer!", "Result", 2250);
            }
            else
            {
                Program.ShowAutoClosingMessageBox("Incorrect Answer! Try again.", "Result", 2500);
            }
        }
    }
}