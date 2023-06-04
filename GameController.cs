using TombOfTheMask;
using SplashKitSDK;

public class GameController
{
    private GameModel _model;
    private GameView _view;

    public GameController()
    {
        _model = new GameModel();
        _view = new GameView(this);
    }

    // Starts the game by showing the initial screen
    public void StartGame()
    {
        _view.ShowScreen();
    }

    // Changes the game state to the specified state
    public void ChangeState(string newState)
    {
        _model.State = newState;
    }

    // Handles the login functionality
    public void Login()
    {
        // Get the username, stage, and time from the home screen form
        string username = _view.HomeScreen.Form.Name;
        int stage = _view.HomeScreen.Form.Stage;
        int time = _view.HomeScreen.Form.Time;

        // Reset the stage and time if the user reaches stage 4
        if (stage == 4)
        {
            stage = 1;
            time = 0;
        }

        // Create a new user with the provided details
        User user = new User(username, stage, time);
        _model.CurrentUser = user;

        // Load the map
        LoadMap();
    }

    // Loads the map and changes the state to "map"
    public void LoadMap()
    {
        _model.LoadMap();
        ChangeState("map");
    }

    // Handles the next stage functionality
    public void NextStage()
    {
        // If the user is not at the final stage or they haven't won the current stage, change the state to "waiting"
        // Otherwise, change the state to "logout"
        if (_model.CurrentUser.CurrentStage < 3 || (_model.CurrentUser.CurrentStage == 3 && !_model.CurrentMap.Win))
        {
            ChangeState("waiting");
        }
        else
        {
            ChangeState("logout");
        }

        // Update the stage
        _model.UpdateStage();
    }

    // Handles the logout functionality
    public void Logout()
    {
        // Clear the current user and change the state to "home"
        _model.CurrentUser = null;
        ChangeState("home");
    }

    // Updates the game
    public void UpdateGame()
    {
        _model.UpdateGame();
    }

    // Gets the game model
    public GameModel Model
    {
        get { return _model; }
    }

    // Gets the game state
    public string State
    {
        get { return _model.State; }
    }
}
