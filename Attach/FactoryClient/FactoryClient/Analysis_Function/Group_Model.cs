using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FactoryClient.Analysis_Function
{
    class Group_Model
    {
        Dictionary<int, string> people_coder;
        Person_Model[] people;

        Thread_Pool thread;
        Dish_Encoder dish_encoder;

        Dictionary<string, float[]> dish_predict;

        int current_days;

        public Group_Model(JArray data , int threads)
        {
            Dictionary<string, JArray> sorted = new Dictionary<string, JArray>();
            foreach (JToken token in data)
            {
                string name = token["user"]["id"].ToString();
                if (sorted.ContainsKey(name)) sorted[name].Add(token);
                else sorted[name] = new JArray(token);
            }

            people = new Person_Model[sorted.Count];
            int id = 0;
            people_coder = new Dictionary<int, string>();
            foreach (KeyValuePair<string, JArray> item in sorted)
            {
                people[id] = new Person_Model(item.Value);
                people_coder[id] = item.Key;
                id += 1;
            }

            dish_encoder = new Dish_Encoder(data);
            for (int i = 0; i != dish_encoder.get_size(); i++)
                dish_predict[dish_encoder.get_name(i)] = new float[people.Length + 1];

            thread = new Thread_Pool(threads);
        }

        public void Train(int gradients, int ternarys)
        {
            foreach (Person_Model p in people)
                thread.Entask(() => p.Train(gradients, ternarys));
            while (thread.TaskLeft() != 0) Thread.Sleep(100);
            Build(1);
        }

        void Build(int days)
        {
            foreach (Person_Model p in people)
                thread.Entask(() =>
                {
                    Vector<float> result = p.Query(days);
                    for (int i = 0; i != result.Count; i++)
                    {
                        float odd = result[i];
                        string dname = p.dish.get_name(i);

                        lock (dish_predict)  // try to release the lock asap.
                        {
                            float[] origin = dish_predict[dname];
                            float[] updated = new float[origin.Length];
                            if (origin[0] == 0)
                            {
                                updated[0] = 1 - odd;
                                updated[1] = odd;
                            }
                            else for (int j = 0; j <= people.Length; j++)
                                    updated[j] = (j == 0 ? origin[0] * (1 - odd) : origin[j] * (1 - odd) + origin[j - 1] * odd);
                            dish_predict[dname] = updated;
                        }
                    }
                });
            while (thread.TaskLeft() != 0) Thread.Sleep(100);
            current_days = days;
        }

        public float[] Query(string dname, int days = 1)
        {
            if(days == current_days) return dish_predict[dname];
            else
            {
                Build(days);
                return dish_predict[dname];
            }
        }
    }
}
