using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace bank_server
{
    class MoneyTable
    {
        List<string> id = new List<string>();
        List<int> money = new List<int>();

        public MoneyTable(string file)
        {
            ReadExcel reader = new ReadExcel(file);
            string[,] buffer = reader.get_row();

            //ignore the first label row
            for (int i = 1; i != buffer.GetLength(0) ; i++)
            {
                id.Add(buffer[i, 0]);
                money.Add(Int32.Parse(buffer[i, 1]));
            }
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
