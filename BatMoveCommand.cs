using System;
namespace TombOfTheMask
{
    public class BatMoveCommand : ICommand
    {
        private Bat _bat;
        private float _x;
        private float _y;

        public BatMoveCommand(Bat bat, float x, float y)
        {
            _bat = bat;
            _x = x;
            _y = y;
        }

        public void Execute()
        {
            _bat.Move(_x, _y);
        }
    }
}

