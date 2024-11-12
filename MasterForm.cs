using System;
using System.Windows.Forms;

namespace bobFinal
{
    public partial class MasterForm : Form
    {
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

        public MasterForm()
        {
            InitializeComponent();
        }
    }
}