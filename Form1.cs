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
        private int diamondStorageUpgradeCost = 5;
        private int goldStorageUpgradeCost = 5;
        private int lumberStorageUpgradeCost = 5;
        private Resource dollars;
        private Resource gold;
        private CustomPictureBox[,] grid;
        private MergeSort mergeSort = new MergeSort();
        private List<Property> listOfAllProperties = new List<Property> { new House(0, 0, 0), new Farm(0, 0, 0), new Sawmill(0, 0, 0), new Mine(0, 0, 0), new Cafe(0, 0, 0) };
        private Resource lumber;
        private Timer newDayTimer;
        private List<Property> properties = new List<Property>();
        private List<Resource> resources;
        private string selectedBuilding;
        private Point selectedPosition;
        private Resource selectedResource;
        private Lesson currentLesson;
        private int currentPropertyIdIndex = 0;

        public Form1()
        {
            InitializeComponent();
            DatabaseUtils.InitializeDatabase();
            initializeGrid();
            initializeLoot();
            initializeStartingProperties();
            initializePrices();
            initializeMarketPrices();
            initializeNewDayTimer();
            initializeLessons();

            // bind the DataTable to a DataGridViews to display the data
            RefreshAllDataGridViews();

            numericUpDownAmount.Maximum = 9999999;

            // open in full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            // set the size of the tables to take up the minmum width required per column
            dataGridViewIncomeHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewIncomeHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewPropertiesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPropertiesList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewLessons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewLessons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            Property sawmill = new Sawmill(currentPropertyIdIndex, initialCoordinate + 4, initialCoordinate + 4);
            grid[sawmill.XCoordinate, sawmill.YCoordinate].Image = Image.FromFile(sawmill.ImageFileName);
            grid[sawmill.XCoordinate, sawmill.YCoordinate].BuiltUpon = true;
            properties.Add(sawmill);
            currentPropertyIdIndex++;
            DatabaseUtils.AddNewProperty(sawmill.PropertyID, sawmill.GetType().Name, sawmill.XCoordinate, sawmill.YCoordinate, sawmill.GoldCost, sawmill.LumberCost, sawmill.DailyGoldGain, sawmill.DailyLumberGain, sawmill.DailyDiamondGain, sawmill.TotalGoldGain, sawmill.TotalLumberGain, sawmill.active);

            // create and place the initial house
            Property house = new House(currentPropertyIdIndex, initialCoordinate + 5, initialCoordinate + 5);
            grid[house.XCoordinate, house.YCoordinate].Image = Image.FromFile(house.ImageFileName);
            grid[house.XCoordinate, house.YCoordinate].BuiltUpon = true;
            properties.Add(house);
            currentPropertyIdIndex++;
            DatabaseUtils.AddNewProperty(house.PropertyID, house.GetType().Name, house.XCoordinate, house.YCoordinate, house.GoldCost, house.LumberCost, house.DailyGoldGain, house.DailyLumberGain, house.DailyDiamondGain, house.TotalGoldGain, house.TotalLumberGain, house.active);
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
            List<Lesson> lessons = new List<Lesson>
            {
                new Lesson(1, "Business", "Business Ownership", "Which of the following is a key advantage of a sole proprietorship?", 0, 50, "Ease of setup", "Limited liability", "Perpetual succession", "Shared decision-making", false),
                new Lesson(2, "Business", "Supply and Demand", "How does an increase in consumer income affect the demand for normal goods?", 0, 50, "Increases demand", "Decreases demand", "No effect on demand", "Increases supply", false),
                new Lesson(3, "Business", "Economics", "What is the primary goal of a not-for-profit organization?", 1, 50, "Profit maximization", "Social welfare", "Market share", "Shareholder value", false),
                new Lesson(4, "Economics", "Opportunity Cost", "A government decides to increase spending on education. What is the opportunity cost of this decision?", 2, 50, "Increased taxes", "Reduced spending on healthcare", "Increased national debt", "All of the above", false),
                new Lesson(5, "Economics", "Scarcity", "How does scarcity affect economic decisions?", 3, 50, "It forces choices to be made", "It eliminates the need for trade", "It leads to unlimited resources", "It ensures economic equality", false),
                new Lesson(6, "Economics", "Trade-offs", "A company decides to invest in new technology. What is the potential trade-off of this decision?", 1, 50, "Increased productivity", "Reduced labor costs", "Lower initial costs", "Delayed profit maximization", false),
                new Lesson(7, "Economics", "Supply and Demand", "What is the likely impact of a decrease in the price of a complementary good on the demand for a related good?", 0, 50, "Increase in demand", "Decrease in demand", "No effect on demand", "Increase in supply", false),
                new Lesson(8, "Economics", "Elasticity", "How does price elasticity of demand affect a firm's pricing strategy?", 2, 50, "It determines the optimal price level", "It measures the responsiveness of supply to price changes", "It indicates the degree of competition in the market", "It measures the impact of government regulations on prices", false),
                new Lesson(9, "Economics", "Monopoly", "What is a key characteristic of a natural monopoly?", 3, 50, "High barriers to entry", "Price-taking behavior", "Homogeneous products", "Perfect information", false),
                new Lesson(10, "Economics", "Oligopoly", "How do firms in an oligopoly typically compete?", 1, 50, "Price competition", "Non-price competition", "Product differentiation", "All of the above", false),
                new Lesson(11, "Economics", "Price Discrimination", "What is a common method used by firms to practice price discrimination?", 0, 50, "Student discounts", "Loyalty programs", "Time-of-day pricing", "All of the above", false),
                new Lesson(12, "Business", "Entrepreneurship", "What is a key risk associated with entrepreneurship?", 2, 50, "Limited liability", "Job security", "Financial loss", "Low income potential", false),
                new Lesson(13, "Economics", "Market Failure", "How can government intervention address the problem of negative externalities?", 1, 50, "Subsidies", "Taxes", "Price controls", "Deregulation", false),
                new Lesson(14, "Business", "Business Objectives", "How does a business achieve sustainable growth?", 3, 50, "Maximizing short-term profits", "Ignoring environmental concerns", "Exploiting natural resources", "Balancing financial, social, and environmental goals", false),
                new Lesson(15, "Economics", "Government Intervention", "What is the purpose of fiscal policy?", 2, 50, "Controlling the money supply", "Influencing interest rates", "Adjusting government spending and taxation", "Regulating market competition", false),
                new Lesson(16, "Business", "Marketing", "What is the marketing mix, and why is it important?", 3, 50, "A set of marketing tools used to achieve marketing objectives", "A strategy for reducing production costs", "A method for analyzing consumer behavior", "A tool for measuring brand loyalty", false),
                new Lesson(17, "Economics", "Inflation", "What is the likely impact of high inflation on economic growth?", 1, 50, "Stimulates economic growth", "Reduces uncertainty and encourages investment", "Erodes purchasing power and slows economic activity", "Increases savings and investment", false),
                new Lesson(18, "Business", "Financial Management", "What is the purpose of a cash flow forecast?", 0, 50, "To predict future cash inflows and outflows", "To analyze past financial performance", "To evaluate long-term investment opportunities", "To measure profitability", false),
                new Lesson(19, "Economics", "GDP", "Why is GDP an imperfect measure of economic well-being?", 2, 50, "It includes non-market activities", "It accounts for income distribution", "It does not measure quality of life", "It excludes government spending", false),
                new Lesson(20, "Economics", "Labour Market", "What is the impact of technological advancements on the demand for labor?", 1, 50, "Increases demand for low-skilled labor", "Decreases demand for high-skilled labor", "Increases demand for both low-skilled and high-skilled labor", "Decreases demand for both low-skilled and high-skilled labor", false),
                new Lesson(21, "Economics", "Unemployment", "What type of unemployment is caused by a recession?", 3, 50, "Frictional unemployment", "Structural unemployment", "Cyclical unemployment", "Seasonal unemployment", false),
                new Lesson(22, "Business", "Corporate Social Responsibility", "How can CSR benefit a business?", 0, 50, "Improved brand reputation", "Reduced costs", "Increased regulatory compliance", "All of the above", false),
                new Lesson(23, "Economics", "Externalities", "What is a government policy to address the problem of negative externalities from pollution?", 2, 50, "Subsidies to polluting industries", "Deregulation of environmental standards", "Taxation on pollution", "Reduced government spending on environmental protection", false),
                new Lesson(24, "Business", "Business Cycle", "What is the role of government during a recession?", 1, 50, "Increase taxes and reduce government spending", "Decrease interest rates and increase government spending", "Increase interest rates and reduce government spending", "No government intervention is necessary", false),
                new Lesson(25, "Economics", "Inflation", "What is the likely impact of cost-push inflation on economic output?", 2, 50, "Increased economic output", "Reduced unemployment", "Decreased economic output", "No impact on economic output", false),
                new Lesson(26, "Business", "Competition", "How does perfect competition benefit consumers?", 3, 50, "Higher prices", "Lower quality products", "Reduced consumer choice", "Lower prices and higher quality products", false),
                new Lesson(27, "Economics", "Taxes", "What is the impact of a regressive tax on income distribution?", 1, 50, "Reduces income inequality", "Increases income inequality", "No impact on income distribution", "Increases economic growth", false),
                new Lesson(28, "Business", "Branding", "How does branding create value for a business?", 0, 50, "Reduced production costs", "Increased price sensitivity", "Lower customer loyalty", "Increased brand recognition and customer loyalty", false),
                new Lesson(29, "Economics", "Monetary Policy", "What is the goal of contractionary monetary policy?", 3, 50, "Stimulate economic growth", "Reduce unemployment", "Control inflation", "Increase government spending", false),
                new Lesson(30, "Business", "E-commerce", "What is a potential disadvantage of e-commerce for businesses?", 2, 50, "Lower costs", "Increased market reach", "Increased competition", "Cybersecurity risks", false),
                new Lesson(31, "Business", "Marketing Mix", "What are the 4 Ps of the marketing mix?", 3, 50, "Product, Price, Promotion, Place", "Product, Price, People, Process", "Product, Price, Promotion, Profit", "Product, Place, People, Profit", false),
                new Lesson(32, "Economics", "Fiscal Policy", "What is the impact of increased government spending on aggregate demand?", 0, 50, "Increases aggregate demand", "Decreases aggregate demand", "No effect on aggregate demand", "Increases aggregate supply", false),
                new Lesson(33, "Business", "Human Resource Management", "What is the primary goal of human resource management?", 1, 50, "Recruiting and selecting employees", "Training and developing employees", "Maximizing employee productivity", "Ensuring legal compliance", false),
                new Lesson(34, "Economics", "International Trade", "What is the theory of comparative advantage?", 2, 50, "Countries should specialize in producing goods and services they can produce most efficiently", "Countries should protect domestic industries from foreign competition", "Countries should impose tariffs on imported goods", "Countries should limit the number of foreign workers", false),
                new Lesson(35, "Business", "Business Ethics", "What is the role of corporate social responsibility (CSR)?", 0, 50, "To improve a company's reputation", "To reduce costs", "To increase profits", "To balance economic, social, and environmental concerns", false),
                new Lesson(36, "Economics", "Inflation", "What is the relationship between inflation and unemployment, as described by the Phillips Curve?", 2, 50, "Inverse relationship", "Direct relationship", "No relationship", "Uncertain relationship", false),
                new Lesson(37, "Business", "Financial Analysis", "What is the purpose of a balance sheet?", 1, 50, "To measure profitability", "To assess liquidity", "To evaluate solvency", "To track cash flow", false),
                new Lesson(38, "Economics", "Market Structures", "In which market structure do firms have the most market power?", 0, 50, "Monopoly", "Oligopoly", "Monopolistic competition", "Perfect competition", false),
                new Lesson(39, "Business", "Operations Management", "What is the purpose of quality control in operations management?", 2, 50, "To reduce costs", "To increase production", "To ensure product quality", "To improve employee morale", false),
                new Lesson(40, "Economics", "Economic Growth", "What is the role of investment in economic growth?", 0, 50, "Increases productive capacity", "Reduces unemployment", "Increases consumer spending", "Reduces inflation", false),
                new Lesson(41, "Business", "Marketing Strategy", "What is the purpose of a SWOT analysis?", 3, 50, "To identify a company's strengths, weaknesses, opportunities, and threats", "To measure a company's market share", "To evaluate a company's financial performance", "To assess a company's customer satisfaction", false),
                new Lesson(42, "Economics", "Exchange Rates", "What is the impact of a depreciation of a country's currency on its exports?", 0, 50, "Increases exports", "Decreases exports", "No effect on exports", "Increases imports", false),
                new Lesson(43, "Business", "Business Plans", "What is the purpose of a business plan?", 1, 50, "To secure funding", "To guide business operations", "To assess market potential", "All of the above", false),
                new Lesson(44, "Economics", "Economic Indicators", "What is the Consumer Price Index (CPI) used to measure?", 2, 50, "Economic growth", "Unemployment rate", "Inflation rate", "Interest rates", false),
                new Lesson(45, "Business", "Innovation", "What is the role of innovation in business success?", 0, 50, "To create new products and services", "To improve efficiency", "To gain a competitive advantage", "All of the above", false),
                new Lesson(46, "Economics", "Externalities", "What is an example of a positive externality?", 1, 50, "Education", "Pollution", "Congestion", "Noise pollution", false),
                new Lesson(47, "Business", "Risk Management", "What is the purpose of risk management in business?", 2, 50, "To eliminate all risk", "To maximize profits", "To minimize potential losses", "To increase market share", false),
                new Lesson(48, "Economics", "Economic Systems", "What is a key characteristic of a command economy?", 3, 50, "Private ownership of resources", "Market forces determine prices", "Government planning and control", "Consumer sovereignty", false),
                new Lesson(49, "Business", "Marketing Research", "What is the purpose of market research?", 0, 50, "To understand customer needs and preferences", "To identify market opportunities", "To assess market competition", "All of the above", false),
                new Lesson(50, "Economics", "Economic Growth", "What is the role of technological advancement in economic growth?", 1, 50, "Increases productivity", "Reduces innovation", "Increases unemployment", "Decreases economic efficiency", false),
                new Lesson(51, "Business", "Marketing Mix", "What are the 4 Ps of the marketing mix?", 3, 50, "Product, Price, Promotion, Place", "Product, Price, People, Process", "Product, Price, Promotion, Profit", "Product, Place, People, Profit", false),
                new Lesson(52, "Economics", "Fiscal Policy", "What is the impact of increased government spending on aggregate demand?", 0, 50, "Increases aggregate demand", "Decreases aggregate demand", "No effect on aggregate demand", "Increases aggregate supply", false),
                new Lesson(53, "Business", "Human Resource Management", "What is the primary goal of human resource management?", 1, 50, "Recruiting and selecting employees", "Training and developing employees", "Maximizing employee productivity", "Ensuring legal compliance", false),
                new Lesson(54, "Economics", "International Trade", "What is the theory of comparative advantage?", 2, 50, "Countries should specialize in producing goods and services they can produce most efficiently", "Countries should protect domestic industries from foreign competition", "Countries should impose tariffs on imported goods", "Countries should limit the number of foreign workers", false),
                new Lesson(55, "Business", "Business Ethics", "What is the role of corporate social responsibility (CSR)?", 0, 50, "To improve a company's reputation", "To reduce costs", "To increase profits", "To balance economic, social, and environmental concerns", false),
                new Lesson(56, "Economics", "Inflation", "What is the relationship between inflation and unemployment, as described by the Phillips Curve?", 2, 50, "Inverse relationship", "Direct relationship", "No relationship", "Uncertain relationship", false),
                new Lesson(57, "Business", "Financial Analysis", "What is the purpose of a balance sheet?", 1, 50, "To measure profitability", "To assess liquidity", "To evaluate solvency", "To track cash flow", false),
                new Lesson(58, "Economics", "Market Structures", "In which market structure do firms have the most market power?", 0, 50, "Monopoly", "Oligopoly", "Monopolistic competition", "Perfect competition", false),
                new Lesson(59, "Business", "Operations Management", "What is the purpose of quality control in operations management?", 2, 50, "To reduce costs", "To increase production", "To ensure product quality", "To improve employee morale", false),
                new Lesson(60, "Economics", "Economic Growth", "What is the role of investment in economic growth?", 0, 50, "Increases productive capacity", "Reduces unemployment", "Increases consumer spending", "Reduces inflation", false),
                new Lesson(61, "Business", "Marketing Strategy", "What is the purpose of a SWOT analysis?", 3, 50, "To identify a company's strengths, weaknesses, opportunities, and threats", "To measure a company's market share", "To evaluate a company's financial performance", "To assess a company's customer satisfaction", false),
                new Lesson(62, "Economics", "Exchange Rates", "What is the impact of a depreciation of a country's currency on its exports?", 0, 50, "Increases exports", "Decreases exports", "No effect on exports", "Increases imports", false),
                new Lesson(63, "Business", "Business Plans", "What is the purpose of a business plan?", 1, 50, "To secure funding", "To guide business operations", "To assess market potential", "All of the above", false),
                new Lesson(64, "Economics", "Economic Indicators", "What is the Consumer Price Index (CPI) used to measure?", 2, 50, "Economic growth", "Unemployment rate", "Inflation rate", "Interest rates", false),
                new Lesson(65, "Business", "Innovation", "What is the role of innovation in business success?", 0, 50, "To create new products and services", "To improve efficiency", "To gain a competitive advantage", "All of the above", false),
                new Lesson(66, "Economics", "Externalities", "What is an example of a positive externality?", 1, 50, "Education", "Pollution", "Congestion", "Noise pollution", false),
                new Lesson(67, "Business", "Risk Management", "What is the purpose of risk management in business?", 2, 50, "To eliminate all risk", "To maximize profits", "To minimize potential losses", "To increase market share", false),
                new Lesson(68, "Economics", "Economic Systems", "What is a key characteristic of a command economy?", 3, 50, "Private ownership of resources", "Market forces determine prices", "Government planning and control", "Consumer sovereignty", false),
                new Lesson(69, "Business", "Marketing Research", "What is the purpose of market research?", 0, 50, "To understand customer needs and preferences", "To identify market opportunities", "To assess market competition", "All of the above", false),
                new Lesson(70, "Economics", "Economic Growth", "What is the role of technological advancement in economic growth?", 1, 50, "Increases productivity", "Reduces innovation", "Increases unemployment", "Decreases economic efficiency", false)
            };

            // Add each lesson to the database
            foreach (var lesson in lessons)
            {
                DatabaseUtils.AddLesson(lesson);
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
                    DatabaseUtils.AddNewProperty(currentPropertyIdIndex, property.GetType().Name, property.XCoordinate, property.YCoordinate, property.GoldCost, property.LumberCost, property.DailyGoldGain, property.DailyLumberGain, property.DailyDiamondGain, property.TotalGoldGain, property.TotalLumberGain, property.active);
                    currentPropertyIdIndex++;
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

                property.TotalGoldGain += property.DailyGoldGain;
                property.TotalLumberGain += property.DailyLumberGain;


                // update the property in the database
                DatabaseUtils.UpdatePropertyTotalIncome(property.XCoordinate, property.YCoordinate, property.TotalGoldGain, property.TotalLumberGain);
                RefreshDataGridView("Properties");
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
            RefreshAllDataGridViews();

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

                // change the Active status of the property in the database
                DatabaseUtils.UpdatePropertyStatus(property.XCoordinate, property.YCoordinate, false);

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
            List<Property> sortedProperties = mergeSort.Sort(properties, "Gold");
            string sortedPropertiesString = "";
            foreach (Property property in sortedProperties)
            {
                sortedPropertiesString += property.TotalGoldGain + "\n";
            }
            MessageBox.Show($"Properties sorted by Gold Income:\n{sortedPropertiesString}");

            DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
            RefreshDataGridView("Properties");
        }

        private void btnSortByLumberIncome_Click(object sender, EventArgs e)
        {
            List<Property> sortedProperties = mergeSort.Sort(properties, "Lumber");
            string sortedPropertiesString = "";
            foreach (Property property in sortedProperties)
            {
                sortedPropertiesString += property.TotalLumberGain + "\n";
            }
            MessageBox.Show($"Properties sorted by Lumber Income:\n{sortedPropertiesString}");
            DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
            RefreshDataGridView("Properties");
        }

        private void btnSortByID_Click(object sender, EventArgs e)
        {
            Program.ShowAutoClosingMessageBox("THIS DOESNT WORK YET IDIOT", "Sort by ID", 2250);
            // List<Property> sortedProperties = mergeSort.Sort(properties.ToArray(), "ID");
            // DatabaseUtils.UpdateDatabaseWithSortedProperties(sortedProperties);
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

            // Check if the question has already been answered:
            if (!currentLesson.Completed)
            {
                // Check if the answer is correct
                if (currentLesson.IsCorrectAnswer(selectedAnswerIndex))
                {
                    Program.ShowAutoClosingMessageBox("Correct Answer!\nYou gained 5 diamond", "Result", 3000);

                    // Update the lesson status in the database
                    DatabaseUtils.UpdateLessonStatus(currentLesson.LessonId, true);
                    RefreshDataGridViewLessons();

                    currentLesson.Completed = true;
                    diamond.ChangeQuantity(5);

                    lblQuestion.Text = "Click 'Perform Lesson' to load an incomplete lesson\nThe question will then show up in this box";
                    radioButton1.Text = "Choice 1 will show here";
                    radioButton2.Text = "Choice 2 will show here";
                    radioButton3.Text = "Choice 3 will show here";
                    radioButton4.Text = "Choice 4 will show here";

                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
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