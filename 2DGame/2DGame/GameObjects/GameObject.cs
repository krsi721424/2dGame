using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.GameObjects
{
    class GameObject : IGameLoopObject
    {
        public Point LocalPosition { get; set; }

        protected float speed;

        protected Point velocity;

        public Rectangle Rectangle { get; set; }

        public bool Visible { get; set; }

        public GameObject Parent { get; set; }

        public GameObject()
        {
            LocalPosition = Point.Zero;
            velocity = Point.Zero;
            speed = 0;
            Visible = true;
        }

        public virtual void Draw(Graphics graphics)
        {
        }

        public virtual void Reset()
        {
            velocity = Point.Zero;
        }

        public virtual void Update(float currentFps)
        {
            LocalPosition += (velocity * speed) * (1 / currentFps);                    
        }

        public Point GlobalPosition
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
