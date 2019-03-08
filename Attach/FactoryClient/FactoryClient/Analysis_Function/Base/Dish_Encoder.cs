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
            foreach (JToken tmp in orders) foreach (JToken item in tmp["dish"])
                {
                    string dname = concat_name(item);
                    int new_id = id.Count;
                    if (!id.ContainsKey(dname))
                    {
                        id[dname] = new_id;
                        name[new_id] = dname;
                    }
                }
            name[id.Count] = "總和";
            id["總和"] = id.Count;
        }

        public string get_name(int did) { return name[did]; }
        public int get_id(string dname) { return id[dname]; }
        public int get_id(JToken dish) { return id[concat_name(dish)]; }
        public int get_size() { return id.Keys.Count; }

        string concat_name(JToken item)
        {
            return item["department"]["factory"]["name"].ToString() + "(" +
                item["department"]["factory"]["id"].ToString() + ")";
        }
    }
}
