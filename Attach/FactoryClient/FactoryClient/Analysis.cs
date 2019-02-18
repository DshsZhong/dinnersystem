using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactoryClient.Analysis_Function;

namespace FactoryClient
{
    public partial class Analysis : Form
    {
        Request req;
        JArray data;
        Classify classify;
        Model model;
        public Analysis(Request req)
        {
            InitializeComponent();
            this.req = req;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Download_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                DateTime start = Start_Date.Value, end = End_Date.Value;
                Invoke((MethodInvoker)(() => Download_Progress_Text.Text = "目前進度: 下載中"));
                data = req.Get_Order(start.ToString("yyyy-MM-dd hh:mm:ss").Replace("-", "/").Replace(" ", "-"),
                    end.ToString("yyyy-MM-dd hh:mm:ss").Replace("-", "/").Replace(" ", "-") ,true);
                Invoke((MethodInvoker)(() => MessageBox.Show("完成下載")));
                Invoke((MethodInvoker)(() =>
                {
                    Download_Progress_Text.Text = "目前進度: 下載完成";
                    Making_Model.Enabled = Classify.Enabled = true;
                }));
                classify = new Classify(data);
            });
        }

        private void Classification_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<Tuple<string, int>> data = new List<Tuple<string, int>>();
            Classify_Chart.Series.Clear();
            Classify_Chart.Series.Add(Classification.Text);
            Semi_Classify.Enabled = false;
            switch (Classification.Text)
            {
                case "班級":
                    Semi_Classify.Enabled = true;
                    break;
                case "年級":
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.grade);
                    break;
                case "每周":
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.week);
                    break;
                case "每月":
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.month);
                    break;
                default:
                    MessageBox.Show("發生問題");
                    break;
            }

            foreach (Tuple<string, int> item in data)
                Classify_Chart.Series[Classification.Text].Points.AddXY(item.Item1, item.Item2);
        }

        private void Semi_Classify_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<Tuple<string, int>> data = new List<Tuple<string, int>>();
            switch (Semi_Classify.Text)
            {
                case "高一":
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.user_class, "1");
                    break;
                case "高二":
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.user_class ,"2");
                    break;
                case "高三":
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.user_class, "3");
                    break;
                default:
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.user_class, "其他");
                    break;
            }

            Classify_Chart.ChartAreas[0].AxisX.Interval = 1;
            Classify_Chart.Series[Classification.Text].Points.Clear();
            foreach (Tuple<string, int> item in data)
                Classify_Chart.Series[Classification.Text].Points.AddXY(item.Item1, item.Item2);
        }

        private void Build_Click(object sender, EventArgs e)
        {
            int psize = Pool_Size.Value ,gvalue = Gradient.Value ,tvalue = Ternary.Value;
            Task.Run(() =>
            {
                model = new Model(data, psize);
                model.Build((int progress, float value, string task) =>
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        Running_Progress.Text = progress.ToString() + value.ToString() + task;
                    }));
                }, gvalue, tvalue);
                while (!model.Finished_Build) Thread.Sleep(100);
                model.UpdateForm(Dish_Name);
                Invoke((MethodInvoker)(() => Predict_Model.Enabled = true));
            });
        }

        private void show_model_Click(object sender, EventArgs e)
        {
            model.Show(main_chart, DateTime.Now.AddDays(1).AddHours(1), Dish_Name.GetItemText(Dish_Name.SelectedItem), 3);
        }
    }
}
