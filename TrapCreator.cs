using System;
namespace TombOfTheMask
{
    public class TrapCreator : TileCreator
    {
        public override Tile CreateTile(int x, int y)
        {
            return new Trap(x, y);
        }
    }
}

