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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using Newtonsoft.Json;

namespace FactoryClient
{
    public partial class Analysis : Form
    {
        Request req;
        JArray data;
        Classify classify;
        Model model;

        const int Running_Previous = 100;
        public Analysis(Request req)
        {
            InitializeComponent();
            this.req = req;
            data = Base_Function.Preload.Load("D:\\data.json");
            export_location.Text = AppDomain.CurrentDomain.BaseDirectory + "輸出模型.xlsx";
            Load_Location.Text = Save_Location.Text = AppDomain.CurrentDomain.BaseDirectory + "data.json";
            load_start.Value = load_end.Value = End_Date.Value = Start_Date.Value = DateTime.Now;
        }

        string OpenFile()
        {
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    path = openFileDialog.FileName;
            }
            return path;
        }

        private void Back_Click(object sender, EventArgs e) { Close(); }

        #region Classification
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
                    data = classify.Get_Classify(Analysis_Function.Classify.Style.user_class, "2");
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
        #endregion

        #region Build
        private void Build_Click(object sender, EventArgs e)
        {
            Model_Status.Enabled = Running_Status.Enabled = true;
            int psize = Pool_Size.Value, gvalue = Gradient.Value, tvalue = Ternary.Value;
            Running_Chart.Series.Clear();
            Running_Chart.Series.Add("損失函數值");
            Running_Chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            Running_Chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            Running_Chart.Series["損失函數值"].ChartType = SeriesChartType.Line;
            Running_Chart.Series["損失函數值"].MarkerStyle = MarkerStyle.Circle;
            Running_Chart.Legends[0].Docking = Docking.Bottom;
            Task.Run(() =>
            {
                model = new Model(data, psize);
                List<double> recorder = new List<double>();
                model.Build((int time, double value, string task) =>
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        Running_Chart.Series["損失函數值"].Points.AddXY(time, -value);
                        Running_Task.Text = "執行任務: " + task;
                        Cost_Sum.Text = "損失函數和: " + Math.Round(-value, 3);
                        Train_Time.Text = "訓練時間: " + time + "(秒)";
                        People_Sum.Text = "參與人數: " + model.Get_Model().people.Count() + " (個)";
                        Order_Sum.Text = "點單量: " + data.Count + " (份)";
                    }));
                }, gvalue, tvalue);
                while (!model.Finished_Build) Thread.Sleep(100);
                model.UpdateForm(Dish_Name);
                Invoke((MethodInvoker)(() => Export.Enabled = Predict_Model.Enabled = true));
            });
        }

        private void Pool_Size_Scroll(object sender, EventArgs e)
        { Pool_Show.Text = "執行池大小:(" + Pool_Size.Value + ")"; }

        private void Ternary_Scroll(object sender, EventArgs e)
        { Ternary_Show.Text = "三分搜迭代量:(" + Ternary.Value + ")"; }

        private void Gradient_Scroll(object sender, EventArgs e)
        { Gradient_Show.Text = "梯度迭代量:(" + Gradient.Value + ")"; }
        #endregion

        private void Update(object sender, EventArgs e)
        {
            Show_Interval_Label.Text = "顯示區間: ±" + Show_Interval.Value + "(份)";
            Confidence_Interval_Label.Text = "信賴區間: ±" + Confidence_Interval.Value + "(份)";
            double odd = model.Show(DateTime.Now.AddDays(1).AddHours(1),
                Dish_Name.GetItemText(Dish_Name.SelectedItem),
                Confidence_Interval.Value,
                Show_Interval.Value,
                main_chart).Item3 * 100;
            Confidence_Level.Text = "信心水平: " + odd.ToString("##.##") + "%";
        }

        #region Export
        private void Open_Excel_Click(object sender, EventArgs e) { export_location.Text = OpenFile(); }

        private void Export_Excel_Click(object sender, EventArgs e)
        {
            void Update(int value)
            {
                export_progress.Value = value;
                progress_text.Text = "輸出進度: " + value + "%";
            }
            Export.Enabled = false;
            Export_Model export = new Export_Model(new ExcelStream(export_location.Text), model);
            export.Write(Show_Datetime.Value, Confidence_Interval.Value, Update);
            Export.Enabled = true;
            MessageBox.Show("輸出完成");
            Update(0);
        }
        #endregion

        #region Load
        private void Download_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                DateTime start = Start_Date.Value, end = End_Date.Value;
                data = req.Get_Order((start.ToString("yyyy-MM-dd") + " 00:00:00").Replace("-", "/").Replace(" ", "-"),
                    (end.ToString("yyyy-MM-dd") + " 23:59:59").Replace("-", "/").Replace(" ", "-"), true);
                Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show("完成下載");
                    Show_Datetime.Value = end.AddDays(1);
                    Making_Model.Enabled = Classify.Enabled = true;
                }));
                classify = new Classify(data);
            });
        }

        private void Save_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Save_Location.Text);
            sw.Write(data.ToString());
            sw.Flush();
            sw.Dispose();
            MessageBox.Show("儲存完成");
        }

        private void Open_Save_Click(object sender, EventArgs e) { Save_Location.Text = OpenFile(); }

        private void Load_Click(object sender, EventArgs e)
        {
            data = JsonConvert.DeserializeObject<JArray>(new StreamReader(Save_Location.Text).ReadToEnd());
            Making_Model.Enabled = Classify.Enabled = true;
            DateTime start = DateTime.MaxValue, end = DateTime.MinValue;
            foreach(JToken token in data)
            {
                DateTime dt = DateTime.Parse(token["recv_date"].ToString());
                start = start > dt ? dt : start;
                end = end > dt ? end : dt;
            }
            load_start.Value = start;
            load_end.Value = end;
            Show_Datetime.Value = end.AddDays(1);
            classify = new Classify(data);
            MessageBox.Show("載入完成");
        }

        private void Open_Load_Click(object sender, EventArgs e) { Load_Location.Text = OpenFile(); }
        #endregion
    }
}
