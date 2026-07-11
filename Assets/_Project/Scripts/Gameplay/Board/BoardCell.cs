namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardCell
    {
        public int X { get; }

        public int Y { get; }

        public bool IsOccupied { get; set; }

        public BoardCell(int x, int y)
        {
            X = x;
            Y = y;
            IsOccupied = false;
        }
    }
}