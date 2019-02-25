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
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bank_server
{
    class Main_Controller
    {
        public Writing writer;
        Internet internet;
        Reading reader;
        DataGridView show;
        StreamWriter logger;

        int Tolerance;
        string password;

        int reads = 0;
        int writes = 0;
        bool alive = true;

        public int Reads
        {
            get { return reads; }
        }
        public int Writes
        {
            get { return writes; }
        }
        public bool Alive
        {
            get { return alive; }
        }
        public Main_Controller(string password, string tolerance, Reading reader, Writing writer, DataGridView show, string log)
        {
            internet = new Internet(new Execute(Run));
            this.reader = reader;
            this.writer = writer;
            this.show = show;
            this.password = password;
            this.Tolerance = Int32.Parse(tolerance);
            logger = new StreamWriter(log, true);
            logger.AutoFlush = true;
        }

        public void Start()
        {
            alive = true;
            internet.Start_Listen();
        }

        public void Stop()
        {
            internet.Stop_Listen();
        }

        bool Auth(string remote_hased)
        {
            SHA512 sha = new SHA512CryptoServiceProvider();
            int now = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            for (int i = now - Tolerance; i != now + Tolerance; i++)
            {
                JObject json_obj = new JObject();
                json_obj["password"] = this.password;
                json_obj["timestamp"] = i.ToString();
                string json = json_obj.ToString(Newtonsoft.Json.Formatting.None);
                string local_hashed = BitConverter.ToString(sha.ComputeHash(Encoding.ASCII.GetBytes(json)));
                local_hashed = local_hashed.Replace("-", "").ToLower();
                if (local_hashed == remote_hased) return true;
            }
            return false;
        }

        bool Write(dynamic json)
        {
            string uid = json.uid.ToString();
            string fid = json.fid.ToString();
            int charge = Int32.Parse(json.charge.ToString());
            int money = reader.Get_Balance(uid);
            if (money < charge) return false;                              // The check before write in.
            writer.Write(uid, fid ,charge);                                // Write in.
            return alive = (reader.Get_Balance(uid) == (money - charge));  // The check after write in.
        }

        string Run(dynamic data)
        {
            /* table.Columns.Add(new DataColumn("行為"));
            table.Columns.Add(new DataColumn("POS帳號"));
            table.Columns.Add(new DataColumn("扣款額"));
            table.Columns.Add(new DataColumn("時間"));
            table.Columns.Add(new DataColumn("回傳值")); */
            dynamic json = data;

            string[] row = new string[5];
            string msg = "";
            string ret = "";
            if (json.operation == "read")
            {
                int balance;
                if (json.uid.ToString() == "-1") balance = 0;
                else balance = reader.Get_Balance(json.uid.ToString());
                row[0] = "讀取";
                row[1] = json.uid.ToString();
                row[2] = "-";
                row[3] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                row[4] = balance.ToString();
                ret = balance.ToString();
                reads += 1;
                msg = row[0] + "\t," + row[1] + "\t," + row[2] + "\t," + row[3] + "\t," + row[4];
            }
            if (json.operation == "write")
            {
                string result;
                int before = reader.Get_Balance(json.uid.ToString());
                if (json.uid.ToString() == "-1") result = "fail";
                else result = (Auth(json.auth.ToString()) && Write(json) ? "success" : "fail");  //Write will not be executed if Auth returns false
                int after = reader.Get_Balance(json.uid.ToString());
                row[0] = "寫入";
                row[1] = json.uid.ToString();
                row[2] = json.charge.ToString();
                row[3] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                row[4] = result;
                ret = result;
                writes += 1;
                msg = row[0] + "\t," + row[1] + "\t," + row[2] + "\t," + row[3] + "\t," + row[4] + "\t," + before.ToString() + "\t," + after.ToString();
            }
            logger.WriteLine(msg);

            show.Invoke((MethodInvoker)(() =>
            {
                DataTable table = show.DataSource as DataTable;
                if (table.Rows.Count >= 100)
                    table.Clear();
                table.Rows.Add(row);
                show.DataSource = table;
            }));

            return ret;
        }
    }
}
