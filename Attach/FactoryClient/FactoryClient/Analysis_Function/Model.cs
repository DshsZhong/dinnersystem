using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryClient.Analysis_Function
{
    delegate void UpdateChart(int progress, double value, string task);
    class Model
    {
        Group_Model model;
        public bool Finished_Build = false;

        public Model(JArray data, int pool)
        {
            model = new Group_Model(data, pool);
        }

        public Group_Model Get_Model() { return model; }

        public void Build(UpdateChart invoker, int gradient, int ternary)
        {
            Task.Run(() => model.Train(gradient, ternary));
            double cost_sum = 0; int counter = 0;
            for (; model.current_days == -1; counter++)
            {
                cost_sum = 0;
                bool all_trained = true;
                foreach (Person_Model p in model.people)
                {
                    if (p.order == null) continue;
                        all_trained &= p.Trained;
                    cost_sum += p.order.Cost();
                }
                invoker(counter, cost_sum, (all_trained ? "建立馬可夫鍊" : "建立數量模型"));
                Thread.Sleep(1000);
            }

            cost_sum = 0;
            foreach (Person_Model p in model.people)
            {
                if (p.order == null) continue;
                cost_sum += p.order.Cost();
            }
            invoker(counter, cost_sum, "完成訓練");
            Finished_Build = true;
        }

        public void UpdateForm(ComboBox dish)
        {
            dish.Invoke((MethodInvoker)(() =>
            {
                dish.Items.Clear();
                for (int i = 0; i != model.dish_encoder.get_size(); i++)
                    dish.Items.Add(model.dish_encoder.get_name(i));
                dish.SelectedIndex = 1;
            }));
        }

        public Tuple<int ,int ,double ,int> 
            Show(DateTime dt, string dname ,int confidence_interval ,int show_interval , Chart show = null)
        {
            double[] result = model.Query(dname , dt.Subtract(DateTime.Now).Days);
            string tag = dname;

            if(show != null)
            {
                show.Series.Clear();
                show.Series.Add(tag);
                show.ChartAreas[0].AxisX.IsMarginVisible = false;
                show.Legends[0].Docking = Docking.Bottom;
            }

            int l = Int32.MaxValue ,r = -1 ,max = 0;
            for (int i = 0; i != result.Length; i++)
                if (result[max] < result[i]) max = i;

            double sum = 0;
            confidence_interval = (int)Math.Floor((double)confidence_interval * max / 100);
            show_interval = (int)Math.Floor((double)show_interval * max / 100);
            for (int i = max - show_interval; i <= max + show_interval; i++)
            {
                if (!(0 <= i && i < result.Length)) continue;

                int length = max - i;
                if (show != null)
                {
                    int pid = show.Series[tag].Points.AddXY(i, result[i]);
                    if ((length > 0 ? length : -length) <= confidence_interval)
                        show.Series[tag].Points[pid].Color = Color.Red;
                    else show.Series[tag].Points[pid].Color = Color.Blue;
                }
                if ((length > 0 ? length : -length) <= confidence_interval)
                {
                    l = (l > i ? i : l);
                    r = (r > i ? r : i);
                    sum += result[i];
                }
            }

            return new Tuple<int, int, double ,int>(l ,r ,sum ,max);
        }
    }
}
