using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TempSpeedBoosterSO", menuName = "Configs/TempSpeedBoosterSO")]
    public class TempSpeedBoosterSO: TemporaryBoosterSO
    {
        [field: SerializeField] public float NewSpeedValue { get; private set; }
        public override void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            player.ApplyTempSpeedBooster(this);
            base.ApplyAbsorbEffect(player, item);
        }
    }
}