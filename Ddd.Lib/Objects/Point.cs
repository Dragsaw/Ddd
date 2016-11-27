using Ddd.Lib.Math;

namespace Ddd.Lib.Objects
{
    public class Point : Vector
    {
        public Point(double x, double y, double z) : base(x, y, z, 1)
        {
        }

        public Point(MatrixBase matrixBase) : base(matrixBase.Rows[0, 0], matrixBase.Rows[0, 1], matrixBase.Rows[0, 2], 1)
        {
        }

        public double X
        {
            get { return this[0]; }
            set { this[0] = value; }
        }

        public double Y
        {
            get { return this[1]; }
            set { this[1] = value; }
        }

        public double Z
        {
            get { return this[2]; }
            set { this[2] = value; }
        }
    }
}