using _2DGame.Engine;
using _2DGame.GameObjects;
using _2DGame.LevelObjects;
using _2DGame.LevelObjects.Enemies;
using System;
using System.Collections.Generic;
using System.IO;

namespace _2DGame.Levels
{
    class Level : GameObjectList
    {
        private int amountOfEnemies;
        private int maxAmountOfEnemies;
        private int enemiesToWin;
        private DateTime enemiesTime;
        private float coolDown = 5.0f;
        private bool isNewGame = false;

        public const int TileWidth = 32;
        public const int TileHeight = 32;

        public Tile[,] Tiles { get; private set; }
        private List<Point> enemiesStaringPoint;

        public Player Player { get; private set; }
        public int LevelIndex { get; private set; }

        bool completionDetected;

        public Level(int levelIndex, string filename)
        {
            LevelIndex = levelIndex;

            amountOfEnemies = 0;
            maxAmountOfEnemies = 20;// i need load it from file as a description
            enemiesToWin = maxAmountOfEnemies;

            this.enemiesStaringPoint = new List<Point>();

            LoadLevelFromFile(filename);
        }

        void LoadLevelFromFile(string filename)
        {
            // open the file
            StreamReader reader = new StreamReader(filename);

            // read the description
            string description = reader.ReadLine();

            // read the rows of the grid; keep track of the longest row
            int gridWidth = 0;

            List<string> gridRows = new List<string>();
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line.Length > gridWidth)
                    gridWidth = line.Length;

                gridRows.Add(line);
                line = reader.ReadLine();
            }

            // stop reading the file
            reader.Close();

            // create all game objects for the grid
            AddPlayingField(gridRows, gridWidth, gridRows.Count);

            // add game objects to show that general level info
            //AddLevelInfoObjects(description);
        }

        void AddPlayingField(List<string> gridRows, int gridWidth, int gridHeight)
        {
            // create a parent object for everything
            GameObjectList playingField = new GameObjectList();

            // prepare the grid arrays
            Tiles = new Tile[gridWidth, gridHeight];

            // load the tiles
            for (int y = 0; y < gridHeight; y++)
            {
                string row = gridRows[y];
                for (int x = 0; x < gridWidth; x++)
                {
                    // the row could be too short; if so, pretend there is an empty tile
                    char symbol = '.';
                    if (x < row.Length)
                        symbol = row[x];

                    // load the tile
                    AddTile(x, y, symbol);
                }
            }
        }

        void AddTile(int x, int y, char symbol)
        {
            // load the static part of the tile
            Tile tile = CharToStaticTile(symbol);
            tile.LocalPosition = GetCellPosition(x, y);
            AddChild(tile);

            // store a reference to that tile in the grid
            Tiles[x, y] = tile;

            // load the dynamic part of the tile
            if (symbol == '1')
                LoadCharacter(x, y);
            else if (symbol == 'A')
            {
                if (!enemiesStaringPoint.Contains(new Point(x, y)))
                {
                    enemiesStaringPoint.Add(new Point(x, y));
                }
            }
        }

        Tile CharToStaticTile(char symbol)
        {
            switch (symbol)
            {
                case '-':
                    return new Tile(Tile.Type.Platform, Tile.SurfaceType.Normal);
                default:
                    return new Tile(Tile.Type.Empty, Tile.SurfaceType.Normal);
            }
        }

        Point GetCellBottomCenter(int x, int y)
        {
            return GetCellPosition(x, y + 1) + new Point(TileWidth / 2, 0);
        }

        public Point GetCellPosition(int x, int y)
        {
            return new Point(x * TileWidth, y * TileHeight);
        }

        void LoadCharacter(int x, int y)
        {
            // create the character
            Player = new Player(this, GetCellBottomCenter(x, y));
            AddChild(Player);
        }

        private void LoadFallowingEnemy(int x, int y)
        {
            FallowingEnemy enemy = new FallowingEnemy(this, GetCellBottomCenter(x, y));
            AddChild(enemy);
            amountOfEnemies++;
        }

        public override void Update(float currentFps)
        {
            base.Update(currentFps);

            if (enemiesToWin == 0)
            {
                GameManager.Instance.GameOver();
            }

            if (DateTime.Now > enemiesTime.AddSeconds(coolDown) || this.isNewGame)
            {
                enemiesTime = DateTime.Now;
                if (amountOfEnemies < maxAmountOfEnemies)
                {
                    foreach (Point item in enemiesStaringPoint)
                    {
                        LoadFallowingEnemy((int)item.X, (int)item.Y);
                    }
                }

                this.isNewGame = false;
            }

            List<GameObject> objectsToDelete = new List<GameObject>();

            foreach (var item in this.GetChildrens())
            {
                if (!item.Visible)
                {
                    objectsToDelete.Add(item);
                }
            }

            foreach (var item in objectsToDelete)
            {
                if (item is FallowingEnemy)
                {
                    enemiesToWin--;
                }
                this.RemoveChild(item);
            }
        }

        public override void Reset()
        {
            base.Reset();

            List<GameObject> fallowingEnemies = new List<GameObject>();

            amountOfEnemies = 0;
            enemiesToWin = maxAmountOfEnemies;
            foreach (var item in this.GetChildrens())
            {
                if (item is FallowingEnemy)
                {
                    fallowingEnemies.Add(item);
                }
            }

            foreach (var item in fallowingEnemies)
            {
                this.GetChildrens().Remove(item);
            }

            this.isNewGame = true;
        }
    }
}
