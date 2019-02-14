using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace FactoryClient.Analysis_Function
{
    class Person_Model
    {
        Logistic order;
        Markov ratio;
        Markov future;

        bool Allow_Future = false;
        public Person_Model(JArray orders)
        {

        }

        public void Train()
        {

        }

        public void Future_Train()
        {

        }

        public Vector<Double> Query(int days = 1)
        {
            return null;
        }
    }
}
