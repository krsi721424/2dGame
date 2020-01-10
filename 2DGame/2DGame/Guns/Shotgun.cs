using System;
using System.Drawing;
using _2DGame.LevelObjects;
using _2DGame.Levels;

namespace _2DGame.Guns
{
    internal class Shotgun : IGun
    {
        private DateTime shootTime;
        private bool canShoot;
        private float coolDown = 1;

        public Shotgun(int x, int y)
        {
            this.canShoot = true;
        }

        public void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public void Update(Level level, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
