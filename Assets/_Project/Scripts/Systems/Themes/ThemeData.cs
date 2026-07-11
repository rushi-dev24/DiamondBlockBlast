using UnityEngine;

namespace BlockPuzzle.Systems.Themes
{
    [CreateAssetMenu(
        fileName = "ThemeData",
        menuName = "Block Puzzle/Themes/Theme Data")]
    public sealed class ThemeData : ScriptableObject
    {
        [Header("Theme Info")]
        public string ThemeId = "default";

        public string ThemeName = "Default";

        [Header("Board")]
        public Color BoardBackgroundColor = Color.black;

        [Header("Cells")]
        public Color EmptyCellColor = Color.gray;

        [Header("Blocks")]
        public Color BlockColor = Color.cyan;
    }
}