using Ddd.Lib.Objects;
using Ddd.Lib.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.Lib
{
    public static class DddFigureFactory
    {
        public static Figure CreateCoordinates(Point initialPoint)
        {
            var xPoint1 = new Point(initialPoint.X, initialPoint.Y, initialPoint.Z);
            var xPoint2 = new Point(initialPoint.X + 200, initialPoint.Y, initialPoint.Z);
            var yPoint1 = new Point(initialPoint.X, initialPoint.Y, initialPoint.Z);
            var yPoint2 = new Point(initialPoint.X, initialPoint.Y - 200, initialPoint.Z);
            var zPoint1 = new Point(initialPoint.X, initialPoint.Y, initialPoint.Z);
            var zPoint2 = new Point(initialPoint.X, initialPoint.Y, initialPoint.Z + 200);
            var xLine = new Line(xPoint1, xPoint2);
            var yLine = new Line(yPoint1, yPoint2);
            var zLine = new Line(zPoint1, zPoint2);
            var face = new Face(xLine, yLine, zLine);
            return new Figure(face);
        }

        /// <summary>
        /// Create a parallelepiped with a cilinder inside
        /// </summary>
        /// <param name="initialPoint">Initial point</param>
        /// <param name="height">Heigth of the parallelepiped</param>
        /// <param name="width">Width of the parallelepiped</param>
        /// <param name="r">Radius of the cilinder</param>
        /// <param name="n">Number of approximated lines</param>
        /// <returns></returns>
        public static Figure Create(Point initialPoint, double length, double width, double height, double r, int n)
        {
            var p1 = new Point(initialPoint.X + length / 2, initialPoint.Y - width / 2, initialPoint.Z + height / 2);
            var p2 = new Point(initialPoint.X + length / 2, initialPoint.Y - width / 2, initialPoint.Z - height / 2);
            var p3 = new Point(initialPoint.X + length / 2, initialPoint.Y + width / 2, initialPoint.Z + height / 2);
            var p4 = new Point(initialPoint.X + length / 2, initialPoint.Y + width / 2, initialPoint.Z - height / 2);
            var p5 = new Point(initialPoint.X - length / 2, initialPoint.Y - width / 2, initialPoint.Z + height / 2);
            var p6 = new Point(initialPoint.X - length / 2, initialPoint.Y - width / 2, initialPoint.Z - height / 2);
            var p7 = new Point(initialPoint.X - length / 2, initialPoint.Y + width / 2, initialPoint.Z + height / 2);
            var p8 = new Point(initialPoint.X - length / 2, initialPoint.Y + width / 2, initialPoint.Z - height / 2);
            var l1 = new Line(p1, p2);
            var l2 = new Line(p3, p4);
            var l3 = new Line(p2, p4);
            var l4 = new Line(p1, p3);
            var l5 = new Line(p1, p5);
            var l6 = new Line(p2, p6);
            var l7 = new Line(p5, p6);
            var l8 = new Line(p5, p7);
            var l9 = new Line(p6, p8);
            var l10 = new Line(p7, p8);
            var l11 = new Line(p3, p7);
            var l12 = new Line(p4, p8);
            var f1 = new Face(l1, l4, l2, l3);
            var f2 = new Face(l1, l5, l7, l6);
            var f3 = new Face(l7, l8, l10, l9);
            var f4 = new Face(l10, l11, l2, l12);
            var f5 = new Face(l6, l9, l12, l3);
            var f6 = new Face(l5, l8, l11, l4);

            var bottomCircleCenter = new Point(initialPoint.X, initialPoint.Y - height / 2, initialPoint.Z);
            var topCircleCenter = new Point(initialPoint.X, initialPoint.Y + height / 2, initialPoint.Z);

            var bottomCirclePoints = bottomCircleCenter.CreateCircleApproximation(r, n);
            var topCirclePoints = topCircleCenter.CreateCircleApproximation(r, n);

            var bottomCircleLines = JoinCircleLines(bottomCirclePoints);
            var topCircleLines = JoinCircleLines(topCirclePoints);

            var bottomCircle = new Face(bottomCircleLines.ElementAt(0), bottomCircleLines.ElementAt(1), bottomCircleLines.ElementAt(2), bottomCircleLines.Skip(3).ToArray());
            var topCircle = new Face(topCircleLines.ElementAt(0), topCircleLines.ElementAt(1), topCircleLines.ElementAt(2), topCircleLines.Skip(3).ToArray());

            var cilinderLines = JoinCilinderLines(bottomCirclePoints, topCirclePoints);
            var ciliderFaces = JoinCilinderFaces(cilinderLines, bottomCircleLines, topCircleLines);

            var figureFaces = new List<Face> { f1, f2, f3, f4, f5, f6, bottomCircle, topCircle, };
            figureFaces.AddRange(ciliderFaces);

            return new Figure(figureFaces.ToArray());
        }

        private static IEnumerable<Face> JoinCilinderFaces(IEnumerable<Line> cilinderLines, IEnumerable<Line> bottomCircleLines, IEnumerable<Line> topCircleLines)
        {
            var count = cilinderLines.Count();
            var faces = new Face[count];
            for (int i = 0; i < count; i++)
            {
                faces[i] = new Face(cilinderLines.ElementAt(i), cilinderLines.ElementAt((i + 1) % count), bottomCircleLines.ElementAt(i), topCircleLines.ElementAt(i));
            }

            return faces;
        }

        private static IEnumerable<Line> JoinCilinderLines(IList<Point> bottomCirclePoints, IList<Point> topCirclePoints)
        {
            return bottomCirclePoints.Select((p, i) => new Line(p, topCirclePoints.ElementAt(i)));
        }

        private static IEnumerable<Line> JoinCircleLines(IEnumerable<Point> points)
        {
            var lines = new List<Line>();
            var count = points.Count();
            for (int i = 0; i < count; i++)
            {
                var point1 = points.ElementAt(i);
                var point2 = points.ElementAt((i + 1) % count);
                lines.Add(new Line(point1, point2));
            }

            return lines;
        }
    }
}
