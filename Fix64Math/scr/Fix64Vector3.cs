namespace Fix64Math
{
    public struct Fix64Vector3
    {

        public static Fix64Vector3 Up = new Fix64Vector3(0, 1, 0);
        public static Fix64Vector3 One = new Fix64Vector3(1, 1, 1);
        public static Fix64Vector3 Zero = new Fix64Vector3(0, 0, 0);

        public Fix64 X;
        public Fix64 Y;
        public Fix64 Z;

        public static Fix64Vector3 operator /(Fix64Vector3 a, Fix64 cs)
        {
            return new Fix64Vector3(a.X / cs, a.Y / cs, a.Z / cs);
        }

        public static Fix64Vector3 operator /(Fix64 cs, Fix64Vector3 a)
        {
            return new Fix64Vector3(cs / a.X, cs / a.Y, cs / a.Z);
        }

        public static Fix64Vector3 operator *(Fix64Vector3 a, Fix64 cs)
        {
            return new Fix64Vector3(a.X * cs, a.Y * cs, a.Z * cs);
        }


        public static Fix64Vector3 operator *(Fix64Vector3 a, int cs)
        {
            return new Fix64Vector3(a.X * (Fix64)cs, a.Y * (Fix64)cs, a.Z * (Fix64)cs);
        }

        public static Fix64Vector3 operator *(Fix64Vector3 a, Fix64Vector3 b)
        {
            return new Fix64Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static Fix64Vector3 operator -(Fix64Vector3 a, Fix64Vector3 cs)
        {
            return new Fix64Vector3(a.X - cs.X, a.Y - cs.Y, a.Z - cs.Z);
        }

        public static Fix64Vector3 operator -(Fix64Vector3 a)
        {
            return new Fix64Vector3(-a.X, -a.Y, -a.Z);
        }

        public static Fix64Vector3 operator +(Fix64Vector3 a, Fix64Vector3 cs)
        {
            return new Fix64Vector3(a.X + cs.X, a.Y + cs.Y, a.Z + cs.Z);
        }

        public static bool operator ==(Fix64Vector3 a, Fix64Vector3 b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(Fix64Vector3 a, Fix64Vector3 b)
        {
            return a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }
        public Fix64Vector3(int x, int y, int z)
        {
            X = new Fix64(x);
            Y = new Fix64(y);
            Z = new Fix64(z);
        }

        public Fix64Vector3(float x, float y, float z)
        {
            X = new Fix64(x);
            Y = new Fix64(y);
            Z = new Fix64(z);
        }

        public Fix64Vector3(Fix64 x, Fix64 y, Fix64 z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Fix64 Magnitude()
        {
            return Fix64.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        public Fix64Vector3 Nomalize()
        {
            return this / this.Magnitude();
        }

        public Fix64Vector2 ToFix64Vector2()
        {
            return new Fix64Vector2(X, Y);
        }
        public static Fix64Vector3 Lerp(Fix64Vector3 a, Fix64Vector3 b, Fix64 t)
        {
            return a + (b - a) * t;
        }

        public static Fix64 Distance(Fix64Vector3 a, Fix64Vector3 b)
        {
            Fix64 xx = Fix64.FastAbs(a.X - b.X);
            Fix64 yy = Fix64.FastAbs(a.Y - b.Y);
            Fix64 zz = Fix64.FastAbs(a.Z - b.Z);
            return Fix64.Sqrt(xx * xx + yy * yy + zz * zz);
        }

        public static Fix64 Dot(Fix64Vector3 a, Fix64Vector3 b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }
        //public static Fix64Vector3 Dot(Fix64Vector3 a, Fix64Vector3 b)
        //{
        //    return new Fix64Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        //}

        public static Fix64Vector3 SetVertex(Fix64 X, Fix64 Y, Fix64 Z)
        {
            return new Fix64Vector3(X, Y, Z);
        }

        public override string ToString()
        {
            return "X:" + X.ToString() + "Y:" + Y.ToString() + "Z:" + Z.ToString();
        }

        public static Fix64Vector3 Max(Fix64Vector3 a, Fix64Vector3 b)
        {
            Fix64Vector3 max = a;
            max.X = Fix64.Max(max.X, b.X);
            max.Y = Fix64.Max(max.Y, b.Y);
            max.Z = Fix64.Max(max.Z, b.Z);
            return max;
        }
        public static Fix64Vector3 Min(Fix64Vector3 a, Fix64Vector3 b)
        {
            Fix64Vector3 min = a;
            min.X = Fix64.Min(min.X, b.X);
            min.Y = Fix64.Min(min.Y, b.Y);
            min.Z = Fix64.Min(min.Z, b.Z);
            return min;
        }
    }
}
