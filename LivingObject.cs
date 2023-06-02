using System;
using SplashKitSDK;
namespace TombOfTheMask
{
	public abstract class LivingObject : GameObject
	{
		private bool _blocked = false;
        private string _way;

        public LivingObject(string name, float x, float y) : base(name, x, y)
        {
		}

        public abstract void Move(float x, float y);

        public bool Blocked
        {
			get { return _blocked; }
            set { _blocked = value; }
        }

        public string Way
        {
            set { _way = value; }
            get { return _way; }
        }
    }
}

