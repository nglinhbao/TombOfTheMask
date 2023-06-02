using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class BlueTile : Tile
    {
        public BlueTile(int x, int y) : base(x, y)
        {
            _type = "blueTile";
            _image = SplashKit.LoadBitmap("blueTile", "blueTile.png");
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(_image, _x, _y);
        }
    }

}

