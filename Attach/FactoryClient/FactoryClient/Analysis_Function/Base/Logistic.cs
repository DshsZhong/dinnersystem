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
        Matrix<float> X;
        Vector<float> W, Y;
        const float L = 0, R = 16;

        public Logistic(Tuple<bool[], bool>[] data)
        {
            X = CreateMatrix.Dense<float>(data.Length, data[0].Item1.Length + 1);
            Y = CreateVector.Dense<float>(data.Length);

            int rows = 0;
            foreach (Tuple<bool[], bool> item in data)
            {
                for (int i = 0; i != item.Item1.Length; i++)
                    X[rows, i] = (item.Item1[i] ? 1 : -1);
                X[rows, item.Item1.Length] = 1;
                Y[rows] = (item.Item2 ? 1 : 0);
                rows += 1;
            }

            W = CreateVector.Dense<float>(X.ColumnCount);
        }

        public void Train(int gradients, int ternarys)
        {
            while (gradients-- != 0)
            {
                Vector<float> slope = FPrime(W);
                float l = L, r = R;
                for (int i = 0; i != ternarys; i++)
                {
                    float lmid = (l + l + r) / 3, rmid = (l + r + r) / 3;
                    float lmid_v = length(FPrime(W + slope * lmid)), rmid_v = length(FPrime(W + slope * rmid));
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

        public float Cost()
        {
            float sum = 0;
            for (int i = 0; i != X.RowCount; i++)
                sum += (float)(Y[i] * Math.Log(sigmoid(X.Row(i) * W)) + (1 - Y[i]) * Math.Log(1 - sigmoid(X.Row(i) * W)));
            return sum;
        }

        public float Query(Vector<float> data)
        {
            Vector<float> tmp = CreateVector.Dense<float>(data.Count + 1, (int i) => (i == data.Count ? 1 : data[i]));
            return sigmoid(tmp * W);
        }

        float length(Vector<float> f)
        {
            float sum = 0;
            foreach (float item in f) sum += item * item;
            return sum;
        }
        float sigmoid(float x) { return (float)(1 / (1 + Math.Exp(-x))); }
        Vector<float> F(Vector<float> x) { return CreateVector.Dense(x.Count, (int i) => { return sigmoid(i); }); }
        Vector<float> FPrime(Vector<float> W) { return (Y - F(X * W)) * X; }
    }
}
