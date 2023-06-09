﻿using System.Xml.Linq;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class LoginForm
    {
        private string _username;
        private int _stage;
        private int _time;
        private bool _done = false;
        private string _inputText = "";

        public void Start()
        {
            //Check for keys down
            if (SplashKit.KeyReleased(KeyCode.BackspaceKey))
            {
                if (_inputText.Length > 0)
                {
                    _inputText = _inputText.Remove(_inputText.Length - 1);
                }
            }
            else if (SplashKit.KeyReleased(KeyCode.ReturnKey))
            {
                string username = _inputText;
                if (CheckUsername(username))
                {
                    Console.WriteLine("Login successful!");
                    // Add your program logic here
                    _done = true;
                }
                else
                {
                    RegisterUsername(username);
                    _done = true;
                }
            }
            else if (SplashKit.KeyReleased(KeyCode.AKey))
            {
                _inputText += "a";
            }
            else if (SplashKit.KeyReleased(KeyCode.BKey))
            {
                _inputText += "b";
            }
            else if (SplashKit.KeyReleased(KeyCode.CKey))
            {
                _inputText += "c";
            }
            else if (SplashKit.KeyReleased(KeyCode.DKey))
            {
                _inputText += "d";
            }
            else if (SplashKit.KeyReleased(KeyCode.EKey))
            {
                _inputText += "e";
            }
            else if (SplashKit.KeyReleased(KeyCode.FKey))
            {
                _inputText += "f";
            }
            else if (SplashKit.KeyReleased(KeyCode.GKey))
            {
                _inputText += "g";
            }
            else if (SplashKit.KeyReleased(KeyCode.HKey))
            {
                _inputText += "h";
            }
            else if (SplashKit.KeyReleased(KeyCode.IKey))
            {
                _inputText += "i";
            }
            else if (SplashKit.KeyReleased(KeyCode.JKey))
            {
                _inputText += "j";
            }
            else if (SplashKit.KeyReleased(KeyCode.KKey))
            {
                _inputText += "k";
            }
            else if (SplashKit.KeyReleased(KeyCode.LKey))
            {
                _inputText += "l";
            }
            else if (SplashKit.KeyReleased(KeyCode.MKey))
            {
                _inputText += "m";
            }
            else if (SplashKit.KeyReleased(KeyCode.NKey))
            {
                _inputText += "n";
            }
            else if (SplashKit.KeyReleased(KeyCode.OKey))
            {
                _inputText += "o";
            }
            else if (SplashKit.KeyReleased(KeyCode.PKey))
            {
                _inputText += "p";
            }
            else if (SplashKit.KeyReleased(KeyCode.QKey))
            {
                _inputText += "q";
            }
            else if (SplashKit.KeyReleased(KeyCode.RKey))
            {
                _inputText += "r";
            }
            else if (SplashKit.KeyReleased(KeyCode.SKey))
            {
                _inputText += "s";
            }
            else if (SplashKit.KeyReleased(KeyCode.TKey))
            {
                _inputText += "t";
            }
            else if (SplashKit.KeyReleased(KeyCode.UKey))
            {
                _inputText += "u";
            }
            else if (SplashKit.KeyReleased(KeyCode.VKey))
            {
                _inputText += "v";
            }
            else if (SplashKit.KeyReleased(KeyCode.WKey))
            {
                _inputText += "w";
            }
            else if (SplashKit.KeyReleased(KeyCode.XKey))
            {
                _inputText += "x";
            }
            else if (SplashKit.KeyReleased(KeyCode.YKey))
            {
                _inputText += "y";
            }
            else if (SplashKit.KeyReleased(KeyCode.ZKey))
            {
                _inputText += "z";
            }

            SplashKit.DrawText("Enter existing username to login/new username to sign up:", Color.White, "Arial", 18, 50, 450);
            SplashKit.DrawRectangle(Color.White, 50, 480, 200, 40);
            SplashKit.DrawText(_inputText, Color.White, "Arial", 18, 60, 490);
        }

        public bool CheckUsername(string username)
        {
            // Read the users.txt file and perform the username comparison logic
            // You can reuse the CheckUsername() method from the previous examples
            StreamReader reader = new("/Users/linhbao/Projects/TombOfTheMask/users.txt");
            int numUsers = reader.ReadInteger();
            for (int i=1; i<=numUsers; i++)
            {
                string name = reader.ReadLine();
                int stage = reader.ReadInteger();
                int time = reader.ReadInteger();

                if (name == username)
                {
                    _username = name;
                    _stage = stage;
                    _time = time;
                    return true;
                }
            }

            return false;
        }

        public void RegisterUsername(string username)
        {
            string filePath = "/Users/linhbao/Projects/TombOfTheMask/users.txt";
            List<string> lines = new List<string>();

            // Read all lines from the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Increment the number of users
            int numUsers = int.Parse(lines[0]);
            numUsers++;

            // Update the first line with the new user count
            lines[0] = numUsers.ToString();

            // Add the new user's information at the end
            lines.Add(username);
            lines.Add("1"); // Set stage to 1 for new user
            lines.Add("0"); // Set time to 0 for new user

            // Write the updated lines back to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }

            _username = username;
            _stage = 1;
            _time = 0;

            Console.WriteLine("Registration successful!");
        }

        public string Name
        {
            get { return _username; }
        }

        public int Stage
        {
            get { return _stage; }
        }

        public int Time
        {
            get { return _time; }
        }

        public string InputText
        {
            get { return _inputText; }
        }

        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }
    }
}
