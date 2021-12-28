using UnityEngine;
using static UnityEngine.GameObject;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private float speed = 3f;
        
        private Transform _playerTransform;
        private SpriteRenderer _spriteRenderer;
        private bool _isFacingRight;

        private void Awake()
        {
            _playerTransform = FindWithTag("Player").transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _isFacingRight = _playerTransform.position.x > transform.position.x;
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _playerTransform.position) > 0.5f) {
                
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    _playerTransform.position,
                    speed * Time.deltaTime);

                if (ShouldFlipSprite())
                {
                    Flip();
                }
            }
            else
            {
                // Attack animation
            }
        }

        private bool ShouldFlipSprite()
        {
            var playerPosition = _playerTransform.position;
            var enemyPosition = transform.position;
            
            return playerPosition.x > enemyPosition.x && !_isFacingRight ||
                   playerPosition.x < enemyPosition.x && _isFacingRight;
        }

        private void Flip()
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            _isFacingRight = !_isFacingRight;
        }
    }
}
