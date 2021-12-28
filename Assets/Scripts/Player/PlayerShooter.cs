using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Weapon activeWeapon;
        
        private void Update()
        {
            var fire = Input.GetButton("Fire1");
            
            if (fire)
                activeWeapon.Fire();
        }
    }
}
