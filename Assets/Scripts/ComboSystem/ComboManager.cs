using System;
using System.Collections.Generic;
using UnityEngine;
using Project.RhythmSystem;
using Project.AudioSystem.Knapik;
using Zenject;

namespace Project.ComboSystem
{
    public class ComboManager : MonoBehaviour
    {
        private int currentCombo;

        private int highestCombo;

        [Inject]
        private RhythmManager rhythmManager;

        [Inject]
        private KnapikManager knapikManager;

        public event Action<int> onComboChanged;

        private void OnEnable()
        {
            rhythmManager.onBeatUsed += AddCombo;
        }

        private void OnDisable()
        {
            rhythmManager.onBeatUsed -= AddCombo;
        }

        private void AddCombo()
        {
            currentCombo++;
            onComboChanged?.Invoke(currentCombo);
            if(currentCombo > highestCombo)
            {
                highestCombo = currentCombo;
                PlayerPrefs.SetInt("Highest Combo", highestCombo);
            }

            switch(currentCombo)
            {
                case 10:
                    knapikManager.PlayKochamCie();
                    break;

                case 20:
                    knapikManager.PlayRamPamPam();
                    break;

                case 30:
                    knapikManager.PlayNasiFaniTancza();
                    break;
            }
        }

        public void ResetCombo()
        {
            currentCombo = 0;
            onComboChanged.Invoke(0);
        }
    }
}
