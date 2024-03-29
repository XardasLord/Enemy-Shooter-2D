﻿using UnityEngine;

namespace Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _enemyAnimator;
        
        private static readonly int AttackProperty = Animator.StringToHash("IsAttacking");
        private static readonly int DieProperty = Animator.StringToHash("IsDead");
        private static readonly int GetHitProperty = Animator.StringToHash("GetHit");

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

        public void Idle()
        {
            _enemyAnimator.SetBool(AttackProperty, false);
        }

        public void Die()
        {
            _enemyAnimator.SetBool(DieProperty, true);
        }

        public void GetHit()
        {
            _enemyAnimator.SetTrigger(GetHitProperty);
        }
    }
}