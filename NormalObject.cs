using System;
using SplashKitSDK;
namespace TombOfTheMask
{
	public abstract class NormalObject : GameObject
	{
		public NormalObject(string name, float x, float y) : base(name, x, y)
		{
		}

		public abstract void Update();
    }
}

