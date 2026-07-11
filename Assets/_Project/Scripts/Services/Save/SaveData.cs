using System;

namespace BlockPuzzle.Services.Save
{
    [Serializable]
    public sealed class SaveData
    {
        public int HighScore;

        public int TotalLifetimeScore = 0;

        public int PlayerLevel = 1;

        public bool MusicEnabled = true;

        public bool SfxEnabled = true;

        public bool HapticsEnabled = true;

        public string SelectedThemeId = "default";
    }
}