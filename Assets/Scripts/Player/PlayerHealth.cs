using System;
using UnityEngine;
using Variables;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private IntVariable health;
        [SerializeField] private IntVariable initialHealth;
        
        public event Action OnDie = delegate { };
        public event Action<int> OnGetHit = delegate { };

        private void Awake()
        {
            health.Value = initialHealth.Value;
        }

        public void TakeDamage(int damage)
        {
            health.Value -= damage;
            
            if (health.Value <= 0)
            {
                health.Value = 0;

                OnDie();
            }
            else
            {
                OnGetHit(damage);
            }
        }
    }
}