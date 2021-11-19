﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core.Core
{
    public class Transform
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Vector2 Rotation { get; set; } = Vector2.Zero;
    }
}
