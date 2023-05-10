using Project.Detective;
using Project.PickupSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Players
{
    public class PriestDetective : Player
    {

        protected override void OnInteract(InputAction.CallbackContext context)
        {
            var fakeWall = FindIteractableItem<FakeWall>();
            if (fakeWall == null)
            {
                return;
            }

            fakeWall.OnBeingInspected();
        }
    }
}