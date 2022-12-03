using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PermWaterBoosterSO", menuName = "Configs/PermWaterBoosterSO")]
    public class PermWaterBoosterSO : PermanentBoosterSO
    {
        public override void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            player.ApplyWaterBooster(this);
            base.ApplyAbsorbEffect(player, item);
        }
    }
}
