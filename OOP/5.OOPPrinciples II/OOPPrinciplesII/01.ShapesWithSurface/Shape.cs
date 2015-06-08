namespace _01.ShapesWithSurface
{
    using System;

    public abstract class Shape
    {
        private double height;
        private double width;

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height cannot be less 0 or negative");
                }
                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width cannot be less 0 or negative");
                }
                this.width = value;
            }
        }

        public abstract double CalculateSurface();
    }
}