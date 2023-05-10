using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Project.TilemapSystem;
using Project.Movement;
using Project.RhythmSystem;
using Project.LevelCompletionSystem;
using Project.AudioSystem;
using Project.ComboSystem;

namespace Project.ZenjectInstallers
{
    public class SceneMonoInstaller : MonoInstaller<SceneMonoInstaller>
    {
        [SerializeField]
        private TilemapManager tilemapManager;

        [SerializeField]
        private CollisionManager collisionManager;

        [SerializeField]
        private RhythmManager rhythmManager;

        [SerializeField]
        private SongManager songManager;

        [SerializeField]
        private LevelCompletionManager levelCompletionManager;

        [SerializeField]
        private PenaltyRewardManager penaltyRewardManager;

        [SerializeField]
        private ComboManager comboManager;

        public override void InstallBindings()
        {
            Container.Bind<TilemapManager>()
                .FromInstance(tilemapManager ?? FindObjectOfType<TilemapManager>()) // spaghet
                .AsSingle();

            Container.Bind<CollisionManager>()
                .FromInstance(collisionManager ?? GetComponentInChildren<CollisionManager>())
                .AsSingle();

            Container.Bind<RhythmManager>()
                .FromInstance(rhythmManager ?? GetComponentInChildren<RhythmManager>()) 
                .AsSingle();

            Container.Bind<SongManager>()
                .FromInstance(songManager ?? GetComponentInChildren<SongManager>()) 
                .AsSingle();

            Container.Bind<LevelCompletionManager>()
                .FromInstance(levelCompletionManager ?? GetComponentInChildren<LevelCompletionManager>()) 
                .AsSingle();

            Container.Bind<PenaltyRewardManager>()
                .FromInstance(penaltyRewardManager ?? GetComponentInChildren<PenaltyRewardManager>())
                .AsSingle(); 

            Container.Bind<ComboManager>()
                .FromInstance(comboManager ?? GetComponentInChildren<ComboManager>())
                .AsSingle(); 
        }
    }
}
