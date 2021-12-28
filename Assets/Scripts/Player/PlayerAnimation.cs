﻿using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int SpeedParameter = Animator.StringToHash("Speed");
        private static readonly int GetHitProperty = Animator.StringToHash("GetHit");
        private static readonly int IsDeadProperty = Animator.StringToHash("IsDead");

        private void Awake()
        {
            var playerHealth = GetComponent<PlayerHealth>();
            playerHealth.OnDie += OnDie;
            playerHealth.OnGetHit += OnGetHit;
        }

        public void Move(Vector3 moveDirection)
        {
            var speedValue = Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.y);

            animator.SetFloat(SpeedParameter, speedValue);
        }

        private void OnGetHit()
        {
            animator.SetTrigger(GetHitProperty);
        }

        private void OnDie()
        {
            animator.SetBool(IsDeadProperty, true);
        }
    }
}