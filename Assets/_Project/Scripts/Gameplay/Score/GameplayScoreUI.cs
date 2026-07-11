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

        private void Update()
        {
            scoreText.text =
                $"Score: {scoreManager.CurrentScore}";
        }
    }
}