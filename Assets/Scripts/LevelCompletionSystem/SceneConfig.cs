using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Assets.Scripts.LevelCompletionSystem
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "SO/SceneConfig")]
    public class SceneConfig : ScriptableObject
    {

        [field: SerializeField]
        public List<string> SceneNamesInRightOrder { get; private set; }
    }
}