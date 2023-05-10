using Project.ExtensionMethods;
using Project.InputSystem;
using Project.LevelCompletionSystem;
using Project.Movement;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using InputActions = Project.InputSystem.InputActions;

namespace Project.Players
{
    public abstract class Player : MonoBehaviour, ICollider
    {
        [Inject]
        private CollisionManager collisionManager;

        public InputActions inputActions;
        public event Action<Vector3> OnLookingDirectionChanged;

        public Vector3 LookingDirection { get; private set; } = Vector3.down;

        public Vector3Int ColliderPosition => transform.position.ToVector3Int();

        protected Vector3 InteractionTilePosition => transform.position + LookingDirection;


        public bool IsColliderEnabled { get; private set; } = true;

        public GameObject GameObject => gameObject;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            inputActions = new InputActions();
            inputActions.Main.Enable();

            collisionManager.RegisterCollider(this);
            GetInteractInputAction().performed += OnInteract;
        }

        private void OnDestroy()
        {
            collisionManager.UnregisterCollider(this);
            GetInteractInputAction().performed -= OnInteract;
        }

        private void UpdateSpriteFlip()
        {
            if(LookingDirection == Vector3.right)
                spriteRenderer.flipX = false;
            else if(LookingDirection == Vector3.left)
                spriteRenderer.flipX = true;
        }

        public void SetLookingDirection(Vector3 lookingDirection)
        {
            LookingDirection = lookingDirection;
            OnLookingDirectionChanged.Invoke(lookingDirection);
            UpdateSpriteFlip();
        }

        protected abstract void OnInteract(InputAction.CallbackContext context);


        protected T FindIteractableItem<T>() where T : MonoBehaviour, ICollider
        {
            var item = collisionManager.GetItemOnTile<T>(InteractionTilePosition);
            return item;
        }

        public InputAction GetMoveInputAction() => GetType() == typeof(PriestDetective) ? inputActions.Main.MovePlayer1 : inputActions.Main.MovePlayer2;
        public InputAction GetInteractInputAction() => GetType() == typeof(PriestDetective) ? inputActions.Main.InteractPlayer1 : inputActions.Main.InteractPlayer2;
    }

}