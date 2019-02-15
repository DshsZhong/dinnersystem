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
        JArray data;
        Dish_Encoder dish;
        Time_Encoder time;

        Logistic order;
        Markov ratio;
        Markov future;

        bool Allow_Future = false;
        public Person_Model(JArray orders)
        {
            dish = new Dish_Encoder(orders);
            time = new Time_Encoder(orders);
            order = new Logistic(time.get_logistic());
            data = orders;
        }

        public void Train(int gradients,int ternarys)
        {
            order.Train(gradients ,ternarys);
            Matrix<float> count = CreateMatrix.Dense<float>(data.Count, data.Count);

            SortedDictionary<DateTime, JArray> markov = time.get_markov();
            JArray previous = markov.First().Value;
            foreach(KeyValuePair<DateTime ,JArray> item in markov)
            {
                if (item.Key.Equals(markov.First().Key)) continue;
                foreach (JToken p in previous) foreach (JToken n in item.Value)
                        count[dish.get_id(dish.concat_name(p["dish_name"].ToString(), p["dish_charge"].ToString()),
                            dish.get_id(dish.concat_name(n["dish_name"].ToString(), n["dish_charge"].ToString())] += 1;
                previous = item.Value;
            }
            ratio = new Markov(count);
        }

        public void Future_Train()
        {

        }

        public Vector<Double> Query(int days = 1)
        {
            return null;
        }
    }
}
