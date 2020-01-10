using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shooter.Levels;
using Shooter.Levels.LevelObjects;

namespace Shooter.Guns
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

        public void Update(Level level, Levels.LevelObjects.Player player)
        {
            throw new NotImplementedException();
        }

        //public void Shoot(IList<Sprite> sprites, Direction direction, Point position)
        //{
        //    if (canShoot)
        //    {
        //        this.shootTime = DateTime.Now;
        //        this.canShoot = false;

        //        switch (direction)
        //        {
        //            case Direction.Up:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalTop));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Up));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalLeft));
        //                }
        //                break;
        //            case Direction.Left:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalDown));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Left));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalLeft));
        //                }
        //                break;
        //            case Direction.Right:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalTop));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Right));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalRight));
        //                }
        //                break;
        //            case Direction.Down:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalDown));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Down));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalRight));
        //                }
        //                break;
        //            case Direction.DiagonalLeft:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Up));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Left));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalLeft));
        //                }
        //                break;
        //            case Direction.DiagonalRight:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Right));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Down));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalRight));
        //                }
        //                break;
        //            case Direction.DiagonalTop:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalTop));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Up));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Right));
        //                }
        //                break;
        //            case Direction.DiagonalDown:
        //                {
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.DiagonalDown));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Down));
        //                    sprites.Add(new Bullet((int)position.X, (int)position.Y, Direction.Left));
        //                }
        //                break;
        //        }
        //    }
        //}

        //public override void Update(PictureBox canvas, List<Sprite> sprites, float currentFps)
        //{
        //    base.Update(canvas, sprites, currentFps);

        //    ShootCoolDown();
        //}

        //private void ShootCoolDown()
        //{
        //    if (!canShoot && DateTime.Now > shootTime.AddSeconds(coolDown))
        //    {
        //        canShoot = true;
        //    }
        //}
    }
}
