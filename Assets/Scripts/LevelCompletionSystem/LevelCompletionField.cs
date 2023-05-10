using Project.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.LevelCompletionSystem
{
    public class LevelCompletionField : MonoBehaviour
    {
        [Inject]
        private CollisionManager collisionManager;

        [Inject]
        private LevelCompletionManager levelCompletionManager;

        private void Awake()
        {
            levelCompletionManager.Register(this);
        }

        private void OnDestroy()
        {
            levelCompletionManager.Unregister(this);
        }

        public bool IsPlayerOnField() => collisionManager.IsPlayerOnTile(transform.position);
    }
}
