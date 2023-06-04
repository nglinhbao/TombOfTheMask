using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public abstract class Tile
    {
        protected int _x;  // Protected field to store the x-coordinate of the tile
        protected int _y;  // Protected field to store the y-coordinate of the tile
        protected string _type;  // Protected field to store the type of the tile
        protected Bitmap _image;  // Protected field to store the image of the tile

        public Tile(int x, int y)
        {
            _x = x;  // Initialize the x-coordinate of the tile
            _y = y;  // Initialize the y-coordinate of the tile
        }

        public abstract void Draw();  // Abstract method to draw the tile, to be implemented by derived classes

        public int X => _x;  // Read-only property to get the x-coordinate of the tile

        public int Y => _y;  // Read-only property to get the y-coordinate of the tile
    }
}
