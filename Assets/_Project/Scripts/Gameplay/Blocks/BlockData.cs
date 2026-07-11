using UnityEngine;

namespace BlockPuzzle.Gameplay.Blocks
{
    [CreateAssetMenu(
        fileName = "BlockData",
        menuName = "Block Puzzle/Blocks/Block Data")]
    public sealed class BlockData : ScriptableObject
    {
        [Header("Info")]
        public string BlockId;

        [Header("Shape")]
        public BlockCellPosition[] Cells;
    }
}