using ScriptableObjects;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
   //using flyweight pattern, we are delegating all variables to ScriptableObjects
   //also for performance purposes all Item objects must have dynamic occlusion and GPU instancing as enabled
   [SerializeField] private ItemSO _config;
   public void ApplyAbsorbEffect(Player.Player player) => _config.ApplyAbsorbEffect(player, this);
}
