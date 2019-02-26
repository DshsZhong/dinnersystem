using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace FactoryClient
{
    class Update_Menu
    {
        Request req;
        ExcelStream excel;
        public Update_Menu(Request req, ExcelStream excel)
        {
            this.req = req;
            this.excel = excel;
        }

        public void Download(UpdateProgress invoker)
        {
            JArray data = req.Get_Dish() ,real = new JArray();
            foreach (JToken item in data)
                if (item["department"]["factory"]["name"].ToString() == req.uname)
                    real.Add(item);

            int sum = real.Count;
            int counter = 2;
            foreach (JToken item in real)
            {
                int id = Int32.Parse(item["dish_id"].ToString());
                string dname = item["dish_name"].ToString();
                string charge = item["dish_cost"].ToString();
                string vege = item["vege"]["name"].ToString();
                string idle = item["is_idle"].ToString();
                string daily_limit = item["daily_produce"].ToString();
                int department_id = Int32.Parse(item["department"]["id"].ToString());
                string department = item["department"]["name"].ToString() + "(" + ((department_id - 1) % 4 + 1).ToString() + ")";
                string factory = item["department"]["factory"]["name"].ToString() + "(" + item["department"]["factory"]["id"].ToString() + ")";

                excel.Write(counter, 1, id);
                excel.Write(counter, 2, dname);
                excel.Write(counter, 3, charge);
                excel.Write(counter, 4, (vege == "MEAT" ? "葷" : "素"));
                excel.Write(counter, 5, (idle == "0" ? "否" : "是"));
                excel.Write(counter, 6, daily_limit);
                excel.Write(counter, 7, department);
                excel.Write(counter, 8, factory);
                excel.Write(counter, 9, DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss"));

                counter += 1;
                invoker((int)Math.Ceiling(((double)(counter - 2)) / sum * 100));
            }
        }

        /* 
         * id=1
         * dish_name=asdfasdfere
         * charge_sum=123
         * is_vege=PURE 
         * is_idle=false
         * daily_limit=1000 
         */
        public void Upload(UpdateProgress invoker)
        {
            List<string> suffix = new List<string>();
            List<List<string>> data = excel.GetRow();
            foreach (List<string> row in data)
            {
                string id = row[0];
                if (!id.All(char.IsDigit)) continue;
                string dname = row[1];
                string charge = row[2];
                string vege = (row[3] == "葷" ? "MEAT" : "PURE");
                string idle = (row[4] == "是" ? "true" : "false");
                string limit = row[5];
                suffix.Add("&id=" + WebUtility.UrlEncode(id) + 
                    "&dish_name=" + WebUtility.UrlEncode(dname) + 
                    "&charge_sum=" + WebUtility.UrlEncode(charge) + 
                    "&is_vege=" + WebUtility.UrlEncode(vege) + 
                    "&is_idle=" + WebUtility.UrlEncode(idle) + 
                    "&daily_limit=" + WebUtility.UrlEncode(limit));
            }
            req.Update_Dish(suffix , invoker);
        }
    }
}
