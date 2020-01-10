using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.GameObjects
{
    interface IGameLoopObject
    {
        void Update(float currentFps);

        void Draw(Graphics graphics);

        void Reset();
    }
}
