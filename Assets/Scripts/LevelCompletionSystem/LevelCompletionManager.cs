using Project.Assets.Scripts.LevelCompletionSystem;
using Project.ExtensionMethods;
using Project.InputSystem;
using Project.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project.LevelCompletionSystem
{
    public class LevelCompletionManager : MonoBehaviour
    {
        private List<LevelCompletionField> levelCompletionFields = new List<LevelCompletionField>();

        [SerializeField]
        private SceneConfig sceneConfig;

        public void Register(LevelCompletionField field) => levelCompletionFields.Add(field);
        public void Unregister(LevelCompletionField field) => levelCompletionFields.Add(field);

        public void TryCompleteLevel()
        {
            if (levelCompletionFields.All(f => f.IsPlayerOnField())) // if both fields contain a player
            {
                LoadNextScene();
            }
        }

        private void LoadNextScene()
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            var currentSceneIndex = sceneConfig.SceneNamesInRightOrder.IndexOf(currentSceneName);
            var nextSceneName = sceneConfig.SceneNamesInRightOrder[currentSceneIndex + 1];
            SceneManager.LoadScene(nextSceneName);

        }
    }
}
