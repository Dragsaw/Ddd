using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ddd.Lib.Objects
{
    public class Line : IEnumerable<Point>
    {
        public Line(Point p1, Point p2)
        {
            Points = new[] { p1, p2 };
        }

        public Point[] Points { get; private set; }

        public IEnumerator<Point> GetEnumerator()
        {
            return Points.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
