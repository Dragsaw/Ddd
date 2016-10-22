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

            return new Plane(p => p.X + initialPoint.X, p => p.Z + initialPoint.Z);
        }
    }
}
