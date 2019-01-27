using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_server
{
    class Database
    {
        SqlConnection conn;
        bool final_check = true;

        public Database(string db_account, string db_name, string db_password)
        {
            string source = System.Environment.MachineName;
            string connetionString = "MultipleActiveResultSets=True;Data Source=" + source + ";Initial Catalog=" + db_name + ";User ID=" + db_account + ";Password=" + db_password;
            conn = new SqlConnection(connetionString);
            conn.Open();
        }

        ~Database()
        {
            conn.Close();
        }

        public int ReadBalance(string uid)
        {
            SqlCommand cmd = new SqlCommand("SELECT Account FROM Personnel WHERE IDno = @uid" ,conn);
            cmd.Parameters.AddWithValue("@uid", uid);
            SqlDataReader reader = cmd.ExecuteReader();
            int ret = -1;
            while (reader.Read())
                ret = (int)Math.Floor(float.Parse(reader.GetValue(0).ToString()));
            reader.Close();
            return ret;
        }

        public bool Debit(string uid ,int charge)
        {
            if (final_check && ReadBalance(uid) < charge)
                return false;
            SqlCommand cmd = new SqlCommand("UPDATE Personnel SET Account = Account - @charge FROM Personnel WHERE IDno = @uid", conn);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@charge", charge);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
