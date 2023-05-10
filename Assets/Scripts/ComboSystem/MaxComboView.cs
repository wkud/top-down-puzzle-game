using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Project
{
    public class MaxComboView : MonoBehaviour
    {
        private TextMeshProUGUI maxComboText;

        private void Awake()
        {
            maxComboText = GetComponent<TextMeshProUGUI>();
            maxComboText.text = $"Max Combo: {PlayerPrefs.GetInt("Highest Combo", 0)}";
        }
    }
}
