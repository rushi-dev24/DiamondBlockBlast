using UnityEngine;

using BlockPuzzle.Core.Bootstrap;

namespace BlockPuzzle.Services.Settings
{
    public sealed class SettingsService : MonoBehaviour
    {
        public bool MusicEnabled =>
            GameRoot.Instance.SaveService.Data.MusicEnabled;

        public bool SfxEnabled =>
            GameRoot.Instance.SaveService.Data.SfxEnabled;

        public bool HapticsEnabled =>
            GameRoot.Instance.SaveService.Data.HapticsEnabled;

        public void SetMusicEnabled(bool value)
        {
            GameRoot.Instance.SaveService.Data.MusicEnabled = value;

            GameRoot.Instance.SaveService.Save();
        }

        public void SetSfxEnabled(bool value)
        {
            GameRoot.Instance.SaveService.Data.SfxEnabled = value;

            GameRoot.Instance.SaveService.Save();
        }

        public void SetHapticsEnabled(bool value)
        {
            GameRoot.Instance.SaveService.Data.HapticsEnabled = value;

            GameRoot.Instance.SaveService.Save();
        }
    }
}