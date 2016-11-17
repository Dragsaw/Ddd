using Ddd.Lib.Objects;
using System.Collections.Generic;
using SysMath = System.Math;
using System;

namespace Ddd.Lib.Math
{
    public static class MathExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return (degrees * SysMath.PI) / 180;
        }

        public static double ToDegrees(this double radians)
        {
            return (radians * 180) / SysMath.PI;
        }

        public static IList<Point> CreateCircleApproximation(this Point center, double r, int n)
        {
            var alpha = 360.0 / n;
            var grad = 0.0;
            var points = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                var z = (int)SysMath.Round(r * SysMath.Sin(grad.ToRadians()));
                var x = (int)SysMath.Round(r * SysMath.Cos(grad.ToRadians()));
                points.Add(new Point(x + center.X, center.Y, z + center.Z));
                grad += alpha;
            }

            return points;
        }

        public static double AngleBetween(Vector viewPoint, Face face)
        {
            var a = face.Normal;
            var faceCentalPoint = face.CentralPoint;
            var b = new Point(
                viewPoint[0] - faceCentalPoint.X,
                viewPoint[1] - faceCentalPoint.Y,
                viewPoint[2] - faceCentalPoint.Z);
            return SysMath.Acos(Cos(a, b)).ToDegrees();
        }

        public static double Cos(Vector v1, Vector v2)
        {
            var ab = v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];

            if (ab == 0)
            {
                return 0;
            }

            return ab / (v1.Length * v2.Length);
        }
    }
}
