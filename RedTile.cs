using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class RedTile : Tile
    {
        public RedTile(int x, int y) : base(x, y)
        {
            _type = "redTile";
            _image = SplashKit.LoadBitmap("redTile", "redTile.png");
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(_image, _x, _y);
        }
    }
}

