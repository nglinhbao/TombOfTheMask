using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class Bat : LivingObject
    {
        // Variables
        private string _direction;
        private Bitmap _batBitMap = SplashKit.LoadBitmap("bat", "bat.png");

        // Constructor
        public Bat(string name, float x, float y, string direction) : base(name, x, y)
        {
            _direction = direction;

            // Set the initial way based on the given direction
            if (_direction == "horizontal")
            {
                Way = "up";
            }
            else
            {
                Way = "left";
            }

            this.Image = _batBitMap;
        }

        // Move the bat
        public override void Move(float x, float y)
        {
            // Check the direction of the bat and move accordingly
            if (_direction == "vertical")
            {
                if (Blocked == false)
                {
                    if (Way == "left")
                    {
                        X -= (float)x;
                    }
                    else
                    {
                        X += (float)x;
                    }
                }
            }
            else
            {
                if (Blocked == false)
                {
                    if (Way == "up")
                    {
                        Y -= (float)y;
                    }
                    else
                    {
                        Y += (float)y;
                    }
                }
            }
        }
    }
}
