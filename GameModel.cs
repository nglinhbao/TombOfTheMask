using SplashKitSDK;
using TombOfTheMask;

public class GameModel
{
    private string _state;
    private User _currentUser;
    private Map _map;

    public GameModel()
    {
        _state = "home";
        _currentUser = null;
    }

    // Loads the map based on the current user's current stage
    public void LoadMap()
    {
        _map = new Map(Color.Black);
        _map.LoadMap(CurrentUser.CurrentStage);
    }

    // Updates the current user
    public void UpdateCurrentUser()
    {
        if (_currentUser != null)
        {
            _currentUser.Update();
        }
    }

    // Updates the game (map)
    public void UpdateGame()
    {
        if (_map != null)
        {
            _map.UpdateMap();
        }
    }

    // Updates the current stage
    public void UpdateStage()
    {
        if (_currentUser != null && _map != null)
        {
            _currentUser.TotalTime += _map.ElapsedTime;

            if (CurrentMap.Win)
            {
                if (_currentUser.CurrentStage < 4)
                {
                    _currentUser.CurrentStage++;
                }
            }
            UpdateCurrentUser();
        }
    }

    // Gets or sets the game state
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    // Gets or sets the current user
    public User CurrentUser
    {
        get { return _currentUser; }
        set { _currentUser = value; }
    }

    // Gets the current map
    public Map CurrentMap
    {
        get { return _map; }
    }
}
