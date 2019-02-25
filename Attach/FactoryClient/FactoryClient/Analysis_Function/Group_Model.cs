﻿using MathNet.Numerics.LinearAlgebra;
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
        public Dictionary<int, string> people_coder;
        public Person_Model[] people;
        public Thread_Pool thread;
        public int current_days = -1;

        public Dish_Encoder dish_encoder;
        double[][] dish_predict;

        public Group_Model(JArray data, int threads)
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
            dish_predict = new double[dish_encoder.get_size()][];

            thread = new Thread_Pool(threads);
        }

        public void Train(int gradients, int ternarys)
        {
            int flag = 0;
            foreach (Person_Model p in people)
                thread.Entask(() =>
                {
                    p.Train(gradients, ternarys);
                    flag += 1;
                });
            while (flag != people.Length) Thread.Sleep(100);

            flag = 0;
            thread.Entask(() =>
            {
                foreach (Person_Model p in people)
                {
                    Vector<double> result = p.Query();
                    for (int i = 0; i != result.Count; i++)
                    {
                        double odd = result[i];
                        string dname = p.dish.get_name(i);
                        int global_did = dish_encoder.get_id(dname);


                        double[] origin = dish_predict[global_did];
                        double[] updated = new double[people.Length + 1];
                        if (origin == null)
                        {
                            updated[0] = 1 - odd;
                            updated[1] = odd;
                        }
                        else for (int j = 0; j <= people.Length; j++)
                                updated[j] = (j == 0 ? origin[0] * (1 - odd) : origin[j] * (1 - odd) + origin[j - 1] * odd);
                        dish_predict[global_did] = updated;
                    }
                    flag = 1;
                }
            });
            while (flag != 1) Thread.Sleep(100);

            current_days = 1;
        }

        public void Future(int days)
        {
            //Temporary using doing this.
            current_days = days;
        }

        public double[] Query(string dname, int days = 1)
        {
            if(days == current_days)
            {
                return dish_predict[dish_encoder.get_id(dname)];
            }
            else
            {
                Future(days);
                return dish_predict[dish_encoder.get_id(dname)];
            }
        }
    }
}
