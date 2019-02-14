using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClient.Analysis_Function
{
    class Group_Model
    {
        Person_Model[] people;
        public Group_Model(JArray data)
        {

        }

        public double[] Query(string dname ,int days = 1)
        {
            return null;
        }
    }
}
