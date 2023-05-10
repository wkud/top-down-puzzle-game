using Project.AudioSystem.Knapik;
using UnityEngine;
using Zenject;

namespace Project.AudioSystem.Injection
{
    public class AudioSystemInstaller : MonoInstaller
    {
        [SerializeField]
        private AudioManager audioManager;
        [SerializeField]
        private KnapikManager knapikManager;
    
        public override void InstallBindings()
        {
            Container.Bind<AudioManager>()
                .FromInstance(audioManager)
                .AsSingle();

            Container.Bind<KnapikManager>()
                .FromInstance(knapikManager)
                .AsSingle();
        }
    }
}