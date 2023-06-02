using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class Trap : Tile
    {
        private bool _attack = false;
        private Bitmap _blueTrapBitMap = SplashKit.LoadBitmap("blueTrap", "blueTrap.png");
        private Bitmap _redTrapBitMap = SplashKit.LoadBitmap("redTrap", "redTrap.png");
        private Bitmap _yellowTrapBitMap = SplashKit.LoadBitmap("yellowTrap", "yellowTrap.png");
        private string _color = "blue";
        private bool _activated = false;

        public Trap(int x, int y) : base(x, y)
        {
        }

        public void Update()
        {
            _activated = true;

            Task.Delay(100).ContinueWith(_ =>
            {
                _color = "yellow";
            });

            Task.Delay(2000).ContinueWith(_ =>
            {
                _color = "red";
                _attack = true;
            });

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