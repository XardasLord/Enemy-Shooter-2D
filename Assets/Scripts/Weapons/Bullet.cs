using Enemy;
using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;

        private int _damage;
 
        private void Start()
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            var enemyHealth = hitInfo.GetComponent<EnemyHealth>();

            if (enemyHealth is null)
                return;
            
            enemyHealth.TakeDamage(_damage);

            Destroy(gameObject);
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }
    }
}
