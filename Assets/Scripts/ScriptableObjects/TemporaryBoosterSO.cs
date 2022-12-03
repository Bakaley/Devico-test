using System.Collections;
using UnityEngine;

namespace ScriptableObjects
{ 
    public abstract class TemporaryBoosterSO : ItemSO
    {
        [field: SerializeField] public string ActivationMessage { get; private set; } = "Booster activated";
        [field: SerializeField] public Color MessageColor { get; private set; } = Color.white;
        [field: SerializeField] public float EffectApplyingTime { get; private set; } = 0.1f;
        [field: SerializeField] public float Duration { get; private set; } = 5f;
    }
}
