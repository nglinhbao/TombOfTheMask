using System;
namespace TombOfTheMask
{
    public class GreenTileCreator : TileCreator
    {
        public override Tile CreateTile(int x, int y)
        {
            return new GreenTile(x, y);
        }
    }
}

