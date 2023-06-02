using System;
namespace TombOfTheMask
{
    public class BlueTileCreator : TileCreator
    {
        public override Tile CreateTile(int x, int y)
        {
            return new BlueTile(x, y);
        }
    }
}

