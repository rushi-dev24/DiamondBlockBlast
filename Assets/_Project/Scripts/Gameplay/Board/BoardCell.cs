namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardCell
    {
        public int X { get; }

        public int Y { get; }

        public bool IsOccupied { get; set; }

        public BoardCellView View { get; }

        public BoardCell(
            int x,
            int y,
            BoardCellView view)
        {
            X = x;
            Y = y;
            View = view;
            IsOccupied = false;
        }
    }
}