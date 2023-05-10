using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.AudioSystem.Knapik
{
    public class KnapikPlayer : MonoBehaviour
    {
        [Inject]
        private KnapikManager knapikManager;

        private void Start()
        {
            knapikManager.PlayRapowalTomaszKnapik();
        }
    }
}
