using UnityEngine;
using UnityEngine.UI;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardCellView : MonoBehaviour
    {
        [SerializeField]
        private Image backgroundImage;

        private Color defaultColor;

        public int X { get; private set; }

        public int Y { get; private set; }

        private void Awake()
        {
            defaultColor = backgroundImage.color;
        }

        public void Initialize(
            int x,
            int y)
        {
            X = x;
            Y = y;
        }

        public void SetColor(Color color)
        {
            backgroundImage.color = color;
        }

        public void Highlight()
        {
            backgroundImage.color = Color.yellow;
        }

        public void ClearHighlight()
        {
            backgroundImage.color = defaultColor;
        }

        public void SetOccupiedVisual(bool occupied)
{
    backgroundImage.color =
        occupied
            ? Color.blue
            : defaultColor;
}
        public void ShowValidPreview()
        {
            backgroundImage.color = Color.green;
        }

        public void ShowInvalidPreview()
        {
            backgroundImage.color = Color.red;
        }
    }
}