using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private IntVariable health;
        
        [Header("Game events")]
        [SerializeField] private VoidEvent playerDeathEvent;
        [SerializeField] private VoidEvent playerGotHitEvent;

        private void Awake()
        {
            health.Value = health.InitialValue;
        }

        public void TakeDamage(int damage)
        {
            health.Value -= damage;
            
            if (health.Value <= 0)
            {
                health.Value = 0;

                playerDeathEvent.Raise();
            }
            else
            {
                playerGotHitEvent.Raise();
            }
        }
    }
}