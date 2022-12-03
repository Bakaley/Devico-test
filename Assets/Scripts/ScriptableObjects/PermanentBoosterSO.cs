using UnityEngine;

namespace ScriptableObjects
{
    public abstract class PermanentBoosterSO : ItemSO
    {
        [field: SerializeField] public string ActivationMessage { get; private set; } = "Booster activated";
        [field: SerializeField] public float EffectApplyingTime { get; private set; } = 0.1f;
        [field: SerializeField] public Color MessageColor { get; private set; } = Color.white;
        [field: SerializeField] public Color IconColor { get; private set; } = Color.white;
        [field: SerializeField] public Gradient OrbitGradient { get; private set; }
    }
}
