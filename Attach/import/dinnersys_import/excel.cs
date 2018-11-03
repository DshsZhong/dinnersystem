using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace dinnersys_import
{
    class excel
    {
        Excel.Worksheet Sheet;
        List<string> keys;
        int count = 2;

        public excel(string path)
        {
            Sheet = initailExcel().Workbooks.Open(path).Sheets[1];
            string tmp = "";
            keys = new List<string>();
            for(int i = 1;;i++)
            {
                tmp = ((Excel.Range)Sheet.Cells[1, i]).Text;
                if (tmp == "") break;
                keys.Add(tmp);
            }
        }
        ~excel()
        {
            Process[] procs = Process.GetProcessesByName("excel");
            foreach (Process pro in procs)
            {
                pro.Kill();//沒有更好的方法,只有殺掉進程
            }
        }

        Excel.Application initailExcel()
        {
            Excel.Application _Excel;
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
                _Excel = new Excel.Application();
            }
            else
            {
                object obj = Marshal.GetActiveObject("Excel.Application");//引用已在執行的Excel
                _Excel = obj as Excel.Application;
            }
            _Excel.Visible = true;//設false效能會比較好
            return _Excel;
        }

        public Dictionary<String ,String> get_row()
        {
            Dictionary<String, String> ret = new Dictionary<string, string>();
            for(int i = 1;i != keys.Count + 1;i++)
            {
                if(((Excel.Range)Sheet.Cells[count, i]).Text == "")
                {
                    return null;
                }
                ret[keys[i - 1]] = ((Excel.Range)Sheet.Cells[count, i]).Text;
            }
            count += 1;
            return ret;
        }
    }
}
