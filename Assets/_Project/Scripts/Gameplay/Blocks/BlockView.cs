using UnityEngine;

namespace BlockPuzzle.Gameplay.Blocks
{
    public sealed class BlockView : MonoBehaviour
    {
        [SerializeField]
        private BlockVisualCell visualCellPrefab;

        [SerializeField]
        private Transform cellParent;

        [SerializeField]
        private float cellSize = 50f;

        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void Initialize(BlockData blockData)
        {
            Clear();

            int maxX = 0;
            int maxY = 0;

            foreach (var cell in blockData.Cells)
            {
                BlockVisualCell visualCell =
                    Instantiate(
                        visualCellPrefab,
                        cellParent);

                RectTransform cellRect =
                    visualCell.GetComponent<RectTransform>();

                cellRect.anchoredPosition =
                    new Vector2(
                        cell.X * cellSize,
                        cell.Y * cellSize);

                if (cell.X > maxX)
                {
                    maxX = cell.X;
                }

                if (cell.Y > maxY)
                {
                    maxY = cell.Y;
                }
            }

            rectTransform.sizeDelta =
                new Vector2(
                    (maxX + 1) * cellSize,
                    (maxY + 1) * cellSize);
        }

        private void Clear()
        {
            for (int i = cellParent.childCount - 1; i >= 0; i--)
            {
                Destroy(cellParent.GetChild(i).gameObject);
            }
        }
    }
}