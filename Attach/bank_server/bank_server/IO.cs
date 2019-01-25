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
        bool enable_writing;
        MoneyTable table;
        Database db;

        public Writing(Database db)
        {
            this.db = db;
            enable_writing = true;
        }

        public Writing(string file)
        {
            enable_writing = false;
            table = new MoneyTable(file);
        }

        public bool Write(string uid ,int charge)
        {
            if (enable_writing) return db.Debit(uid, charge);
            else return true;
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
    }
}
