using UnityEngine;

using BlockPuzzle.Services.Save;
using BlockPuzzle.Services.Audio;
using BlockPuzzle.Services.Settings;
using BlockPuzzle.Services.Progression;
using BlockPuzzle.Services.SceneManagement;
using BlockPuzzle.Systems.Themes;

namespace BlockPuzzle.Core.Bootstrap
{
    public sealed class GameRoot : MonoBehaviour
    {
        private static GameRoot instance;

        [SerializeField]
        private SaveService saveService;

        [SerializeField]
        private AudioService audioService;

        [SerializeField]
        private ThemeService themeService;

        [SerializeField]
        private SettingsService settingsService;

        [SerializeField]
        private ProgressionService progressionService;

        [SerializeField]
        private SceneService sceneService;

        public static GameRoot Instance => instance;

        public SaveService SaveService => saveService;

        public AudioService AudioService => audioService;

        public ThemeService ThemeService => themeService;

        public SettingsService SettingsService => settingsService;

        public ProgressionService ProgressionService => progressionService;

        public SceneService SceneService => sceneService;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            themeService.Initialize();
        }
    }
}