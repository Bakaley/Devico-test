using UnityEngine;

namespace ScriptableObjects
{
    public abstract class ItemSO : ScriptableObject
    {
        public virtual void ApplyAbsorbEffect(Player.Player player, Item item)
        {
            Destroy(item.gameObject);
        }
    }
}
