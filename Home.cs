using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace TombOfTheMask
{
    // Represents the home screen of the game.
    public class Home : Screen
    {
        private List<User> _users = new List<User>();
        private int _visibleRows = 5;
        private int _scrollIndex;
        private LoginForm _form = new LoginForm();
        private Window _window;

        public Home(Color background, Window window)
            : base(background)
        {
            _window = window;
            _scrollIndex = 0;
        }

        private void LoadUsers()
        {
            // Read user data from a file and populate the _users list
            StreamReader reader = new StreamReader("/Users/linhbao/Projects/TombOfTheMask/users.txt");
            int numUsers = reader.ReadInteger();

            List<User> sortedUsers = new List<User>();

            for (int i = 0; i < numUsers; i++)
            {
                string name = reader.ReadLine();
                int stage = reader.ReadInteger();
                int time = reader.ReadInteger();

                User newUser = new User(name, stage, time);
                sortedUsers.Add(newUser);
            }

            sortedUsers.Sort((x, y) =>
            {
                if (x.CurrentStage != y.CurrentStage)
                {
                    return y.CurrentStage.CompareTo(x.CurrentStage);
                }
                else
                {
                    return x.TotalTime.CompareTo(y.TotalTime);
                }
            });

            _users.Clear();
            _users.AddRange(sortedUsers);
        }

        public override void Show()
        {
            LoadUsers();
            DisplayHeading();
            DisplayRankings();
            _form.Start();

            // Handle scroll input
            ScrollTable();
        }

        private void DisplayHeading()
        {
            // Draw the heading of the home screen
            SplashKit.DrawText("Tomb Of The Mask", Color.White, 50, 50);
        }

        private void DisplayRankings()
        {
            // Calculate the visible portion of the table
            int startIndex = _scrollIndex;
            int endIndex = Math.Min(_scrollIndex + _visibleRows, _users.Count);

            // Draw rankings
            for (int i = startIndex; i < endIndex; i++)
            {
                int rank = i + 1;
                User user = _users[i];
                int y = 150 + (i - startIndex) * 50;

                // Draw rank
                SplashKit.DrawText($"{rank}.", Color.White, 50, y);

                // Draw user details
                SplashKit.DrawText(user.Name, Color.White, 100, y);
                SplashKit.DrawText($"Stage: {user.CurrentStage}", Color.White, 300, y);
                SplashKit.DrawText($"Total Time: {user.TotalTime}", Color.White, 450, y);
            }
        }

        public void ScrollTable()
        {
            Vector2D scroll = SplashKit.MouseWheelScroll();
            int scrollAmount = Convert.ToInt32(scroll.Y);

            if (scrollAmount != 0)
            {
                _scrollIndex -= scrollAmount;

                // Clamp scroll index to valid range
                _scrollIndex = Math.Max(0, _scrollIndex);
                _scrollIndex = Math.Min(_scrollIndex, _users.Count - _visibleRows);
            }
        }

        public LoginForm Form
        {
            get { return _form; }
        }
    }
}
