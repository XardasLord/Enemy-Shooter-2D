using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5;
    
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private bool _isFacedRight = true;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");

            var movement = new Vector3(inputX, inputY);

            movement *= speed * Time.deltaTime;

            transform.Translate(movement);

            AdjustMoveAnimation(inputX);
            Flip(inputX);
        }

        private void AdjustMoveAnimation(float horizontalMove)
        {
            _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        private void Flip(float horizontalMove)
        {
            if (horizontalMove > 0 && !_isFacedRight)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _isFacedRight = true;
            }
            else if (horizontalMove < 0 && _isFacedRight)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _isFacedRight = false;
            }
        }
    }
}
