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

        public Person_Model(JArray orders)
        {
            data = orders;
            dish = new Dish_Encoder(orders);
            time = new Time_Encoder(orders);
            Tuple<bool[], bool>[] result = time.get_logistic(days);
            if(result.Length == 0)
            {
                Not_Enough = true;
                return;
            }
            last = CreateVector.Dense<double>(days, (int i) => (i == days - 1 ? result.Last().Item2 : result.Last().Item1[i + 1]) ? 1 : -1);
            order = new Logistic(result);
        }

        public void Train(int gradients, int ternarys)
        {
            if (Not_Enough) return;

            order.Train(gradients, ternarys);
            Matrix<double> count = CreateMatrix.Dense<double>(dish.get_size() ,dish.get_size());

            SortedDictionary<DateTime, JArray> markov = time.get_markov();
            JArray previous = markov.First().Value;
            foreach (KeyValuePair<DateTime, JArray> item in markov)
            {
                if (item.Key.Equals(markov.First().Key)) continue;
                foreach (JToken p in previous) foreach (JToken op in p["dish"])
                        foreach (JToken n in item.Value) foreach (JToken on in n["dish"])
                                count[dish.get_id(dish.concat_name(op["dish_name"].ToString(), op["dish_cost"].ToString())),
                                    dish.get_id(dish.concat_name(on["dish_name"].ToString(), on["dish_cost"].ToString()))] += 1;
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

            if (days == 1)
                return order.Query(last) * ratio.Stable();
            else
                return ratio.Stable() *
                    future.Future(last, days).DotProduct(
                        CreateVector.Dense<double>(days,
                        (int i) => (i > (1 << (days - 1)) ? 1 : 0))
                    );
        }
    }
}
