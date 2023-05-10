using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Project.UI
{
    public class KeyInfoManager : MonoBehaviour
    {
        [SerializeField] private float scaleMultiplier = 1.2f;
        [SerializeField] private float duration = 0.5f;

        [Header("Restart")]
        [SerializeField] private Button restartButton;
        [SerializeField] private Image restartIcon;

        [SerializeField]
        private bool isRestartGame;

        private void Awake()
        {
            restartButton.onClick.AddListener(RestartLevel);
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(RestartLevel);
        }
        private void RestartLevel()
        {
            if (isRestartGame)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void OnRestartButtonEnter(BaseEventData baseEventData)
        {
            restartIcon.transform.DOScale(restartIcon.transform.localScale * scaleMultiplier, duration);
        }

        public void OnRestartButtonExit(BaseEventData baseEventData)
        {
            restartIcon.transform.DOScale(restartIcon.transform.localScale / scaleMultiplier, duration);
        }
    }
}
