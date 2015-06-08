using System;

namespace Game
{
    public class Point
    {
        private string name;
        private int points;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The points cannot have value less than zero");
                }

                points = value;
            }
        }

        public Point()
        {
        }

        public Point(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
}