using Player.Commands;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5;
    
        private PlayerAnimation _playerAnimator;
        private bool _isFacedRight = true;

        public bool IsFacingRight => _isFacedRight;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimation>();
        }

        private void Update()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");

            var movement = new Vector3(inputX, inputY);

            movement *= speed * Time.deltaTime;

            var moveCommand = new MoveCommand(gameObject, movement);
            moveCommand.Execute();

            _playerAnimator.Move(movement);
            Flip(inputX);
        }

        private void Flip(float horizontalMove)
        {
            if (!ShouldFlipSprite(horizontalMove)) 
                return;
            
            transform.localScale = new Vector3(
                transform.localScale.x * -1,
                transform.localScale.y,
                transform.localScale.z);
            
            _isFacedRight = !_isFacedRight;
        }

        private bool ShouldFlipSprite(float horizontalMove)
        {
            return horizontalMove > 0 && !_isFacedRight ||
                   horizontalMove < 0 && _isFacedRight;
        }
    }
}
