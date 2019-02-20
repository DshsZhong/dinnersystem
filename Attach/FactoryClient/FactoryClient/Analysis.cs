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

        const int Running_Previous = 5;
        public Analysis(Request req)
        {
            InitializeComponent();
            this.req = req;
            data = Base_Function.Preload.Load("D:\\data.json");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Download_Click(object sender, EventArgs e)
        {
            Download_Progress_Text.Text = "目前進度: 下載完成";
            Making_Model.Enabled = Classify.Enabled = true;
            classify = new Classify(data);
            /*Task.Run(() =>
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
            });*/
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
                List<double> recorder = new List<double>();
                model.Build((int time, double value, string task) =>
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        double max = double.MinValue;
                        Running_Task.Text = "執行任務:" + task;
                        recorder.Add(value);
                        Running_Chart.Series.Clear();
                        Running_Chart.Series.Add("損失函數值");
                        for (int i = 1; i <= Running_Previous; i++)
                        {
                            int index = i + recorder.Count - Running_Previous;
                            if (!(recorder.Count > index && index >= 0)) continue;
                            double data = -recorder[index];
                            Running_Chart.Series["損失函數值"].Points.AddXY(i, data);
                            max = (max > data ? max : data);
                        }
                        Running_Chart.ChartAreas[0].AxisY.Minimum = 0;
                        Running_Chart.ChartAreas[0].AxisY.Maximum = max;
                        Running_Chart.ChartAreas[0].AxisY.Interval = max / 2;
                    }));
                }, gvalue, tvalue);
                while (!model.Finished_Build) Thread.Sleep(100);
                model.UpdateForm(Dish_Name);
                Invoke((MethodInvoker)(() => Predict_Model.Enabled = true));
            });
        }

        private void Update(object sender, EventArgs e)
        {
            Show_Interval_Label.Text = "顯示區間: ±" + Show_Interval.Value + "(份)";
            Confidence_Interval_Label.Text = "信賴區間: ±" + Confidence_Interval.Value + "(份)";
            double odd = model.Show(main_chart, 
                DateTime.Now.AddDays(1).AddHours(1), 
                Dish_Name.GetItemText(Dish_Name.SelectedItem), 
                Confidence_Interval.Value,
                Show_Interval.Value) * 100;
            Confidence_Level.Text = "信心水平: " + odd.ToString("##.##") + "%";
        }

        private void Pool_Size_Scroll(object sender, EventArgs e)
        { Pool_Show.Text = "執行池大小:(" + Pool_Size.Value + ")"; }

        private void Ternary_Scroll(object sender, EventArgs e)
        { Ternary_Show.Text = "三分搜迭代量:(" + Ternary.Value + ")"; }

        private void Gradient_Scroll(object sender, EventArgs e)
        { Gradient_Show.Text = "梯度上升迭代數:(" + Gradient.Value + ")"; }
    }
}
