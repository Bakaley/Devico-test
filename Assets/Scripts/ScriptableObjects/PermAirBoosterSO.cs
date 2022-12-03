using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PermAirBoosterSO", menuName = "Configs/PermAirBoosterSO")]
    public class PermAirBoosterSO : PermanentBoosterSO
    {
        public override void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            player.ApplyAirBooster(this);
            base.ApplyAbsorbEffect(player, item);
        }
    }
}
