namespace RefactorVariableNaming
{
    using System;

    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

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
                    throw new ArgumentException("Height cannot be negative or zero");
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
                    throw new ArgumentException("Width cannot be negative or zero");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Returns a new instance of the Figure class, by rotating the current instance of the figure by angle
        /// </summary>
        /// <param name="angle">Angle is in radians</param>
        /// <returns>a new Figure, rotated by angle</returns>
        public Figure GetRotatedFigure(double angle)
        {
            var cosAngleRotation = Math.Abs(Math.Cos(angle));
            var sinAngleRotation = Math.Abs(Math.Sin(angle));

            var rotatedWidth = (cosAngleRotation * this.Width) + (sinAngleRotation * this.Height);
            var rotatedHeight = (sinAngleRotation * this.Width) + (cosAngleRotation * this.Height);

            return new Figure(rotatedWidth, rotatedHeight);
        }
    }
}