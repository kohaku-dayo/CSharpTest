using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniEx
{

    public struct Vector2 : IEquatable<Vector2>, IFormattable
    {
        public double x;
        public double y;

        #region Static Readonly Func

        private static readonly Vector2 zeroVector = new Vector2(0d, 0d);
        private static readonly Vector2 oneVector = new Vector2(1d, 1d);
        private static readonly Vector2 upVector = new Vector2(0d, 1d);
        private static readonly Vector2 downVector = new Vector2(0d, -1d);
        private static readonly Vector2 leftVector = new Vector2(-1d, 0d);
        private static readonly Vector2 rightVector = new Vector2(1d, 0d);
        private static readonly Vector2 positiveInfinityVector = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
        private static readonly Vector2 negativeInfinityVector = new Vector2(double.NegativeInfinity, double.NegativeInfinity);
        public static Vector2 zero => zeroVector;
        public static Vector2 one => oneVector;
        public static Vector2 up => upVector;
        public static Vector2 down => downVector;
        public static Vector2 left => leftVector;
        public static Vector2 right => rightVector;
        public static Vector2 positiveInfinity => positiveInfinityVector;
        public static Vector2 negativeInfinity => negativeInfinityVector;

        #endregion

        public double this[int index]
        {
            get => index switch
            {
                0 => x,
                1 => y,
                _ => throw new IndexOutOfRangeException("Invalid Vector2 index!")
            };
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: throw new IndexOutOfRangeException("Invalid Vector2 index!");
                }
            }
        }

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        bool IEquatable<Vector2>.Equals(Vector2 other) => x == other.x && y == other.y;
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2)) return false;
            return Equals((Vector2)obj);
        }

        #region operators

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - a.y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / a.y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * a.y);
        public static Vector2 operator *(Vector2 a, double d) => new Vector2(a.x * d, a.y * d);
        public static Vector2 operator *(double d, Vector2 a) => new Vector2(a.x * d, a.y * d);
        public static Vector2 operator /(Vector2 a, double d) => new Vector2(a.x / d, a.y / d);
        public static bool operator ==(Vector2 left, Vector2 right) => left.Equals(right);
        public static bool operator !=(Vector2 left, Vector2 right) => !(left == right);

        public static implicit operator Vector2(Vector3 v) => new Vector2(v.x, v.y);
        public static implicit operator Vector3(Vector2 v) => new Vector3(v.x, v.y, 0d);

        #endregion

        public override int GetHashCode() => new { x, y }.GetHashCode();
        public override string ToString() => ToString(null, null);
        public string ToString(string format) => ToString(format, null);
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "F1";
            if (formatProvider == null) formatProvider = CultureInfo.InvariantCulture.NumberFormat;
            return string.Format("({0}{1})", x.ToString(format, formatProvider), y.ToString(format, formatProvider));
        }
    }

    public struct Vector3 : IEquatable<Vector3>, IFormattable
    {
        public double x;
        public double y;
        public double z;

        #region Static Readonly Func

        private static readonly Vector3 zeroVector = new Vector3(0d, 0d, 0d);
        private static readonly Vector3 oneVector = new Vector3(1d, 1d, 1d);
        private static readonly Vector3 upVector = new Vector3(0d, 1d, 0d);
        private static readonly Vector3 downVector = new Vector3(0d, -1d, 0d);
        private static readonly Vector3 leftVector = new Vector3(-1d, 0d, 0d);
        private static readonly Vector3 rightVector = new Vector3(1d, 0d, 0d);
        private static readonly Vector3 fowardVector = new Vector3(1d, 0d, 1d);
        private static readonly Vector3 backVector = new Vector3(1d, 0d, -1d);
        private static readonly Vector3 positiveInfinityVector = new Vector3(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
        private static readonly Vector3 negativeInfinityVector = new Vector3(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);
        public static Vector3 zero => zeroVector;
        public static Vector3 one => oneVector;
        public static Vector3 up => upVector;
        public static Vector3 down => downVector;
        public static Vector3 left => leftVector;
        public static Vector3 right => rightVector;
        public static Vector3 foward => fowardVector;
        public static Vector3 back => backVector;
        public static Vector3 positiveInfinity => positiveInfinityVector;
        public static Vector3 negativeInfinity => negativeInfinityVector;

        #endregion

        public double this[int index]
        {

            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.z = 0d;
        }

        bool IEquatable<Vector3>.Equals(Vector3 other) => x == other.x && y == other.y && z == other.z;
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3)) return false;
            return Equals((Vector3)obj);
        }

        #region operators

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - a.y, a.z - b.z);
        public static Vector3 operator /(Vector3 a, Vector3 b) => new Vector3(a.x / b.x, a.y / a.y, a.z / b.z);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * a.y, a.z * b.z);
        public static Vector3 operator *(Vector3 a, double d) => new Vector3(a.x * d, a.y * d, a.z * d);
        public static Vector3 operator *(double d, Vector3 a) => new Vector3(a.x * d, a.y * d, a.z * d);
        public static Vector3 operator /(Vector3 a, double d) => new Vector3(a.x / d, a.y / d, a.z / d);
        public static bool operator ==(Vector3 left, Vector3 right) => left.Equals(right);
        public static bool operator !=(Vector3 left, Vector3 right) => !(left == right);

        #endregion

        public override int GetHashCode() => new { x, y, z }.GetHashCode();

        public override string ToString() => ToString(null, null);
        public string ToString(string format) => ToString(format, null);
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "F1";
            if (formatProvider == null) formatProvider = CultureInfo.InvariantCulture.NumberFormat;
            return string.Format("({0}{1}{2})", x.ToString(format, formatProvider), y.ToString(format, formatProvider), z.ToString(format, formatProvider));
        }
    }

}
