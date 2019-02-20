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
        const double L = 0, R = 2;

        public Logistic(Tuple<bool[], bool>[] data)
        {
            X = CreateMatrix.Dense<double>(data.Length, data[0].Item1.Length + 1);
            Y = CreateVector.Dense<double>(data.Length);

            int rows = 0;
            foreach (Tuple<bool[], bool> item in data)
            {
                for (int i = 0; i != item.Item1.Length; i++)
                    X[rows, i] = (item.Item1[i] ? 1 : -1);
                X[rows, item.Item1.Length] = 1;
                Y[rows] = (item.Item2 ? 1 : 0);
                rows += 1;
            }

            W = CreateVector.Dense<double>(X.ColumnCount);
        }

        public void Train(int gradients, int ternarys)
        {
            while (gradients-- != 0)
            {
                Vector<double> slope = FPrime(W);
                double l = L, r = R;
                for (int i = 0; i != ternarys; i++)
                {
                    double lmid = (l + l + r) / 3, rmid = (l + r + r) / 3;
                    Vector<double> lpos = W + lmid * slope, rpos = W + rmid * slope;
                    Vector<double> lgrad = FPrime(W + lmid * slope), rgrad = FPrime(W + rmid * slope);
                    double lmid_v = length(FPrime(W + lmid * slope)), rmid_v = length(FPrime(W + rmid * slope));
                    if (lmid_v < rmid_v) r = rmid;
                    if (lmid_v > rmid_v) l = lmid;
                    if (lmid_v == rmid_v)
                    {
                        l = lmid;
                        r = rmid;
                    }
                }
                W += (l + r) / 2 * slope;
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

        double length(Vector<double> f)
        {
            double sum = 0;
            foreach (double item in f) sum += item * item;
            return sum;
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
