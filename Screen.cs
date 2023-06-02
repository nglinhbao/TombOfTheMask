using System;
using SplashKitSDK;
namespace TombOfTheMask
{
	public abstract class Screen
	{
        private Color _background;

        public Screen(Color background)
		{
			_background = background;
		}

		public Color Background
		{
			set { _background = value; }
		}

		public abstract void Show();
	}
}

