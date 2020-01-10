using _2DGame.GameObjects;
using System.Collections.Generic;
using System.Drawing;

namespace _2DGame.GameStates
{
    class GameStateManager : IGameLoopObject
    {
        private Dictionary<string, GameState> gameStates;

        private GameState currentState;

        public GameStateManager()
        {
            gameStates = new Dictionary<string, GameState>();
            currentState = null;
        }

        public void AddGameState(string name, GameState state)
        {
            gameStates[name] = state;
        }

        public GameState GetGameState(string name)
        {
            if (gameStates.ContainsKey(name))
            {
                return gameStates[name];
            }

            return null;
        }

        public void SwitchTo(string name)
        {
            if(gameStates.ContainsKey(name))
            {
                currentState = gameStates[name];
            }
        }

        public void Draw(Graphics graphics)
        {
            if(currentState != null)
            {
                currentState.Draw(graphics);
            }
        }

        public void Reset()
        {
            if (currentState != null)
            {
                currentState.Reset();
            }
        }

        public void Update(float currentFps)
        {
            if (currentState != null)
            {
                currentState.Update(currentFps);
            }
        }
    }
}
