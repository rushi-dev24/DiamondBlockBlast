using UnityEngine;

namespace BlockPuzzle.Gameplay.Blocks
{
    public sealed class BlockRenderTester : MonoBehaviour
    {
        [SerializeField]
        private BlockView blockView;

        [SerializeField]
        private BlockData testBlock;

        private void Start()
        {
            blockView.Initialize(testBlock);
        }
    }
}