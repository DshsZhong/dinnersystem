using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClient.Analysis_Function
{
    class Logistic
    {
        Matrix<double> X;
        Vector<double> W, Y;
        const double L = 0, R = 2 ,beta = 0.1;
        public static bool Momentum = true;

        public Logistic(Tuple<double[], double>[] data)
        {
            X = CreateMatrix.Dense<double>(data.Length, data[0].Item1.Length + 1);
            Y = CreateVector.Dense<double>(data.Length);

            int rows = 0;
            foreach (Tuple<double[], double> item in data)
            {
                for (int i = 0; i != item.Item1.Length; i++)
                    X[rows, i] = item.Item1[i];
                X[rows, item.Item1.Length] = 1;
                Y[rows] = item.Item2;
                rows += 1;
            }

            W = CreateVector.Dense<double>(X.ColumnCount);
        }

        public void Train(int gradients, int ternarys)
        {
            Vector<double> previous = CreateVector.Dense<double>(W.Count);
            while (gradients-- != 0)
            {
                Vector<double> slope = FPrime(W);
                double l = L, r = R;
                for (int i = 0; i != ternarys; i++)
                {
                    double lmid = (l + l + r) / 3, rmid = (l + r + r) / 3;
                    Vector<double> lpos = W + lmid * slope, rpos = W + rmid * slope;
                    Vector<double> lgrad = FPrime(W + lmid * slope), rgrad = FPrime(W + rmid * slope);
                    double leftover = (lgrad + rgrad) * (lgrad - rgrad);

                    if (leftover < 0) r = rmid;
                    if (leftover > 0) l = lmid;
                    if (leftover == 0)
                        break;
                }
                W += (l + r) / 2 * slope + (Momentum ? beta : 0) * previous;
                previous = (l + r) / 2 * slope;
            }
        }

        public double Cost()
        {
            double sum = 0 ,value;
            for (int i = 0; i != X.RowCount; i++)
            {
                value = sigmoid(X.Row(i) * W);
                sum += (Y[i] * Math.Log(value) + (1 - Y[i]) * Math.Log(1 - value));
            }
            return sum;
        }

        public double Query(Vector<double> data)
        {
            Vector<double> tmp = CreateVector.Dense(data.Count + 1, (int i) => (i == data.Count ? 1 : data[i]));
            return sigmoid(tmp * W);
        }

        double sigmoid(double x)
        {
            if (x > 30)
                return 1 - 1e-5;
            if (x < -30)
                return 1e-5;
            return (1 / (1 + Math.Exp(-x)));
        }
        Vector<double> F(Vector<double> x) { return CreateVector.Dense(x.Count, (int i) => { return sigmoid(x[i]); }); }
        Vector<double> FPrime(Vector<double> weight) { return (Y - F(X * weight)) * X; }
    }
}
