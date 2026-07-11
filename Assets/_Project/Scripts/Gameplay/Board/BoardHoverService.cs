using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using BlockPuzzle.Gameplay.Blocks;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardHoverService : MonoBehaviour
    {
        [SerializeField]
        private BoardManager boardManager;

        [SerializeField]
        private BoardPlacementValidator placementValidator;

        private readonly List<BoardCellView> previewCells =
            new();

        private BoardCellView currentHoveredCell;

        public BoardCellView CurrentHoveredCell =>
            currentHoveredCell;

        public bool HasValidPlacement { get; private set; }

        public void UpdateHover(
            PointerEventData eventData,
            BlockData blockData)
        {
            ClearPreview();

            PointerEventData pointerData =
                new PointerEventData(
                    EventSystem.current);

            pointerData.position =
                eventData.position;

            List<RaycastResult> results =
                new();

            EventSystem.current.RaycastAll(
                pointerData,
                results);

            foreach (RaycastResult result in results)
            {
                BoardCellView cell =
                    result.gameObject
                        .GetComponent<BoardCellView>();

                if (cell == null)
                {
                    continue;
                }

                currentHoveredCell = cell;

                HasValidPlacement =
                    placementValidator.CanPlaceBlock(
                        blockData,
                        cell.X,
                        cell.Y);

                bool valid = HasValidPlacement;

                foreach (BlockCellPosition shapeCell
                    in blockData.Cells)
                {
                    BoardCell boardCell =
                        boardManager.GetCell(
                            cell.X + shapeCell.X,
                            cell.Y - shapeCell.Y);

                    if (boardCell == null)
                    {
                        continue;
                    }

                    if (valid)
                    {
                        boardCell.View.ShowValidPreview();
                    }
                    else
                    {
                        boardCell.View.ShowInvalidPreview();
                    }

                    previewCells.Add(
                        boardCell.View);
                }

                return;
            }
        }

        public void ClearCurrentHover()
        {
            currentHoveredCell = null;

            HasValidPlacement = false;

            ClearPreview();
        }

        private void ClearPreview()
        {
            foreach (BoardCellView view
                in previewCells)
            {
                if (view != null)
                {
                    view.ClearHighlight();
                }
            }

            previewCells.Clear();
        }
    }
}