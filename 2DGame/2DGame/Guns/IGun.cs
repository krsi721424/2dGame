using Shooter.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.Guns
{
    interface IGun
    {
        void Update(Level level, Levels.LevelObjects.Player player);
        void Draw(Graphics graphics);
    }
}
