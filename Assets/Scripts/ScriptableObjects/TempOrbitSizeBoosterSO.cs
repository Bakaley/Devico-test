using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TempOrbitBoosterSO", menuName = "Configs/TempOrbitBoosterSO")]
    public class TempOrbitSizeBoosterSO : TemporaryBoosterSO
    {
        [field: SerializeField] public float NewSizeValue { get; private set; }
        public override void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            player.ApplyTempOrbitSizeBooster(this);
            base.ApplyAbsorbEffect(player, item);
        }
    }
}