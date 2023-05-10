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

        public void StartSong()
        {
            audioManager.PlayMusic(songData.Song, songData.Delay);
            rhythmManager.StartRhythm(songData.Bpm);
        }
    }
}