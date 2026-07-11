using System.Collections.Generic;
using UnityEngine;

using BlockPuzzle.Core.Bootstrap;

namespace BlockPuzzle.Systems.Themes
{
    public sealed class ThemeService : MonoBehaviour
    {
        [SerializeField]
        private List<ThemeData> themes = new();

        private ThemeData currentTheme;

        public ThemeData CurrentTheme => currentTheme;

        public void Initialize()
        {
            string themeId =
                GameRoot.Instance
                    .SaveService
                    .Data
                    .SelectedThemeId;

            ThemeData foundTheme =
                themes.Find(theme => theme.ThemeId == themeId);

            if (foundTheme == null && themes.Count > 0)
            {
                foundTheme = themes[0];
            }

            currentTheme = foundTheme;

            if (currentTheme != null)
            {
                Debug.Log(
                    $"Current Theme = {currentTheme.ThemeName}");
            }
        }

        public void SetTheme(ThemeData theme)
        {
            if (theme == null)
            {
                return;
            }

            currentTheme = theme;

            GameRoot.Instance
                .SaveService
                .Data
                .SelectedThemeId = theme.ThemeId;

            GameRoot.Instance
                .SaveService
                .Save();
        }
    }
}