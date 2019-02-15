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
        Vector<float> last;

        public Dish_Encoder dish;
        Time_Encoder time;

        Logistic order;
        Markov ratio;
        Markov future;

        bool Trained = false;
        bool Allow_Future = false;
        public Person_Model(JArray orders)
        {
            dish = new Dish_Encoder(orders);
            time = new Time_Encoder(orders);
            Tuple<bool[], bool>[] result = time.get_logistic(days);
            last = CreateVector.Dense<float>(days, (int i) => (i == days - 1 ? result.Last().Item2 : result.Last().Item1[i + 1]) ? 1 : -1);
            order = new Logistic(result);
            data = orders;
        }

        public void Train(int gradients, int ternarys)
        {
            order.Train(gradients, ternarys);
            Matrix<float> count = CreateMatrix.Dense<float>(data.Count, data.Count);

            SortedDictionary<DateTime, JArray> markov = time.get_markov();
            JArray previous = markov.First().Value;
            foreach (KeyValuePair<DateTime, JArray> item in markov)
            {
                if (item.Key.Equals(markov.First().Key)) continue;
                foreach (JToken p in previous) foreach (JToken n in item.Value)
                        count[dish.get_id(dish.concat_name(p["dish_name"].ToString(), p["dish_charge"].ToString())),
                            dish.get_id(dish.concat_name(n["dish_name"].ToString(), n["dish_charge"].ToString()))] += 1;
                previous = item.Value;
            }
            ratio = new Markov(count);
            Trained = true;
        }

        public void Future_Train()
        {
            if (!Trained) throw new Exception("Must train before calling this function.");

            Matrix<float> count = CreateMatrix.Dense<float>((1 << days), (1 << days));
            for (int i = 0; i != (1 << days); i++)
            {
                int has_order = (i >> 1) | (1 << (days - 1));
                int hasnt_order = (i >> 1);
                Vector<float> tmp = CreateVector.Dense<float>(days,
                    (int j) => ((i >> j) & 1) == 1 ? 1 : -1);
                float odd = order.Query(tmp);
                count[i, has_order] = odd;
                count[i, hasnt_order] = 1 - odd;
            }
            future = new Markov(count);
            Allow_Future = true;
        }

        public Vector<float> Query(int days = 1)
        {
            if (!Trained) throw new Exception("Must train before query.");
            if (!Allow_Future && days > 1) throw new Exception("Must train before query.");

            if (days == 1)
                return order.Query(last) * ratio.Stable();
            else
                return ratio.Stable() *
                    future.Future(last, days).DotProduct(
                        CreateVector.Dense<float>(days,
                        (int i) => (i > (1 << (days - 1)) ? 1 : 0))
                    );
        }
    }
}
