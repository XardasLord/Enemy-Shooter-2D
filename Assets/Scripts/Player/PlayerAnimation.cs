using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int Speed = Animator.StringToHash("Speed");

        public void Move(Vector3 moveDirection)
        {
            var speedValue = Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.y);

            animator.SetFloat(Speed, speedValue);
        }
    }
}