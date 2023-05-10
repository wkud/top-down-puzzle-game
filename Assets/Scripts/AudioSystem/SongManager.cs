using Project.RhythmSystem;
using UnityEngine;
using Zenject;

namespace Project.AudioSystem
{
    public class SongManager : MonoBehaviour
    {
        [SerializeField]
        private SongData songData;

        [Inject]
        private AudioManager audioManager;
        [Inject]
        private RhythmManager rhythmManager;

        private bool songIsPlaying;

        private void OnEnable()
        {
            rhythmManager.onBeat += PlayBeatSFX;
        }

        private void OnDisable()
        {
            rhythmManager.onBeat -= PlayBeatSFX;
        }
        
        public void StartSong()
        {
            audioManager.PlayMusic(songData.Song, songData.Delay);
            rhythmManager.StartRhythm(songData.Bpm);
        }

        private void PlayBeatSFX()
        {
            if(songData.BeatSFX)
            {
                audioManager.PlaySoundEffect(songData.BeatSFX);
            }
        }
    }
}