using Project.InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using TMPro;
using Zenject;

namespace Project.RhythmSystem
{
    public class RhythmManager : MonoBehaviour
    {
        [Space]
        [SerializeField, Header("Beat Settings")]
        private float maxAllowedBeatDifference;

        [Inject]
        private PenaltyRewardManager penaltyRewardManager;

        private float bpm;
        private float timeSinceLastBeat;
        private InputActions inputActions;

        public float TimeToBeat => 60f / bpm;
        private float TimeToLastBeat => Time.time - timeSinceLastBeat;

        public event Action onBeat;
        public event Action onBeatUsed;


        public void StartRhythm(float bpm)
        {
            this.bpm = bpm;
            InvokeRepeating("Beat", 0, TimeToBeat);
        }

        private void Beat()
        {
            timeSinceLastBeat = Time.time;
            onBeat?.Invoke();
        }

        public bool IsOnBeat(bool useBeat = true)
        {
            bool isOnBeat = (TimeToLastBeat <= maxAllowedBeatDifference || TimeToBeat - TimeToLastBeat <= maxAllowedBeatDifference);
            if(useBeat)
            {
                if(isOnBeat)
                {
                    onBeatUsed?.Invoke();
                }
                else
                {
                    penaltyRewardManager.Penalize(); // Penalization logic like end of combo
                }
            }

            return isOnBeat;
        }
    }
}