using Ddd.Lib.Math;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ddd.Lib.Objects
{
    public class Face : IEnumerable<Line>
    {
        public Face(Line l1, Line l2, Line l3, params Line[] lines)
        {
            var list = new List<Line> { l1, l2, l3 };
            if (lines != null)
            {
                list.AddRange(lines);
            }

            Lines = list;
        }

        public IEnumerable<Line> Lines { get; private set; }

        public IEnumerator<Line> GetEnumerator()
        {
            return Lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Vector Normal
        {
            get
            {
                var points = FacePoints;
                var x = points[0].Y * points[1].Z + points[1].Y * points[2].Z + points[2].Y * points[0].Z
                    - points[1].Y * points[0].Z - points[2].Y * points[1].Z - points[0].Y * points[2].Z;
                var y = points[0].Z * points[1].X + points[1].Z * points[2].X + points[2].Z * points[0].X
                    - points[1].Z * points[0].X - points[2].Z * points[1].X - points[0].Z * points[2].X;
                var z = points[0].X * points[1].Y + points[1].X * points[2].Y + points[2].X * points[0].Y
                    - points[1].X * points[0].Y - points[2].X * points[1].Y - points[0].X * points[2].Y;

                return new Vector(x, y, z);
            }
        }

        private Point[] FacePoints
        {
            get
            {
                var lines = Lines.ToArray();

                if (lines.Length == 3)
                {
                    return new[] {
                        lines[0].First(),
                        lines[0].Last(),
                        lines[1].Last()};
                }

                return new[] {
                    lines[0].First(),
                    lines[1].First(),
                    lines[2].First()
                };
            }
        }
    }
}
