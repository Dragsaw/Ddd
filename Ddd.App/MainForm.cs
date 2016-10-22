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
        DddObjects.Figure coordinates;

        private DddObjects.Point DefaultPoint { get { return new DddObjects.Point(canvasBitmap.Width / 2, 0, canvasBitmap.Height / 2); } }

        public MainForm()
        {
            InitializeComponent();
            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;
            graphics = Graphics.FromImage(canvasBitmap);
        }

        public void RedrawFigure(object sender, TransformationCompletedEventArgs e)
        {
            graphics.Clear(Color.Transparent);
            var figure = sender as DddObjects.Figure;
            DrawFigure(figure);
            DrawFigure(coordinates, Color.Blue);
            canvas.Refresh();
        }

        public void DrawFigure(DddObjects.Figure figure, Color? color = null)
        {
            color = color ?? Color.Red;
            foreach (var line in figure.Faces.SelectMany(f => f.Lines).Distinct())
            {
                var point1 = currentPlane.ConvertToSquareCoordinates(line.Points[0]);
                var point2 = currentPlane.ConvertToSquareCoordinates(line.Points[1]);
                graphics.DrawLine(new Pen(color.Value), point1, point2);
            }
        }

        private void Create(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXZ(DefaultPoint);
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
            currentPlane = PlaneFactory.CreateXZ(DefaultPoint);
            var rotateTransformation = TransformationsFactory.CreateRotateTransformation(
                (double)angleX.Value,
                (double)angleY.Value,
                (double)angleZ.Value);
            coordinates.ApplyTransformation(rotateTransformation);
            figure.ApplyTransformation(rotateTransformation);
        }

        private void Shift(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXZ(DefaultPoint);
            var moveTransformation = TransformationsFactory.CreateMoveTransformation(
                (double)moveX.Value,
                (double)moveY.Value,
                (double)-moveZ.Value);
            figure.ApplyTransformation(moveTransformation);
        }

        private void Scale(object sender, System.EventArgs e)
        {
            currentPlane = PlaneFactory.CreateXZ(DefaultPoint);
            var scaleTransformation = TransformationsFactory.CreateScaleTransformation(
                (double)scaleX.Value,
                (double)scaleY.Value,
                (double)scaleZ.Value);
            figure.ApplyTransformation(scaleTransformation);
        }
    }
}