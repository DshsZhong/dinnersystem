using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClient.Analysis_Function
{
    class Export_Model
    {
        ExcelStream excel;
        Model data;

        public Export_Model(ExcelStream excel ,Model data)
        {
            this.data = data;
            this.excel = excel;
        }

        public void Write(DateTime dt ,int conf_interval ,UpdateProgress invoker)
        {
            int size = data.Get_Model().dish_encoder.get_size();
            for(int i = 0;i != size;i++)
            {
                string dname = data.Get_Model().dish_encoder.get_name(i);
                Tuple<int ,int ,double ,int> result = data.Show(dt, dname, 
                    conf_interval, data.Get_Model().people.Count());
                double value = result.Item3;
                excel.Write(i + 2, 1, dname);
                excel.Write(i + 2, 2, Math.Round(value * 100).ToString() + "%");
                excel.Write(i + 2, 3, result.Item1.ToString());
                excel.Write(i + 2, 4, result.Item2.ToString());
                excel.Write(i + 2, 5, result.Item4.ToString());
                invoker((int)Math.Ceiling((double)(i + 1) / size * 100));
            }
        }
    }
}
