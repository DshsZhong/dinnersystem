using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dinnersys_export
{
    public partial class Form1 : Form
    {
        export_excel excel;
        fetch_infor info;
        public Form1()
        {
            InitializeComponent();
        }

        private void export_Click(object sender, EventArgs e)
        {
            string start = this.start.Value.ToShortDateString().Replace("-" ,"/");
            string end = this.end.Value.ToShortDateString().Replace("-", "/");

            string fileName = "";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                }
            }
            excel = new export_excel(fileName);
            info = new fetch_infor(account.Text, password.Text, start ,end);
            JArray arr = info.get(history.Checked);

            string[] money = { "40", "55" };
            string[] facto = { "台灣小吃部", "愛佳便當" };
            for (int grade = 1; grade <= 3;grade++)
            {
                for(int cls = 1;cls <= 20;cls++)
                {
                    for(int charge = 0;charge != 2;charge++)
                    {
                        for(int factory = 0;factory != 2;factory++)
                        {
                            int value = (from objs in arr.Values<JObject>()
                                         where objs["dish"]["dish_cost"].ToString() == money[charge]
                                             && objs["user"]["class"]["class_no"].ToString() == (grade * 100 + cls).ToString()
                                             && objs["dish"]["factory"]["name"].ToString().Split('-')[0] == facto[factory]
                                         select objs).Count();
                            excel.write(grade * 100 + cls, facto[factory], Int32.Parse(money[charge]), value);
                        }
                    }
                }
            }
            
            
        }


    }
}
