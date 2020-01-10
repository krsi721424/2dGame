using System.Drawing;

namespace _2DGame.GameObjects
{
    class GameObject : IGameLoopObject
    {
        public Engine.Point LocalPosition { get; set; }

        protected float speed;

        protected Engine.Point velocity;

        public Rectangle Rectangle { get; set; }

        public bool Visible { get; set; }

        public GameObject Parent { get; set; }

        public GameObject()
        {
            LocalPosition = Engine.Point.Zero;
            velocity = Engine.Point.Zero;
            speed = 0;
            Visible = true;
        }

        public virtual void Draw(Graphics graphics)
        {
        }

        public virtual void Reset()
        {
            velocity = Engine.Point.Zero;
        }

        public virtual void Update(float currentFps)
        {
            LocalPosition += (velocity * speed) * (1 / currentFps);                    
        }

        public Engine.Point GlobalPosition
        {
            get
            {
                if (Parent == null)
                    return LocalPosition;
                return LocalPosition + Parent.GlobalPosition;
            }
        }
    }
}
