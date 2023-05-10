using System.Collections.Generic;
using UnityEngine;
using Project.AudioSystem;
using DG.Tweening;
using Zenject;

namespace Project.RhythmSystem
{
    public class RhythmIndicator : MonoBehaviour
    {
        [SerializeField, Header("Rhythm Indicator")]
        private RectTransform beatContainer;
        [SerializeField]
        private GameObject beatIndicatorPrefab;
        [SerializeField]
        private int beatIndicatorsAmount;
        [SerializeField]
        private Ease ease;
    
        [Inject]
        private RhythmManager rhythmManager;

        [Inject]
        private SongManager songManager;

        private List<RectTransform> instantiatedBeatIndicators = new List<RectTransform>();
        
        private float indicatorsOffset => beatContainer.rect.width / (beatIndicatorsAmount - 1);

        private void OnEnable()
        {
            rhythmManager.onBeat += MoveIndicators;
        }
        
        private void Start()
        {
            InitializeUI();
            songManager.StartSong();
        }

        private void OnDisable()
        {
            rhythmManager.onBeat -= MoveIndicators;
        }
    
        private void InitializeUI()
        {
            for(int i = 0; i < beatIndicatorsAmount; i++)
            {
                var newBeatIndicator = Instantiate(beatIndicatorPrefab, beatContainer)
                    .GetComponent<RectTransform>();

                instantiatedBeatIndicators.Add(newBeatIndicator);
                Vector2 newPosition = new Vector2(indicatorsOffset * i, 0);
                newBeatIndicator.anchoredPosition = newPosition;
            }
        }

        private void MoveIndicators()
        {
            for(int i = 0; i < beatIndicatorsAmount; i++)
            {
                RectTransform indicator = instantiatedBeatIndicators[i];
                if(i == 0)
                {
                    float durationPerUnit = rhythmManager.TimeToBeat / indicatorsOffset;
                    float unitsToHide = indicator.rect.width / 2;
                    Sequence sequence = DOTween.Sequence();
                    sequence
                        .Append(
                            indicator.DOAnchorPosX(indicator.anchoredPosition.x - unitsToHide, unitsToHide * durationPerUnit)
                                .SetEase(Ease.Linear)
                                .OnComplete(() =>
                                {
                                    indicator.anchoredPosition = new Vector2(beatContainer.rect.width + indicatorsOffset - unitsToHide, 0);
                                })
                        )
                        .Append(
                            indicator.DOAnchorPosX(beatContainer.rect.width, (indicatorsOffset - unitsToHide) * durationPerUnit)
                        )
                        .SetEase(ease);
                }
                else
                {
                    indicator.DOAnchorPosX(indicatorsOffset * (i - 1), rhythmManager.TimeToBeat).SetEase(ease);
                }
            }

            var firstIndicator = instantiatedBeatIndicators[0];
            instantiatedBeatIndicators.RemoveAt(0);
            instantiatedBeatIndicators.Add(firstIndicator);
        }
    }
}