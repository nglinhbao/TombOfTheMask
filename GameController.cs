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

    public void StartGame()
    {
        _view.ShowScreen();
    }

    public void ChangeState(string newState)
    {
        _model.State = newState;
    }

    public void Login()
    {
        string username = _view.HomeScreen.Form.Name;
        int stage = _view.HomeScreen.Form.Stage;
        int time = _view.HomeScreen.Form.Time;

        if (stage == 4)
        {
            stage = 1;
            time = 0;
        }

        User user = new User(username, stage, time);
        _model.CurrentUser = user;
        LoadMap();
    }

    public void LoadMap()
    {
        _model.LoadMap();
        ChangeState("map");
    }

    public void NextStage()
    {
        if (_model.CurrentUser.CurrentStage < 3 || (_model.CurrentUser.CurrentStage == 3 && !_model.CurrentMap.Win))
        {
            ChangeState("waiting");
        }
        else
        {
            ChangeState("logout");
        }
        _model.UpdateStage();
    }

    public void Logout()
    {
        _model.CurrentUser = null;
        ChangeState("home");
    }

    public void UpdateGame()
    {
        _model.UpdateGame();
    }

    public GameModel Model
    {
        get { return _model; }
    }

    public string State
    {
        get { return _model.State; }
    }

}