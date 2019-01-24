using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace bank_server
{
    class MoneyTable
    {
        List<string> id;
        List<int> money;
        public MoneyTable(string file)
        {
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(file);
            _Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Range xlRange = xlWorksheet.UsedRange;
            for (int i = 1; i <= xlRange.Row; i++)
            {
                id.Add(xlRange[i, 1]);
                money.Add(xlRange[i, 2]);
            }
            xlWorkbook.Close();
        }

        public List<string> decompose(int charge)
        {
            //Assume that money[i + 1] = n * money[i] ,n is a natural number.
            List<string> ret = new List<string>();
            for (int i = money.Count - 1; i != -1;)
            {
                if (charge >= money[i])
                {
                    ret.Add(id[i]);
                    charge -= money[i];
                }
                else i--;
            }
            return ret;
        }
    }
}
