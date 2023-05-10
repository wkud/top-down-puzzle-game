using UnityEngine;
using Zenject;

namespace Project.RhythmSystem
{
    public class RhythmSystemInstaller : MonoInstaller
    {
        [SerializeField]
        private RhythmManager rhythmManager;

        public override void InstallBindings()
        {
            Container.Bind<RhythmManager>()
                .FromInstance(rhythmManager)
                .AsSingle();
        }
    }
}