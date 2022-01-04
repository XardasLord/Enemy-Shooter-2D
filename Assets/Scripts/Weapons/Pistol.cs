using Player;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] [Range(1, 100)] private int damage = 5;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private PlayerMovement playerMovement; // TODO: Would be nice to get rid of this
        [SerializeField] private Transform firePoint;
        
        [Header("Game events")]
        [SerializeField] private VoidBaseEventReference weaponFire;
        
        private float _nextFire;

        public override void Fire()
        {
            if (Time.time < _nextFire) 
                return;
            
            var angle = playerMovement.IsFacingRight ? 0f : 180f;
            var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));

            bullet.SetDamage(damage);
            
            weaponFire.Event.Raise();
                
            _nextFire = Time.time + fireRate;
        }
    }
}
