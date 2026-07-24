using UnityEngine;

using BlockPuzzle.Core.Constants;
using BlockPuzzle.Gameplay.Blocks;
using BlockPuzzle.Gameplay.Board;

namespace BlockPuzzle.Gameplay.GameOver
{
    public sealed class GameOverDetector : MonoBehaviour
    {
        [SerializeField]
        private BoardPlacementValidator placementValidator;

        [SerializeField]
        private BoardManager boardManager;

        public bool HasAnyValidMove(
            BlockData[] trayBlocks)
        {
            Debug.Log("HAS ANY VALID MOVE");
            if (!boardManager.IsInitialized)
            {
                Debug.LogWarning(
                    "GameOverDetector: Board not initialized yet.");
                Debug.Log("VALID MOVE FOUND");
                return true;
            }
            if (trayBlocks == null ||
                trayBlocks.Length == 0)
            {
                Debug.Log("NO VALID MOVES FOUND");
                return false;
            }

            foreach (BlockData blockData
                in trayBlocks)
            {
                if (blockData == null)
                {
                    continue;
                }

                if (CanPlaceAnywhere(blockData))
                {
                    Debug.Log("VALID MOVE FOUND");
                    return true;
                }
            }
            Debug.Log("NO VALID MOVES FOUND");
            return false;
        }

        private bool CanPlaceAnywhere(
            BlockData blockData)
        {
            for (int y = 0;
                y < AppConstants.BoardHeight;
                y++)
            {
                for (int x = 0;
                    x < AppConstants.BoardWidth;
                    x++)
                {
                    if (placementValidator
                        .CanPlaceBlock(
                            blockData,
                            x,
                            y))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}