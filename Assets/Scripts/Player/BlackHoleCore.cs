using System;
using UnityEngine;

namespace Player
{
    public class BlackHoleCore : MonoBehaviour
    {
        public event Action<Item> OnItemAbsorbed;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Item item))
            {
                OnItemAbsorbed?.Invoke(item);
            }
        }
    }
}
