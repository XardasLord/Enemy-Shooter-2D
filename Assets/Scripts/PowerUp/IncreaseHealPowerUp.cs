using Player;
using UnityEngine;

namespace PowerUp
{
    public class IncreaseHealPowerUp : MonoBehaviour
    {
        [SerializeField] private int increaseHealthBy;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player"))
                return;

            col.GetComponent<PlayerHealth>().Heal(increaseHealthBy);
            
            Destroy(gameObject);
        }
    }
}
