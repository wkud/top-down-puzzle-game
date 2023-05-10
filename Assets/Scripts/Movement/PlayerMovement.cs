using DG.Tweening;
using Project.ExtensionMethods;
using Project.LevelCompletionSystem;
using Project.Players;
using Project.RhythmSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Project.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string isJumpingAnimationParameter = "isJumping";

        [Range(0, 1)]
        [SerializeField]
        private float jumpForce;

        [Range(0, 1)]
        [SerializeField]
        private float jumpDuration;

        [SerializeField]
        private bool debugUseBeat;

        [Inject]
        private CollisionManager collisionManager;
        [Inject]
        private RhythmManager rhythmManager;
        [Inject]
        private LevelCompletionManager levelCompletionManager;
        [Inject]
        private PenaltyRewardManager penaltyRewardManager;

        private Player player;
        private Animator animator;
        private bool isJumping;
        private event Action onMovementStart;
        private event Action onMovementComplete;

        private void OnValidate()
        {
            if (!debugUseBeat)
            {
                Debug.LogWarning(nameof(PlayerMovement) + $": Make sure to set {nameof(debugUseBeat)} to true after debugging");
            }
        }

        private void Start()
        {
            player = GetComponent<Player>();
            animator = GetComponent<Animator>();
            player.GetMoveInputAction().performed += OnMove;
            onMovementStart += OnStartMoving;
            onMovementComplete += OnFinishMoving;
            onMovementComplete += levelCompletionManager.TryCompleteLevel;
        }

        private void OnDestroy()
        {
            player.GetMoveInputAction().performed -= OnMove;
            onMovementComplete -= levelCompletionManager.TryCompleteLevel;
            onMovementStart -= OnStartMoving;
            onMovementComplete -= OnFinishMoving;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            if (isJumping)
            {
                return;
            }

            var walkingDirection = context.ReadValue<Vector2>().ToVector3();
            var targetPosition = transform.position + walkingDirection;

            var hasLookingDirectionChanged = UpdateLookingDirection(walkingDirection);

            if (collisionManager.IsTileWalkable(targetPosition))
            {
                Move(targetPosition); // no beat penalty (has moves = no collision)
            }
        }

        private void Move(Vector3 targetPosition)
        {
            isJumping = true;
            onMovementStart.Invoke();

            transform.DOJump(targetPosition, jumpForce, 1, jumpDuration).OnComplete(() =>
            {
                isJumping = false;
                transform.position = targetPosition.ToVector3Int().ToVector3();
                onMovementComplete.Invoke();
            });
        }

        private void OnStartMoving()
        {
            animator.SetBool(isJumpingAnimationParameter, true);
        }

        private void OnFinishMoving()
        {
            animator.SetBool(isJumpingAnimationParameter, false);
        }

        private bool UpdateLookingDirection(Vector3 newLookingDirection)
        {
            if (player.LookingDirection == newLookingDirection)
            {
                var hasChanged = false;
                return hasChanged;
            }

            player.SetLookingDirection(newLookingDirection);
            return true;
        }
    }
}
