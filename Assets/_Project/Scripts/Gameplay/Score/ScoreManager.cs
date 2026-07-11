using UnityEngine;

using BlockPuzzle.Core.Bootstrap;

namespace BlockPuzzle.Gameplay.Score
{
    public sealed class ScoreManager : MonoBehaviour
    {
        public int CurrentScore { get; private set; }

        public int HighScore =>
            GameRoot.Instance
                .SaveService
                .Data
                .HighScore;

        public void AddPlacementScore(
            int blockCellCount)
        {
            AddScore(blockCellCount);
        }

        public void AddLineClearScore(
            int clearedLineCount)
        {
            AddScore(clearedLineCount * 10);
        }

        private void AddScore(
            int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            CurrentScore += amount;

            UpdateHighScore();
        }

        private void UpdateHighScore()
        {
            if (GameRoot.Instance == null)
            {
                Debug.LogWarning(
                    "GameRoot not found.");

                return;
            }

            if (GameRoot.Instance.SaveService == null)
            {
                Debug.LogWarning(
                    "SaveService not found.");

                return;
            }

            var saveData =
                GameRoot.Instance
                    .SaveService
                    .Data;

            if (CurrentScore <= saveData.HighScore)
            {
                return;
            }

            saveData.HighScore =
                CurrentScore;

            GameRoot.Instance
                .SaveService
                .Save();
        }
    }
}