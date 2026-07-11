using UnityEngine;
using UnityEngine.SceneManagement;

using BlockPuzzle.Core.Scenes;

namespace BlockPuzzle.Services.SceneManagement
{
    public sealed class SceneService : MonoBehaviour
    {
        public string ActiveSceneName =>
            SceneManager.GetActiveScene().name;

        public void LoadMainMenu()
        {
            LoadScene(SceneId.MainMenu);
        }

        public void LoadGameplay()
        {
            LoadScene(SceneId.Gameplay);
        }

        public void LoadBootstrap()
        {
            LoadScene(SceneId.Bootstrap);
        }

        public void LoadScene(string sceneName)
        {
            if (string.IsNullOrWhiteSpace(sceneName))
            {
                Debug.LogError("Scene name is invalid.");
                return;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}