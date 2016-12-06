using Ddd.Lib.Math;
using Ddd.Lib.Objects;

namespace Ddd.Lib.Transformations
{
    public class MatrixTransformation : ITransformation
    {
        public MatrixTransformation(MatrixBase matrix)
        {
            TransformationMatrix = matrix;
        }

        public MatrixBase TransformationMatrix { get; private set; }

        public Point Project(Point point)
        {
            return new Point(point.MultiplyBy(TransformationMatrix));
        }

        public void Transform(Point point)
        {
            point.Multiply(TransformationMatrix);
        }
    }
}
