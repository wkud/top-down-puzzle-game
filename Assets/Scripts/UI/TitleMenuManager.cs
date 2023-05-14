using UnityEngine;
using UnityEngine.SceneManagement;
using Project.Assets.Scripts.LevelCompletionSystem;
using Project.AudioSystem.Knapik;
using UnityEditor;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    public class TitleMenuManager : MonoBehaviour
    {
        [SerializeField] private SceneConfig sceneConfig;

        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        [Inject] private KnapikManager knapikManager;

        private void Awake()
        {
            playButton.onClick.AddListener(LoadFirstLevel);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveListener(LoadFirstLevel);
            quitButton.onClick.RemoveListener(QuitGame);
        }

        private void LoadFirstLevel()
        {
            var firstScene = sceneConfig.SceneNamesInRightOrder[0];
            SceneManager.LoadScene(firstScene);
        }

        private void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}