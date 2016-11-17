namespace Ddd.Lib.Math
{
    public class Vector : MatrixBase
    {
        public Vector(params double[] rows)
        {
            Rows = new double[1, rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                this[i] = rows[i];
            }
        }

        public double this[int index]
        {
            get { return Rows[0, index]; }
            set { Rows[0, index] = value; }
        }

        public double Length
        {
            get
            {
                var sqSum = this[0] * this[0] + this[1] * this[1] + this[2] * this[2];
                return System.Math.Sqrt(sqSum);
            }
        }
    }
}
