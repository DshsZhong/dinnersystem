using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryClient.Analysis_Function
{
    delegate void UpdateChart(int progress, float value, string task);
    class Model
    {
        Group_Model model;
        public bool Finished_Build = false;

        public Model(JArray data, int pool)
        {
            model = new Group_Model(data, pool);
        }

        public void Build(UpdateChart invoker, int gradient, int ternary)
        {
            Task.Run(() => model.Train(gradient, ternary));
            for (int counter = 0; model.current_days == -1; counter++)
            {
                float cost_sum = 0;
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
            invoker(0 ,0 ,"完成訓練");
            Finished_Build = true;
        }

        public void UpdateForm(ComboBox dish)
        {
            dish.Invoke((MethodInvoker)(() =>
            {
                dish.Items.Clear();
                for (int i = 0; i != model.dish_encoder.get_size(); i++)
                    dish.Items.Add(model.dish_encoder.get_name(i));
            }));
        }

        public float Show(Chart show, DateTime dt, string dname ,int interval)
        {
            float[] result = model.Query(dname , dt.Subtract(DateTime.Now).Days);
            string tag = "模型預測 " + dname + ": ";
            show.Series.Add(tag);
            int max = 0;
            for (int i = 0; i != result.Length; i++)
            {
                if (result[max] < result[i]) max = i;
                show.Series[tag].Points.AddXY(i, result[i]);
            }

            float sum = 0;
            for(int i = max - interval;i != max + interval;i++)
            {
                if (!(0 <= i && i < result.Length)) continue;
                sum += result[i];
            }

            return sum;
        }
    }
}
