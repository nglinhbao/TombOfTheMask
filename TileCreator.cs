using System;

namespace TombOfTheMask
{
    // Abstract class for creating tiles in the game
    public abstract class TileCreator
    {
        // Abstract method for creating a tile
        public abstract Tile CreateTile(int x, int y);
    }
}
