using Player;
using UnityEngine;

namespace Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private PlayerMovement playerMovement; // TODO: Would be nice to get rif of this
        [SerializeField] private Transform firePoint;
        
        private float _nextFire;
        
        public override void Fire()
        {
            if (!(Time.time > _nextFire)) 
                return;
            
            var angle = playerMovement.IsFacingRight ? 0f : 180f;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
                
            _nextFire = Time.time + fireRate;
        }
    }
}
