using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace FactoryClient
{
    class ExcelStream
    {
        Excel.Worksheet Sheet;
        public ExcelStream(string path)
        {
            Sheet = initailExcel().Workbooks.Open(path).Sheets[1];
        }
        ~ExcelStream()
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

        public void Write(int x, int y, object value)
        {
            Sheet.Cells[x, y] = value;
        }

        public List<List<string>> GetRow()
        {
            List<List<string>> ret = new List<List<string>>();
            List<string> row = new List<string>();
            for(int i = 0; ;i++)
            {
                if (((Excel.Range)Sheet.Cells[i, 0]).Text == "") break;
                for (int j = 0; ; j++)
                {
                    string value = ((Excel.Range)Sheet.Cells[i, j]).Text;
                    if (value == "")
                    {
                        ret.Add(new List<string>(row));
                        row = new List<string>();
                        break;
                    }
                    row.Add(value);
                }
            }
            
            return ret;
        }
    }
}
