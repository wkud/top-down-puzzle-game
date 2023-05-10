using Project.ExtensionMethods;
using Project.PickupSystem;
using Project.Players;
using Project.TilemapSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Project.Movement
{
    public class CollisionManager : MonoBehaviour
    {
        [Inject]
        private TilemapManager tilemapManager;

        private List<ICollider> nonTilemapColliders { get; } = new List<ICollider>();

        public void RegisterCollider(ICollider collider) => nonTilemapColliders.Add(collider);

        public void UnregisterCollider(ICollider collider) => nonTilemapColliders.Remove(collider);

        internal bool IsTileWalkable(Vector3 targetPosition)
        {
            var isGround = tilemapManager.IsGround(targetPosition);
            
            var isOccupied = nonTilemapColliders.Any(c => c.ColliderPosition == targetPosition.ToVector3Int() && c.IsColliderEnabled);
            return isGround && !isOccupied;
        }

        public bool IsPlayerOnTile(Vector3 targetPosition)
        {
            var isPlayerOnTile = nonTilemapColliders.Where(c => c is Player).Any(c => c.ColliderPosition == targetPosition.ToVector3Int());
            return isPlayerOnTile;
        }

        internal T GetItemOnTile<T>(Vector3 position) where T : MonoBehaviour
        {
            var collider = nonTilemapColliders.FirstOrDefault(item => item.ColliderPosition == position);
            if (collider == null)
                return null;
            return collider.GameObject.GetComponent<T>();
        }
    }
}