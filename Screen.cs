using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public abstract class Screen
    {
        private Color _background;  // Private field to store the background color of the screen

        public Screen(Color background)
        {
            _background = background;  // Initialize the background color of the screen in the constructor
        }

        public Color Background
        {
            set { _background = value; }  // Property to set the background color of the screen
        }

        public abstract void Show();  // Abstract method to show the screen, to be implemented by derived classes
    }
}
