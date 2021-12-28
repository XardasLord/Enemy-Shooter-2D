using UnityEngine;

namespace Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _enemyAnimator;
        
        private static readonly int AttackProperty = Animator.StringToHash("IsAttacking");

        private void Awake()
        {
            _enemyAnimator = GetComponent<Animator>();
        }

        public void Attack()
        {
            _enemyAnimator.SetBool(AttackProperty, true);
        }

        public void Move()
        {
            _enemyAnimator.SetBool(AttackProperty, false);
        }
    }
}