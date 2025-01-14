using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using bobFinal.PropertiesFolder;
using Path = System.IO.Path;

// ReSharper disable InvertIf

namespace bobFinal
{
    public partial class Form1 : Form
    {
        private const int GridSize = 15;
        private const int TileSize = 40;
        private const int NewDayInterval = 2000;
        private const int InitialCoordinate = 1;

        private readonly List<Property> _listOfAllProperties = new List<Property> { new House(0, 0, 0), new Sawmill(0, 0, 0), new Farm(0, 0, 0), new Cafe(0, 0, 0), new Mine(0, 0, 0) };
        private readonly MergeSort _mergeSort = new MergeSort();
        private readonly List<PathTile> _pathTilesList = new List<PathTile>();
        private readonly List<Property> _properties = new List<Property>();

        private float _commissionFluctuation;
        private string _currentAction;

        private DateTime _currentDate = new DateTime(2024, 1, 1);
        private Lesson _currentLesson;
        private int _currentPropertyIdIndex;
        private Resource _diamond;

        private int _diamondStorageUpgradeCost = 5;
        private Resource _dollars;
        private Resource _gold;
        private int _goldStorageUpgradeCost = 5;

        private CustomPictureBox[,] _grid;
        private Resource _lumber;
        private int _lumberStorageUpgradeCost = 5;
        private Timer _newDayTimer;
        private int _previousLessonId;

        private List<Resource> _resources;
        private string _selectedBuilding;
        private Point _selectedPosition;
        private Resource _selectedResource;

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
            foreach (Resource resource in _resources)
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
            _grid = new CustomPictureBox[GridSize, GridSize];
            const int panelWidth = GridSize * TileSize;
            const int panelHeight = GridSize * TileSize;

            // set the size of the grid panel
            gridPanel.Size = new Size(panelWidth, panelHeight);

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    // initialize each PictureBox in the grid
                    _grid[i, j] = new CustomPictureBox
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Location = new Point(i * TileSize, j * TileSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        Image = Image.FromFile("Images/empty.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BuiltUpon = false,
                        ConnectedViaPathOrProperty = false,
                        Tag = new Point(i, j) // store the position in the tag property
                    };
                    // add click event handler to each PictureBox
                    _grid[i, j].Click += GridPictureBox_Click;
                    // add the PictureBox to the grid panel
                    gridPanel.Controls.Add(_grid[i, j]);
                }
            }
        }

        private void InitializeLoot()
        {
            _dollars = new Resource("Dollars", 100, 10000, progressBarDollars, textBoxDollarsAmount, 1);
            _lumber = new Resource("Lumber", 100, 300, progressBarLumber, textBoxLumberAmount, 3);
            _gold = new Resource("Gold", 100, 300, progressBarGold, textBoxGoldAmount, 2);
            _diamond = new Resource("Diamond", 5, 50, progressBarDiamond, textBoxDiamondAmount, 10);

            _resources = new List<Resource> { _dollars, _lumber, _gold, _diamond };
        }

        private void InitializePropertyPrices()
        {
            listViewPrices.Items.Clear();
            foreach (Property property in _listOfAllProperties)
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
            // create and place the Town Hall
            _grid[InitialCoordinate + 1, InitialCoordinate + 1].Image = Image.FromFile("Images/TownHallTopLeft.jpg");
            _grid[InitialCoordinate + 1, InitialCoordinate + 1].BuiltUpon = true;
            _grid[InitialCoordinate + 1, InitialCoordinate + 1].ConnectedViaPathOrProperty = true;
            _grid[InitialCoordinate + 1, InitialCoordinate + 2].Image = Image.FromFile("Images/TownHallBottomLeft.jpg");
            _grid[InitialCoordinate + 2, InitialCoordinate + 2].BuiltUpon = true;
            _grid[InitialCoordinate + 2, InitialCoordinate + 2].ConnectedViaPathOrProperty = true;
            _grid[InitialCoordinate + 2, InitialCoordinate + 1].Image = Image.FromFile("Images/TownHallTopRight.jpg");
            _grid[InitialCoordinate + 2, InitialCoordinate + 1].BuiltUpon = true;
            _grid[InitialCoordinate + 2, InitialCoordinate + 1].ConnectedViaPathOrProperty = true;
            _grid[InitialCoordinate + 2, InitialCoordinate + 2].Image = Image.FromFile("Images/TownHallBottomRight.jpg");
            _grid[InitialCoordinate + 2, InitialCoordinate + 2].BuiltUpon = true;
            _grid[InitialCoordinate + 2, InitialCoordinate + 2].ConnectedViaPathOrProperty = true;

            // create and place the initial sawmill
            Property sawmill = new Sawmill(_currentPropertyIdIndex, InitialCoordinate + 4, InitialCoordinate + 4);
            _grid[sawmill.GetXCoordinate(), sawmill.GetYCoordinate()].Image = Image.FromFile(sawmill.GetImageFileName());
            _grid[sawmill.GetXCoordinate(), sawmill.GetYCoordinate()].BuiltUpon = true;
            _grid[sawmill.GetXCoordinate(), sawmill.GetYCoordinate()].ConnectedViaPathOrProperty = true;
            _properties.Add(sawmill);
            _currentPropertyIdIndex++;
            DatabaseUtils.AddNewProperty(sawmill.GetPropertyId(), sawmill.GetType().Name, sawmill.GetXCoordinate(), sawmill.GetYCoordinate(), sawmill.GetGoldCost(), sawmill.GetLumberCost(), sawmill.GetDailyGoldGain(), sawmill.GetDailyLumberGain(), sawmill.GetDailyDiamondGain(), sawmill.GetTotalGoldGain(), sawmill.GetTotalLumberGain(), sawmill.GetActive());

            // create and place the initial house
            Property house = new House(_currentPropertyIdIndex, InitialCoordinate + 5, InitialCoordinate + 5);
            _grid[house.GetXCoordinate(), house.GetYCoordinate()].Image = Image.FromFile(house.GetImageFileName());
            _grid[house.GetXCoordinate(), house.GetYCoordinate()].BuiltUpon = true;
            _grid[house.GetXCoordinate(), house.GetYCoordinate()].ConnectedViaPathOrProperty = true;
            _properties.Add(house);
            _currentPropertyIdIndex++;
            DatabaseUtils.AddNewProperty(house.GetPropertyId(), house.GetType().Name, house.GetXCoordinate(), house.GetYCoordinate(), house.GetGoldCost(), house.GetLumberCost(), house.GetDailyGoldGain(), house.GetDailyLumberGain(), house.GetDailyDiamondGain(), house.GetTotalGoldGain(), house.GetTotalLumberGain(), house.GetActive());

            // create and place the initial path tile
            ClearAndResetPathTiles(_grid, _pathTilesList);
        }

        private void InitializeNewDayTimer()
        {
            lblNextDayTimer.Text = "";
            _newDayTimer = new Timer();
            _newDayTimer.Interval = NewDayInterval; // set the interval to 2 seconds
            _newDayTimer.Tick += newDayTimer_Tick;
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
            _newDayTimer.Stop();
        }

        private void listViewPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPrices.SelectedItems.Count <= 0) return;

            string selectedItem = listViewPrices.SelectedItems[0].Text;
            _selectedBuilding = selectedItem.Split(':')[0].Trim();
        }

        private void GridPictureBox_Click(object sender, EventArgs e)
        {
            if (!(sender is PictureBox pictureBox)) return;

            _selectedPosition = (Point)pictureBox.Tag;
            lblSelectedPosition.Text = $@"Selected Tile: ({_selectedPosition.X}, {_selectedPosition.Y})";
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            Property property = null;

            // Determine the type of property to build based on selectedBuilding
            switch (_selectedBuilding)
            {
                case "House":
                    property = new House(_currentPropertyIdIndex, _selectedPosition.X, _selectedPosition.Y);
                    break;
                case "Farm":
                    property = new Farm(_currentPropertyIdIndex, _selectedPosition.X, _selectedPosition.Y);
                    break;
                case "Sawmill":
                    property = new Sawmill(_currentPropertyIdIndex, _selectedPosition.X, _selectedPosition.Y);
                    break;
                case "Mine":
                    property = new Mine(_currentPropertyIdIndex, _selectedPosition.X, _selectedPosition.Y);
                    break;
                case "Cafe":
                    property = new Cafe(_currentPropertyIdIndex, _selectedPosition.X, _selectedPosition.Y);
                    break;
            }

            if (property == null) return;

            CustomPictureBox selectedTile = _grid[_selectedPosition.X, _selectedPosition.Y];

            // Check if the selected tile is empty by verifying the image and BuiltUpon status
            if (selectedTile.BuiltUpon || (selectedTile.ImageLocation != null && !selectedTile.ImageLocation.Contains("empty.jpg")))
            {
                Program.ShowAutoClosingMessageBox("You can only build on an empty tile!", "Error", 2500);
                return;
            }

            // Check if there are enough resources to build the property
            if (_gold.GetValue() >= property.GetGoldCost() && _lumber.GetValue() >= property.GetLumberCost())
            {
                // Deduct the cost of the property from the resources
                _gold.ChangeQuantity(-property.GetGoldCost());
                _lumber.ChangeQuantity(-property.GetLumberCost());

                // Set the image of the selected grid position to the property image
                selectedTile.Image = Image.FromFile(property.GetImageFileName());
                selectedTile.BuiltUpon = true;
                selectedTile.ConnectedViaPathOrProperty = true;
                _properties.Add(property);

                // Add the property to the database and update the DataGridView
                DatabaseUtils.AddNewProperty(_currentPropertyIdIndex, property.GetType().Name, property.GetXCoordinate(), property.GetYCoordinate(), property.GetGoldCost(), property.GetLumberCost(), property.GetDailyGoldGain(), property.GetDailyLumberGain(), property.GetDailyDiamondGain(), property.GetTotalGoldGain(), property.GetTotalLumberGain(), property.GetActive());
                _currentPropertyIdIndex++;
                RefreshDataGridView("Properties");
            }

            else
            {
                Program.ShowAutoClosingMessageBox("Not enough resources!", "Error", 2500);
            }
        }

        private void CheckIfPropertiesAreConnected()
        {
            foreach (Property property in _properties)
            {
                if (!property.GetConnected())
                {
                    // check if any of the neighbouring tiles are built upon or if there is a path tile
                    int currentX = property.GetXCoordinate();
                    int currentY = property.GetYCoordinate();
                    bool isConnected = false;

                    // Check all neighbors in a 3x3 grid around (currentX, currentY)
                    for (int offsetX = -1; offsetX <= 1; offsetX++)
                    {
                        for (int offsetY = -1; offsetY <= 1; offsetY++)
                            // Skip the current property itself
                            if (!((offsetX == 0) && (offsetY == 0)))
                            {
                                int neighborX = currentX + offsetX;
                                int neighborY = currentY + offsetY;

                                // Check bounds to handle edge properties and corner properties
                                if ((neighborX >= 0) && (neighborX < GridSize) && (neighborY >= 0) && (neighborY < GridSize))
                                {
                                    if (_grid[neighborX, neighborY].ConnectedViaPathOrProperty)
                                    {
                                        isConnected = true;
                                        break;
                                    }
                                }
                            }

                        // exit loop early if connected for efficiency
                        if (isConnected) break;
                    }

                    if (isConnected && !property.GetConnected())
                    {
                        // then this property has newly been connected
                        property.SetConnected(true);
                        // update the database with the fact that this property is or is not connected
                        DatabaseUtils.UpdatePropertyConnectedStatus(property.GetXCoordinate(), property.GetYCoordinate(), true);

                        int newGoldGain = (int)(1.3 * property.GetDailyGoldGain());
                        int newLumberGain = (int)(1.3 * property.GetDailyLumberGain());
                        int newDiamondGain = (int)(1.3 * property.GetDailyDiamondGain());
                        property.SetDailyGoldGain(newGoldGain);
                        property.SetDailyLumberGain(newLumberGain);
                        property.SetDailyDiamondGain(newDiamondGain);
                    }
                }
            }
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            // Disable the button and start the timer
            lblNextDayTimer.Text = @"Next day available in 2 seconds...";
            btnNextDay.Enabled = false;
            _newDayTimer.Start();

            CheckIfPropertiesAreConnected();

            float totalGoldGain = 0;
            float totalLumberGain = 0;
            float totalDiamondGain = 0;

            // calculate the total resource gain from all properties
            foreach (Property property in _properties)
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
            _gold.ChangeQuantity(totalGoldGain);
            _lumber.ChangeQuantity(totalLumberGain);
            _diamond.ChangeQuantity(totalDiamondGain);

            // update market prices
            Market.UpdateConversionRates(_resources);
            UpdateMarketPrices();
            UpdateMarketPanel();

            // fluctuate the commission amount to be within 0-10%
            _commissionFluctuation = CustomRandom.Next(0, 11);
            lblCommission.Text = $@"Commission: {_commissionFluctuation}%";

            // update cost of building properties
            RefreshPropertyIncomes();
            InitializePropertyPrices();

            // update databases and their dataGridViews
            DatabaseUtils.AddNewDayOfIncome(_currentDate, totalGoldGain, totalLumberGain, totalDiamondGain, _properties.Count);
            RefreshAllDataGridViews();

            _currentDate = _currentDate.AddDays(1);
            lblDate.Text = @"Today's Date: " + _currentDate.ToString("dd MMMM yyyy");
        }

        private void RefreshPropertyIncomes()
        {
            // for the box that shows incomes and prices of properties
            foreach (Property property in _listOfAllProperties)
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
            foreach (Property property in _properties)
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
            foreach (Property property in _properties)
            {
                DatabaseUtils.UpdatePropertyIncomes(property.GetXCoordinate(), property.GetYCoordinate(), property.GetDailyGoldGain(), property.GetDailyLumberGain(), property.GetDailyDiamondGain());
            }
        }

        private void UpdateMarketPrices()
        {
            listViewMarket.Items.Clear();
            foreach (Resource resource in _resources)
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
            if (_selectedResource == null) return;

            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * _selectedResource.GetConversionRate() - _commissionFluctuation / 100;
            if (cost <= 0) cost = 0;

            if (_currentAction == "buy")
            {
                label1.Text = $@"Enter amount of {_selectedResource.GetName().ToLower()} to buy";
                lblCost.Text = $@"Cost: {Math.Round(cost, 2)} dollars";
            }
            else
            {
                label1.Text = $@"Enter amount of {_selectedResource.GetName().ToLower()} to sell";
                lblCost.Text = $@"Value: {Math.Round(cost, 2)} dollars";
            }
        }

        private void UpdateCost(string buyOrSell)
        {
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * _selectedResource.GetConversionRate();

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (buyOrSell == "buy")
            {
                lblCost.Text = $@"Cost: {Math.Round(cost, 2)} dollars";
            }
            else
            {
                lblCost.Text = $@"Value: {Math.Round(cost, 2)} dollars";
            }
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
            _currentAction = buyOrSell;

            // check if a resource is selected in the market list view
            if (listViewMarket.SelectedItems.Count == 1)
            {
                string selectedItem = listViewMarket.SelectedItems[0].SubItems[1].Text;
                // find the selected resource from the list of resources using regex
                _selectedResource = _resources.Find(r => r.Name == selectedItem);

                if (_selectedResource != null)
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
            UpdateCost(_currentAction); // using the stored action type
        }

        private void btnConfirmMarketAction_Click(object sender, EventArgs e)
        {
            int amount = (int)numericUpDownAmount.Value;
            float cost = amount * _selectedResource.GetConversionRate();

            if (_selectedResource == null) return;

            if (_currentAction == "buy")
            {
                if (_dollars.GetValue() >= cost)
                {
                    _dollars.ChangeQuantity(-cost);
                    _selectedResource.ChangeQuantity(amount);
                }
                else
                {
                    Program.ShowAutoClosingMessageBox("Not enough dollars!", "Error", 2500);
                }
            }
            else
            {
                if (_selectedResource.GetValue() >= amount)
                {
                    _dollars.ChangeQuantity(cost);
                    _selectedResource.ChangeQuantity(-amount);
                }
                else
                {
                    // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                    if (_selectedResource.GetName() != "Diamond")
                    {
                        Program.ShowAutoClosingMessageBox($"Not enough {_selectedResource.GetName()}!", "Error", 2500);
                    }
                    else
                    {
                        Program.ShowAutoClosingMessageBox("Not enough diamonds!\nEarn diamond by completing lessons", "Error", 2500);
                    }
                }
            }
        }

        private void btnCancelMarketAction_Click(object sender, EventArgs e)
        {
            _selectedResource = null;
            lblCost.Text = @"Buy / Sell Panel";
            label1.Text = @"Select a resource to buy or sell";
        }

        private void btnUpgradeLumberStorage_Click_1(object sender, EventArgs e)
        {
            UpgradeStorage(_lumber, _lumberStorageUpgradeCost);
            _lumberStorageUpgradeCost *= 2;
            btnUpgradeLumberStorage.Text = $@"Upgrade Lumber Storage (Cost: {_lumberStorageUpgradeCost} diamonds)";
        }

        private void btnUpgradeGoldStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(_gold, _goldStorageUpgradeCost);
            _goldStorageUpgradeCost *= 2;
            btnUpgradeGoldStorage.Text = $@"Upgrade Gold Storage (Cost: {_goldStorageUpgradeCost} diamonds)";
        }

        private void btnUpgradeDiamondStorage_Click(object sender, EventArgs e)
        {
            UpgradeStorage(_diamond, _diamondStorageUpgradeCost);
            _diamondStorageUpgradeCost *= 2;
            btnUpgradeDiamondStorage.Text = $@"Upgrade Diamond Storage (Cost: {_diamondStorageUpgradeCost} diamonds)";
        }

        private void UpgradeStorage(Resource resource, int cost)
        {
            if (_diamond.GetValue() >= cost)
            {
                _diamond.ChangeQuantity(-cost);
                resource.IncreaseCapacity(100);
                Program.ShowAutoClosingMessageBox($"{resource.GetName()} storage upgraded!", "Success", 2500);
            }
            else
            {
                Program.ShowAutoClosingMessageBox("Not enough diamonds to upgrade storage!\nEarn diamond by completing lessons", "Error", 2500);
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
            if (_selectedResource != null)
            {
                numericUpDownAmount.Value = (decimal)(_selectedResource.GetValue() * percentage);

                UpdateMarketPanel();
            }
            else
            {
                Program.ShowAutoClosingMessageBox("No resource selected!", "Error", 2500);
            }
        }

        private void btnSellBuilding_Click(object sender, EventArgs e)
        {
            CustomPictureBox selectedTile = _grid[_selectedPosition.X, _selectedPosition.Y];
            Property property = _properties.Find(p => p.GetXCoordinate() == _selectedPosition.X && p.GetYCoordinate() == _selectedPosition.Y);

            if (property != null)
            {
                // calculate the sell price (80% of the original cost)
                int sellPriceGold = (int)(property.GetGoldCost() * 0.8);
                int sellPriceLumber = (int)(property.GetLumberCost() * 0.8);

                // remove the property from the list and update the grid
                _properties.Remove(property);
                selectedTile.Image = Image.FromFile("Images/empty.jpg");
                selectedTile.BuiltUpon = false;
                selectedTile.ConnectedViaPathOrProperty = false;

                // Add the sell price to the resources
                _gold.ChangeQuantity(sellPriceGold);
                _lumber.ChangeQuantity(sellPriceLumber);

                // change the Active status of the property in the database
                DatabaseUtils.UpdatePropertyActiveStatus(property.GetXCoordinate(), property.GetYCoordinate(), false);

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

        private static void ClearAndResetPathTiles(CustomPictureBox[,] grid, List<PathTile> pathTilesList)
        {
            // swap out all path tiles for empty tiles
            foreach (PathTile pathTile in pathTilesList)
            {
                grid[pathTile.GetXCoordinate(), pathTile.GetYCoordinate()].Image = Image.FromFile("Images/empty.jpg");
            }

            // empty out the list
            pathTilesList.Clear();

            // place the initial path tile
            grid[InitialCoordinate + 3, InitialCoordinate + 3].Image = Image.FromFile("Images/PathTile.jpg");
            pathTilesList.Add(new PathTile(InitialCoordinate + 3, InitialCoordinate + 3));
        }

        private static void PlacePathTiles(List<PathTile> pathTiles, List<(Property, Property)> mstEdges, CustomPictureBox[,] grid)
        {
            ClearAndResetPathTiles(grid, pathTiles);

            foreach ((Property, Property) edge in mstEdges)
            {
                int startX = edge.Item1.GetXCoordinate();
                int startY = edge.Item1.GetYCoordinate();
                int endX = edge.Item2.GetXCoordinate();
                int endY = edge.Item2.GetYCoordinate();

                int currentX = startX;
                int currentY = startY;

                // while not at the end coordinates
                while (currentX != endX || currentY != endY)
                {
                    if (currentX != endX)
                    {
                        if (currentX < endX)
                        {
                            currentX++;
                        }
                        else
                        {
                            currentX--;
                        }
                    }

                    if (currentY != endY)
                    {
                        if (currentY < endY)
                        {
                            currentY++;
                        }
                        else
                        {
                            currentY--;
                        }
                    }

                    if (!grid[currentX, currentY].BuiltUpon)
                    {
                        grid[currentX, currentY].Image = Image.FromFile("Images/PathTile.jpg");
                        grid[currentX, currentY].ConnectedViaPathOrProperty = true;
                        pathTiles.Add(new PathTile(currentX, currentY));
                    }
                }
            }
        }

        // btnApplyPrims click event handler
        private void button1_Click(object sender, EventArgs e)
        {
            // charge 5 diamonds to do this:
            if (_diamond.GetValue() >= 5)
            {
                _diamond.ChangeQuantity(-5);

                List<(Property, Property)> mstEdges = FindMst(_properties);

                string message = "";
                // display the edges of the MST in a message box
                foreach ((Property, Property) edge in mstEdges) message += $"({edge.Item1.GetXCoordinate()}, {edge.Item1.GetYCoordinate()}) -> ({edge.Item2.GetXCoordinate()}, {edge.Item2.GetYCoordinate()})\n";

                Program.ShowAutoClosingMessageBox($"Edges in the MST: {message}\nPath tiles will be automatically placed to reflect the new MST\nAll properties connected to the MST experience a 1.3x boost in income", "Minimum Spanning Tree", 5000);
                PlacePathTiles(_pathTilesList, mstEdges, _grid);
            }
            else
            {
                Program.ShowAutoClosingMessageBox("Not enough diamonds to apply Prim's algorithm!\nEarn diamond by completing lessons", "Error", 2500);
            }
        }

        private void btnLesson1_Click_1(object sender, EventArgs e)
        {
            // Get the selected lesson from the DataGridView
            _currentLesson = DatabaseUtils.GetRandomIncompleteLesson();

            if (_currentLesson != null)
            {
                // display the question
                // ReSharper disable twice LocalizableElement
                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (_previousLessonId == 0)
                {
                    lblQuestion.Text = $"Current Lesson ID: {_currentLesson.LessonId}\n{_currentLesson.Question}";
                }
                else
                {
                    lblQuestion.Text = $"Previous Lesson ID: {_previousLessonId}\nCurrent Lesson ID: {_currentLesson.LessonId}\n{_currentLesson.Question}";
                }

                // populate choices
                radioButton1.Text = _currentLesson.ChoiceOne;
                radioButton2.Text = _currentLesson.ChoiceTwo;
                radioButton3.Text = _currentLesson.ChoiceThree;
                radioButton4.Text = _currentLesson.ChoiceFour;
            }
            else
            {
                Program.ShowAutoClosingMessageBox("No lessons found!", "Error", 2500);
            }
        }

        private void btnSortByGoldIncome_Click(object sender, EventArgs e)
        {
            List<Property> sortedProperties = _mergeSort.Sort(_properties, "Gold", "descending");
            DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
            RefreshDataGridView("Properties");
        }

        private void btnSortByLumberIncome_Click(object sender, EventArgs e)
        {
            List<Property> sortedProperties = _mergeSort.Sort(_properties, "Lumber", "descending");
            DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
            RefreshDataGridView("Properties");
        }

        private void btnSortByID_Click(object sender, EventArgs e)
        {
            List<Property> sortedProperties = _mergeSort.Sort(_properties, "ID", "ascending");
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
            // bind the DataTable to a DataGridViews to display the data
            RefreshDataGridView("Properties");
            RefreshDataGridView("incomeHistoryTable");
            RefreshDataGridViewLessons();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int selectedAnswerIndex = -1;

            // determine which answer was selected
            if (radioButton1.Checked)
            {
                selectedAnswerIndex = 0;
            }
            else if (radioButton2.Checked)
            {
                selectedAnswerIndex = 1;
            }
            else if (radioButton3.Checked)
            {
                selectedAnswerIndex = 2;
            }
            else if (radioButton4.Checked)
            {
                selectedAnswerIndex = 3;
            }

            // if not already answered
            if (!_currentLesson.Completed)
            {
                // if correct answer
                if (_currentLesson.IsCorrectAnswer(selectedAnswerIndex))
                {
                    Program.ShowAutoClosingMessageBox("Correct Answer!\nYou gained 5 diamond", "Result", 5000);

                    DatabaseUtils.UpdateLessonStatus(_currentLesson.LessonId, true);

                    _previousLessonId = _currentLesson.LessonId;
                    _currentLesson.Completed = true;
                    _diamond.ChangeQuantity(5);

                    RefreshDataGridViewLessons();
                }
                else
                {
                    Program.ShowAutoClosingMessageBox("Incorrect Answer! Try again.", "Result", 4500);
                }
            }
            else
            {
                Program.ShowAutoClosingMessageBox("You have already completed this lesson.\nGo to the next lesson!", "Error", 2500);
            }
        }
    }
}