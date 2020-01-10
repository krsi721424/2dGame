using Shooter.Guns;
using Shooter.Levels.LevelObjects.Animation;
using Shooter.Levels.LevelObjects.Enemies;
using Shooter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter.Levels.LevelObjects
{
    class Player : AnimatedGameObject
    {
        const float walkingSpeed = 150; // Standard walking speed.

        Level level;
        Point startPosition;
        IGun gun;

        public bool IsAlive { get; private set; }

        public Player(Level level, Point startPosition) 
            : base()
        {
            this.level = level;
            this.startPosition = startPosition;            

            // load all animations
            LoadAnimation(@"F:\Projekty\Shooter\shooter2\Shooter\Resources\test.png", "idle", true, 0.1f); //TODO change path to general
            //LoadAnimation("Sprites/LevelObjects/Player/spr_run@13", "run", true, 0.04f);
            //LoadAnimation("Sprites/LevelObjects/Player/spr_jump@14", "jump", false, 0.08f);
            //LoadAnimation("Sprites/LevelObjects/Player/spr_celebrate@14", "celebrate", false, 0.05f);
            //LoadAnimation("Sprites/LevelObjects/Player/spr_die@5", "die", true, 0.1f);
            //LoadAnimation("Sprites/LevelObjects/Player/spr_explode@5x5", "explode", false, 0.04f);

            this.Rectangle = new Rectangle(0, 0, 32, 32);           

            Reset();
        }

        public override void Reset()
        {
            // go back to the starting position
            LocalPosition = startPosition;
            velocity = Point.Zero;

            this.gun = new Revolver();

            // start with the idle sprite
            PlayAnimation("idle", true);

            IsAlive = true;
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            this.gun.Draw(graphics);
        }

        void SetOriginToBottomCenter()
        {
            Origin = new Point(sprite.Width / 2, sprite.Height);
        }

        #region Move
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
        #endregion

        public override void Update(float currentFps)
        {
            Point previousPosition = LocalPosition;

            if (UserInputController.KeyPressed(Keys.D))
                this.MoveRight();
            if (UserInputController.KeyPressed(Keys.A))
                this.MoveLeft();
            if (UserInputController.KeyPressed(Keys.W))
                this.MoveUp();
            if (UserInputController.KeyPressed(Keys.S))
                this.MoveDown();

            foreach (var item in level.GetChildrens())
            {
                if(item is FallowingEnemy)
                {
                    if(this.BoundingBox.IntersectsWith(item.Rectangle))
                    {
                        this.Die();
                    }                   
                }

                if(item is Tile)
                {                    
                    if (this.velocity.X > 0 && Collision.IsTouchingLeft(this.velocity, this.BoundingBox, item))
                    {
                        this.velocity.X = 0;
                    }

                    if (this.velocity.X < 0 && Collision.IsTouchingRight(this.velocity, this.BoundingBox, item))
                    {
                        this.velocity.X = 0;
                    }

                    if (this.velocity.Y < 0 && Collision.IsTouchingBottom(this.velocity, this.BoundingBox, item))
                    {
                        this.velocity.Y = 0;
                    }

                    if (this.velocity.Y > 0 && Collision.IsTouchingTop(this.velocity, this.BoundingBox, item))
                    {
                        this.velocity.Y = 0;
                    }
                }
            }

            base.Update(currentFps);

            if (IsAlive)
            {
                LocalPosition += (velocity * walkingSpeed) * (1 / currentFps);
                velocity = Point.Zero;

                this.gun.Update(this.level, this);
            }

        }

        //Rectangle BoundingBoxForCollisions
        //{
        //    get
        //    {
        //        Rectangle bbox = BoundingBox;
        //        // adjust the bounding box
        //        bbox.X += 20;
        //        bbox.Width -= 40;
        //        bbox.Height += 1;

        //        return bbox;
        //    }
        //}

        public void Die()
        {
            IsAlive = false;
            // stop moving
            velocity = Point.Zero;

            GameManager.Instance.GameOver();
        }
    }
}
