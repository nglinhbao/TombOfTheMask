using SplashKitSDK;

namespace TombOfTheMask
{
    public class LogoutScreen : Screen
    {
        private GameController _controller;

        public LogoutScreen(Color background, GameController controller) : base(background)
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

            SplashKit.DrawText($"User: {username}", Color.White, 20, 20);
            SplashKit.DrawText($"Number of stages: {stage}", Color.White, 20, 50);
            SplashKit.DrawText($"Total Time: {totalTime} seconds", Color.White, 20, 80);
            SplashKit.DrawText($"Press enter to sign out", Color.White, 20, 110);

            // Check if Enter key is pressed
            if (SplashKit.KeyTyped(KeyCode.ReturnKey))
            {
                _controller.Logout();
            }

            SplashKit.RefreshScreen();
        }
    }
}
