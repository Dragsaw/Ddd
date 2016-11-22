using Ddd.Lib;
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
        DddObjects.Figure cone;
        DddObjects.Figure coordinates;
        DddObjects.Point lightPoint = new DddObjects.Point(500, 0, 5000);

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
            DrawCoordinates(coordinates, Color.Blue);
            canvas.Refresh();
        }

        public void DrawFigure(object sender, TransformationCompletedEventArgs e)
        {
            var figure = sender as DddObjects.Figure;
            DrawFigure(figure);
            canvas.Refresh();
        }

        public void DrawFigure(DddObjects.Figure figure, Color? color = null)
        {
            color = color ?? Color.Red;
            foreach (var face in figure.Faces.Where(f => f.IsVisible(currentPlane.ViewPoint)))
            {
                var points = face.FillPoints
                    .Select(currentPlane.ConvertToSquareCoordinates)
                    .ToArray();

                var brightness = face.GetBrightness(lightPoint);
                var brush = new SolidBrush(Color.FromArgb(brightness, 0, 0));
                graphics.FillPolygon(brush, points);

                foreach (var line in face.Distinct())
                {
                    var point1 = currentPlane.ConvertToSquareCoordinates(line.Points[0]);
                    var point2 = currentPlane.ConvertToSquareCoordinates(line.Points[1]);
                    graphics.DrawLine(new Pen(color.Value), point1, point2);
                }
            }
        }

        public void DrawCoordinates(DddObjects.Figure figure, Color? color = null)
        {
            foreach (var line in figure.Faces.SelectMany(f => f.Lines).Distinct())
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
            cone = DddFigureFactory.CreateCone(new DddObjects.Point(0, 0, 0), l, w, h, r, n);
            figure.OnTransformationCompleted += DrawFigure;
            cone.OnTransformationCompleted += RedrawFigure;
            coordinates = DddFigureFactory.CreateCoordinates(new DddObjects.Point(0, 0, 0));
            RedrawFigure(cone, null);
            DrawFigure((object)figure, null);
        }

        private void Rotate(object sender, System.EventArgs e)
        {
            var rotateTransformation = TransformationsFactory.CreateRotateTransformation(
                (double)angleX.Value,
                (double)angleY.Value,
                (double)angleZ.Value);
            coordinates.ApplyTransformation(rotateTransformation);
            cone.ApplyTransformation(rotateTransformation);
            figure.ApplyTransformation(rotateTransformation);
        }

        private void Shift(object sender, System.EventArgs e)
        {
            var moveTransformation = TransformationsFactory.CreateMoveTransformation(
                (double)moveX.Value,
                (double)moveY.Value,
                (double)moveZ.Value);
            cone.ApplyTransformation(moveTransformation);
            figure.ApplyTransformation(moveTransformation);
        }

        private void Scale(object sender, System.EventArgs e)
        {
            var scaleTransformation = TransformationsFactory.CreateScaleTransformation(
                (double)scaleX.Value,
                (double)scaleY.Value,
                (double)scaleZ.Value);
            cone.ApplyTransformation(scaleTransformation);
            figure.ApplyTransformation(scaleTransformation);
        }

        private void ViewAxonometricProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var axonometricTransformation = TransformationsFactory.CreateAxonometricProjection(
                (double)anglePsi.Value,
                (double)angleFi.Value);
            coordinates.ApplyTransformation(axonometricTransformation);
            cone.ApplyTransformation(axonometricTransformation);
            figure.ApplyTransformation(axonometricTransformation);
        }

        private void ViewProfileProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateZY(DefaultPoint);
            var profileTransofrmation = TransformationsFactory.CreateProfileProjection();
            coordinates.ApplyTransformation(profileTransofrmation);
            cone.ApplyTransformation(profileTransofrmation);
            figure.ApplyTransformation(profileTransofrmation);
        }

        private void ViewHorizontalProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXZ(DefaultPoint);
            var horizontalTransofrmation = TransformationsFactory.CreateHorizontalProjection();
            coordinates.ApplyTransformation(horizontalTransofrmation);
            cone.ApplyTransformation(horizontalTransofrmation);
            figure.ApplyTransformation(horizontalTransofrmation);
        }

        private void ViewFrontalProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var frontalTransofrmation = TransformationsFactory.CreateFrontalProjection();
            coordinates.ApplyTransformation(frontalTransofrmation);
            cone.ApplyTransformation(frontalTransofrmation);
            figure.ApplyTransformation(frontalTransofrmation);
        }

        private void ViewObliqueProjection(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXY(DefaultPoint);
            var obliqueTransofrmation = TransformationsFactory.CreateObliqueProjection(
                (double)angleAlpha.Value,
                (double)lengthOblique.Value);
            coordinates.ApplyTransformation(obliqueTransofrmation);
            cone.ApplyTransformation(obliqueTransofrmation);
            figure.ApplyTransformation(obliqueTransofrmation);
        }

        private void ViewViewTransformationProjection(object sender, System.EventArgs e)
        {
            var viewTransformation = TransformationsFactory.CreateViewTransformation(
                (double)anglePhiView.Value,
                (double)angleTheta.Value,
                (double)rho.Value);
            coordinates.ApplyTransformation(viewTransformation);
            cone.ApplyTransformation(viewTransformation);
            figure.ApplyTransformation(viewTransformation);
            var perspectiveProjection = TransformationsFactory.CreatePerspectiveProjection((double)d.Value);
            coordinates.ApplyTransformation(perspectiveProjection);
            cone.ApplyTransformation(perspectiveProjection);
            figure.ApplyTransformation(perspectiveProjection);
        }

        private void ViewPerspectiveProjection(object sender, System.EventArgs e)
        {
            var perspectiveProjection = TransformationsFactory.CreatePerspectiveProjection((double)d.Value);
            coordinates.ApplyTransformation(perspectiveProjection);
            cone.ApplyTransformation(perspectiveProjection);
            figure.ApplyTransformation(perspectiveProjection);
        }
    }
}