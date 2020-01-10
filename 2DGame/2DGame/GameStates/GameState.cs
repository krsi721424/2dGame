using Shooter.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.GameStates
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
