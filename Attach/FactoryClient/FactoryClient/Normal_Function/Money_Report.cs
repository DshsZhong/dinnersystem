using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClient
{
    class Money_Report
    {
        Request req;
        ExcelStream excel;
        public Money_Report(Request req, ExcelStream excel)
        {
            this.req = req;
            this.excel = excel;
        }

        public void Download(string l, string r ,UpdateProgress invoker)
        {
            invoker(25);
            JArray data = req.Get_Order(l.Replace("-", "/").Replace(" ", "-"), r.Replace("-", "/").Replace(" ", "-"));
            Dictionary<string, int> charge = new Dictionary<string, int>();
            Dictionary<int, int> amounts = new Dictionary<int, int>();
            for (int year = 1; year <= 3; year++)
                for (int cls = 1; cls <= 20; cls++)
                    charge[(year * 100 + cls).ToString()] = 0;
            charge["other"] = 0;
            for (int i = 40; i <= 100; i += 5) amounts[i] = 0;
            amounts[-1] = 0;

            foreach (JToken item in data)
            {
                string cno = item["user"]["class"]["class_no"].ToObject<string>();
                int value = item["money"]["charge"].ToObject<int>(); ;
                charge[charge.ContainsKey(cno) ? cno : "other"] += value;
                amounts[amounts.ContainsKey(value) ? value : -1] += 1;
            }

            invoker(75);
            for (int year = 1; year <= 3; year++)
                for (int cls = 1; cls <= 20; cls++)
                    excel.Write(cls + 1, year * 3 - 1, charge[(year * 100 + cls).ToString()]);
            for (int i = 11; i <= 23; i++)
                excel.Write(i, 11, amounts[(i - 11) * 5 + 40]);
            excel.Write(24, 11, amounts[-1]);
            excel.Write(24, 2, charge["other"]);
            excel.Write(5, 11, req.uname);
            excel.Write(6, 11, l);
            excel.Write(7, 11, r);

            invoker(100);
        }
    }
}
