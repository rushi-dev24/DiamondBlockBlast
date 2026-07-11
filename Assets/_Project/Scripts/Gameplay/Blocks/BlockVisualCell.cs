using UnityEngine;
using UnityEngine.UI;

namespace BlockPuzzle.Gameplay.Blocks
{
    public sealed class BlockVisualCell : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public void SetColor(Color color)
        {
            image.color = color;
        }
    }
}