using TMPro;
using UnityEngine;
using UnityEngine.UI;

using BlockPuzzle.Core.Bootstrap;

namespace BlockPuzzle.UI.MainMenu
{
    public sealed class MainMenuController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Button settingsButton;

        [Header("Settings")]
        [SerializeField]
        private SettingsPanelController settingsPanel;

        [Header("Texts")]
        [SerializeField]
        private TMP_Text highScoreText;

        [SerializeField]
        private TMP_Text playerLevelText;

        [SerializeField]
        private TMP_Text versionText;

        private void Start()
        {
            RefreshUI();

            playButton.onClick.AddListener(OnPlayClicked);
            settingsButton.onClick.AddListener(OnSettingsClicked);

            settingsPanel.Hide();
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveListener(OnPlayClicked);
            settingsButton.onClick.RemoveListener(OnSettingsClicked);
        }

        private void RefreshUI()
        {
            highScoreText.text =
                $"High Score: {GameRoot.Instance.SaveService.Data.HighScore}";

            playerLevelText.text =
                $"Level: {GameRoot.Instance.ProgressionService.CurrentLevel}";

            versionText.text =
               $"Version {Core.Constants.GameVersion.Version}";
        }

        private void OnPlayClicked()
        {
            GameRoot.Instance.SceneService.LoadGameplay();
        }

        private void OnSettingsClicked()
        {
            settingsPanel.Show();
        }
    }
}