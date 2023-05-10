using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.RhythmSystem
{
    public class HealthBar : MonoBehaviour
    {
        private Slider slider;

        [SerializeField]
        private float decayAmount = 0.01f;

        [SerializeField]
        private float penaltyAmount = 0.05f;

        [SerializeField]
        private float rewardAmount = 0.1f;

        private const float MAX_VALUE = 1;

        private float currentValue = 1;

        public event Action OnDeath;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        public void ApplyReward() => Increase(rewardAmount);

        public void ApplyPenalty() => Decrease(penaltyAmount);

        private void Increase(float value)
        {
            currentValue += value;
            currentValue = Mathf.Min(currentValue, MAX_VALUE);
            UpdateSlider();
        }

        private void Decrease(float value)
        {
            if(currentValue < 0)
            {
                return;
            }

            currentValue -= value;
            UpdateSlider();

            if(currentValue < 0)
            {
                OnDeath?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            Decrease(decayAmount * Time.fixedDeltaTime);
        }

        private void UpdateSlider()
        {
            slider.value = currentValue;
        }
    }
}
