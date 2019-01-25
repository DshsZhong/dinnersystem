using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using System.IO;

namespace bank_server
{
    class Main_Controller
    {
        Internet internet;
        Reading reader;
        Writing writer;
        DataGridView show;
        StreamWriter logger;

        int reads = 0;
        int writes = 0;

        public int Reads
        {
            get { return reads; }
        }
        public int Writes
        {
            get { return writes; }
        }
        
        public Main_Controller(IPAddress allow_ip, Reading reader ,Writing writer, DataGridView show ,string log)
        {
            internet = new Internet(allow_ip, new Execute(Run));
            internet.Start_Listen();
            this.reader = reader;
            this.writer = writer;
            this.show = show;
            logger = new StreamWriter(log ,true);
            logger.AutoFlush = true;
        }

        public void Stop()
        {
            internet.Stop_Listen();
        }

        void Run(Tuple<dynamic, NetworkStream> data)
        {
            /* table.Columns.Add(new DataColumn("行為"));
            table.Columns.Add(new DataColumn("POS帳號"));
            table.Columns.Add(new DataColumn("扣款額"));
            table.Columns.Add(new DataColumn("時間"));
            table.Columns.Add(new DataColumn("回傳值")); */
            dynamic json = data.Item1;
            NetworkStream nws = data.Item2;

            DataTable table = show.DataSource as DataTable;
            DataRow row = table.NewRow();
            if (json.operation == "read")
            {
                int balance = reader.Get_Balance(json.uid.ToString());
                row[0] = "讀取";
                row[1] = json.uid.ToString();
                row[2] = "-";
                row[3] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                row[4] = balance.ToString();
                byte[] buffer = Encoding.ASCII.GetBytes(balance.ToString());
                nws.Write(buffer, 0, buffer.Length);
                reads += 1;
            }
            if (json.operation == "write")
            {
                string uid = json.uid.ToString();
                string charge = json.charge.ToString();
                string buffer = (writer.Write(uid ,Int32.Parse(charge)) ? "success" : "fail");
                row[0] = "寫入";
                row[1] = uid;
                row[2] = charge;
                row[3] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                row[4] = buffer;
                byte[] buf = Encoding.ASCII.GetBytes(buffer);
                nws.Write(buf, 0, buf.Length);
                writes += 1;
            }
            string msg = row[0] + "\t," + row[1] + "\t," + row[2] + "\t," + row[3] + "\t," + row[4];
            logger.WriteLine(msg);

            table.Rows.Add(row);
            nws.Close(3000);
        }
    }
}
