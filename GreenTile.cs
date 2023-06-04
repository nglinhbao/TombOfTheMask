using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class GreenTile : Tile
    {
        public GreenTile(int x, int y) : base(x, y)
        {
            _type = "greenTile";
            _image = SplashKit.LoadBitmap("greenTile", "greenTile.png");
        }

        //Draw green tile on the screen
        public override void Draw()
        {
            SplashKit.DrawBitmap(_image, _x, _y);
        }
    }
}

