using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class RedTile : Tile
    {
        public RedTile(int x, int y) : base(x, y)
        {
            _type = "redTile";                            // Set the type of tile to "redTile"
            _image = SplashKit.LoadBitmap("redTile", "redTile.png");   // Load the bitmap image for the red tile
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(_image, _x, _y);          // Draw the red tile using the loaded bitmap image
        }
    }
}
