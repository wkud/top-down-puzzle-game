using UnityEngine;
using UnityEngine.SceneManagement;
using Project.Assets.Scripts.LevelCompletionSystem;
using Project.AudioSystem.Knapik;
using Zenject;

namespace Project.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private SceneConfig sceneConfig;

        [Inject]
        private KnapikManager knapikManager;

        public void LoadFirstLevel()
        {
            knapikManager.PlayYo();
            var firstScene = sceneConfig.SceneNamesInRightOrder[0];
            SceneManager.LoadScene(firstScene);
        }
    }
}
