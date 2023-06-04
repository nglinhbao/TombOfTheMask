using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class Heart : NormalObject
    {
        private Bitmap _heartBitMap = SplashKit.LoadBitmap("heart", "heart.png");

        public Heart(string name, float x, float y) : base(name, x, y)
        {
            this.Image = _heartBitMap;
        }

        // Overrides the Update method of the base class.
        public override void Update()
        {
            // No implementation in this case
        }
    }
}
