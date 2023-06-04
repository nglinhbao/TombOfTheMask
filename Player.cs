using System;
using System.Drawing;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class Player : LivingObject
    {
        private int _heartCount = 0;                          // Number of hearts collected by the player
        private Bitmap _charBitMap = SplashKit.LoadBitmap("char", "char.png");    // Bitmap to store the player's image
        private bool _blocked = true;                         // Determines if the player is blocked from moving
        private bool _immune = false;                         // Indicates if the player is in an immune state

        public Player(string name, float x, float y) : base(name, x, y)
        {
            this.Image = _charBitMap;                         // Set the player's image to the loaded bitmap
        }

        public override void Move(float x, float y)
        {
            if (Blocked == false)
            {
                if (Way == "left")
                {
                    X -= x;                                  // Move the player left by subtracting the x-coordinate
                }
                else if (Way == "right")
                {
                    X += x;                                  // Move the player right by adding the x-coordinate
                }
                else if (Way == "up")
                {
                    Y -= x;                                  // Move the player up by subtracting the y-coordinate
                }
                else
                {
                    Y += x;                                  // Move the player down by adding the y-coordinate
                }
            }
        }

        public void BeImmune()
        {
            _immune = true;

            // Delay the immunity state for 500 milliseconds (0.5 seconds)
            // using Task.Delay and ContinueWith
            Task.Delay(500).ContinueWith(_ =>
            {
                _immune = false;                             // Disable the immunity state after the delay
            });
        }

        public bool IsImmune
        {
            get { return _immune; }                          // Get the current immunity state of the player
        }

        public bool Blocked
        {
            get { return _blocked; }                         // Get the blocked state of the player
            set { _blocked = value; }                        // Set the blocked state of the player
        }

        public int HeartCount
        {
            get { return _heartCount; }                       // Get the number of hearts collected by the player
            set { _heartCount = value; }                      // Set the number of hearts collected by the player
        }
    }
}
