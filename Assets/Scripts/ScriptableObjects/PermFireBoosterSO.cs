using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PermFireBoosterSO", menuName = "Configs/PermFireBoosterSO")]
    public class PermFireBoosterSO : PermanentBoosterSO
    {
        public override void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            player.ApplyFireBooster(this);
            base.ApplyAbsorbEffect(player, item);
        }
    }
}
