using SplashKitSDK;

namespace TombOfTheMask
{
    public class WaitingScreen : Screen
    {
        private GameController _controller;

        public WaitingScreen(Color background, GameController controller) : base(background)
        {
            _controller = controller;
        }

        public override void Show()
        {
            // Clear the screen
            SplashKit.ClearScreen(Color.Black);

            // Draw user name, stage, and total time
            User user = _controller.Model.CurrentUser;
            string username = user.Name;
            int stage = user.CurrentStage;
            int totalTime = user.TotalTime;

            if (_controller.Model.CurrentMap.Win)
            {
                SplashKit.DrawText("You win", Color.White, 20, 20);
            }
            else
            {
                SplashKit.DrawText("You lose", Color.White, 20, 20);
            }
            SplashKit.DrawText($"User: {username}", Color.White, 20, 50);
            SplashKit.DrawText($"Next Stage: {stage}", Color.White, 20, 80);
            SplashKit.DrawText($"Total Time: {totalTime} seconds", Color.White, 20, 110);

            if (_controller.Model.CurrentMap.Win)
            {
                SplashKit.DrawText($"Press enter to play next stage", Color.White, 20, 140);
            }
            else
            {
                SplashKit.DrawText($"Press enter to play again", Color.White, 20, 140);
            }

            SplashKit.DrawText($"Press ESC to log out", Color.White, 20, 170);

            // Check if Enter key is pressed
            if (SplashKit.KeyTyped(KeyCode.ReturnKey))
            {
                _controller.LoadMap();
            }
            if (SplashKit.KeyTyped(KeyCode.EscapeKey))
            {
                _controller.Logout();
            }

            SplashKit.RefreshScreen();
        }
    }
}
