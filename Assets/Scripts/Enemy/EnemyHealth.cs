using System;
using Common;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealthBase : HealthBase
    {
        [SerializeField] [Range(1, 100)] private int health = 20;

        public override event Action OnDie = delegate { };
        public override event Action<int> OnGetHit = delegate { };

        public override void TakeDamage(int damage)
        {
            health -= damage;
            
            if (health <= 0)
            {
                health = 0;

                OnDie();
                Destroy(gameObject, 2f);
            }
            else
            {
                OnGetHit(damage);
            }
        }

        public override int GetHealth() => health;
    }
}