using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FactoryClient
{
    class Scale_Report
    {
        Request req;
        ExcelStream excel;
        public Scale_Report(Request req ,ExcelStream excel)
        {
            this.req = req;
            this.excel = excel;
        }

        public void Download(string l, string r ,UpdateProgress invoker)
        {
            JArray data = req.Get_Order(l.Replace("-", "/").Replace(" ", "-"), r.Replace("-", "/").Replace(" ", "-"));
            Dictionary<int, string> dish = new Dictionary<int, string>();
            Dictionary<int, string> department = new Dictionary<int, string>();
            int[] parent = new int[1000];
            JArray dish_respond = req.Get_Dish();
            foreach (JToken item in dish_respond)
            {
                if (item["department"]["factory"]["name"].ToString(Newtonsoft.Json.Formatting.None) != "\"" + req.uname + "\"") continue;
                if (item["is_idle"].ToString(Newtonsoft.Json.Formatting.None) == "\"1\"") continue;
                dish[item["dish_id"].ToObject<int>()] = item["dish_name"].ToString() + "(" + item["dish_cost"].ToString() + "$.)";
                department[item["department"]["id"].ToObject<int>()] = item["department"]["name"].ToString();
                parent[item["dish_id"].ToObject<int>()] = item["department"]["id"].ToObject<int>();
            }
            Dictionary<string, int[]> processed = preprocess(data);

            int row, col, i, j ,counter;
            counter = row = col = i = j = 1;
            foreach (KeyValuePair<string, int[]> tag in processed)
            {
                row = i;
                foreach (KeyValuePair<int, string> depart in department)
                {
                    excel.Write(i, j, tag.Key);
                    excel.Write(i, j + 1, depart.Value);
                    i += 1;
                    foreach (KeyValuePair<int, string> item in dish)
                    {
                        if (parent[item.Key] != depart.Key) continue;
                        excel.Write(i, j, item.Value);
                        excel.Write(i, j + 1, tag.Value[item.Key]);
                        i += 1;
                    }
                    i += 1;
                }

                if (col == 1)
                {
                    col += 1;
                    i = row;
                    j = 4;
                }
                else if (col == 2)
                {
                    excel.PageBreak(i);
                    col = 1;
                    j = 1;
                }

                invoker((int)Math.Ceiling((double)counter / processed.Keys.Count * 100));
                counter += 1;
            }
        }

        Dictionary<string, int[]> preprocess(JArray data)
        {
            Dictionary<string, int[]> ret = new Dictionary<string, int[]>();
            ret["總表"] = new int[1000];
            foreach (JToken item in data)
            {
                string did = item["dish"][0].ToString();
                string cno = item["user"]["class"]["class_no"].ToString();
                if (!ret.ContainsKey(cno)) ret[cno] = new int[1000];
                ret[cno][Int32.Parse(did)] += 1;
                ret["總表"][Int32.Parse(did)] += 1;
            }
            return ret;
        }
    }
}
