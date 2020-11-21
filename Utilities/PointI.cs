using System;
using System.Diagnostics;
using Zen.Utilities.ExtensionMethods;

namespace Zen.Utilities
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [Serializable]
    public readonly struct PointI
    {
        #region State
        public int X { get; }
        public int Y { get; }
        #endregion

        public PointI(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static PointI Empty => new PointI(0, 0);
        public static PointI Zero => new PointI(0, 0);

        public static PointI Lerp(PointI start, PointI end, float t)
        {
            var x = (1 - t) * start.X + t * end.X;
            var y = (1 - t) * start.Y + t * end.Y;
            var p = new PointI(x.Round(), y.Round());

            return p;
        }

        #region Overrides and Overloads

        public override bool Equals(object obj)
        {
            return obj is PointI point && this == point;
        }

        public static bool operator == (PointI a, PointI b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator != (PointI a, PointI b)
        {
            return !(a == b);
        }

        public static PointI operator + (PointI a, PointI b)
        {
            return new PointI(a.X + b.X, a.Y + b.Y);
        }

        public static PointI operator - (PointI a, PointI b)
        {
            return new PointI(a.X - b.X, a.Y - b.Y);
        }

        public static PointI operator * (PointI a, PointI b)
        {
            return new PointI(a.X * b.X, a.Y * b.Y);
        }

        public static PointI operator * (PointI a, int scalar)
        {
            return new PointI(a.X * scalar, a.Y * scalar);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay => $"{{X={X},Y={Y}}}";

        #endregion

    }
}