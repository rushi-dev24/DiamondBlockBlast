using System.Collections.Generic;
using UnityEngine;
using BlockPuzzle.Gameplay.GameOver;

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

        [SerializeField]
        private GameOverManager gameOverManager;

        private readonly List<BlockView> activeBlocks = new();

        [SerializeField]
        private GameOverDetector gameOverDetector;

        private void Start()
        {
            GenerateTray();
        }

        public void GenerateTray()
        {
            Debug.Log("GENERATE TRAY");
            ClearTray();

            for (int i = 0; i < 3; i++)
            {
                CreateRandomBlock();
            }
            Debug.Log("CHECKING GAME OVER");
            CheckForGameOver();
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
        public BlockData[] GetCurrentTrayBlocks()
        {
            BlockData[] blocks =
                new BlockData[activeBlocks.Count];

            for (int i = 0;
                i < activeBlocks.Count;
                i++)
            {
                if (activeBlocks[i] != null)
                {
                    blocks[i] =
                        activeBlocks[i].BlockData;
                }
            }

            return blocks;
        }
       private void CheckForGameOver()
        {
            if (gameOverDetector == null)
            {
                Debug.LogError(
                    "BlockTrayManager: GameOverDetector missing.");

                return;
            }

            BlockData[] trayBlocks =
                GetCurrentTrayBlocks();

            bool hasValidMove =
                gameOverDetector.HasAnyValidMove(
                    trayBlocks);

            if (hasValidMove)
            {
                Debug.Log(
                    "Game continues. Valid move exists.");

                return;
            }

            Debug.Log(
                "No valid moves available. GAME OVER.");

            gameOverManager.TriggerGameOver();
        }
    }
}