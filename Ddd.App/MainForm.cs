﻿using Ddd.Lib;
using DddObjects = Ddd.Lib.Objects;
using Ddd.Lib.Transformations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ddd.App
{
    public partial class MainForm : Form
    {
        Bitmap canvasBitmap;
        DddObjects.Plane currentPlane;
        Graphics graphics;
        DddObjects.Figure figure;
        DddObjects.Figure coordinates;

        private DddObjects.Point DefaultPoint { get { return new DddObjects.Point(canvas.Width / 2, canvas.Height / 2, 0); } }

        public MainForm()
        {
            InitializeComponent();
            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;
            graphics = Graphics.FromImage(canvasBitmap);
        }

        public void RedrawFigure(object sender, TransformationCompletedEventArgs e)
        {
            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;
            graphics = Graphics.FromImage(canvasBitmap);
            var figure = sender as DddObjects.Figure;
            DrawFigure(figure);
            DrawFigure(coordinates, Color.Blue);
            canvas.Refresh();
        }

        public void DrawFigure(DddObjects.Figure figure, Color? color = null)
        {
            color = color ?? Color.Red;
            var viewPoint = new DddObjects.Point(0, 0, -1000);
            foreach (var line in figure.Faces.Where(f => f.IsVisible(viewPoint)).SelectMany(f => f.Lines).Distinct())
            {
                var point1 = currentPlane.ConvertToSquareCoordinates(line.Points[0]);
                var point2 = currentPlane.ConvertToSquareCoordinates(line.Points[1]);
                graphics.DrawLine(new Pen(color.Value), point1, point2);
            }
        }

        private void Create(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var l = (int)length.Value;
            var w = (int)width.Value;
            var h = (int)height.Value;
            var r = (int)radius.Value;
            var n = (int)interpolationN.Value;
            figure = DddFigureFactory.Create(new DddObjects.Point(0, 0, 0), l, w, h, r, n);
            figure.OnTransformationCompleted += RedrawFigure;
            coordinates = DddFigureFactory.CreateCoordinates(new DddObjects.Point(0, 0, 0));
            RedrawFigure(figure, null);
        }

        private void Rotate(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var rotateTransformation = TransformationsFactory.CreateRotateTransformation(
                (double)angleX.Value,
                (double)angleY.Value,
                (double)angleZ.Value);
            coordinates.ApplyTransformation(rotateTransformation);
            figure.ApplyTransformation(rotateTransformation);
        }

        private void Shift(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var moveTransformation = TransformationsFactory.CreateMoveTransformation(
                (double)moveX.Value,
                (double)moveY.Value,
                (double)-moveZ.Value);
            figure.ApplyTransformation(moveTransformation);
        }

        private void Scale(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var scaleTransformation = TransformationsFactory.CreateScaleTransformation(
                (double)scaleX.Value,
                (double)scaleY.Value,
                (double)scaleZ.Value);
            figure.ApplyTransformation(scaleTransformation);
        }

        private void ViewAxonometricProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var axonometricTransformation = TransformationsFactory.CreateAxonometricProjection(
                (double)anglePsi.Value,
                (double)angleFi.Value);
            coordinates.ApplyTransformation(axonometricTransformation);
            figure.ApplyTransformation(axonometricTransformation);
        }

        private void ViewProfileProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateZY(DefaultPoint);
            var profileTransofrmation = TransformationsFactory.CreateProfileProjection();
            coordinates.ApplyTransformation(profileTransofrmation);
            figure.ApplyTransformation(profileTransofrmation);
        }

        private void ViewHorizontalProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXZ(DefaultPoint);
            var horizontalTransofrmation = TransformationsFactory.CreateHorizontalProjection();
            coordinates.ApplyTransformation(horizontalTransofrmation);
            figure.ApplyTransformation(horizontalTransofrmation);
        }

        private void ViewFrontalProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var frontalTransofrmation = TransformationsFactory.CreateFrontalProjection();
            coordinates.ApplyTransformation(frontalTransofrmation);
            figure.ApplyTransformation(frontalTransofrmation);
        }

        private void ViewObliqueProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var obliqueTransofrmation = TransformationsFactory.CreateObliqueProjection(
                (double)angleAlpha.Value,
                (double)lengthOblique.Value);
            coordinates.ApplyTransformation(obliqueTransofrmation);
            figure.ApplyTransformation(obliqueTransofrmation);
        }

        private void ViewViewTransformationProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var viewTransformation = TransformationsFactory.CreateViewTransformation(
                (double)anglePhiView.Value,
                (double)angleTheta.Value,
                (double)rho.Value);
            coordinates.ApplyTransformation(viewTransformation);
            figure.ApplyTransformation(viewTransformation);
            var perspectiveProjection = TransformationsFactory.CreatePerspectiveProjection((double)d.Value);
            coordinates.ApplyTransformation(perspectiveProjection);
            figure.ApplyTransformation(perspectiveProjection);
        }

        private void ViewPerspectiveProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var perspectiveProjection = TransformationsFactory.CreatePerspectiveProjection((double)d.Value);
            coordinates.ApplyTransformation(perspectiveProjection);
            figure.ApplyTransformation(perspectiveProjection);
        }
    }
}