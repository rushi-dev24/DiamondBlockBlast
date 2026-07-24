using UnityEngine;
using UnityEngine.EventSystems;
using BlockPuzzle.Gameplay.Board;

namespace BlockPuzzle.Gameplay.Blocks
{
    public sealed class BlockView :
        MonoBehaviour,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler
    {
        [SerializeField]
        private BlockVisualCell visualCellPrefab;

        [SerializeField]
        private Transform cellParent;

        [SerializeField]
        private float cellSize = 50f;

        private RectTransform rectTransform;
        private Canvas canvas;
        private CanvasGroup canvasGroup;

        private Vector2 originalPosition;

        private BoardHoverService hoverService;

        private BoardManager boardManager;

        private BlockTrayManager trayManager;

        private BlockData blockData;

        public BlockData BlockData =>
            blockData;
        
        private void Awake()
        {
            
            rectTransform = GetComponent<RectTransform>();

            canvas = GetComponentInParent<Canvas>();

            canvasGroup =
                GetComponent<CanvasGroup>();

            if (canvasGroup == null)
            {
                canvasGroup =
                    gameObject.AddComponent<CanvasGroup>();
            }
            hoverService =
                FindFirstObjectByType<BoardHoverService>();
            boardManager =
                FindFirstObjectByType<BoardManager>();
            trayManager =
                FindFirstObjectByType<BlockTrayManager>();
        }

        public void Initialize(BlockData blockData)
        {
            this.blockData = blockData;
            
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

        public void OnBeginDrag(
            PointerEventData eventData)
        {
            originalPosition =
                rectTransform.anchoredPosition;

            canvasGroup.blocksRaycasts = false;
        }

            public void OnDrag(
                PointerEventData eventData)
            {
                rectTransform.anchoredPosition +=
                    eventData.delta / canvas.scaleFactor;

                hoverService?.UpdateHover(
                    eventData,
                    BlockData);
            }

            public void OnEndDrag(
                PointerEventData eventData)
            {
                canvasGroup.blocksRaycasts = true;

                if (hoverService != null &&
                    hoverService.HasValidPlacement &&
                    hoverService.CurrentHoveredCell != null)
                {
                    BoardCellView hoveredCell =
                        hoverService.CurrentHoveredCell;

                    boardManager.PlaceBlock(
                        BlockData,
                        hoveredCell.X,
                        hoveredCell.Y);

                    hoverService.ClearCurrentHover();

                    trayManager?.NotifyBlockUsed(this);

                    Destroy(gameObject);

                    return;
                }

                hoverService?.ClearCurrentHover();

                rectTransform.anchoredPosition =
                    originalPosition;
            }

        private void Clear()
        {
            for (int i = cellParent.childCount - 1; i >= 0; i--)
            {
                Destroy(
                    cellParent.GetChild(i).gameObject);
            }
        }
    }
}