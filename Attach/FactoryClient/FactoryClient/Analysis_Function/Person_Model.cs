using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace FactoryClient.Analysis_Function
{
    class Person_Model
    {
        const int days = 7;

        JArray data;
        Vector<double> last;

        public Dish_Encoder dish;
        Time_Encoder time;

        public Logistic order;
        Markov ratio;
        Markov future;

        public bool Trained = false;
        public bool Allow_Future = false;
        public bool Not_Enough = false;

        public Person_Model(JArray orders, DateTime start, DateTime end)
        {
            data = orders;
            dish = new Dish_Encoder(orders);
            time = new Time_Encoder(orders, start, end);
            Tuple<bool[], bool, int>[] result = time.get_logistic(days);
            if (result.Length == 0)
            {
                Not_Enough = true;
                return;
            }
            last = CreateVector.Dense<double>(days, (int i) =>
                {
                    if (i == (result.Last().Item3 + 1) % 7) return 1;
                    else return 0;
                });

            List<Tuple<double[], double>> param = new List<Tuple<double[], double>>();
            for (int i = 0; i != result.Length; i++)
            {
                double[] tmp = new double[days];
                for (int j = 0; j != 7; j++)
                    tmp[j] = (j == result[i].Item3 ? 1 : 0);
                Tuple<double[], double> row = new Tuple<double[], double>(tmp, result[i].Item2 ? 1 : 0);
                param.Add(row);
            }
            order = new Logistic(param.ToArray());
        }

        public void Train(int gradients, int ternarys)
        {
            if (Not_Enough) return;

            order.Train(gradients, ternarys);
            Matrix<double> count = CreateMatrix.Dense<double>(dish.get_size() - 1 ,dish.get_size() - 1);

            SortedDictionary<DateTime, JArray> markov = time.get_markov();
            JArray previous = markov.First().Value;
            foreach (KeyValuePair<DateTime, JArray> item in markov)
            {
                if (item.Key.Equals(markov.First().Key)) continue;
                foreach (JToken p in previous) foreach (JToken op in p["dish"])
                        foreach (JToken n in item.Value) foreach (JToken on in n["dish"])
                                count[dish.get_id(op), dish.get_id(on)] += 1;
                previous = item.Value;
            }
            ratio = new Markov(count);
            Trained = true;
        }

        public void Future_Train()
        {
            if (Not_Enough) return;
            if (!Trained) throw new Exception("Must train before calling this function.");

            Matrix<double> count = CreateMatrix.Dense<double>((1 << days), (1 << days));
            for (int i = 0; i != (1 << days); i++)
            {
                int has_order = (i >> 1) | (1 << (days - 1));
                int hasnt_order = (i >> 1);
                Vector<double> tmp = CreateVector.Dense<double>(days,
                    (int j) => ((i >> j) & 1) == 1 ? 1 : -1);
                double odd = order.Query(tmp);
                count[i, has_order] = odd;
                count[i, hasnt_order] = 1 - odd;
            }
            future = new Markov(count);
            Allow_Future = true;
        }

        public Vector<double> Query(int days = 1)
        {
            if (Not_Enough) return CreateVector.Dense<double>(dish.get_size());

            if (!Trained) throw new Exception("Must train before query.");
            if (!Allow_Future && days > 1) throw new Exception("Must train before query.");

            Vector<double> ret;
            if (days == 1)
                ret = order.Query(last) * ratio.Stable();
            else
                ret = ratio.Stable() *
                    future.Future(last, days).DotProduct(
                        CreateVector.Dense<double>(days,
                        (int i) => (i > (1 << (days - 1)) ? 1 : 0))
                    );
            return CreateVector.Dense(ret.Count + 1, (int i) =>
            {
                if (i == ret.Count) return ret.Sum();
                else return ret[i];
            });
        }
    }
}
