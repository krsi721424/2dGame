using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shooter.Levels;
using Shooter.Levels.LevelObjects;

namespace Shooter.GameStates.States
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
            this.level = new Level(1, $"level{level}.txt");
        }

    }
}
