using System;
using System.IO;

namespace TombOfTheMask
{
    // Represents a user in the game
    public class User
    {
        private string _name;
        private int _currentStage;
        private int _totalTime;

        // Constructor to initialize the user object with name, current stage, and total time
        public User(string name, int currentStage, int totalTime)
        {
            _name = name;
            _currentStage = currentStage;
            _totalTime = totalTime;
        }

        // Updates the user's information in the file
        public void Update()
        {
            string filename = "/Users/linhbao/Projects/TombOfTheMask/users.txt"; // File path of the user data
            string[] arrLine = File.ReadAllLines(filename); // Read all lines from the file into an array

            // Iterate through each line in the array
            for (int i = 0; i < arrLine.Length; i++)
            {
                string line = arrLine[i];

                // Check if the line matches the user's name
                if (line == Name)
                {
                    // Update the next two lines with the current stage and total time
                    arrLine[i + 1] = CurrentStage.ToString();
                    arrLine[i + 2] = TotalTime.ToString();
                }
            }

            // Write the updated array of lines back to the file
            File.WriteAllLines(filename, arrLine);
        }

        // Property for accessing and modifying the user's name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Property for accessing and modifying the user's current stage
        public int CurrentStage
        {
            get { return _currentStage; }
            set { _currentStage = value; }
        }

        // Property for accessing and modifying the user's total time
        public int TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
        }
    }
}
