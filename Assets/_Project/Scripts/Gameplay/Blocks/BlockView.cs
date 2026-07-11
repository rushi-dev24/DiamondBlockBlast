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

        public void Initialize(BlockData blockData)
        {
            Clear();

            foreach (var cell in blockData.Cells)
            {
                BlockVisualCell visualCell =
                    Instantiate(
                        visualCellPrefab,
                        cellParent);

                RectTransform rect =
                    visualCell.GetComponent<RectTransform>();

                rect.anchoredPosition =
                    new Vector2(
                        cell.X * cellSize,
                        cell.Y * cellSize);
            }
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