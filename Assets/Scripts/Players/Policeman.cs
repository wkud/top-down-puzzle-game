using Project.Movement;
using Project.PickupSystem;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Players
{
    public class Policeman : Player
    {
        private PickupItem pickedUpItem;

        protected override void OnInteract(InputAction.CallbackContext context)
        {
            if (pickedUpItem == null)
            {
                var item = FindIteractableItem<PickupItem>();
                if (item == null)
                {
                    return;
                }

                item.OnBeingPickedUp(this);
                pickedUpItem = item;
            }
            else
            {
                pickedUpItem.OnBeingDropedDown(InteractionTilePosition);
                pickedUpItem = null;
            }
        }
    }
}