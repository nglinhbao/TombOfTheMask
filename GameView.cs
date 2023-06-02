using System;
using SplashKitSDK;

namespace TombOfTheMask
{
    public class GameView
    {
        private GameController _controller;
        private Home _home;
        private Window _gameWindow;
        private Map _map;
        private WaitingScreen _waitingScreen;
        private LogoutScreen _logoutScreen;


        public GameView(GameController controller)
        {
            _controller = controller;
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            _gameWindow = new Window("Tomb of the Mask", 600, 700);
            _home = new Home(Color.Black, _gameWindow);
        }

        public void ShowScreen()
        {
            while (!_gameWindow.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (_controller.State == "home")
                {
                    _home.Show();

                    if (HomeScreen.Form.Done == true)
                    {
                        _controller.Login(); // Call the Login() method in the GameController
                        _home = new Home(Color.Black, _gameWindow);
                    }
                }
                else if (_controller.State == "map")
                {
                    if (_controller.Model.CurrentMap == null)
                    {
                        Console.WriteLine("Map is not loaded.");
                        return;
                    }

                    _controller.UpdateGame();
                    _controller.Model.CurrentMap.Show();

                    if (_controller.Model.CurrentMap.IsFinished)
                    {
                        _controller.NextStage();
                    }
                }
                else if (_controller.State == "waiting")
                {
                    _waitingScreen = new WaitingScreen(Color.Black, _controller);
                    _waitingScreen.Show();
                }
                else if (_controller.State == "logout")
                {
                    _logoutScreen = new LogoutScreen(Color.Black, _controller);
                    _logoutScreen.Show();
                }

                SplashKit.RefreshScreen();
            }
        }

        public void CloseGameWindow()
        {
            _gameWindow.Close();
        }

        public void ShowFinishScreen(int elapsedTime)
        {
            // Clear the screen
            SplashKit.ClearScreen(Color.Black);

            // Draw the finish screen with the elapsed time
            SplashKit.DrawText("Congratulations! You finished the map.", Color.White, 20, 20);
            SplashKit.DrawText($"Time taken: {elapsedTime} seconds", Color.White, 20, 50);

            SplashKit.RefreshScreen();
        }

        public Home HomeScreen
        {
            get { return _home; }
        }

    }
}
