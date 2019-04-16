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

        public Dish_Encoder dish;
        Time_Encoder time;

        public Logistic order;
        Markov ratio;

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

            double[,] X = new double[result.Length, 7];
            double[] Y = new double[result.Length];
            for (int i = 0; i != result.Length; i++)
            {
                for (int j = 0; j != 7; j++)
                    X[i ,j] = (j == result[i].Item3 ? 1 : 0);
                Y[i] = (result[i].Item2 ? 1 : 0);
            }
            order = new Logistic(X ,Y);
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

        public Vector<double> Query(DateTime dt)
        {
            if (Not_Enough) return CreateVector.Dense<double>(dish.get_size());
            if (!Trained) throw new Exception("Must train before query.");

            Vector<double> ret = order.Query(CreateVector.Dense<double>(7 ,(int i) => i == (int)dt.DayOfWeek ? 1 : 0)) * ratio.Stable();
            
            return CreateVector.Dense(ret.Count + 1, (int i) =>
            {
                if (i == ret.Count) return ret.Sum();
                else return ret[i];
            });
        }
    }
}
