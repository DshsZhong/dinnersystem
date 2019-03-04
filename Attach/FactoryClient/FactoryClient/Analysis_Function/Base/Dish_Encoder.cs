using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClient.Analysis_Function
{
    class Dish_Encoder
    {
        Dictionary<string, int> id = new Dictionary<string, int>();
        Dictionary<int, string> name = new Dictionary<int, string>();

        public Dish_Encoder(JArray orders)
        {
            foreach (JToken tmp in orders)
                foreach (JToken item in tmp["dish"])
                {
                    string dname = item["dish_name"].ToString() + "(" + item["dish_cost"].ToString() + "$.)";
                    int new_id = id.Count;
                    if (!id.ContainsKey(dname))
                    {
                        id[dname] = new_id;
                        name[new_id] = dname;
                    }
                }
        }

        public string get_name(int did) { return name[did]; }
        public int get_id(string dname) { return id[dname]; }
        public int get_id(JToken dish)
        {
            string dname = dish["dish_name"].ToString() + "(" + dish["dish_cost"].ToString() + "$.)";
            return id[dname];
        }
        public int get_size() { return id.Keys.Count; }
    }
}
