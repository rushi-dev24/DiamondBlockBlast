using TMPro;
using UnityEngine;

namespace BlockPuzzle.Gameplay.Score
{
    public sealed class GameplayScoreUI : MonoBehaviour
    {
        [SerializeField]
        private ScoreManager scoreManager;

        [SerializeField]
        private TMP_Text scoreText;

        [SerializeField]
        private TMP_Text highScoreText;

        private void Update()
        {
            scoreText.text =
                $"Score: {scoreManager.CurrentScore}";

            highScoreText.text =
                $"High Score: {scoreManager.HighScore}";
        }
    }
}