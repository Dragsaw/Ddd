namespace Ddd.Lib.Math
{
    public abstract class MatrixBase
    {
        public double[,] Rows { get; protected set; }

        public int Height => Rows.GetLength(0);

        public int Width => Rows.GetLength(1);

        public void Multiply(MatrixBase other)
        {
            Rows = (this * other).Rows;
        }

        public static MatrixBase Multiply(MatrixBase m1, MatrixBase m2)
        {
            int h = m1.Height;
            int w = m2.Width;
            int l = m1.Width;
            var resultMatrix = new double[m1.Height, m2.Width];
            unsafe
            {
                fixed (double* pm = resultMatrix, pm1 = m1.Rows, pm2 = m2.Rows)
                {
                    int i1, i2;
                    for (int i = 0; i < h; i++)
                    {
                        i1 = i * l;
                        for (int j = 0; j < w; j++)
                        {
                            i2 = j;
                            double res = 0;
                            for (int k = 0; k < l; k++, i2 += w)
                            {
                                res += pm1[i1 + k] * pm2[i2];
                            }
                            pm[i * w + j] = res;
                        }
                    }
                }
            }

            return new Matrix(resultMatrix);
        }

        public static MatrixBase operator *(MatrixBase m1, MatrixBase m2)
        {
            return Multiply(m1, m2);
        }
    }
}
