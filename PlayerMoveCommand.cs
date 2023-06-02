using System;
namespace TombOfTheMask
{
    public class PlayerMoveCommand : ICommand
    {
        private Player _player;
        private float _x;
        private float _y;

        public PlayerMoveCommand(Player player, float x, float y)
        {
            _player = player;
            _x = x;
            _y = y;
        }

        public void Execute()
        {
            _player.Move(_x, _y);
        }
    }
}

