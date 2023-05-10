using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.AudioSystem.Knapik
{
    public class KnapikManager : MonoBehaviour
    {
        [SerializeField]
        private KnapikVoicelines voiceLines;

        [Inject]
        private AudioManager audioManager;

        public void PlayYo()
        {
            audioManager.PlaySoundEffect(voiceLines.Yo);
        }

        public void PlayKochamCie()
        {
            audioManager.PlaySoundEffect(voiceLines.KochamCie);
        }

        public void PlayNasiFaniTancza()
        {
            audioManager.PlaySoundEffect(voiceLines.NasiFaniTancza);
        }

        public void PlayPowiedzJakMozeszStac()
        {
            audioManager.PlaySoundEffect(voiceLines.PowiedzJakMozeszStac);
        }

        public void PlayRamPamPam()
        {
            audioManager.PlaySoundEffect(voiceLines.RamPamPam);
        }

        public void PlayRapowalTomaszKnapik()
        {
            audioManager.PlaySoundEffect(voiceLines.RapowalTomaszKnapik);
        }
    }
}