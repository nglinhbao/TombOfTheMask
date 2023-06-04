using System;

namespace TombOfTheMask
{
    public class NoTileCreator : TileCreator
    {
        private string _background;

        public NoTileCreator(string background)
        {
            _background = background;
        }

        // Overrides the CreateTile method from the base class to create a NoTile instance
        // with the specified background color
        public override Tile CreateTile(int x, int y)
        {
            return new NoTile(x, y, _background);
        }
    }
}
