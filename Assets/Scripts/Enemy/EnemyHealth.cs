using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private IntVariableInstancer health;

        [Header("Game events")] 
        [SerializeField] private VoidBaseEventReference enemyDeathEvent;
        [SerializeField] private VoidBaseEventReference enemyGotHit;

        private void Awake()
        {
            health.Value = health.Base.InitialValue;
        }

        public void TakeDamage(int damage)
        {
            health.Value -= damage;
            
            if (health.Value <= 0)
            {
                health.Value = 0;

                enemyDeathEvent.Event.Raise();
                
                // TODO: Move it to other script like `Enemy.cs`
                Destroy(gameObject, 2f);
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                enemyGotHit.Event.Raise();
            }
        }
    }
}