using _2DGame.GameObjects;
using System.Drawing;

namespace _2DGame.GameStates
{
    abstract class GameState : IGameLoopObject
    {
        protected GameObjectList gameObjects;

        public GameState()
        {
            gameObjects = new GameObjectList();
        }

        public virtual void Draw(Graphics graphics)
        {
            gameObjects.Draw(graphics);
        }

        public virtual void Reset()
        {
            gameObjects.Reset();
        }

        public virtual void Update(float currentFps)
        {
            gameObjects.Update(currentFps);
        }
    }
}
