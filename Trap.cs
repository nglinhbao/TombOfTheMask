using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class Trap : Tile
    {
        private bool _attack = false; // Flag to indicate if the trap is in attack mode
        private Bitmap _blueTrapBitMap = SplashKit.LoadBitmap("blueTrap", "blueTrap.png"); // Bitmap for blue trap
        private Bitmap _redTrapBitMap = SplashKit.LoadBitmap("redTrap", "redTrap.png"); // Bitmap for red trap
        private Bitmap _yellowTrapBitMap = SplashKit.LoadBitmap("yellowTrap", "yellowTrap.png"); // Bitmap for yellow trap
        private string _color = "blue"; // Current color of the trap
        private bool _activated = false; // Flag to indicate if the trap is activated

        public Trap(int x, int y) : base(x, y)
        {
        }

        public void Update()
        {
            _activated = true;

            // Delay for 100 milliseconds and change trap color to yellow
            Task.Delay(100).ContinueWith(_ =>
            {
                _color = "yellow";
            });

            // Delay for 2000 milliseconds and change trap color to red, and enable attack mode
            Task.Delay(2000).ContinueWith(_ =>
            {
                _color = "red";
                _attack = true;
            });

            // Delay for 3000 milliseconds and change trap color back to blue, disable attack mode, and deactivate the trap
            Task.Delay(3000).ContinueWith(_ =>
            {
                _color = "blue";
                _activated = false;
                _attack = false;
            });

            Draw();
        }


        public override void Draw()
        {
            // Draw trap based on _color
            Bitmap trapBitmap = _blueTrapBitMap;

            if (_color == "yellow")
            {
                trapBitmap = _yellowTrapBitMap;
            }
            else if (_color == "red")
            {
                trapBitmap = _redTrapBitMap;
            }

            SplashKit.DrawBitmap(trapBitmap, X, Y);
        }

        public bool Activated
        {
            get { return _activated; }
        }

        public bool Attack
        {
            get { return _attack; }
        }
    }
}
