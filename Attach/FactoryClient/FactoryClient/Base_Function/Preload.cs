using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FactoryClient.Base_Function
{
    public class Preload
    {
        public static JArray Load(string location)
        {
            StreamReader sr = new StreamReader(location);
            string s = sr.ReadToEnd();
            return JArray.Parse(s);
        }

        public static void Save(string location ,JArray data)
        {
            string s = data.ToString();
            StreamWriter sw = new StreamWriter(location, false);
            sw.Write(s);
            sw.Flush();
        }
    }
}
