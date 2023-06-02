using System;
namespace TombOfTheMask
{
    public class RedTileCreator : TileCreator
    {
        public override Tile CreateTile(int x, int y)
        {
            return new RedTile(x, y);
        }
    }
}

