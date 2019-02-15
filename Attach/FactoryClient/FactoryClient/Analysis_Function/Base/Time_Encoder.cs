using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FactoryClient.Analysis_Function
{
    class Time_Encoder
    {
        SortedDictionary<DateTime, JArray> markov_data;
        BitArray logstic_data;
        
        const int max_days = 30;

        public Time_Encoder(JArray orders)
        {
            Dictionary<DateTime, bool> tmp = new Dictionary<DateTime, bool>();
            markov_data = new SortedDictionary<DateTime, JArray>();
            DateTime min = DateTime.MaxValue, max = DateTime.MinValue;
            foreach (JToken item in orders)
            {
                DateTime dt = DateTime.ParseExact(item["recv_date"].ToString(), "yyyy-MM-dd hh:mm:ss", null);
                tmp[dt] = true;
                if (!markov_data.ContainsKey(dt)) markov_data[dt].Add(item);
                else markov_data[dt] = new JArray(item);
                min = (min < dt ? min : dt);
                max = (max > dt ? max : dt);
            }

            List<bool> list = new List<bool>();
            int idle_days = 0;
            for (DateTime i = min; i <= max; i = i.AddDays(1))
            {
                if (tmp[i]) idle_days = 0;
                else idle_days += 1;

                if (idle_days >= max_days) continue;
                list.Add(tmp[i]);
            }
            logstic_data = new BitArray(list.ToArray());
        }

        public Tuple<bool[] ,bool>[] get_logistic(int offset) 
        {
            Tuple<bool[], bool>[] ret = new Tuple<bool[], bool>[logstic_data.Length - offset];
            for(int i = 0;i != ret.Length;i++)
            {
                bool[] tmp = new bool[offset];
                for (int j = 0; j != offset; j++)
                    tmp[j] = logstic_data[i + j];
                ret[i] = new Tuple<bool[], bool>(tmp, logstic_data[i + offset]);
            }
            return ret;
        }

        public SortedDictionary<DateTime, JArray> get_markov() { return markov_data; }
    }
}
