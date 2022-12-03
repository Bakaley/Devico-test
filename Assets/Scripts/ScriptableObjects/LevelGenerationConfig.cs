using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelGenerationConfig", menuName = "Configs/LevelGenerationConfg")]
    public class LevelGenerationConfig : SerializedScriptableObject
    {
        [field: SerializeField] public Dictionary<Item, float> FeedPercentTable { get; private set; }
        [field: SerializeField] public int BoosterSpawnChance { get; private set; } = 5;
        [field: SerializeField] public List<Item> BoosterList { get; private set; }
        [field: SerializeField] public int ObjectsCount { get; private set; }= 4000;
    }
}