using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.AudioSystem.Knapik
{
    [CreateAssetMenu(menuName = "Audio System/Knapik Voicelines", fileName = "Knapik Voicelines")]
    public class KnapikVoicelines : ScriptableObject
    {
        [field: SerializeField]
        public AudioClip Yo { get; private set; }

        [field: SerializeField]
        public AudioClip KochamCie { get; private set; }

        [field: SerializeField]
        public AudioClip NasiFaniTancza { get; private set; }

        [field: SerializeField]
        public AudioClip PowiedzJakMozeszStac { get; private set; }

        [field: SerializeField]
        public AudioClip RamPamPam { get; private set; }

        [field: SerializeField]
        public AudioClip RapowalTomaszKnapik { get; private set; }
    
    }
}