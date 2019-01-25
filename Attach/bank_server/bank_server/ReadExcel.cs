using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace bank_server
{
    class ReadExcel
    {
        Worksheet Sheet;
        public ReadExcel(string path)
        {
            Sheet = initailExcel().Workbooks.Open(path).Sheets[1];
        }
        ~ReadExcel()
        {
            Process[] procs = Process.GetProcessesByName("excel");
            foreach (Process pro in procs)
            {
                pro.Kill();//沒有更好的方法,只有殺掉進程
            }
        }

        Application initailExcel()
        {
            Application _Excel;
            bool flag = false;
            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName == "EXCEL")
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                _Excel = new Application();
            }
            else
            {
                object obj = Marshal.GetActiveObject("Excel.Application");//引用已在執行的Excel
                _Excel = obj as Application;
            }
            _Excel.Visible = true;//設false效能會比較好
            return _Excel;
        }

        public string[,] get_row()
        {
            int x = 0, y = 0;
            for (int i = 1; ; i++)
            {
                int j;
                for (j = 1; ; j++)
                {
                    if (((Range)Sheet.Cells[i, j]).Text == "") break;
                    x = (x > i ? x : i);
                    y = (y > j ? y : j);
                }
                if (j == 1) break;
            }

            string[,] ret = new string[x, y];
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                    ret[i - 1, j - 1] = ((Range)Sheet.Cells[i, j]).Text;
            return ret;
        }
    }
}
