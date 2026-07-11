using UnityEngine;

using BlockPuzzle.Gameplay.Blocks;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardPlacementValidator : MonoBehaviour
    {
        [SerializeField]
        private BoardManager boardManager;

        public bool CanPlaceBlock(
            BlockData blockData,
            int originX,
            int originY)
        {
            foreach (BlockCellPosition shapeCell in blockData.Cells)
            {
                int boardX = originX + shapeCell.X;
                int boardY = originY - shapeCell.Y;

                BoardCell boardCell =
                    boardManager.GetCell(
                        boardX,
                        boardY);

                if (boardCell == null)
                {
                    return false;
                }

                if (boardCell.IsOccupied)
                {
                    return false;
                }
            }

            return true;
        }
    }
}