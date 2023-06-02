using System;
namespace TombOfTheMask
{
    // User class remains the same
    public class User
    {
        private string _name;
        private int _currentStage;
        private int _totalTime;

        public User(string name, int currentStage, int totalTime)
        {
            _name = name;
            _currentStage = currentStage;
            _totalTime = totalTime;
        }

        public void Update()
        {
            string filename = "/Users/linhbao/Projects/TombOfTheMask/users.txt";
            string[] arrLine = File.ReadAllLines(filename);
            for (int i=0; i<arrLine.Length; i++)
            {
                string line = arrLine[i];

                if (line == Name)
                {
                    arrLine[i+1] = CurrentStage.ToString();
                    arrLine[i+2] = TotalTime.ToString();
                }
            }
            File.WriteAllLines(filename, arrLine);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int CurrentStage
        {
            get { return _currentStage; }
            set { _currentStage = value; }
        }

        public int TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
        }
    }
}

