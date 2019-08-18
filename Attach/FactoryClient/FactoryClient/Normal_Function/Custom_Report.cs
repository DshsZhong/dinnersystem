using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FactoryClient
{
    class Custom_Report
    {
        Request req;
        ExcelStream excel;
        public Custom_Report(Request req, ExcelStream excel)
        {
            this.req = req;
            this.excel = excel;
        }

        public void Download(string l, string r ,UpdateProgress invoker)
        {
            JArray orders = req.Get_Order(l.Replace("-", "/").Replace(" ", "-"), r.Replace("-", "/").Replace(" ", "-"));
            List<JToken> data = new List<JToken>(from token in orders orderby DateTime.Parse(token["recv_date"].ToString()) select token);

            JArray dish_respond = req.Get_Dish();

            int counter = 5;
            Dictionary<int, int> did_to_cordinate = new Dictionary<int, int>();
            
            foreach (JToken item in dish_respond)
            {
                if (item["department"]["factory"]["name"].ToString(Newtonsoft.Json.Formatting.None) != "\"" + req.uname + "\"") continue;
                if (item["is_idle"].ToString(Newtonsoft.Json.Formatting.None) == "\"1\"") continue;
                did_to_cordinate[item["dish_id"].ToObject<int>()] = counter;
                excel.Write(1, counter, item["dish_name"].ToString(Newtonsoft.Json.Formatting.None).Replace("\"" ,""));
                counter += 1;
            }

            counter = 2;
            foreach (JToken item in data)
            {
                int[] sum = new int[1000];
                foreach (JToken dish in item["dish"])
                    sum[dish.ToObject<int>()] += 1;

                excel.Write(counter, 1, counter - 1);
                excel.Write(counter, 2, item["user"]["seat_no"].ToString());
                excel.Write(counter, 3, Regex.Match(item["recv_date"].ToString(), " [0-9]{2}:[0-9]{2}").Groups[0].ToString().Replace(" " ,""));
                excel.Write(counter, 4, item["money"]["charge"].ToString());

                foreach (JToken dish in dish_respond)
                {
                    if (dish["department"]["factory"]["name"].ToString(Newtonsoft.Json.Formatting.None) != "\"" + req.uname + "\"") continue;
                    if (dish["is_idle"].ToString(Newtonsoft.Json.Formatting.None) == "\"1\"") continue;
                    excel.Write(counter, did_to_cordinate[dish["dish_id"].ToObject<int>()], 
                        sum[dish["dish_id"].ToObject<int>()] == 0 ? "" : sum[dish["dish_id"].ToObject<int>()].ToString());
                }

                counter += 1;
                invoker((int)Math.Ceiling((double)(counter - 2) / data.Count * 100));
            }
        }
    }
}
