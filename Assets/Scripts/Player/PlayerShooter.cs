using Player.Commands;
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
            {
                var shootCommand = new ShootCommand(activeWeapon);
                shootCommand.Execute();
            }
        }
    }
}
