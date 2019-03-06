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
        DateTime min;
        const int max_days = 30;

        public Time_Encoder(JArray orders ,DateTime min ,DateTime max)
        {
            this.min = min;
            Dictionary<DateTime, bool> tmp = new Dictionary<DateTime, bool>();
            markov_data = new SortedDictionary<DateTime, JArray>();
            foreach (JToken item in orders)
            {
                DateTime dt = DateTime.ParseExact(item["recv_date"].ToString(), "yyyy-MM-dd HH:mm:ss", null);
                tmp[dt] = true;
                if (markov_data.ContainsKey(dt)) markov_data[dt].Add(item);
                else markov_data[dt] = new JArray(item);
            }

            List<bool> list = new List<bool>();
            for (DateTime i = min; i <= max; i = i.AddDays(1))
            {
                list.Add(tmp.ContainsKey(i));
            }
            logstic_data = new BitArray(list.ToArray());
        }

        public Tuple<bool[] ,bool ,int>[] get_logistic(int offset) 
        {
            int len = logstic_data.Length - offset;
            Tuple<bool[], bool ,int>[] ret = new Tuple<bool[], bool ,int>[len > 0 ? len : 0];
            for(int i = 0;i != ret.Length;i++)
            {
                bool[] tmp = new bool[offset];
                for (int j = 0; j != offset; j++)
                    tmp[j] = logstic_data[i + j];
                ret[i] = new Tuple<bool[], bool ,int>(tmp, logstic_data[i + offset] ,(int)min.AddDays(i).DayOfWeek);
            }
            return ret;
        }

        public SortedDictionary<DateTime, JArray> get_markov() { return markov_data; }
    }
}
