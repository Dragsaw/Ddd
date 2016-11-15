﻿using System;
using Ddd.Lib.Math;
using SysMath = System.Math;
using Ddd.Lib.Objects;

namespace Ddd.Lib.Transformations
{
    public static class TransformationsFactory
    {
        public static Transformation CreateRotateTransformation(double angleX, double angleY, double angleZ)
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

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateMoveTransformation(double deltaX, double deltaY, double deltaZ)
        {
            var transformationMatrix = new Matrix(new[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { deltaX, deltaY, deltaZ, 1}
            });

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateScaleTransformation(double scaleX, double scaleY, double scaleZ)
        {
            var transformationMatrix = new Matrix(new[,] {
                {scaleX, 0, 0, 0},
                {0, scaleY, 0, 0},
                {0, 0, scaleZ, 0},
                {0, 0, 0, 1 }
            });

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateAxonometricProjection(double psi, double fi)
        {
            psi = psi.ToRadians();
            fi = fi.ToRadians();

            var transformationMatrix = new Matrix(new[,] {
                { SysMath.Cos(psi), SysMath.Sin(psi) * SysMath.Sin(fi), 0, 0},
                { 0, SysMath.Cos(fi), 0, 0},
                { SysMath.Sin(psi), -SysMath.Sin(fi) * SysMath.Cos(psi), 0, 0},
                { 0, 0, 0, 1 }
            });

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateProfileProjection()
        {
            var transformationMatrix = new Matrix(new double[,] {
                { 0, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1 }
            });

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateHorizontalProjection()
        {
            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0},
                { 0, 0, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1 }
            });

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateFrontalProjection()
        {
            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 0, 0},
                { 0, 0, 0, 1 }
            });

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateObliqueProjection(double alpha, double length)
        {
            alpha = alpha.ToRadians();

            var transformationMatrix = new Matrix(new double[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { length * SysMath.Cos(alpha), length * SysMath.Sin(alpha), 0, 0},
                { 0, 0, 0, 1 }
            });

            return new Transformation(transformationMatrix);
        }

        public static Transformation CreateViewTransformation(double phi, double theta, double rho)
        {
            phi = phi.ToRadians();
            theta = theta.ToRadians();

            var transformationMatrix = new Matrix(new double[,] {
                { -SysMath.Sin(theta), -SysMath.Cos(phi)*SysMath.Cos(theta), -SysMath.Sin(phi)*SysMath.Cos(theta), 0},
                { SysMath.Cos(theta), -SysMath.Cos(phi)*SysMath.Sin(theta), -SysMath.Sin(phi)*SysMath.Sin(theta), 0},
                { 0, SysMath.Sin(phi), -SysMath.Cos(phi), 0},
                { 0, 0, rho, 1 }
            });

            return new Transformation(transformationMatrix);
        }

        public static Action<Point> CreatePerspectiveProjection(double d)
        {
            var transformationAction = (Action<Point>)(p =>
            {
                var distance = SysMath.Abs(p.Z) < 0.1 ? 0.1 : SysMath.Abs(p.Z);
                p.X = p.X * d / distance;
                p.Y = p.Y * d / distance;
            });

            return transformationAction;
        }
    }
}
