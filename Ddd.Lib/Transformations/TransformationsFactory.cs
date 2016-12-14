using Ddd.Lib.Math;
using Ddd.Lib.Objects;
using System;
using SysMath = System.Math;

namespace Ddd.Lib.Transformations
{
    public static class TransformationsFactory
    {
        public static ITransformation CreateRotateTransformation(double angleX, double angleY, double angleZ)
        {
            angleX = angleX.ToRadians();
            angleY = angleY.ToRadians();
            angleZ = angleZ.ToRadians();

            var rotateX = new Matrix(new[,] {
                { 1, 0, 0, 0 },
                {0, SysMath.Cos(angleX), SysMath.Sin(angleX), 0 },
                { 0, -SysMath.Sin(angleX), SysMath.Cos(angleX), 0},
                { 0, 0, 0, 1 }
            });

            var rotateY = new Matrix(new[,] {
                { SysMath.Cos(angleY), 0, -SysMath.Sin(angleY), 0 },
                { 0, 1, 0, 0 },
                { SysMath.Sin(angleY), 0, SysMath.Cos(angleY), 0 },
                { 0, 0, 0, 1 }
            });

            var rotateZ = new Matrix(new[,] {
                { SysMath.Cos(angleZ), SysMath.Sin(angleZ), 0, 0},
                { -SysMath.Sin(angleZ), SysMath.Cos(angleZ), 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1 }
            });

            var transformationMatrix = rotateX * rotateY * rotateZ;

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreateMoveTransformation(double deltaX, double deltaY, double deltaZ)
        {
            var transformationMatrix = new Matrix(new[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { deltaX, deltaY, deltaZ, 1}
            });

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreateScaleTransformation(double scaleX, double scaleY, double scaleZ)
        {
            var transformationMatrix = new Matrix(new[,] {
                {scaleX, 0, 0, 0},
                {0, scaleY, 0, 0},
                {0, 0, scaleZ, 0},
                {0, 0, 0, 1 }
            });

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreateViewTransformation(double phi, double theta, double rho, double d)
        {
            phi = phi.ToRadians();
            theta = theta.ToRadians();

            var transformationMatrix = new Matrix(new double[,] {
                { -SysMath.Sin(theta), -SysMath.Cos(phi)*SysMath.Cos(theta), -SysMath.Sin(phi)*SysMath.Cos(theta), 0},
                { SysMath.Cos(theta), -SysMath.Cos(phi)*SysMath.Sin(theta), -SysMath.Sin(phi)*SysMath.Sin(theta), 0},
                { 0, SysMath.Sin(phi), -SysMath.Cos(phi), 0},
                { 0, 0, rho, 1 }
            });

            var action = (Func<Point, Point>)(point =>
            {
                var p = new Point(point.MultiplyBy(transformationMatrix));
                var z = SysMath.Abs(p.Z) <= 0.1f ? 0.1 : SysMath.Abs(p.Z);
                var x = p.X * d / p.Z;
                var y = p.Y * d / p.Z;
                z = d;
                return new Point(x, y, z);
            });

            return new ActionTransformation(action);
        }
    }
}
