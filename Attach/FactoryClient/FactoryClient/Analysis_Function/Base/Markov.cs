using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Single;
using MathNet.Numerics.LinearAlgebra;

namespace FactoryClient.Analysis_Function
{
    class Markov
    {
        Matrix<float> data;
        const int days = 100000;

        public Markov(Matrix<float> data)
        {
            this.data = data;
            Vector<float> sum = this.data.RowSums();
            for (int i = 0; i != this.data.RowCount; i++)
                for (int j = 0; j != this.data.ColumnCount; j++)
                    this.data[i, j] /= sum[i];
        }

        public Vector<float> Future(Vector<float> now, int days)
        {
            Matrix<float> tmp = data;
            Matrix<float> sum = Matrix.Build.Dense(data.ColumnCount, data.RowCount);
            while (days != 0)
            {
                if (days % 2 == 1) sum += tmp;
                tmp *= tmp;
            }
            return now * sum;
        }

        public Vector<float> Stable()
        {
            Matrix<float> Z = data - CreateMatrix.DenseIdentity<float>(data.ColumnCount, data.RowCount);
            for (int i = 0; i != data.ColumnCount; i++) Z[0, i] = 1;
            var LU = Z.LU();
            if (LU.Determinant == 0) // single or multiple solves.
            {
                return Fake_Stable();
            }
            else // single solve.
            {
                Vector<float> S = CreateVector.Dense<float>(data.ColumnCount);
                S[0] = 1;
                return LU.Solve(S);
            }
        }

        Vector<float> Fake_Stable()
        {
            Matrix<float> M = DenseMatrix.Build.Dense(data.ColumnCount * 2, data.RowCount * 2,
                (int i, int j) =>
                {
                    if (i < data.RowCount) return data[i, j % data.RowCount];
                    if (i == j) return 1;
                    return 0;
                });

            Matrix<float> ans = Matrix.Build.Dense(data.ColumnCount, data.RowCount);
            int moves = days;
            while (moves != 0)
            {
                if (moves % 2 == 1) ans += M;
                M *= M;
            }

            Matrix<float> average = DenseMatrix.Build.Dense(data.ColumnCount, data.RowCount,
                (int i, int j) => { return M[i + data.ColumnCount, j]; });
            Vector<float> V = DenseVector.Build.Dense(data.ColumnCount, 1 / data.ColumnCount);
            return V * average;
        }
    }
}
