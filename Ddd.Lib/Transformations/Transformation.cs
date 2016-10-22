using Ddd.Lib.Math;

namespace Ddd.Lib.Transformations
{
    public class Transformation
    {
        public Transformation(MatrixBase rotateX)
        {
            this.TransformationMatrix = rotateX;
        }

        public MatrixBase TransformationMatrix { get; private set; }
    }
}
