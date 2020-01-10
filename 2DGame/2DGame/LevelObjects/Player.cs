using _2DGame.Engine;
using _2DGame.Guns;
using _2DGame.LevelObjects.Animation;
using _2DGame.LevelObjects.Enemies;
using _2DGame.Levels;
using _2DGame.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace _2DGame.LevelObjects
{
    class Player : AnimatedGameObject
    {
        const float walkingSpeed = 150; // Standard walking speed.

        Level level;
        Engine.Point startPosition;
        IGun gun;

        public bool IsAlive { get; private set; }

        public Player(Level level, Engine.Point startPosition) 
            : base()
        {
            this.level = level;
            this.startPosition = startPosition;            

            // load all animations
            LoadAnimation(Resources.test, "idle", true, 0.1f); //TODO change path to general

            this.Rectangle = new Rectangle(0, 0, 32, 32);           

            Reset();
        }

        public override void Reset()
        {
            // go back to the starting position
            LocalPosition = startPosition;
            velocity = Engine.Point.Zero;

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
            Origin = new Engine.Point(sprite.Width / 2, sprite.Height);
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
            Engine.Point previousPosition = LocalPosition;

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
                velocity = Engine.Point.Zero;

                this.gun.Update(this.level, this);
            }

        }

        public void Die()
        {
            IsAlive = false;
            // stop moving
            velocity = Engine.Point.Zero;

            GameManager.Instance.GameOver();
        }
    }
}
