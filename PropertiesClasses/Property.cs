﻿namespace bobFinal
{
    public abstract class Property
    {
        protected Property(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public int GoldCost { get; protected set; }
        public int LumberCost { get; protected set; }
        public int DailyGoldGain { get; protected set; }
        public int DailyLumberGain { get; protected set; }
        public int DailyDiamondGain { get; protected set; }
        public string ImageFileName { get; protected set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
    }
}