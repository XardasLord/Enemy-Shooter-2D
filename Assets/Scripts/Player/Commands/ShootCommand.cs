using Common;
using Weapons;

namespace Player.Commands
{
    public class ShootCommand : ICommand
    {
        private readonly Weapon _weapon;

        public ShootCommand(Weapon weapon)
        {
            _weapon = weapon;
        }
        
        public void Execute()
        {
            _weapon.Fire();
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}