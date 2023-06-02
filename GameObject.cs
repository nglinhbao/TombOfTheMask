using System;
using SplashKitSDK;
namespace TombOfTheMask
{
	public abstract class GameObject
	{
		private float _x;
		private float _y;
		private string _name;
		private Bitmap _image;

		public GameObject(string name, float x, float y)
		{
			_x = x;
			_y = y;
			_name = name;
		}

        public void Draw()
        {
            SplashKit.DrawBitmap(_image, _x, _y);
        }

        public string Name
		{
			get { return _name; }
		}

		public float X
		{
			get { return _x; }
			set { _x = value; }
		}

		public float Y
		{
			get { return _y; }
            set { _y = value; }
        }

		public Bitmap Image
		{
			set { _image = value; }
			get { return _image; }
		}
	}
}

