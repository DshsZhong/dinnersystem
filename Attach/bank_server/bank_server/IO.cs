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
        KeyPress presser;

        public Writing(Database db)
        {
            this.db = db;
            enable_writing = true;
        }

        public Writing(string file ,int delay)
        {
            enable_writing = false;
            table = new MoneyTable(file);
            presser = new KeyPress(delay);
        }

        public bool Write(string uid ,int charge)
        {
            if (enable_writing) return db.Debit(uid, charge);
            else
            {
                presser.Run(table.decompose(charge));
                return true;
            }
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
