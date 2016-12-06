using Ddd.Lib;
using DddObjects = Ddd.Lib.Objects;
using Ddd.Lib.Transformations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;
using Ddd.Lib.Math;
using System.Collections.Generic;

namespace Ddd.App
{
    public partial class MainForm : Form
    {
        private Bitmap canvasBitmap;
        private Graphics graphics;
        private DddObjects.Plane currentPlane;
        private ITransformation projection;
        private List<DddObjects.Figure> figures = new List<DddObjects.Figure>();
        private DddObjects.Point lightPoint = new DddObjects.Point(0, 0, 1000);

        private DddObjects.Point DefaultPoint { get { return new DddObjects.Point(canvas.Width / 2, canvas.Height / 2, 0); } }

        public MainForm()
        {
            InitializeComponent();
            UpdateGraphics();
        }

        public void RedrawFigures()
        {
            UpdateGraphics();
            DrawFigures();
        }

        public void DrawFigures()
        {
            var pen = new Pen(Color.Red);
            var faces = figures.SelectMany(f => f.Faces);

            foreach (var face in faces)
            {
                face.SetBrightness(lightPoint);
                face.SetVisibility(currentPlane.ViewPoint);
            }

            foreach (var face in faces
                .Where(f => f.Visible)
                .OrderBy(f => f.CentralPoint.Z)
                .ThenBy(f => f.CentralPoint.Y)
                .ThenBy(f => f.CentralPoint.X))
            {
                var points = face.FillPoints
                    .Select(p => projection.Project(p))
                    .Select(currentPlane.ConvertToSquareCoordinates)
                    .ToArray();

                var brush = new SolidBrush(Color.FromArgb(0, face.Brightness, 0));
                graphics.FillPolygon(brush, points);

                foreach (var line in face.Distinct())
                {
                    var point1 = currentPlane.ConvertToSquareCoordinates(projection.Project(line.Points[0]));
                    var point2 = currentPlane.ConvertToSquareCoordinates(projection.Project(line.Points[1]));
                    graphics.DrawLine(pen, point1, point2);
                }
            }
        }

        private void UpdateGraphics()
        {
            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;
            graphics = Graphics.FromImage(canvasBitmap);
        }

        private void Create(object sender, EventArgs e)
        {
            DddObjects.Point lightPoint = new DddObjects.Point(0, 0, 5000);
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var l = (int)length.Value;
            var w = (int)width.Value;
            var h = (int)height.Value;
            var r = (int)radius.Value;
            var n = (int)interpolationN.Value;
            var figure = DddFigureFactory.Create(new DddObjects.Point(0, 0, 0), l, w, h, r, n);
            var cone = DddFigureFactory.CreateCone(new DddObjects.Point(0, 0, 0), l, w, h, r, n);
            projection = ProjectionsFactory.CreateFrontalProjection();

            figures = new List<DddObjects.Figure> { cone, figure };
            RedrawFigures();
        }

        private void ApplyTransformation(ITransformation transformation)
        {
            figures.ForEach(f => f.ApplyTransformation(transformation));
            RedrawFigures();
        }

        private void Rotate(object sender, EventArgs e)
        {
            var rotateTransformation = TransformationsFactory.CreateRotateTransformation(
                (double)angleX.Value,
                (double)angleY.Value,
                (double)angleZ.Value);
            ApplyTransformation(rotateTransformation);
        }

        private void Shift(object sender, EventArgs e)
        {
            var moveTransformation = TransformationsFactory.CreateMoveTransformation(
                (double)moveX.Value,
                (double)moveY.Value,
                (double)moveZ.Value);
            ApplyTransformation(moveTransformation);
        }

        private void Scale(object sender, EventArgs e)
        {
            var scaleTransformation = TransformationsFactory.CreateScaleTransformation(
                (double)scaleX.Value,
                (double)scaleY.Value,
                (double)scaleZ.Value);
            ApplyTransformation(scaleTransformation);
        }

        private void ViewAxonometricProjection(object sender, EventArgs e)
        {
            projection = ProjectionsFactory.CreateFrontalProjection();
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var transformation = ProjectionsFactory.CreateAxonometricProjection(
                (double)anglePsi.Value,
                (double)-angleFi.Value);
            ApplyTransformation(transformation);
        }

        private void ViewProfileProjection(object sender, EventArgs e)
        {
            currentPlane = PlaneFactory.CreateZY(DefaultPoint);
            projection = ProjectionsFactory.CreateProfileProjection();
            RedrawFigures();
        }

        private void ViewHorizontalProjection(object sender, EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXZ(DefaultPoint);
            projection = ProjectionsFactory.CreateHorizontalProjection();
            RedrawFigures();
        }

        private void ViewFrontalProjection(object sender, EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            projection = ProjectionsFactory.CreateFrontalProjection();
            RedrawFigures();
        }

        private void ViewObliqueProjection(object sender, EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            projection = ProjectionsFactory.CreateFrontalProjection();
            var transformation = ProjectionsFactory.CreateObliqueProjection(
                (double)angleAlpha.Value,
                (double)lengthOblique.Value);
            ApplyTransformation(transformation);
        }

        private void ViewViewTransformationProjection(object sender, EventArgs e)
        {
            projection = ProjectionsFactory.CreatePerspectiveProjection((double)d.Value);
            //projection = ProjectionsFactory.CreateFrontalProjection();
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            currentPlane.ViewPoint = MathExtensions.CreatePolarPoint(
                (double)anglePhiView.Value,
                (double)angleTheta.Value,
                (double)rho.Value);
            var viewTransformation = TransformationsFactory.CreateViewTransformation(
                (double)anglePhiView.Value,
                (double)angleTheta.Value,
                (double)rho.Value);
            ApplyTransformation(viewTransformation);
        }

        private void ViewPerspectiveProjection(object sender, EventArgs e)
        {
            projection = ProjectionsFactory.CreatePerspectiveProjection((double)d.Value);
            RedrawFigures();
        }

        private void MoveLight(object sender, EventArgs e)
        {
            var moveTransformation = TransformationsFactory.CreateMoveTransformation(
                (double)moveLightX.Value,
                (double)moveLightY.Value,
                (double)moveLightZ.Value);
            moveTransformation.Transform(lightPoint);
            RedrawFigures();
        }

        private void SetLight(object sender, EventArgs e)
        {
            var x = (double)setLightX.Value;
            var y = (double)setLightY.Value;
            var z = (double)setLightZ.Value;
            lightPoint = new DddObjects.Point(x, y, z);
            RedrawFigures();
        }
    }
}