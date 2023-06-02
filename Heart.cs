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

        public override void Update()
        {
        }
    }
}

