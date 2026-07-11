using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardHoverService : MonoBehaviour
    {
        private BoardCellView currentHoveredCell;

        public void UpdateHover(PointerEventData eventData)
        {
            ClearCurrentHover();

            PointerEventData pointerData =
                new PointerEventData(EventSystem.current);

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

                currentHoveredCell.Highlight();

                return;
            }
        }

        public void ClearCurrentHover()
        {
            if (currentHoveredCell == null)
            {
                return;
            }

            currentHoveredCell.ClearHighlight();

            currentHoveredCell = null;
        }
    }
}