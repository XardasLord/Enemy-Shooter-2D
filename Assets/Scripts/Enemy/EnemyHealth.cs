using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] [Range(1, 100)] private int health = 20;
        
        private EnemyAnimation _enemyAnimator;

        private void Awake()
        {
            _enemyAnimator = GetComponent<EnemyAnimation>();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            
            if (health <= 0)
            {
                health = 0;
                
                _enemyAnimator.Die();
                Destroy(gameObject, 2f);
            }
        }

        public bool IsAlive() => health > 0;
    }
}