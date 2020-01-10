using _2DGame.Levels;
using _2DGame.PathFinding;
using _2DGame.GameObjects;
using System.Collections.Generic;
using System.Drawing;
using _2DGame.Properties;

namespace _2DGame.LevelObjects.Enemies
{
    class FallowingEnemy : Animation.AnimatedGameObject
    {
        public Stack<MatrixNode> Path { get; set; }
        protected Level level;
        Engine.Point startPosition;
        const float walkSpeed = 180;

        public FallowingEnemy(Level level, Engine.Point startPosition)
        {
            this.level = level;
            this.startPosition = startPosition;
            Path = new Stack<MatrixNode>();

            LoadAnimation(Resources.test, "idle", true, 0.1f);

            this.Reset();
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
        }

        public override void Update(float currentFps)
        {
            base.Update(currentFps);

            if (this.Path.Count == 0)
            {
                GameObject player = level.GetChildrens().Find(x => x is Player);

                MatrixNode endNode = MatrixNode.AStar(level.Tiles, (int)this.LocalPosition.X / 32, (int)this.LocalPosition.Y / 32, (int)player.LocalPosition.X / 32, (int)player.LocalPosition.Y / 32);

                //looping through the Parent nodes until we get to the start node
                this.Path = new Stack<MatrixNode>();
                if (endNode != null)
                {
                    while (endNode.x != (int)this.LocalPosition.X / 32 || endNode.y != (int)this.LocalPosition.Y / 32)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            this.Path.Push(endNode);
                        }

                        endNode = endNode.parent;
                    }
                    this.Path.Push(endNode);
                }
            }

            if (this.Path.Count > 0)
            {
                MatrixNode node = this.Path.Pop();
                this.MoveTo(node.x * 32, node.y * 32);
            }
            this.Rectangle = BoundingBox;
        }

        public override void Reset()
        {
            LocalPosition = startPosition;
            velocity = Engine.Point.Zero;

            // start with the idle sprite
            PlayAnimation("idle", true);
        }

        public void MoveTo(int X, int Y)
        {
            if (this.LocalPosition.X > X)
                this.MoveLeft();
            else if (this.LocalPosition.X < X)
                this.MoveRight();
            else if (this.LocalPosition.Y > Y)
                this.MoveUp();
            else if (this.LocalPosition.Y < Y)
                this.MoveDown();
        }

        public void MoveLeft()
        {
            this.LocalPosition.X--;
        }

        public void MoveRight()
        {
            this.LocalPosition.X++;
        }

        public void MoveUp()
        {
            this.LocalPosition.Y--;
        }

        public void MoveDown()
        {
            this.LocalPosition.Y++;
        }
    }
}
