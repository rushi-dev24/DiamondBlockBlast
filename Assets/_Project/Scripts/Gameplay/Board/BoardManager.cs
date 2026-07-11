using UnityEngine;

using BlockPuzzle.Core.Constants;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardManager : MonoBehaviour
    {
        [SerializeField]
        private BoardCellView cellPrefab;

        [SerializeField]
        private Transform cellParent;

        private BoardCell[,] cells;

        private void Start()
        {
            GenerateBoard();
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
                    cells[x, y] = new BoardCell(x, y);

                    Instantiate(
                        cellPrefab,
                        cellParent);
                }
            }
        }
    }
}