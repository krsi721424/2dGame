using _2DGame.Levels;
using _2DGame.Properties;
using System.Drawing;

namespace _2DGame.GameStates.States
{
    class PlayingState : GameState
    {
        Level level;

        public PlayingState(int level)
        {
            LoadLevel(level);
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            if(level != null)
            {
                level.Draw(graphics);
            }
        }

        public override void Update(float currentFps)
        {
            base.Update(currentFps);
            if (level != null)
            {
                level.Update(currentFps);
            }
        }

        public override void Reset()
        {
            base.Reset();
            if (level != null)
            {
                level.Reset();
            }
        }

        public void LoadLevel(int level)
        {
            this.level = new Level(1, $@"C:\Users\bezimienny\Desktop\Nowy folder\2dGame\2DGame\2DGame\Resources\level{level}.txt");
        }

    }
}
