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

        public override Tile CreateTile(int x, int y)
        {
            return new NoTile(x, y, _background);
        }
    }
}

