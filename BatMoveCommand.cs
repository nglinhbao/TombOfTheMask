using System;

namespace TombOfTheMask
{
    // Represents a command to move the Bat object
    public class BatMoveCommand : ICommand
    {
        private Bat _bat;      // The Bat object to move
        private float _x;      // The amount to move along the x-axis
        private float _y;      // The amount to move along the y-axis

        // Constructor to initialize the BatMoveCommand with the Bat object and movement values
        public BatMoveCommand(Bat bat, float x, float y)
        {
            _bat = bat;
            _x = x;
            _y = y;
        }

        // Execute the bat movement command
        public void Execute()
        {
            _bat.Move(_x, _y);
        }
    }
}
