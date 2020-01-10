using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public static Point Zero { get { return new Point(0, 0); } }

        public Point(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point(int size)
        {
            this.X = size;
            this.Y = size;
        }

        private float Length()
        {
            return (float)Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }

        public void Normalize()
        {
            float length = Length();
            if(length > 0)
            {
                this.X = (this.X / length);
                this.Y = (this.Y / length);
            }
            
        }

        public static Point operator +(Point value1, Point value2)
        {
            return new Point(value1.X + value2.X, value1.Y + value2.Y);
        }

        public static Point operator +(Point value1, int value2)
        {
            return new Point(value1.X + value2, value1.Y + value2);
        }

        public static Point operator -(Point value1, Point value2)
        {
            return new Point(value1.X - value2.X, value1.Y - value2.Y);
        }

        public static Point operator *(Point value1, float value2)
        {
            return new Point((int)(value1.X * value2), (int)(value1.Y * value2));
        }

        public static Point operator /(Point value1, int value2)
        {
            return new Point((int)(value1.X / value2), (int)(value1.Y / value2));
        }
    }
}
