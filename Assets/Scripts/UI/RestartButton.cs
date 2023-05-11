using System;
using System.Linq;
using Project.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Project.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private RestartMode restartMode;


        private InputActions inputActions; // TODO debug


        private void Awake()
        {
            restartButton.onClick.AddListener(Restart);
            inputActions = new InputActions(); // TODO debug
            // inputActions.Main.Beat.performed += DebugMethod; // TODO debug
            // inputActions.Main.Beat.performed += context => Debug.Log("Space"); // TODO debug)
            
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(Restart);
        }

        public void Restart()
        {
            Debug.Log("Restart");
            switch (restartMode)
            {
                case RestartMode.RestartLevel:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                case RestartMode.RestartGame:
                    SceneManager.LoadScene(0);
                    break;
                default:
                    Debug.LogError("Restart mode set to invalid value");
                    break;
            }
        }

        private void DebugMethod(InputAction.CallbackContext callbackContext) // TODO debug
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hits = Physics.RaycastAll(ray);
            var transforms = hits.Select(h => h.transform);
            foreach (var transform1 in transforms)
            {
                Debug.Log(transform1.name);
            }
        }
    }
}