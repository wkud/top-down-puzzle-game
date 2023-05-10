using Project.RhythmSystem;
using Project.ComboSystem;
using Project.AudioSystem.Knapik;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project
{
    public class PenaltyRewardManager : MonoBehaviour
    {
        [SerializeField]
        private HealthBar healthBar;

        [SerializeField]
        private GameObject gameOverPanel;

        [Inject]
        private ComboManager comboManager;
        [Inject]
        private KnapikManager knapikManager;

        private void Awake()
        {
            gameOverPanel.SetActive(false);

            healthBar.OnDeath += OnDeath;
        }

        private void OnDestroy()
        {
            healthBar.OnDeath -= OnDeath;
        }

        public void Penalize()
        {
            healthBar.ApplyPenalty();
            comboManager.ResetCombo();
        }

        public void Reward()
        {
            healthBar.ApplyReward();
        }

        private void OnDeath()
        {
            gameOverPanel.SetActive(true);
            knapikManager.PlayPowiedzJakMozeszStac();
        }

    }
}
