using System.Collections.Generic;
using UnityEngine;

namespace BlockPuzzle.Gameplay.Blocks
{
    [CreateAssetMenu(
        fileName = "BlockDatabase",
        menuName = "Block Puzzle/Blocks/Block Database")]
    public sealed class BlockDatabase : ScriptableObject
    {
        [SerializeField]
        private List<BlockData> blocks = new();

        public IReadOnlyList<BlockData> Blocks => blocks;
    }
}