using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace dinnersys_export
{
    class export_excel
    {
        Excel.Worksheet Sheet;
        public export_excel(string path)
        {
            Sheet = initailExcel().Workbooks.Open(path).Sheets[1];
        }
        ~export_excel()
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

        public void write(int class_no ,string factory ,int charge ,int value)
        {
            int row, col = 0;
            row = class_no % 100 + 2;

            col += 1;
            if (factory == "台灣小吃部") col += 1;
            else col += 3;
            col += ((class_no / 100) - 1) * 7;

            if (charge == 55) col += 1;
            Sheet.Cells[row, col] = value;
        }
    }
}
