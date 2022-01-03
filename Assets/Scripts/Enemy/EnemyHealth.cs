using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private IntConstant initialHealth;

        public int Health => health;
        
        public event Action OnDie = delegate { };
        public event Action<int> OnGetHit = delegate { };

        private void Awake()
        {
            health = initialHealth.Value;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            
            if (health <= 0)
            {
                health = 0;

                OnDie();
                
                Destroy(gameObject, 2f);
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                OnGetHit(damage);
            }
        }
    }
}