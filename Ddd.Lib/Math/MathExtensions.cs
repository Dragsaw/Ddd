using Ddd.Lib.Objects;
using System.Collections.Generic;
using SysMath = System.Math;

namespace Ddd.Lib.Math
{
    public static class MathExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return (degrees * SysMath.PI) / 180;
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
    }
}
