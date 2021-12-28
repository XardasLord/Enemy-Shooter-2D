using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] [Range(1, 100)] private int health = 100;

        public void TakeDamage(int damage)
        {
            health -= damage;
            
            if (health <= 0)
            {
                health = 0;
                
                // TODO: Die animation
                Destroy(gameObject, 2f);
            }
        }
    }
}