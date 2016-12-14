using Ddd.Lib.Math;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ddd.Lib.Objects
{
    public class Face : IEnumerable<Line>
    {
        private IEnumerable<Point> fillPoints;

        public Face(Line l1, Line l2, Line l3, params Line[] lines)
        {
            var list = new List<Line> { l1, l2, l3 };
            if (lines != null)
            {
                list.AddRange(lines);
            }

            Lines = list;
        }

        public Face(IEnumerable<Line> lines)
        {
            Lines = lines.ToList();
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

        public void SetBrightness(Point lightPoint, double ia, double ka, double il, double kd)
        {
            Brightness = GetBrightness(lightPoint, ia, ka, il, kd);
        }

        public bool Visible { get; set; }
        public double Brightness { get; set; }

        public void SetVisibility(Point viewPoint)
        {
            Visible = IsVisible(viewPoint);
            //Visible = true;
        }

        public double GetBrightness(Point lightPoint, double ia, double ka, double il, double kd)
        {
            var vector = MathExtensions.Vectorize(lightPoint, CentralPoint);
            var angleCos = MathExtensions.Cos(Normal, vector);
            angleCos = angleCos < 0 ? 0 : angleCos;
            var brightness = ia * ka + il * kd * angleCos;
            brightness = brightness / 255;
            return brightness;
        }

        public bool IsVisible(Point viewPoint)
        {
            var angle = MathExtensions.AngleBetween(viewPoint, this);
            return angle <= 90;
        }

        public Point CentralPoint
        {
            get
            {
                var points = Lines.SelectMany(l => l.Points).Distinct();
                var xAvg = points.Average(p => p.X);
                var yAvg = points.Average(p => p.Y);
                var zAvg = points.Average(p => p.Z);
                var point = new Point(xAvg, yAvg, zAvg);
                if (points.Count() < 4)
                {
                    point.Z -= 60;
                }
                return point;
            }
        }

        public IEnumerable<Point> FillPoints
        {
            get
            {
                if (fillPoints != null)
                {
                    return fillPoints;
                }

                var points = this.SelectMany(l => l.Points)
                    .Distinct()
                    .ToArray();
                var t = points[0];
                points[0] = points[1];
                points[1] = t;

                return fillPoints = points;
            }
            set
            {
                fillPoints = value;
            }
        }
    }
}
