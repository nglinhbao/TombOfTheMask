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

    public void LoadMap()
    {
        _map = new Map(Color.Black);
        _map.LoadMap(CurrentUser.CurrentStage);
    }

    public void UpdateCurrentUser()
    {
        if (_currentUser != null)
        {
            _currentUser.Update();
        }
    }

    public void UpdateGame()
    {
        if (_map != null)
        {
            _map.UpdateMap();
        }
    }

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

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public User CurrentUser
    {
        get { return _currentUser; }
        set { _currentUser = value; }
    }

    public Map CurrentMap
    {
        get { return _map; }
    }
}
