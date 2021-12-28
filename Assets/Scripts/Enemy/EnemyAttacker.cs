using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] [Range(1, 50)] private int damage = 10;
        [SerializeField] private PlayerHealth playerHealth;
    
        public void DealDamage()
        {
            playerHealth.TakeDamage(damage);
        }
    }
}