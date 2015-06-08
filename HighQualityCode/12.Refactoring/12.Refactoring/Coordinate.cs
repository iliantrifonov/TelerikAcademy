namespace _12.Refactoring
{
    /// <summary>
    /// Encapsulates the object that represents a single instance of the ICell interface
    /// </summary>
    public class Coordinate : ICoordinate
    {
        private int row;
        private int col;

        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }
    }
}