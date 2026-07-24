using TMPro;
using UnityEngine;
using UnityEngine.UI;

using BlockPuzzle.Core.Bootstrap;
using BlockPuzzle.Gameplay.Score;
using BlockPuzzle.Gameplay.GameOver;

namespace BlockPuzzle.UI.GameOver
{
    public sealed class GameOverPanelController : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField]
        private TMP_Text finalScoreText;

        [SerializeField]
        private TMP_Text highScoreText;

        [Header("Buttons")]
        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private Button mainMenuButton;

        [Header("References")]
        [SerializeField]
        private ScoreManager scoreManager;

        [SerializeField]
        private GameOverManager gameOverManager;

        private void Start()
        {
            restartButton.onClick.AddListener(
                gameOverManager.RestartGame);

            mainMenuButton.onClick.AddListener(
                gameOverManager.ReturnToMenu);
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(
                gameOverManager.RestartGame);

            mainMenuButton.onClick.RemoveListener(
                gameOverManager.ReturnToMenu);
        }

        public void Refresh()
        {
            Debug.Log($"FinalScoreText = {finalScoreText}");
            Debug.Log($"HighScoreText = {highScoreText}");
            Debug.Log($"ScoreManager = {scoreManager}");
            Debug.Log($"GameRoot = {GameRoot.Instance}");

            finalScoreText.text =
                $"Score: {scoreManager.CurrentScore}";

            highScoreText.text =
                $"High Score: {GameRoot.Instance.SaveService.Data.HighScore}";
        }
    }
}