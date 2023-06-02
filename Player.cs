using System;
using System.Drawing;
using SplashKitSDK;
namespace TombOfTheMask
{
	public class Player : LivingObject
	{
        private int _heartCount = 0;
        private Bitmap _charBitMap = SplashKit.LoadBitmap("char", "char.png");
        private bool _blocked = true;
        private bool _immune = false;
        
        public Player(string name, float x, float y) : base(name, x, y)
        {
            this.Image = _charBitMap;
        }

        public override void Move(float x, float y)
        {
            if (Blocked == false)
            {
                if (Way == "left")
                {
                    X -= x;
                }
                else if (Way == "right")
                {
                    X += x;
                }
                else if (Way == "up")
                {
                    Y -= x;
                }
                else
                {
                    Y += x;
                }
            }
        }

        public void BeImmune()
        {
            _immune = true;
            Task.Delay(500).ContinueWith(_ =>
            {
                _immune = false;
            });
        }

        public bool IsImmune
        {
            get { return _immune; }
        }

        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }

        public int HeartCount
        {
            get { return _heartCount; }
            set { _heartCount = value; }
        }
    }
}

