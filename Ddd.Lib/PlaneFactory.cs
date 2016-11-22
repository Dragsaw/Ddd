using Ddd.Lib.Objects;

namespace Ddd.Lib
{
    public static class PlaneFactory
    {
        public static Plane CreateXZ(Point initialPoint = null)
        {
            if (initialPoint == null)
            {
                initialPoint = new Point(0, 0, 0);
            }

            return new Plane(p => p.X + initialPoint.X, p => p.Z + initialPoint.Y)
            {
                ViewPoint = new Point(0, 5000, 0)
            };
        }

        public static Plane CreateXY(Point initialPoint = null)
        {
            if (initialPoint == null)
            {
                initialPoint = new Point(0, 0, 0);
            }

            return new Plane(p => p.X + initialPoint.X, p => -p.Y + initialPoint.Y)
            {
                ViewPoint = new Point(0, 0, 5000)
            };
        }

        public static Plane CreateZY(Point initialPoint)
        {
            if (initialPoint == null)
            {
                initialPoint = new Point(0, 0, 0);
            }

            return new Plane(p => p.Z + initialPoint.X, p => p.Y + initialPoint.Y)
            {
                ViewPoint = new Point(5000, 0, 0)
            };
        }
    }
}
