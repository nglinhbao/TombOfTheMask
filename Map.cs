using System;
using SplashKitSDK;
using TombOfTheMask;

namespace TombOfTheMask
{
	public class Map : Screen
	{
        // Dictionary to store player direction values
        private Dictionary<string, Tuple<float, float>> _directionValue = new Dictionary<string, Tuple<float, float>>
        {
            {
                "right", new Tuple<float, float>(50, 0)
            },
            {
                "left", new Tuple<float, float>(-1, 0)
            },
                                    {
                "up", new Tuple<float, float>(0, -1)
            },
                                                {
                "down", new Tuple<float, float>(0, 50)
            },
        };

        // Dictionary to store bat values
        private Dictionary<string, int> _batValue = new Dictionary<string, int>
        {
            {
                "right", 1
            },
            {
                "left", 4
            },
            {
                "up", 2
            },
            {
                "down", 3
            }
        };

        private List<Tile> _tiles = new List<Tile> { };
		private List<GameObject> _objects = new List<GameObject> { };

        private Color _background;
        private int _columns, _rows;
        private Player _player;
        private bool _win;

        private int _time;
        private SplashKitSDK.Timer _timer;
        private bool _isFinished;
        private int _elapsedTime;
        private bool _lose = false;
        private CommandInvoker _invoker;

        private int _numberOfNoTile;

        private int _stage;

        //Constructor

        public Map(Color background) : base(background)
		{
            _time = 0;
            _timer = new SplashKitSDK.Timer("timer");
            _timer.Start();
            _isFinished = false;
            _elapsedTime = 0;
        }

        //Method
        //Method to calculate tile location
        private int TileLocationCalculation(float x, float y)
        {
            int tileX = (int)(x / 50f);
            int tileY = (int)(y / 50f);
            int tileIndex = tileY * 12 + tileX;
            return tileIndex;
        }

        //Method to calculate location
        private int[] CalculateLocation(int col, int row)
        {
            List<int> ans = new List<int> { };
            ans.Add(row * 50);
            ans.Add(col * 50);
            return ans.ToArray();
        }

        //Method to check if a tile is solid
        private bool Solid(float x, float y, bool playerChecking)
        {
            int tileIndex = TileLocationCalculation(x, y);

            if (_tiles[tileIndex] is NoTile)
            {
                return false;
            }
            if (playerChecking)
            {
                if (_tiles[tileIndex] is Trap trapTile)
                {
                    if (!trapTile.Activated)
                    {
                        trapTile.Update();
                    }
                    if (trapTile.Attack)
                    {
                        if (_player.HeartCount < 0)
                        {
                            _lose = true;
                        }
                        else
                        {
                            if (!_player.IsImmune)
                            {
                                _player.HeartCount -= 1;
                                _player.BeImmune();
                            }
                        }
                    }
                }
            }

            return true;
        }

        //Method to load the map from a file
        public void LoadMap(int stage)
        {
            _stage = stage;
            string filename = $"/Users/linhbao/Projects/TombOfTheMask/map{stage}.txt";
            StreamReader reader = new(filename);
            string tileColor = reader.ReadLine();
            int _columns = reader.ReadInteger();
            int _rows = reader.ReadInteger();

            try
            {
                for (int i = 0; i < _columns; i++)
                {
                    string col = reader.ReadLine();

                    for (int j = 0; j < _rows; j++)
                    {
                        string element = col[j].ToString();
                        int[] calculatedLocation = CalculateLocation(i, j);

                        Tile newTile = null;

                        if (element == "#")
                        {
                            TileCreator creator;

                            if (tileColor == "red")
                            {
                                creator = new RedTileCreator();
                            }
                            else if (tileColor == "blue")
                            {
                                creator = new BlueTileCreator();
                            }
                            else
                            {
                                creator = new GreenTileCreator();
                            }

                            newTile = creator.CreateTile(calculatedLocation[0], calculatedLocation[1]);
                        }
                        else if (element == "T")
                        {
                            TileCreator creator = new TrapCreator();
                            newTile = creator.CreateTile(calculatedLocation[0], calculatedLocation[1]);
                        }
                        else if (element == ".")
                        {
                            TileCreator creator = new NoTileCreator(tileColor);
                            newTile = creator.CreateTile(calculatedLocation[0], calculatedLocation[1]);
                            _numberOfNoTile++;
                        }
                        else
                        {
                            newTile = new NoTile(calculatedLocation[0], calculatedLocation[1], tileColor);
                            _numberOfNoTile++;
                            GameObject? obj = null;
                            List<Bitmap> tempImg = new List<Bitmap> { };

                            if (element == "x")
                            {
                                obj = new Heart("heart", calculatedLocation[0], calculatedLocation[1]);
                            }
                            else if (element == ":")
                            {
                                _player = new Player("player", calculatedLocation[0], calculatedLocation[1]);
                            }
                            else if (element == "B")
                            {
                                obj = new Bat("bat", calculatedLocation[0], calculatedLocation[1], "horizontal");
                            }
                            else if (element == "b")
                            {
                                obj = new Bat("bat", calculatedLocation[0], calculatedLocation[1], "vertical");
                            }

                            if (obj != null)
                            {
                                _objects.Add(obj);
                            }
                        }

                        _tiles.Add(newTile);
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }

        //Method to update player location
        public void MovePlayer()
        {
            Tuple<float, float> value = _directionValue[_player.Way];
            _player.Blocked = Solid(_player.X + value.Item1, _player.Y + value.Item2, true);

            if (!Solid(_player.X + value.Item1, _player.Y + value.Item2, true))
            {
                int tileIndex = TileLocationCalculation(_player.X, _player.Y);

                if (_tiles[tileIndex] is NoTile tile)
                {
                    if (!tile.Painted)
                    {
                        tile.Paint();
                        _numberOfNoTile -= 1;
                    }
                }
            }

            ICommand movePlayer = new PlayerMoveCommand(_player, 1f, 1f);
            _invoker = new CommandInvoker(movePlayer);
            _invoker.ExecuteCommand();
        }

        //Method to update bat location
        private void UpdateBat(Bat batObj)
        {
            Tuple<float, float> value = _directionValue[batObj.Way];

            if (Solid(batObj.X + value.Item1, batObj.Y + value.Item2, false))
            {
                batObj.Way = _batValue.FirstOrDefault(x => x.Value == 5 - _batValue[batObj.Way]).Key;
            }

            ICommand moveBat = new BatMoveCommand(batObj, 0.05f, 0.05f);
            _invoker = new CommandInvoker(moveBat);
            _invoker.ExecuteCommand();
        }

        //Method to update map
        public void UpdateMap()
        {
            CheckWin();

            CheckTrap();

            //Update player
            if (!Player.Blocked)
            {
                MovePlayer();
            }
            else
            {
                if (SplashKit.KeyReleased(KeyCode.WKey))
                {
                    Player.Way = "up";
                    MovePlayer();
                }
                if (SplashKit.KeyReleased(KeyCode.AKey))
                {
                    Player.Way = "left";
                    MovePlayer();
                }
                if (SplashKit.KeyReleased(KeyCode.DKey))
                {
                    Player.Way = "right";
                    MovePlayer();
                }
                if (SplashKit.KeyReleased(KeyCode.SKey))
                {
                    Player.Way = "down";
                    MovePlayer();
                }
            }

            //Update bat
            foreach (GameObject obj in _objects)
            {
                if (obj is Bat batObj)
                {
                    UpdateBat(batObj);
                }
            }

            //Check collision
            CollisionDetection();

            RandomlyAddHeart();
        }

        //Method to draw the map
        public override void Show()
        {
            foreach (Tile tile in _tiles)
            {
                tile.Draw();
            }

            foreach (GameObject obj in _objects)
            {
                obj.Draw();
            }

            _player.Draw();

            SplashKit.DrawText("Stage: " + _stage, Color.White, "Arial", 20, 10, 625);
            SplashKit.DrawText("Time: " + _time, Color.White, "Arial", 20, 10, 650);
            SplashKit.DrawText("Lives remaining: " + _player.HeartCount, Color.White, "Arial", 20, 10, 675);
        }

        //Method to check if the player move through a trap
        private void CheckTrap()
        {
            Solid(_player.X - 1, _player.Y, true);
            Solid(_player.X + 50, _player.Y, true);
            Solid(_player.X, _player.Y - 1, true);
            Solid(_player.X, _player.Y + 50, true);
        }

        //Method to check if 2 objects collide
        private void CollisionDetection()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                GameObject obj = _objects[i];

                if ((Math.Abs(_player.X - obj.X) <= 30) && (Math.Abs(_player.Y - obj.Y) <= 30))
                {
                    if (obj.Name == "bat")
                    {
                        if (_player.HeartCount < 0)
                        {
                            _lose = true;
                        }
                        else
                        {
                            if (!_player.IsImmune)
                            {
                                _player.HeartCount -= 1;
                                _player.BeImmune();
                            }
                        }
                    }
                    else if (obj.Name == "heart")
                    {
                        Player.HeartCount++;
                        _objects.RemoveAt(i);
                    }
                }
            }
        }

        //Method to check if the player wins
        private void CheckWin()
        {
            // Update time
            _time = (int)(_timer.Ticks / 1000);

            // Check if the map is finished
            if (!_isFinished && _numberOfNoTile == 0)
            {
                _isFinished = true;
                _win = true;
                _elapsedTime = _time;
            }
            else if (_lose && !_isFinished)
            {
                _isFinished = true;
                _win = false;
                _elapsedTime = _time;
            }
        }

        //Method to increment player's heart count
        private void RandomlyAddHeart()
        {
            Random random = new Random();

            if (random.Next(100000) == 0)
            {
                List<NoTile> noTileTiles = _tiles.OfType<NoTile>().ToList();
                if (noTileTiles.Count > 0)
                {
                    NoTile randomNoTile = noTileTiles[random.Next(noTileTiles.Count)];
                    float x = randomNoTile.X;
                    float y = randomNoTile.Y;
                    Heart heart = new Heart("heart", x, y);
                    _objects.Add(heart);
                }
            }
        }

        //Property

        public Player Player
        {
            get { return _player; }
        }

        public int Stage
        {
            set { _stage = value; }
        }

        public bool IsFinished
        {
            get { return _isFinished; }
            set { _isFinished = value; }
        }

        public bool Win
        {
            get { return _win; }
            set { _win = value; }
        }

        public int ElapsedTime
        {
            get { return _elapsedTime; }
            set { _elapsedTime = value; }
        }
    }
}

