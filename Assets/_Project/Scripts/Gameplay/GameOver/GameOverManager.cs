using UnityEngine;
using UnityEngine.SceneManagement;
using BlockPuzzle.Core.Bootstrap;
using BlockPuzzle.Gameplay.Score;

using BlockPuzzle.UI.GameOver;

namespace BlockPuzzle.Gameplay.GameOver
{
    public sealed class GameOverManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverPanel;

        [SerializeField]
        private GameOverPanelController panelController;
        
        [SerializeField]
        private ScoreManager scoreManager;

        public bool IsGameOver { get; private set; }

        private void Start()
        {
            HideGameOver();
        }

        public void TriggerGameOver()
        {
            Debug.Log("TriggerGameOver ENTER");

            if (IsGameOver)
            {
                Debug.Log("Already GameOver");
                return;
            }

            IsGameOver = true;

            Debug.Log("Refreshing Panel");

            if (panelController != null)
            {
                panelController.Refresh();
            }
            else
            {
                Debug.LogError("PanelController NULL");
            }
            Debug.Log(
                $"Panel Active Before = {gameOverPanel.activeSelf}");
            GameRoot.Instance
            .ProgressionService
            .AddLifetimeScore(
                scoreManager.CurrentScore);
            ShowGameOver();
            Debug.Log(
                $"Panel Active After = {gameOverPanel.activeSelf}");

            Debug.Log("Setting TimeScale");

            Time.timeScale = 0f;

            Debug.Log("GAME OVER");
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;

            SceneManager.LoadScene("Gameplay");
        }

        public void ReturnToMenu()
        {
            Time.timeScale = 1f;

            SceneManager.LoadScene("MainMenu");
        }

        private void ShowGameOver()
        {
            gameOverPanel.SetActive(true);

            RectTransform rect =
                gameOverPanel.GetComponent<RectTransform>();

            rect.anchoredPosition = Vector2.zero;
            rect.sizeDelta = new Vector2(800, 800);

            gameOverPanel.transform.SetAsLastSibling();
        }

        private void HideGameOver()
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(false);
            }
        }
    }
}