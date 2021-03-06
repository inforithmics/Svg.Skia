﻿using System;

namespace Svg.Model.Primitives
{
    public readonly struct PointI
    {
        public int X { get; }
        public int Y { get; }

        public static readonly PointI Empty;

        public readonly bool IsEmpty => X == default && Y == default;

        public PointI(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            return FormattableString.Invariant($"{X}, {Y}");
        }
    }
}
