using System;

namespace TombOfTheMask
{
    // Represents a BlueTileCreator object, a subclass of TileCreator
    public class BlueTileCreator : TileCreator
    {
        // Override the CreateTile method to create and return a BlueTile object
        public override Tile CreateTile(int x, int y)
        {
            return new BlueTile(x, y);
        }
    }
}
