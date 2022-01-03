using System;
using EventSystem;
using UnityEngine;
using Variables;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private IntVariable health;
        [SerializeField] private IntVariable initialHealth;
        
        [Header("Game events")]
        [SerializeField] private GameEvent playerDeathEvent;
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

                playerDeathEvent.Raise();
            }
            else
            {
                OnGetHit(damage);
            }
        }
    }
}