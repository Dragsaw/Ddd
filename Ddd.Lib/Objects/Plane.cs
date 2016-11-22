using System;

namespace Ddd.Lib.Objects
{
    public class Plane
    {
        private Func<Point, double> _xCoordinate;
        private Func<Point, double> _yCoordinate;

        public Point ViewPoint { get; set; }

        public Plane(Func<Point, double> xCoordinate, Func<Point, double> yCoordinate)
        {
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }

        public System.Drawing.Point ConvertToSquareCoordinates(Point p)
        {
            return new System.Drawing.Point((int)_xCoordinate(p), (int)_yCoordinate(p));
        }
    }
}
