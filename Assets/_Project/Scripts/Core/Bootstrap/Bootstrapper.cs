using UnityEngine;
using UnityEngine.SceneManagement;

using BlockPuzzle.Core.Constants;

namespace BlockPuzzle.Core.Bootstrap
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(AppConstants.MainMenuScene);
        }
    }
}