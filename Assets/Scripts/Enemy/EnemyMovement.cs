using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private float speed = 3f;
        
        private Transform _playerTransform;
        private SpriteRenderer _spriteRenderer;
        private EnemyAnimation _enemyAnimator;
        private bool _isFacingRight;
        private bool _isDead;
        private bool _shouldStay;

        private void Awake()
        {
            _playerTransform = GameObject.FindWithTag("Player").transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _enemyAnimator = GetComponent<EnemyAnimation>();
            
            var enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.OnDie += EnemyOnDie;

            var playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.OnDie += PlayerOnDie;
        }

        private void Start()
        {
            _isFacingRight = _playerTransform.position.x > transform.position.x;
        }

        private void Update()
        {
            if (_isDead || _shouldStay)
                return;
                
            if (Vector3.Distance(transform.position, _playerTransform.position) > 1f) {
                
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    _playerTransform.position,
                    speed * Time.deltaTime);

                if (ShouldFlipSprite())
                {
                    Flip();
                }
                
                _enemyAnimator.Move();
            }
            else
            {
                _enemyAnimator.Attack();
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

        private void EnemyOnDie() => _isDead = true;

        private void PlayerOnDie()
        {
            _enemyAnimator.Idle();
            _shouldStay = true;
        }
    }
}
