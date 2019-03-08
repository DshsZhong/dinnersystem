using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace bank_server
{
    class Writing
    {
        Database db;
        public KeyPress presser;

        public Writing()
        {
            presser = new KeyPress();
        }

        public void Write(string uid, string fid , int charge ,Action callback)
        {
            List<string> tmp = new List<string>();
            tmp.Add(uid);
            tmp.Add(fid + charge.ToString());
            presser.Run(tmp ,callback);
        }
    }

    class Reading
    {
        Database db;
        public Reading(Database db)
        {
            this.db = db;
        }

        public int Get_Balance(string uid)
        {
            return db.ReadBalance(uid);
        }

        public string Get_Cardno(string uid) { return db.Get_Card(uid); }
    }
}
