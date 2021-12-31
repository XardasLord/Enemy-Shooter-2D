using Common;
using UnityEngine;

namespace Player.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly GameObject _player;
        private readonly Vector3 _movement;
        private Vector3 _previousLocation;

        public MoveCommand(GameObject player, Vector3 movement)
        {
            _player = player;
            _movement = movement;
        }
        
        public void Execute()
        {
            _previousLocation = _player.transform.position;
            
            _player.transform.Translate(_movement);
        }

        public void Undo()
        {
            _player.transform.Translate(_previousLocation);
        }
    }
}