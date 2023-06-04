using System;
namespace TombOfTheMask
{
    public class RedTileCreator : TileCreator
    {
        // Override the CreateTile method to create and return a RedTile object
        public override Tile CreateTile(int x, int y)
        {
            return new RedTile(x, y);
        }
    }
}

