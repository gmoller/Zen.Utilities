using System;
using System.Diagnostics;
using Zen.Utilities.ExtensionMethods;

namespace Zen.Utilities
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [Serializable]
    public struct PointI : IComparable<PointI>
    {
        #region State
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        public PointI(int x, int y)
        {
            X = x;
            Y = y;
        }

        public PointI(string p)
        {
            var p2 = p.Replace("[", "");
            var p3 = p2.Replace("]", "");
            var split = p3.Split(';');
            X = Convert.ToInt32(split[0]);
            Y = Convert.ToInt32(split[1]);
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

        public int CompareTo(PointI p)
        {
            if (Y < p.Y)
            {
                return -1;
            }
            if (Y > p.Y)
            {
                return 1;
            }
            if (X < p.X)
            {
                return -1;
            }
            if (X > p.X)
            {
                return 1;
            }
            return 0;
        }

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