using UnityEngine;

using BlockPuzzle.Core.Bootstrap;

namespace BlockPuzzle.Services.Progression
{
    public sealed class ProgressionService : MonoBehaviour
    {
        public int CurrentLevel =>
            GameRoot.Instance.SaveService.Data.PlayerLevel;

        public int TotalLifetimeScore =>
            GameRoot.Instance.SaveService.Data.TotalLifetimeScore;

        public int RequiredScoreForNextLevel =>
            CurrentLevel * 1000;

        public void AddLifetimeScore(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            var saveData = GameRoot.Instance.SaveService.Data;

            saveData.TotalLifetimeScore += amount;

            RecalculateLevel();

            GameRoot.Instance.SaveService.Save();
        }

        private void RecalculateLevel()
        {
            var saveData = GameRoot.Instance.SaveService.Data;

            int calculatedLevel =
                Mathf.Max(1, (saveData.TotalLifetimeScore / 1000) + 1);

            saveData.PlayerLevel = calculatedLevel;
        }
    }
}