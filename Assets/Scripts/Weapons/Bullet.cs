using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;
 
        private void Start()
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            
            Destroy(gameObject);
        }
    }
}
