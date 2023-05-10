using Project.ExtensionMethods;
using Project.PickupSystem;
using Project.TilemapSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Zenject;

namespace Project
{
    public class FillFloorPickupItem : PickupItem
    {
        [field: FormerlySerializedAs("tileFormOfThisItem")]
        [field: SerializeField]
        public TileBase ItemAsFloorTile { get; private set; }

        [Inject]
        private TilemapManager tilemapManager;


        public override void OnBeingDropedDown(Vector3 positionToBeDropedDown)
        {
            if (tilemapManager.IsGround(positionToBeDropedDown))
            {
                base.OnBeingDropedDown(positionToBeDropedDown); // item drop on the floor (if floor is on that tile)
            }
            else
            {
                FillFloor(positionToBeDropedDown); // if there is no floor on that tile - put item, to create floor at this tile
            }
        }

        private void FillFloor(Vector3 positionToFill)
        {
            tilemapManager.LayItemOnFloor(positionToFill.ToVector3Int(), this);
            Destroy(gameObject);
        }


    }
}
