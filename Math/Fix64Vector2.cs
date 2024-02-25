using UnityEngine;
namespace LookStep.VGLookStep.Math
{
    public struct Fix64Vector2
    {

        public static Fix64Vector2 Up = new Fix64Vector2(0, 1);
        public static Fix64Vector2 Zero = new Fix64Vector2(0, 0);

        public Fix64 X;
        public Fix64 Y;

        public static Fix64Vector2 operator /(Fix64Vector2 a, Fix64 cs)
        {
            return new Fix64Vector2(a.X / cs, a.Y / cs);
        }

        public static Fix64Vector2 operator *(Fix64Vector2 a, Fix64 cs)
        {
            return new Fix64Vector2(a.X * cs, a.Y * cs);
        }


        public static Fix64Vector2 operator *(Fix64Vector2 a, int cs)
        {
            return new Fix64Vector2(a.X * (Fix64)cs, a.Y * (Fix64)cs);
        }

        public static Fix64Vector2 operator -(Fix64Vector2 a, Fix64Vector2 cs)
        {
            return new Fix64Vector2(a.X - cs.X, a.Y - cs.Y);
        }

        public static Fix64Vector2 operator -(Fix64Vector2 a)
        {
            return new Fix64Vector2(-a.X, -a.Y);
        }

        public static Fix64Vector2 operator +(Fix64Vector2 a, Fix64Vector2 cs)
        {
            return new Fix64Vector2(a.X + cs.X, a.Y + cs.Y);
        }

        public static bool operator ==(Fix64Vector2 x, Fix64Vector2 y)
        {
            return x.X == y.X && x.Y == y.Y;
        }
        public static bool operator !=(Fix64Vector2 x, Fix64Vector2 y)
        {
            return x.X != y.X || x.Y != y.Y;
        }
        public Fix64Vector2(int x, int y)
        {
            X = new Fix64(x);
            Y = new Fix64(y);
        }

        public Fix64Vector2(float x, float y)
        {
            X = new Fix64(x);
            Y = new Fix64(y);
        }

        public Fix64Vector2(Fix64 x, Fix64 y)
        {
            X = x;
            Y = y;
        }

        public Fix64Vector2(Vector2 v)
        {
            X = new Fix64(v.x);
            Y = new Fix64(v.y);
        }
        public Fix64 Magnitude()
        {
            return Fix64.Sqrt((X * X) + (Y * Y));
        }

        public Fix64Vector2 Nomalize()
        {
            return this / this.Magnitude();
        }

        public Vector2 ToVector2()
        {
            return new Vector2((float)X, (float)Y);
        }

        public Vector3 ToVector3()
        {
            return new Vector3((float)X, (float)Y, 0);
        }

        public Vector3 ToVector3Zero()
        {
            return new Vector3((float)X, (float)Y, 0);
        }

        public static Fix64Vector2 Lerp(Fix64Vector2 a, Fix64Vector2 b, Fix64 t)
        {
            return a + (b - a) * t;
        }

        public static Fix64 Distance(Fix64Vector2 a, Fix64Vector2 b)
        {
            Fix64 a2 = Fix64.FastAbs(a.X - b.X);
            Fix64 b2 = Fix64.FastAbs(a.Y - b.Y);

            return Fix64.Sqrt(a2 * a2 + b2 * b2);
        }

        public static Fix64 Dot(Fix64Vector2 a, Fix64Vector2 b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        public static Fix64 Angle(Fix64Vector2 a, Fix64Vector2 b)
        {
            return Fix64.Acos(Dot(a.Nomalize(), b.Nomalize()));
        }

        public static Fix64Vector2 Rotate(Fix64Vector2 iA, Fix64 degrees)
        {
            degrees *= Fix64.DegreeToRad;
            Fix64Vector2 A = new Fix64Vector2(0, 0);
            A.X = (iA.X * Fix64.Cos(degrees) - iA.Y * Fix64.Sin(degrees));
            A.Y = (iA.X * Fix64.Sin(degrees) + iA.Y * Fix64.Cos(degrees));

            return A;
        }

        public static Fix64Vector2 SetVertex(Fix64 X, Fix64 Y)
        {
            return new Fix64Vector2(X, Y);
        }

        public override string ToString()
        {
            return "X:" + X.ToString() + "Y:" + Y.ToString();
        }


    }
}
