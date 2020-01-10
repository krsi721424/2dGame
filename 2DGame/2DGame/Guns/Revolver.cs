using _2DGame.Engine;
using _2DGame.GameObjects;
using _2DGame.LevelObjects;
using _2DGame.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2DGame.Guns
{
    internal class Revolver : GameObjectList, IGun
    {
        private DateTime shootTime;
        private bool canShoot;
        private float coolDown = 0.3f;
        private int bullets = 6;

        public Revolver(int x, int y)
            :this()
        {            
        }

        public Revolver()
        {
            this.canShoot = true;
        }

        public override void Update(float currentFps)
        {
            base.Update(currentFps);
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            
            if(!(this.coolDown == 3))
            {
                graphics.DrawString(bullets.ToString(), drawFont, drawBrush, new PointF(50, 50));
            }
            else
            {
                graphics.DrawString("Reloading", drawFont, drawBrush, new PointF(50, 50));
            }
        }

        private void ShootCoolDown()
        {            
            if (!canShoot && DateTime.Now > shootTime.AddSeconds(coolDown))
            {             
                canShoot = true;
                this.coolDown = 0.3f;
            }
        }

        private void Shoot(Level level, Player player, Direction dir)
        {
            if (canShoot)
            {
                this.shootTime = DateTime.Now;
                this.canShoot = false;
                this.bullets--;

                if (bullets == 0)
                {
                    this.bullets = 6;
                    this.coolDown = 3;
                }

                this.AddChild(new Bullet((int)player.LocalPosition.X, (int)player.LocalPosition.Y, dir, level));
            }
        }

        public void Update(Level level, Player player)
        {
            #region i need to change this, this is very ugly
            if (UserInputController.KeyPressed(Keys.Up))
            {
                this.Shoot(level, player, Direction.Up);
            }
            else if (UserInputController.KeyPressed(Keys.Down))
            {
                this.Shoot(level, player, Direction.Down);
            }
            else if (UserInputController.KeyPressed(Keys.Left))
            {
                this.Shoot(level, player, Direction.Left);
            }
            else if (UserInputController.KeyPressed(Keys.Right))
            {
                this.Shoot(level, player, Direction.Right);
            }
            #endregion

            this.Update(60);

            ShootCoolDown();

            List<GameObject> objectsToDelete = new List<GameObject>();

            foreach (var item in this.GetChildrens())
            {
                if (!item.Visible)
                {
                    objectsToDelete.Add(item);
                }
            }

            foreach (var item in objectsToDelete)
            {
                this.RemoveChild(item);
            }
        }
    }
}
