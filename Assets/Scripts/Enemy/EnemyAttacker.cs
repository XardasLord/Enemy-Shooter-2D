using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] [Range(1, 50)] private int damage = 10;
        
        private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        public void DealDamage()
        {
            _playerHealth.TakeDamage(damage);
        }
    }
}