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

        // Draws the game object on the screen
        public void Draw()
        {
            SplashKit.DrawBitmap(_image, _x, _y);
        }

        // Gets the name of the game object
        public string Name
        {
            get { return _name; }
        }

        // Gets or sets the X-coordinate of the game object
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        // Gets or sets the Y-coordinate of the game object
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Gets or sets the image of the game object
        public Bitmap Image
        {
            set { _image = value; }
            get { return _image; }
        }
    }
}
