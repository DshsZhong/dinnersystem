using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace FactoryClient.Analysis_Function
{
    class Markov
    {
        Matrix<double> data;
        const int days = 100000;

        public Markov(Matrix<double> data)
        {
            this.data = data;
            Vector<double> sum = this.data.RowSums();
            for (int i = 0; i != this.data.RowCount; i++)
                for (int j = 0; j != this.data.ColumnCount; j++)
                    this.data[i, j] = (sum[i] == 0 ? 0 : this.data[i,j] / sum[i]);
        }

        public Vector<double> Future(Vector<double> now, int days)
        {
            Matrix<double> tmp = data;
            Matrix<double> sum = CreateMatrix.Dense<double>(data.ColumnCount, data.RowCount);
            while (days != 0)
            {
                if (days % 2 == 1) sum += tmp;
                tmp *= tmp;
            }
            return now * sum;
        }

        public Vector<double> Stable()
        {
            Matrix<double> Z = data - CreateMatrix.DenseIdentity<double>(data.ColumnCount, data.RowCount);
            for (int i = 0; i != data.ColumnCount; i++) Z[0, i] = 1;
            var LU = Z.LU();
            if (LU.Determinant == 0) // single or multiple solves.
            {
                return Fake_Stable();
            }
            else // single solve.
            {
                Vector<double> S = CreateVector.Dense<double>(data.ColumnCount);
                S[0] = 1;
                Vector<double> ans = LU.Solve(S);
                return ans;
            }
        }

        Vector<double> Fake_Stable()
        {
            Matrix<double> M = CreateMatrix.Dense(data.ColumnCount * 2, data.RowCount * 2,
                (int i, int j) =>
                {
                    if (i < data.RowCount) return data[i, j % data.RowCount];
                    if (i == j) return 1;
                    return 0;
                });

            Matrix<double> ans = M;
            int moves = days - 1;   // already have one on ans.
            while (moves != 0)
            {
                if (moves % 2 == 1) ans *= M;
                M *= M;
                moves >>= 1;
            }
            Matrix<double> average = CreateMatrix.Dense(data.ColumnCount, data.RowCount,
                (int i, int j) => { return ans[i, j + data.RowCount] / days; });
            Vector<double> V = CreateVector.Dense<double>(data.ColumnCount, 1 / data.ColumnCount);
            return V * average;
        }
    }
}
