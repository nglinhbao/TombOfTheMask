using System;

namespace TombOfTheMask
{
    // Concrete subclass of TileCreator responsible for creating Trap tiles
    public class TrapCreator : TileCreator
    {
        // Overrides the CreateTile method to create a new Trap instance
        public override Tile CreateTile(int x, int y)
        {
            return new Trap(x, y); // Create a new Trap object with the given coordinates
        }
    }
}
