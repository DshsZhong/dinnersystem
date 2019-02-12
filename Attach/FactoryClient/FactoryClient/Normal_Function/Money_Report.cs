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
            for (int year = 1; year <= 3; year++)
                for (int cls = 1; cls <= 20; cls++)
                    charge[(year * 100 + cls).ToString()] = 0;
            charge["other"] = 0;

            foreach (JToken item in data)
            {
                string cno = item["user"]["class"]["class_no"].ToObject<string>();
                if(charge.ContainsKey(cno))
                    charge[cno] += item["money"]["charge"].ToObject<int>();
                else
                    charge["other"] += item["money"]["charge"].ToObject<int>();
            }

            invoker(75);
            for (int year = 1; year <= 3; year++)
                for (int cls = 1; cls <= 20; cls++)
                    excel.Write(cls + 1, year * 3 - 1, charge[(year * 100 + cls).ToString()]);
            excel.Write(24, 2, charge["other"]);
            excel.Write(5, 11, req.uname);
            excel.Write(6, 11, l);
            excel.Write(7, 11, r);

            invoker(100);
        }
    }
}
