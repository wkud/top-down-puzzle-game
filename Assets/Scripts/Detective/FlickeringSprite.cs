using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Detective
{
    public class FlickeringSprite : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField]
        private float minAlpha;

        [Range(0f, 1f)]
        [SerializeField]
        private float dotweenDuration;

        private float MAX_ALPHA = 1;

        private void Start()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();

            var sequence = DOTween.Sequence();
            sequence.Append(spriteRenderer.DOFade(minAlpha, dotweenDuration));
            sequence.Append(spriteRenderer.DOFade(MAX_ALPHA, dotweenDuration));
            sequence.SetLoops(-1);
        }
    }
}
