using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bobFinal
{
    public partial class MasterForm : Form
    {
        protected class CustomPictureBox : PictureBox { public bool BuiltUpon { get; set; } }
        protected CustomPictureBox[,] grid;

        protected const int gridSize = 30;
        protected const int tileSize = 32;
        protected string selectedBuilding;
        protected Resource dollars;
        protected Resource gold;
        protected Resource lumber;
        protected Resource diamond;
        protected Resource selectedResource;
        protected string currentAction;
        protected DateTime currentDate = new DateTime(2021, 1, 1);

        protected List<Property> listOfAllProperties = new List<Property>
        {
            new House(0, 0), new Farm(0, 0), new Sawmill(0, 0), new Mine(0, 0), new Cafe(0, 0)
        };

        protected List<Property> properties = new List<Property>();
        protected List<Resource> resources;

        public MasterForm()
        {
            InitializeComponent();
        }
    }
}