using System.Collections.Generic;
using UnityEngine;

namespace BlockPuzzle.Gameplay.Blocks
{
    public sealed class BlockTrayManager : MonoBehaviour
    {
        [SerializeField]
        private BlockDatabase blockDatabase;

        [SerializeField]
        private BlockView blockViewPrefab;

        [SerializeField]
        private Transform trayRoot;

        private readonly List<BlockView> activeBlocks = new();

        private void Start()
        {
            GenerateTray();
        }

        public void GenerateTray()
        {
            ClearTray();

            for (int i = 0; i < 3; i++)
            {
                CreateRandomBlock();
            }
        }

        private void CreateRandomBlock()
        {
            int randomIndex =
                Random.Range(
                    0,
                    blockDatabase.Blocks.Count);

            BlockData blockData =
                blockDatabase.Blocks[randomIndex];

            BlockView blockView =
                Instantiate(
                    blockViewPrefab,
                    trayRoot);

            blockView.Initialize(blockData);

            activeBlocks.Add(blockView);
        }

        private void ClearTray()
        {
            foreach (BlockView block in activeBlocks)
            {
                if (block != null)
                {
                    Destroy(block.gameObject);
                }
            }

            activeBlocks.Clear();
        }

        public void NotifyBlockUsed(BlockView blockView)
        {
            if (blockView == null)
            {
                return;
            }

            activeBlocks.Remove(blockView);

            if (activeBlocks.Count == 0)
            {
                GenerateTray();
            }
        }
    }
}