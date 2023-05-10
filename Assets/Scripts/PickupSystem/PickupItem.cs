using DG.Tweening;
using Player = Project.Players.Player;
using System;
using UnityEngine;
using Zenject.SpaceFighter;
using Project.Players;
using UnityEngine.Tilemaps;
using Project.ExtensionMethods;
using Zenject;
using Project.Movement;

namespace Project.PickupSystem
{
    public class PickupItem : MonoBehaviour, ICollider
    {
        [SerializeField]
        private Vector3 offsetFromParentWhenBeingPickedUp;

        [Range(0f, 1f)]
        [SerializeField]
        private float targetScaleWhenBeingPickedUp;
        private const float DEFAULT_SCALE = 1;

        [Range(0f, 1f)]
        [SerializeField]
        private float dotweenMovementDuration;

        [Inject]
        private CollisionManager collisionManager;

        public Vector3Int ColliderPosition => transform.position.ToVector3Int();

        public bool IsColliderEnabled { get; private set; } = true;

        public GameObject GameObject => gameObject;

        private void Awake()
        {
            collisionManager.RegisterCollider(this);
        }

        private void OnDestroy()
        {
            collisionManager.UnregisterCollider(this);
        }

        public virtual void OnBeingPickedUp(Player player)
        {
            IsColliderEnabled = false;

            transform.SetParent(player.transform);
            var targetPosition = transform.parent.position + offsetFromParentWhenBeingPickedUp;

            transform.DOMove(targetPosition, dotweenMovementDuration);
            transform.DOScale(targetScaleWhenBeingPickedUp, dotweenMovementDuration);
        }

        public virtual void OnBeingDropedDown(Vector3 positionToBeDropedDown)
        {
            IsColliderEnabled = true;

            transform.SetParent(null);

            transform.DOMove(positionToBeDropedDown, dotweenMovementDuration);
            transform.DOScale(DEFAULT_SCALE, dotweenMovementDuration);
        }
    }
}