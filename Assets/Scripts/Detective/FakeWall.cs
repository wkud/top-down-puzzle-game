using Project.ExtensionMethods;
using Project.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Detective
{
    public class FakeWall : MonoBehaviour, ICollider
    {
        public Vector3Int ColliderPosition => transform.position.ToVector3Int();

        public bool IsColliderEnabled => true;

        public GameObject GameObject => gameObject;

        [Inject]
        private CollisionManager collisionManager;

        private void Start()
        {
            collisionManager.RegisterCollider(this);
        }

        private void OnDestroy()
        {
            collisionManager.UnregisterCollider(this);
        }

        public void OnBeingInspected()
        {
            Destroy(gameObject);
        }
    }
}
