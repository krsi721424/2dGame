using _2DGame.GameObjects;
using System.Drawing;
using System.Windows.Forms;

namespace _2DGame.Engine
{
    class Collision
    {
        public static bool IsTouchingLeft(Point velocity, Rectangle Rectangle, GameObject sprite2)
        {
            return Rectangle.Right + velocity.X > sprite2.Rectangle.Left &&
                Rectangle.Left < sprite2.Rectangle.Left &&
                Rectangle.Bottom > sprite2.Rectangle.Top &&
                Rectangle.Top < sprite2.Rectangle.Bottom;
        }

        public static bool IsTouchingRight(Point velocity, Rectangle Rectangle, GameObject sprite2)
        {
            return Rectangle.Left + velocity.X < sprite2.Rectangle.Right &&
                Rectangle.Right > sprite2.Rectangle.Right &&
                Rectangle.Bottom > sprite2.Rectangle.Top &&
                Rectangle.Top < sprite2.Rectangle.Bottom;
        }

        public static bool IsTouchingTop(Point velocity, Rectangle Rectangle, GameObject sprite2)
        {
            return Rectangle.Bottom + velocity.Y > sprite2.Rectangle.Top &&
                Rectangle.Top < sprite2.Rectangle.Top &&
                Rectangle.Right > sprite2.Rectangle.Left &&
                Rectangle.Left < sprite2.Rectangle.Right;
        }

        public static bool IsTouchingBottom(Point velocity, Rectangle Rectangle, GameObject sprite2)
        {
            return Rectangle.Top + velocity.Y < sprite2.Rectangle.Bottom &&
            Rectangle.Bottom > sprite2.Rectangle.Bottom &&
            Rectangle.Right > sprite2.Rectangle.Left &&
            Rectangle.Left < sprite2.Rectangle.Right;
        }

        public static Point CheckEndOfWindow(Point velocity, Point position, PictureBox canvas)
        {
            if (position.X + velocity.X > (canvas.Width-32)
                || position.X + velocity.X < 0)
            {
                velocity.X = 0;
            }
            else if (position.Y + velocity.Y > (canvas.Height-32)
                || position.Y + velocity.Y < 0)
            {
                velocity.Y = 0;
            }

            return velocity;
        }
    }
}
