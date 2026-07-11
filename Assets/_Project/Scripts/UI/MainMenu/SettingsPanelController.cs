using UnityEngine;
using UnityEngine.UI;

using BlockPuzzle.Core.Bootstrap;

namespace BlockPuzzle.UI.MainMenu
{
    public sealed class SettingsPanelController : MonoBehaviour
    {
        [SerializeField]
        private Toggle musicToggle;

        [SerializeField]
        private Toggle sfxToggle;

        [SerializeField]
        private Toggle hapticsToggle;

        [SerializeField]
        private Button closeButton;

        private void Start()
        {
            musicToggle.isOn =
                GameRoot.Instance.SettingsService.MusicEnabled;

            sfxToggle.isOn =
                GameRoot.Instance.SettingsService.SfxEnabled;

            hapticsToggle.isOn =
                GameRoot.Instance.SettingsService.HapticsEnabled;

            musicToggle.onValueChanged.AddListener(OnMusicChanged);
            sfxToggle.onValueChanged.AddListener(OnSfxChanged);
            hapticsToggle.onValueChanged.AddListener(OnHapticsChanged);

            closeButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            musicToggle.onValueChanged.RemoveListener(OnMusicChanged);
            sfxToggle.onValueChanged.RemoveListener(OnSfxChanged);
            hapticsToggle.onValueChanged.RemoveListener(OnHapticsChanged);

            closeButton.onClick.RemoveListener(Hide);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnMusicChanged(bool value)
        {
            GameRoot.Instance.SettingsService.SetMusicEnabled(value);
        }

        private void OnSfxChanged(bool value)
        {
            GameRoot.Instance.SettingsService.SetSfxEnabled(value);
        }

        private void OnHapticsChanged(bool value)
        {
            GameRoot.Instance.SettingsService.SetHapticsEnabled(value);
        }
    }
}