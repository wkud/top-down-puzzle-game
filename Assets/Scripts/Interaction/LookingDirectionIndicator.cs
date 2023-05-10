using DG.Tweening;
using Project.Players;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
    public class LookingDirectionIndicator : MonoBehaviour
    {
        [SerializeField]
        private Sprite icon;

        [SerializeField]
        private float offsetRangeFromCharacter = 1;

        [Range(0f, 1f)]
        [SerializeField]
        private float dotweenDuration;

        [SerializeField]
        private Player player;

        private Vector3 targetPosition => player.LookingDirection * offsetRangeFromCharacter;
        private bool shouldBeFlipped => player.LookingDirection.x > 0; // it should be flipped only if player is looking right
        private bool isFlipped = false; 

        private void OnValidate()
        {
            GetComponent<SpriteRenderer>().sprite = icon;
        }

        private void Awake()
        {
            GetComponent<SpriteRenderer>().sprite = icon;
            UpdateIndicatorLocation(player.LookingDirection);

            player.OnLookingDirectionChanged += UpdateIndicatorLocation;
        }

        private void OnDestroy()
        {
            player.OnLookingDirectionChanged -= UpdateIndicatorLocation;
        }

        private void UpdateIndicatorLocation(Vector3 lookingDirection)
        {
            DOTween.To(() => transform.localPosition, (value) => transform.localPosition = value, targetPosition, dotweenDuration);

            if (isFlipped != shouldBeFlipped)
            {
                transform.DOScaleX(-1 * transform.localScale.x, dotweenDuration);
                isFlipped = shouldBeFlipped;
            }
        }
    }
}
