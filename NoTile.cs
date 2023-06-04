using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class NoTile : Tile
    {
        private string _background;
        private bool _painted;

        public NoTile(int x, int y, string background) : base(x, y)
        {
            _type = "noTile";
            _background = background;
            _painted = false;
        }

        // Paints the tile
        public void Paint()
        {
            _painted = true;
        }

        // Draws the tile on the screen
        public override void Draw()
        {
            if (_painted)
            {
                Color rectangleColor = GetRectangleColor();
                Rectangle rectangle = SplashKit.RectangleFrom(_x, _y, 50, 50);

                SplashKit.FillRectangle(rectangleColor, rectangle);
            }
        }

        // Maps the background color to a Color object
        private Color GetRectangleColor()
        {
            if (_background == "green")
            {
                return Color.Green;
            }
            else if (_background == "red")
            {
                return Color.Tomato;
            }
            else
            {
                return Color.Blue;
            }
        }

        // Gets the value indicating whether the tile has been painted or not
        public bool Painted
        {
            get { return _painted; }
        }
    }
}
