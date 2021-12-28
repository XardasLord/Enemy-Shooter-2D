using System;
using Common;
using UnityEngine;

namespace Player
{
    public class PlayerHealthBase : HealthBase
    {
        [SerializeField] [Range(1, 100)] private int health = 100;
        
        public override event Action OnDie = delegate { };
        public override event Action<int> OnGetHit = delegate { };

        public override void TakeDamage(int damage)
        {
            health -= damage;
            
            if (health <= 0)
            {
                health = 0;
                
                OnDie();
            }
            else
            {
                OnGetHit(damage);
            }
        }

        public override int GetHealth() => health;
    }
}