using System.Drawing;

namespace _2DGame.GameObjects
{
    interface IGameLoopObject
    {
        void Update(float currentFps);

        void Draw(Graphics graphics);

        void Reset();
    }
}
