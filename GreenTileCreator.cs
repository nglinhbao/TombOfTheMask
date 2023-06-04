using System;
namespace TombOfTheMask
{
    public class GreenTileCreator : TileCreator
    {
        // Override the CreateTile method to create and return a GreenTile object
        public override Tile CreateTile(int x, int y)
        {
            return new GreenTile(x, y);
        }
    }
}

