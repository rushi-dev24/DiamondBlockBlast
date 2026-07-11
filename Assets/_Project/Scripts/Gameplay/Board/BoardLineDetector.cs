using UnityEngine;

using BlockPuzzle.Core.Constants;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardLineDetector : MonoBehaviour
    {
        [SerializeField]
        private BoardManager boardManager;

        public LineDetectionResult DetectCompletedLines()
        {
            LineDetectionResult result =
                new();

            DetectRows(result);

            DetectColumns(result);

            return result;
        }

        private void DetectRows(
            LineDetectionResult result)
        {
            for (int y = 0;
                y < AppConstants.BoardHeight;
                y++)
            {
                bool rowComplete = true;

                for (int x = 0;
                    x < AppConstants.BoardWidth;
                    x++)
                {
                    BoardCell cell =
                        boardManager.GetCell(x, y);

                    if (cell == null ||
                        !cell.IsOccupied)
                    {
                        rowComplete = false;
                        break;
                    }
                }

                if (rowComplete)
                {
                    result.CompletedRows.Add(y);
                }
            }
        }

        private void DetectColumns(
            LineDetectionResult result)
        {
            for (int x = 0;
                x < AppConstants.BoardWidth;
                x++)
            {
                bool columnComplete = true;

                for (int y = 0;
                    y < AppConstants.BoardHeight;
                    y++)
                {
                    BoardCell cell =
                        boardManager.GetCell(x, y);

                    if (cell == null ||
                        !cell.IsOccupied)
                    {
                        columnComplete = false;
                        break;
                    }
                }

                if (columnComplete)
                {
                    result.CompletedColumns.Add(x);
                }
            }
        }
    }
}