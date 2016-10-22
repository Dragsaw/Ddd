namespace Ddd.Lib.Math
{
    public class Matrix : MatrixBase
    {
        public Matrix(double[,] rows)
        {
            Rows = rows;
        }

        public double this[int x, int y]
        {
            get { return Rows[x, y]; }
            set { Rows[x, y] = value; }
        }
    }
}
