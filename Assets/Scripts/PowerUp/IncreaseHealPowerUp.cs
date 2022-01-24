using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace PowerUp
{
    public class IncreaseHealPowerUp : MonoBehaviour
    {
        [SerializeField] private int increaseHealthBy;
        [SerializeField] private VoidEvent powerUpTakenEvent;
        [SerializeField] private IntEvent increaseHealPowerUpTookEvent;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player"))
                return;

            powerUpTakenEvent.Raise();
            increaseHealPowerUpTookEvent.Raise(increaseHealthBy);
            
            Destroy(gameObject);
        }

        public void PlayPowerUpTookSound()
        {
            // TODO: Add sound
            Debug.Log("PlayPowerUpTookSound");
        }
    }
}
