using UnityEngine;

namespace Project.AudioSystem
{
    [CreateAssetMenu(menuName = "Audio System/Song Data", fileName = "Song Data")]
    public class SongData : ScriptableObject
    {
        [field: SerializeField]
        public AudioClip Song { get; private set; }

        [field: SerializeField]
        public AudioClip BeatSFX { get; private set; }
        
        [field: SerializeField]
        public float Bpm { get; private set; }

        [field: SerializeField]
        public float Delay { get; private set; }
    }
}