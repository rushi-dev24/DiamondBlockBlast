using UnityEngine;
using UnityEngine.UI;

namespace BlockPuzzle.Gameplay.Board
{
    public sealed class BoardCellView : MonoBehaviour
    {
        [SerializeField]
        private Image backgroundImage;

        public void SetColor(Color color)
        {
            backgroundImage.color = color;
        }

        public void SetOccupiedVisual(bool occupied)
        {
            backgroundImage.color =
                occupied
                    ? Color.green
                    : Color.white;
        }
    }
}