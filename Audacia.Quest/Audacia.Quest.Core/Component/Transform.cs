using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core.Components
{
    public class Transform
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Vector2 Rotation { get; set; } = Vector2.Zero;

        public void Move(Vector2 other)
        {
            Position = other;
        }

        public void MoveX(float x)
        {
            var pos = new Vector2(Position.X + x, Position.Y);
            Position = pos;
        }

        public void MoveY(float y)
        {
            var pos = new Vector2(Position.X, Position.Y + y);
            Position = pos;
        }
    }
}
