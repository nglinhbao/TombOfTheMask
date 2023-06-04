using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    // Represents a BlueTile object, a subclass of Tile
    public class BlueTile : Tile
    {
        // Constructor to initialize a BlueTile object with its coordinates
        public BlueTile(int x, int y) : base(x, y)
        {
            _type = "blueTile";
            _image = SplashKit.LoadBitmap("blueTile", "blueTile.png");
        }

        // Override the Draw method to draw the BlueTile
        public override void Draw()
        {
            SplashKit.DrawBitmap(_image, _x, _y);
        }
    }
}
