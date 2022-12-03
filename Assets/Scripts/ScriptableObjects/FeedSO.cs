using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Feed", menuName = "Configs/Feed")]
    public class FeedSO : ItemSO
    {
        [SerializeField] private int _feedValue;
        public override void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            player.Feed(_feedValue);
            base.ApplyAbsorbEffect(player, item);
        }
    }
}
