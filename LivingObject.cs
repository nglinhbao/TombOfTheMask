using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    // Represents a living object in the game.
    public abstract class LivingObject : GameObject
    {
        private bool _blocked = false;
        private string _way;

        public LivingObject(string name, float x, float y) : base(name, x, y)
        {
        }

        // Moves the living object to the specified coordinates.
        public abstract void Move(float x, float y);

        // Gets or sets a value indicating whether the living object is blocked.
        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }

        // Gets or sets the way the living object is facing or moving.
        public string Way
        {
            set { _way = value; }
            get { return _way; }
        }
    }
}
