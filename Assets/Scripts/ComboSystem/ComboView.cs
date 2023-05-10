using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

namespace Project.ComboSystem
{
    public class ComboView : MonoBehaviour
    {
        private TextMeshProUGUI comboText;

        [Inject]
        private ComboManager comboManager;

        private void Awake()
        {
            comboText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            comboManager.onComboChanged += UpdateComboText;
        }

        private void OnDisable()
        {
            comboManager.onComboChanged -= UpdateComboText;
        }

        private void UpdateComboText(int combo)
        {
            comboText.text = $"Combo: {combo}";
        }
    }
}