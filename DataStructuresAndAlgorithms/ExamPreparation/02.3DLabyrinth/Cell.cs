namespace _02._3DLabyrinth
{
    public class Cell
    {
        public Cell(int l, int r, int c, int moves)
        {
            this.PosL = l;
            this.PosR = r;
            this.PosC = c;
            this.Moves = moves;
        }

        public int PosL { get; set; }

        public int PosR { get; set; }

        public int PosC { get; set; }

        public int Moves { get; set; }

        public override int GetHashCode()
        {
            return PosC.GetHashCode() ^ PosL.GetHashCode() ^ PosR.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Cell;
            return this.PosR.Equals(other.PosR) && this.PosL.Equals(other.PosL) && this.PosC.Equals(PosC);
        }
    }
}
