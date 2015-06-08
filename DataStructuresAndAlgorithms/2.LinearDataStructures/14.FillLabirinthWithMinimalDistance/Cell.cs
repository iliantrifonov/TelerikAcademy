namespace _14.FillLabirinthWithMinimalDistance
{
    public struct Cell
    {
        public int Row;
        public int Col;
        public int Value;
        public Cell(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }
    }
}
