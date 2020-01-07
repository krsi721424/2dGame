using Shooter.GameObjects;
using Shooter.Levels;
using Shooter.Levels.LevelObjects.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter
{
    class Bullet : GameObject
    {
        public Point Velocity { get; set; }
        private Direction direction;
        private Level level;

        public Bullet(int x, int y, Direction direction, Level level)
        {
            this.LocalPosition = new Point(x + 11, y + 11);
            this.speed = 80;
            this.velocity = Point.Zero;
            this.direction = direction;
            this.level = level;
        }

        public override void Update(float currentFps)
        {
            switch (direction)
            {
                case Direction.Up:
                    {
                        this.MoveUp();
                    }
                    break;
                case Direction.Left:
                    {
                        this.MoveLeft();
                    }
                    break;
                case Direction.Right:
                    {
                        this.MoveRight();
                    }
                    break;
                case Direction.Down:
                    {
                        this.MoveDown();
                    }
                    break;
                case Direction.DiagonalRight:
                    {
                        this.MoveDown();
                        this.MoveRight();
                    }
                    break;
                case Direction.DiagonalDown:
                    {
                        this.MoveDown();
                        this.MoveLeft();
                    }
                    break;
                case Direction.DiagonalTop:
                    {
                        this.MoveUp();
                        this.MoveRight();
                    }
                    break;
                case Direction.DiagonalLeft:
                    {
                        this.MoveUp();
                        this.MoveLeft();
                    }
                    break;
            }

            base.Update(currentFps);

            this.Rectangle = new Rectangle((int)LocalPosition.X, (int)LocalPosition.Y, 8, 8);

            foreach (var item in level.GetChildrens())
            {
                if(item is FallowingEnemy)
                {
                    if(this.Rectangle.IntersectsWith(item.Rectangle))
                    {
                        this.Visible = false;
                        item.Visible = false;
                    }
                }
            }
        }

        public override void Draw(Graphics canvas)
        {
            canvas.FillEllipse(Brushes.Black, this.LocalPosition.X, this.LocalPosition.Y, 8, 8);
        }

        public void MoveLeft()
        {
            this.velocity.X--;
        }

        public void MoveRight()
        {
            this.velocity.X++;
        }

        public void MoveUp()
        {
            this.velocity.Y--;
        }

        public void MoveDown()
        {
            this.velocity.Y++;
        }
    }
}
