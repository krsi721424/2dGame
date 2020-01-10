using _2DGame.LevelObjects;
using _2DGame.Levels;
using System.Drawing;

namespace _2DGame.Guns
{
    interface IGun
    {
        void Update(Level level, Player player);
        void Draw(Graphics graphics);
    }
}
