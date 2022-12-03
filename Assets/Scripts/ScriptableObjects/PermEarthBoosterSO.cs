using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PermEarthBoosterSO", menuName = "Configs/PermEarthBoosterSO")]
    public class PermEarthBoosterSO : PermanentBoosterSO
    {
        public override void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            player.ApplyEarthBooster(this);
            base.ApplyAbsorbEffect(player, item);
        }
    }
}
