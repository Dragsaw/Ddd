using Ddd.Lib.Math;
using Ddd.Lib.Objects;
using System;
using SysMath = System.Math;

namespace Ddd.Lib.Transformations
{
    public static class ProjectionsFactory
    {
        public static ITransformation CreateAxonometricProjection(double psi, double fi)
        {
            psi = psi.ToRadians();
            fi = fi.ToRadians();

            var transformationMatrix = new Matrix(new[,] {
                { SysMath.Cos(psi), SysMath.Sin(psi) * SysMath.Sin(fi), 0, 0},
                { 0, SysMath.Cos(fi), 0, 0},
                { SysMath.Sin(psi), -SysMath.Sin(fi) * SysMath.Cos(psi), 1, 0},
                { 0, 0, 0, 1 }
            });

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreateProfileProjection()
        {
            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1 }
            });

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreateHorizontalProjection()
        {
            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1 }
            });

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreateFrontalProjection()
        {
            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1 }
            });

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreateObliqueProjection(double alpha, double length)
        {
            alpha = alpha.ToRadians();

            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { length * SysMath.Cos(alpha), length * SysMath.Sin(alpha), 1, 0},
                { 0, 0, 0, 1 }
            });

            return new MatrixTransformation(transformationMatrix);
        }

        public static ITransformation CreatePerspectiveProjection(double d)
        {
            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 1/d },
                { 0, 0, 0, 0 }
            });

            return new MatrixTransformation(transformationMatrix);
        }
    }
}
