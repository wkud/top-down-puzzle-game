using UnityEngine;

namespace Project.AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource musicAudioSource;
        [SerializeField]
        private AudioSource soundEffectsAudioSource;

        public void PlayMusic(AudioClip musicClip, float delay = 0)
        {
            musicAudioSource.clip = musicClip;
            if(delay > 0)
            {
                musicAudioSource.PlayDelayed(delay);
            }
            else
            {
                musicAudioSource.Play();
            }
        }

        public void PlaySoundEffect(AudioClip soundEffectClip)
        {
            soundEffectsAudioSource.PlayOneShot(soundEffectClip);
        }
    }
}