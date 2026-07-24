using UnityEngine;

using BlockPuzzle.Core.Constants;
using BlockPuzzle.Gameplay.Blocks;
using BlockPuzzle.Gameplay.Score;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardManager : MonoBehaviour
    {
        [SerializeField]
        private BoardCellView cellPrefab;

        [SerializeField]
        private Transform cellParent;

        private BoardCell[,] cells;

        public bool IsInitialized { get; private set; }

        [SerializeField]
        private BoardLineDetector lineDetector;

        [SerializeField]
        private ScoreManager scoreManager;

        private void Start()
        {
            GenerateBoard();

            IsInitialized = true;
        }

        public BoardCell GetCell(int x, int y)
        {
            if (x < 0 ||
                x >= AppConstants.BoardWidth ||
                y < 0 ||
                y >= AppConstants.BoardHeight)
            {
                return null;
            }

            return cells[x, y];
        }

        private void GenerateBoard()
        {
            cells = new BoardCell[
                AppConstants.BoardWidth,
                AppConstants.BoardHeight];

            for (int y = 0; y < AppConstants.BoardHeight; y++)
            {
                for (int x = 0; x < AppConstants.BoardWidth; x++)
                {
                    BoardCellView cellView =
                        Instantiate(
                            cellPrefab,
                            cellParent);

                    cellView.Initialize(x, y);

                    cells[x, y] =
                        new BoardCell(
                            x,
                            y,
                            cellView);
                }
            }
            Debug.Log("BOARD GENERATED");
        }
        public BoardCell GetCell(BoardCellView view)
        {
            if (view == null)
            {
                return null;
            }

            return GetCell(
                view.X,
                view.Y);
        }

        public void PlaceBlock(
            BlockData blockData,
            int originX,
            int originY)
        {
            foreach (BlockCellPosition shapeCell
                in blockData.Cells)
            {
                int boardX =
                    originX + shapeCell.X;

                int boardY =
                    originY - shapeCell.Y;

                BoardCell boardCell =
                    GetCell(
                        boardX,
                        boardY);

                if (boardCell == null)
                {
                    continue;
                }

                boardCell.IsOccupied = true;

                boardCell.View.SetOccupiedVisual(true);
            }
            scoreManager.AddPlacementScore(
                blockData.Cells.Length);
            LineDetectionResult result =
                lineDetector.DetectCompletedLines();

            if (result.HasAnyLines)
            {
                int clearedLines =
                    result.CompletedRows.Count +
                    result.CompletedColumns.Count;

                scoreManager.AddLineClearScore(
                    clearedLines);

                ClearLines(result);

                Debug.Log(
                    $"Cleared Rows:{result.CompletedRows.Count} " +
                    $"Columns:{result.CompletedColumns.Count}");
            }
        }

        private void ClearLines(
            LineDetectionResult result)
        {
            ClearRows(result);

            ClearColumns(result);
        }

        private void ClearRows(
            LineDetectionResult result)
        {
            foreach (int row in result.CompletedRows)
            {
                for (int x = 0;
                    x < AppConstants.BoardWidth;
                    x++)
                {
                    BoardCell cell =
                        GetCell(x, row);

                    if (cell == null)
                    {
                        continue;
                    }

                    cell.IsOccupied = false;

                    cell.View.SetOccupiedVisual(false);
                }
            }
        }

        private void ClearColumns(
            LineDetectionResult result)
        {
            foreach (int column
                in result.CompletedColumns)
            {
                for (int y = 0;
                    y < AppConstants.BoardHeight;
                    y++)
                {
                    BoardCell cell =
                        GetCell(column, y);

                    if (cell == null)
                    {
                        continue;
                    }

                    cell.IsOccupied = false;

                    cell.View.SetOccupiedVisual(false);
                }
            }
        }
    }
}