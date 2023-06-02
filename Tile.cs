using System;
using SplashKitSDK;
namespace TombOfTheMask
{
    public abstract class Tile
    {
        protected int _x;
        protected int _y;
        protected string _type;
        protected Bitmap _image;

        public Tile(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public abstract void Draw();

        public int X => _x;

        public int Y => _y;
    }
}

