using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Engine
{
    interface IMovable
    {
        Point Velocity { get; set; }        
    }
    enum Direction
    {
        Up,
        Left,
        Right,
        Down,
        DiagonalLeft,
        DiagonalRight,
        DiagonalTop,
        DiagonalDown
    }
}
