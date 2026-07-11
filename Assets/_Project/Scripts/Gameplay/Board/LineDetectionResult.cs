using System.Collections.Generic;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class LineDetectionResult
    {
        public readonly List<int> CompletedRows =
            new();

        public readonly List<int> CompletedColumns =
            new();

        public bool HasAnyLines =>
            CompletedRows.Count > 0 ||
            CompletedColumns.Count > 0;
    }
}