using Project.ExtensionMethods;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Project.TilemapSystem
{
    public class TilemapManager : MonoBehaviour
    {
        [SerializeField]
        private Tilemap walkableTilemap;

        [SerializeField]
        private Tilemap nonWalkableTilemap;

        private readonly Dictionary<Vector3Int, FillFloorPickupItem> pickupableItemsOnTilemap = new Dictionary<Vector3Int, FillFloorPickupItem>();

        public bool IsGround(Vector3 position)
        {
            var tilePosition = position.ToVector3Int();
            var isGroundThere = walkableTilemap.GetTile(tilePosition) != null;
            var isWallThere = nonWalkableTilemap.GetTile(tilePosition) != null;

            return isGroundThere && !isWallThere; // there is a ground && there is no wall
        }

        public void LayItemOnFloor(Vector3Int tilePosition, FillFloorPickupItem pickupItem)
        {
            walkableTilemap.SetTile(tilePosition, pickupItem.ItemAsFloorTile);
            pickupableItemsOnTilemap.Add(tilePosition, pickupItem);
        }


        public FillFloorPickupItem TakePickupItemFromFloor(Vector3Int tilePosition)
        {
            var item = pickupableItemsOnTilemap[tilePosition];
            
            walkableTilemap.SetTile(tilePosition, null);
            pickupableItemsOnTilemap.Remove(tilePosition);

            return item;
        }
    }
}