using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using bobFinal.PropertiesClasses;

namespace bobFinal
{
    public partial class Form1 : Form
    {
        private const int GridSize = 15;
        private const int TileSize = 40;
        private const int NewDayInterval = 2000;
        private string currentAction;
        private DateTime currentDate = new DateTime(2024, 1, 1);
        private Resource diamond;
        private int diamondStorageUpgradeCost = 5;
        private int goldStorageUpgradeCost = 5;
        private int lumberStorageUpgradeCost = 5;
        private Resource dollars;
        private Resource gold;
        private CustomPictureBox[,] grid;
        private readonly MergeSort mergeSort = new MergeSort();
        private readonly List<Property> listOfAllProperties = new List<Property> { new House(0, 0, 0), new Farm(0, 0, 0), new Sawmill(0, 0, 0), new Mine(0, 0, 0), new Cafe(0, 0, 0) };
        private Resource lumber;
        private Timer newDayTimer;
        private readonly List<Property> properties = new List<Property>();
        private List<Resource> resources;
        private string selectedBuilding;
        private Point selectedPosition;
        private Resource selectedResource;
        private Lesson currentLesson;
        private int currentPropertyIdIndex;
        private const int InitialCoordinate = 1;
        private int previousLessonID;

        public Form1()
        {
            InitializeComponent();
            
            DatabaseUtils.InitializeDatabase();
            InitializeGrid();
            InitializeLoot();
            InitializeStartingProperties();
            InitializePropertyPrices();
            InitializeMarketPrices();
            InitializeNewDayTimer();
            InitializeLessons();

            // bind the DataTable to a DataGridViews to display the data
            RefreshAllDataGridViews();

            numericUpDownAmount.Maximum = 9999999;

            // open in full screen
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

            // set the size of the tables to take up the minimum width required per column
            dataGridViewIncomeHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIncomeHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewPropertiesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPropertiesList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewLessons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewLessons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void InitializeMarketPrices()
        {
            listViewMarket.Items.Clear();
            foreach (Resource resource in resources)
            {
                if (resource.GetName() != "Dollars")
                {
                    string conversionRate = $"{Math.Round(resource.GetConversionRate(), 2)} dollars";
                    listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, resource.GetName() }));
                }
            }
        }

        private void InitializeGrid()
        {
            // create a new grid of PictureBox objects
            grid = new CustomPictureBox[GridSize, GridSize];
            const int panelWidth = GridSize * TileSize;
            const int panelHeight = GridSize * TileSize;

            // set the size of the grid panel
            gridPanel.Size = new Size(panelWidth, panelHeight);

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    // initialize each PictureBox in the grid
                    grid[i, j] = new CustomPictureBox
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Location = new Point(i * TileSize, j * TileSize),
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

        private void InitializeLoot()
        {
            dollars = new Resource("Dollars", 100, 10000, progressBarDollars, textBoxDollarsAmount, 1);
            lumber = new Resource("Lumber", 100, 200, progressBarLumber, textBoxLumberAmount, 3);
            gold = new Resource("Gold", 100, 200, progressBarGold, textBoxGoldAmount, 2);
            diamond = new Resource("Diamond", 5, 50, progressBarDiamond, textBoxDiamondAmount, 10);

            resources = new List<Resource> { dollars, lumber, gold, diamond };
        }

        private void InitializePropertyPrices()
        {
            listViewPrices.Items.Clear();
            foreach (Property property in listOfAllProperties)
            {
                string cost = $"{Math.Round(property.GetGoldCost(), 1)} Gold, {Math.Round(property.GetLumberCost(), 1)} Lumber";
                string gain = "";

                if (property.GetDailyGoldGain() > 0)
                {
                    gain += $"{Math.Round(property.GetDailyGoldGain(), 1)} Gold, ";
                }

                if (property.GetDailyLumberGain() > 0)
                {
                    gain += $"{Math.Round(property.GetDailyLumberGain(), 1)} Lumber, ";
                }

                if (property.GetDailyDiamondGain() > 0)
                {
                    gain += $"{Math.Round(property.GetDailyDiamondGain(), 1)} Diamond, ";
                }

                // remove the trailing comma and space (if any)
                if (gain.EndsWith(", "))
                {
                    gain = gain.Substring(0, gain.Length - 2);
                }

                listViewPrices.Items.Add(new ListViewItem(new[] { property.GetType().Name, cost, gain }));
            }
        }

        private void InitializeStartingProperties()
        {
            // create and place the initial Town Hall
            grid[InitialCoordinate + 1, InitialCoordinate + 1].Image = Image.FromFile("Images/TownHallTopLeft.jpg");
            grid[InitialCoordinate + 1, InitialCoordinate + 1].BuiltUpon = true;
            grid[InitialCoordinate + 1, InitialCoordinate + 2].Image = Image.FromFile("Images/TownHallBottomLeft.jpg");
            grid[InitialCoordinate + 2, InitialCoordinate + 2].BuiltUpon = true;
            grid[InitialCoordinate + 2, InitialCoordinate + 1].Image = Image.FromFile("Images/TownHallTopRight.jpg");
            grid[InitialCoordinate + 2, InitialCoordinate + 1].BuiltUpon = true;
            grid[InitialCoordinate + 2, InitialCoordinate + 2].Image = Image.FromFile("Images/TownHallBottomRight.jpg");
            grid[InitialCoordinate + 2, InitialCoordinate + 2].BuiltUpon = true;

            // create and place the initial sawmill
            Property sawmill = new Sawmill(currentPropertyIdIndex, InitialCoordinate + 4, InitialCoordinate + 4);
            grid[sawmill.GetXCoordinate(), sawmill.GetYCoordinate()].Image = Image.FromFile(sawmill.GetImageFileName());
            grid[sawmill.GetXCoordinate(), sawmill.GetYCoordinate()].BuiltUpon = true;
            properties.Add(sawmill);
            currentPropertyIdIndex++;
            DatabaseUtils.AddNewProperty(sawmill.GetPropertyId(), sawmill.GetType().Name, sawmill.GetXCoordinate(), sawmill.GetYCoordinate(), sawmill.GetGoldCost(), sawmill.GetLumberCost(), sawmill.GetDailyGoldGain(), sawmill.GetDailyLumberGain(), sawmill.GetDailyDiamondGain(), sawmill.GetTotalGoldGain(), sawmill.GetTotalLumberGain(), sawmill.GetActive());

            // create and place the initial house
            Property house = new House(currentPropertyIdIndex, InitialCoordinate + 5, InitialCoordinate + 5);
            grid[house.GetXCoordinate(), house.GetYCoordinate()].Image = Image.FromFile(house.GetImageFileName());
            grid[house.GetXCoordinate(), house.GetYCoordinate()].BuiltUpon = true;
            properties.Add(house);
            currentPropertyIdIndex++;
            DatabaseUtils.AddNewProperty(house.GetPropertyId(), house.GetType().Name, house.GetXCoordinate(), house.GetYCoordinate(), house.GetGoldCost(), house.GetLumberCost(), house.GetDailyGoldGain(), house.GetDailyLumberGain(), house.GetDailyDiamondGain(), house.GetTotalGoldGain(), house.GetTotalLumberGain(), house.GetActive());
        }

        private void InitializeNewDayTimer()
        {
            lblNextDayTimer.Text = "";
            newDayTimer = new Timer();
            newDayTimer.Interval = NewDayInterval; // set the interval to 2 seconds
            newDayTimer.Tick += newDayTimer_Tick;
        }

        private static void InitializeLessons()
        {
            // ReSharper disable once CollectionNeverQueried.Local
            List<Lesson> lessons = new List<Lesson>();
           string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "LessonsFolder", "LessonsFile.txt");
            // Add lessons to the list
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    Lesson tempLesson = new Lesson(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], Convert.ToInt32(parts[4]), parts[5], parts[6], parts[7], parts[8], false);
                    lessons.Add(tempLesson);
                    DatabaseUtils.AddLesson(tempLesson);
                }
            }
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
            if (listViewPrices.SelectedItems.Count <= 0) return;
            string selectedItem = listViewPrices.SelectedItems[0].Text;
            selectedBuilding = selectedItem.Split(':')[0].Trim();
        }

        private void GridPictureBox_Click(object sender, EventArgs e)
        {
            if (!(sender is PictureBox pictureBox)) return;
            selectedPosition = (Point)pictureBox.Tag;
            lblSelectedPosition.Text = $@"Selected Tile: ({selectedPosition.X}, {selectedPosition.Y})";
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            Property property = null;

            // Determine the type of property to build based on selectedBuilding
            switch (selectedBuilding)
            {
                case "House":
                    property = new House(currentPropertyIdIndex, selectedPosition.X, selectedPosition.Y);
                    break;
                case "Farm":
                    property = new Farm(currentPropertyIdIndex, selectedPosition.X, selectedPosition.Y);
                    break;
                case "Sawmill":
                    property = new Sawmill(currentPropertyIdIndex, selectedPosition.X, selectedPosition.Y);
                    break;
                case "Mine":
                    property = new Mine(currentPropertyIdIndex, selectedPosition.X, selectedPosition.Y);
                    break;
                case "Cafe":
                    property = new Cafe(currentPropertyIdIndex, selectedPosition.X, selectedPosition.Y);
                    break;
            }

            if (property == null) return;
            CustomPictureBox selectedTile = grid[selectedPosition.X, selectedPosition.Y];

            // Check if the selected tile is empty by verifying the image and BuiltUpon status
            if (selectedTile.BuiltUpon || (selectedTile.ImageLocation != null && !selectedTile.ImageLocation.Contains("empty.jpg")))
            {
                Program.ShowAutoClosingMessageBox("You can only build on an empty tile!", "Error", 2500);
                return;
            }

            // Check if there are enough resources to build the property
            if (gold.GetValue() >= property.GetGoldCost() && lumber.GetValue() >= property.GetLumberCost())
            {
                // Deduct the cost of the property from the resources
                gold.ChangeQuantity(-property.GetGoldCost());
                lumber.ChangeQuantity(-property.GetLumberCost());

                // Set the image of the selected grid position to the property image
                selectedTile.Image = Image.FromFile(property.GetImageFileName());
                selectedTile.BuiltUpon = true;
                properties.Add(property);

                // Add the property to the database and update the DataGridView
                DatabaseUtils.AddNewProperty(currentPropertyIdIndex, property.GetType().Name, property.GetXCoordinate(), property.GetYCoordinate(), property.GetGoldCost(), property.GetLumberCost(), property.GetDailyGoldGain(), property.GetDailyLumberGain(), property.GetDailyDiamondGain(), property.GetTotalGoldGain(), property.GetTotalLumberGain(), property.GetActive());
                currentPropertyIdIndex++;
                RefreshDataGridView("Properties");
            }

            else
            {
                Program.ShowAutoClosingMessageBox("Not enough resources!", "Error", 2500);
            }
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            // Disable the button and start the timer
            lblNextDayTimer.Text = @"Next day available in 2 seconds...";
            btnNextDay.Enabled = false;
            newDayTimer.Start();

            float totalGoldGain = 0;
            float totalLumberGain = 0;
            float totalDiamondGain = 0;

            // calculate the total resource gain from all properties
            foreach (Property property in properties)
            {
                totalGoldGain += property.GetDailyGoldGain();
                totalLumberGain += property.GetDailyLumberGain();
                totalDiamondGain += property.GetDailyDiamondGain();

                property.IncreaseTotalGoldGain(property.GetDailyGoldGain());
                property.IncreaseTotalLumberGain(property.GetDailyLumberGain());

                // update the property in the database
                DatabaseUtils.UpdatePropertyTotalIncome(property.GetXCoordinate(), property.GetYCoordinate(), property.GetTotalGoldGain(), property.GetTotalLumberGain());
                RefreshDataGridView("Properties");
            }

            // update the resource quantities with the total gains
            gold.ChangeQuantity(totalGoldGain);
            lumber.ChangeQuantity(totalLumberGain);
            diamond.ChangeQuantity(totalDiamondGain);

            // update market prices
            Market.UpdateConversionRates(resources);
            UpdateMarketPrices();
            UpdateMarketPanel();

            // update cost of building properties
            RefreshPropertyIncomes();
            InitializePropertyPrices();

            // update databases and their dataGridViews
            DatabaseUtils.AddNewDayOfIncome(currentDate, totalGoldGain, totalLumberGain, totalDiamondGain, properties.Count);
            RefreshAllDataGridViews();

            currentDate = currentDate.AddDays(1);
            lblDate.Text = @"Today's Date: " + currentDate.ToString("dd MMMM yyyy");
        }

        private void RefreshPropertyIncomes()
        {
            // for the box that shows incomes and prices of properties
            foreach (Property property in listOfAllProperties)
            {
                // fluctuate the cost by upto +/- 10%
                // as this random number is based upon the time in milliseconds, it will be different each time

                float fluctuation = CustomRandom.Next(-10, 10);

                float tempGoldGain = property.GetDailyGoldGain() + property.GetDailyGoldGain() * fluctuation / 100;
                fluctuation = CustomRandom.Next(-10, 10);
                float tempLumberGain = property.GetDailyLumberGain() + property.GetDailyLumberGain() * fluctuation / 100;
                fluctuation = CustomRandom.Next(-10, 10);
                float tempDiamondGain = property.GetDailyDiamondGain() + property.GetDailyDiamondGain() * fluctuation / 100;

                property.SetDailyGoldGain(tempGoldGain);
                property.SetDailyLumberGain(tempLumberGain);
                property.SetDailyDiamondGain(tempDiamondGain);
            }

            // for the properties in existence right now
            foreach (Property property in properties)
            {
                // fluctuate the cost by upto +/- 10%
                // as this random number is based upon the time (in 'ticks'), it will be different each time
                float fluctuation = CustomRandom.Next(-10, 10);

                float tempGoldGain = property.GetDailyGoldGain() + property.GetDailyGoldGain() * fluctuation / 100;
                fluctuation = CustomRandom.Next(-10, 10);
                float tempLumberGain = property.GetDailyLumberGain() + property.GetDailyLumberGain() * fluctuation / 100;
                fluctuation = CustomRandom.Next(-10, 10);
                float tempDiamondGain = property.GetDailyDiamondGain() + property.GetDailyDiamondGain() * fluctuation / 100;

                property.SetDailyGoldGain(tempGoldGain);
                property.SetDailyLumberGain(tempLumberGain);
                property.SetDailyDiamondGain(tempDiamondGain);
            }

            // update the database with the new costs and incomes for current properties
            foreach (Property property in properties)
            {
                DatabaseUtils.UpdatePropertyIncomes(property.GetXCoordinate(), property.GetYCoordinate(), property.GetDailyGoldGain(), property.GetDailyLumberGain(), property.GetDailyDiamondGain());
            }
        }

        private void UpdateMarketPrices()
        {
            listViewMarket.Items.Clear();
            foreach (Resource resource in resources)
            {
                if (resource.GetName() != "Dollars")
                {
                    string conversionRate = $"{Math.Round(resource.GetConversionRate(), 2)} dollars";
                    listViewMarket.Items.Add(new ListViewItem(new[] { conversionRate, resource.GetName() }));
                }
            }
        }

        private void UpdateMarketPanel()
        {
            if (selectedResource == null) return;
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * selectedResource.GetConversionRate();

            if (currentAction == "buy")
            {
                label1.Text = $@"Enter amount of {selectedResource.GetName().ToLower()} to buy";
                lblCost.Text = $@"Cost: {Math.Round(cost, 2)} dollars";
            }
            else
            {
                label1.Text = $@"Enter amount of {selectedResource.GetName().ToLower()} to sell";
                lblCost.Text = $@"Value: {Math.Round(cost, 2)} dollars";
            }
        }

        private void UpdateCost(string buyOrSell)
        {
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * selectedResource.GetConversionRate();

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (buyOrSell == "buy")
                lblCost.Text = $@"Cost: {Math.Round(cost, 2)} dollars";
            else
                lblCost.Text = $@"Value: {Math.Round(cost, 2)} dollars";
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            PerformMarketAction("buy");
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            PerformMarketAction("sell");
        }

        private void PerformMarketAction(string buyOrSell)
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
            float cost = amount * selectedResource.GetConversionRate();

            if (selectedResource == null) return;
            if (currentAction == "buy")
            {
                if (dollars.GetValue() >= cost)
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
                if (selectedResource.GetValue() >= amount)
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

        private void btnCancelMarketAction_Click(object sender, EventArgs e)
        {
            selectedResource = null;
            lblCost.Text = @"Buy / Sell Panel";
            label1.Text = @"Select a resource to buy or sell";
        }

        private void btnUpgradeLumberStorage_Click_1(object sender, EventArgs e)
        {
            UpgradeStorage(lumber, lumberStorageUpgradeCost);
            lumberStorageUpgradeCost *= 2;
            btnUpgradeLumberStorage.Text = $@"Upgrade Lumber Storage (Cost: {lumberStorageUpgradeCost} diamonds)";
        }

        private void btnUpgradeGoldStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(gold, goldStorageUpgradeCost);
            goldStorageUpgradeCost *= 2;
            btnUpgradeGoldStorage.Text = $@"Upgrade Gold Storage (Cost: {goldStorageUpgradeCost} diamonds)";
        }

        private void btnUpgradeDiamondStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(diamond, diamondStorageUpgradeCost);
            diamondStorageUpgradeCost *= 2;
            btnUpgradeDiamondStorage.Text = $@"Upgrade Diamond Storage (Cost: {diamondStorageUpgradeCost} diamonds)";
        }

        private void UpgradeStorage(Resource resource, int cost)
        {
            if (diamond.GetValue() >= cost)
            {
                diamond.ChangeQuantity(-cost);
                resource.IncreaseCapacity(100);
                Program.ShowAutoClosingMessageBox($"{resource.GetName()} storage upgraded!", "Success", 2500);
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
                numericUpDownAmount.Value = (decimal)(selectedResource.GetValue() * percentage);

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
            Property property = properties.Find(p => p.GetXCoordinate() == selectedPosition.X && p.GetYCoordinate() == selectedPosition.Y);

            if (property != null)
            {
                // calculate the sell price (80% of the original cost)
                int sellPriceGold = (int)(property.GetGoldCost() * 0.8);
                int sellPriceLumber = (int)(property.GetLumberCost() * 0.8);

                // remove the property from the list and update the grid
                properties.Remove(property);
                selectedTile.Image = Image.FromFile("Images/empty.jpg");
                selectedTile.BuiltUpon = false;

                // Add the sell price to the resources
                gold.ChangeQuantity(sellPriceGold);
                lumber.ChangeQuantity(sellPriceLumber);

                // change the Active status of the property in the database
                DatabaseUtils.UpdatePropertyStatus(property.GetXCoordinate(), property.GetYCoordinate(), false);

                Program.ShowAutoClosingMessageBox($"{property.GetType().Name} sold for {sellPriceGold} Gold and {sellPriceLumber} Lumber!", "Success", 2500);

                RefreshDataGridView("Properties");
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

        private static List<(Property, Property)> FindMst(List<Property> propertiesToFindMstOf)
        {
            // List to store the edges of the MST
            List<(Property, Property)> mstEdges = new List<(Property, Property)>();

            // If there are no properties, return an empty list
            if (propertiesToFindMstOf == null || propertiesToFindMstOf.Count == 0)
            {
                return mstEdges;
            }

            // List to keep track of visited properties
            List<Property> visited = new List<Property>();

            // Start with the first property
            Property start = propertiesToFindMstOf[0];
            visited.Add(start);

            // While not all properties are visited
            while (visited.Count < propertiesToFindMstOf.Count)
            {
                double minDistance = double.MaxValue;
                Property minProperty1 = null;
                Property minProperty2 = null;

                // Find the smallest edge connecting a visited property to an unvisited property
                foreach (Property property1 in visited)
                {
                    foreach (Property property2 in propertiesToFindMstOf)
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

        private static double CalculateDistance(Property a, Property b)
        {
            int deltaX = a.GetXCoordinate() - b.GetXCoordinate();
            int deltaY = a.GetYCoordinate() - b.GetYCoordinate();
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<(Property, Property)> mstEdges = FindMst(properties);

            string message = "";
            // display the edges of the MST in a message box
            foreach ((Property, Property) edge in mstEdges)
            {
                message += $"({edge.Item1.GetXCoordinate()}, {edge.Item1.GetYCoordinate()}) -> ({edge.Item2.GetXCoordinate()}, {edge.Item2.GetYCoordinate()})\n";
            }

            MessageBox.Show($@"Edges in the MST: {message}", @"Minimum Spanning Tree", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLesson1_Click_1(object sender, EventArgs e)
        {
            // Get the selected lesson from the DataGridView
            currentLesson = DatabaseUtils.GetRandomIncompleteLesson();

            if (currentLesson != null)
            {
                // display the question
                // ReSharper disable twice LocalizableElement
                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (previousLessonID == 0)
                {
                    lblQuestion.Text = $"Current Lesson ID: {currentLesson.LessonId}\n{currentLesson.Question}";
                }
                else
                {
                    lblQuestion.Text = $"Previous Lesson ID: {previousLessonID}\nCurrent Lesson ID: {currentLesson.LessonId}\n{currentLesson.Question}";
                }

                // populate choices
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
            List<Property> sortedProperties = mergeSort.Sort(properties, "Gold", "descending");
            DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
            RefreshDataGridView("Properties");
        }

        private void btnSortByLumberIncome_Click(object sender, EventArgs e)
        {
            List<Property> sortedProperties = mergeSort.Sort(properties, "Lumber", "descending");
            DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
            RefreshDataGridView("Properties");
        }

        private void btnSortByID_Click(object sender, EventArgs e)
        {
            List<Property> sortedProperties = mergeSort.Sort(properties, "ID", "ascending");
            DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
            RefreshDataGridView("Properties");
        }

        private void RefreshDataGridView(string tableName)
        {
            if (tableName == "Properties")
            {
                dataGridViewPropertiesList.DataSource = DatabaseUtils.LoadDatabaseData(tableName);
            }
            else if (tableName == "incomeHistoryTable")
            {
                dataGridViewIncomeHistory.DataSource = DatabaseUtils.LoadDatabaseData(tableName);

                // rename the column titles to make more sense to the user
                dataGridViewIncomeHistory.Columns[0].HeaderText = @"Date";
                dataGridViewIncomeHistory.Columns[1].HeaderText = @"Gold Income";
                dataGridViewIncomeHistory.Columns[2].HeaderText = @"Lumber Income";
                dataGridViewIncomeHistory.Columns[3].HeaderText = @"Diamond Income";
            }
        }

        private void RefreshDataGridViewLessons()
        {
            dataGridViewLessons.DataSource = DatabaseUtils.LoadLessonStatus();

            // ReSharper disable once LocalizableElement -> to make it shut up about verbatim strings
            lblQuestion.Text = @"Click 'Perform Lesson' to load an incomplete lesson\nThe question will then show up in this box";
            radioButton1.Text = @"Choice 1 will show here";
            radioButton2.Text = @"Choice 2 will show here";
            radioButton3.Text = @"Choice 3 will show here";
            radioButton4.Text = @"Choice 4 will show here";

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void RefreshAllDataGridViews()
        {
            RefreshDataGridView("Properties");
            RefreshDataGridView("incomeHistoryTable");
            RefreshDataGridViewLessons();
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

            // if not already answered
            if (!currentLesson.Completed)
            {
                // if correct answer
                if (currentLesson.IsCorrectAnswer(selectedAnswerIndex))
                {
                    Program.ShowAutoClosingMessageBox("Correct Answer!\nYou gained 5 diamond", "Result", 5000);

                    DatabaseUtils.UpdateLessonStatus(currentLesson.LessonId, true);

                    previousLessonID = currentLesson.LessonId;
                    currentLesson.Completed = true;
                    diamond.ChangeQuantity(5);

                    RefreshDataGridViewLessons();
                }
                else
                {
                    Program.ShowAutoClosingMessageBox("Incorrect Answer! Try again.", "Result", 2500);
                }
            }
            else
            {
                Program.ShowAutoClosingMessageBox("You have already completed this lesson.\nGo to the next lesson!", "Error", 2500);
            }
        }
    }
}