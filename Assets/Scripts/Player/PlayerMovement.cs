using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5;
    
        private SpriteRenderer _spriteRenderer;
        private bool _isFacedRight = true;
        private PlayerAnimation _playerAnimator;

        public bool IsFacingRight => _isFacedRight;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimation>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");

            var movement = new Vector3(inputX, inputY);

            movement *= speed * Time.deltaTime;

            transform.Translate(movement);

            _playerAnimator.Move(movement);
            Flip(inputX);
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
