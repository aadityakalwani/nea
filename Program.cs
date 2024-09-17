using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bobFinal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public abstract class Property
    {
        public string Name { get; set; }
        public int GoldCost { get; set; }
        public int LumberCost { get; set; }
        public int WeeklyGain { get; set; }

        public abstract void Advertise();
    }

    public class House : Property
    {
        public House()
        {
            Name = "House";
            GoldCost = 100;
            LumberCost = 50;
            WeeklyGain = 30;
        }

        public override void Advertise()
        {
            // tk to do later
        }
    }

    public class Farm : Property
    {
        public Farm()
        {
            Name = "Farm";
            GoldCost = 100;
            LumberCost = 100;
            WeeklyGain = 60;
        }

        public override void Advertise()
        {
            // again to do later
        }
    }
}