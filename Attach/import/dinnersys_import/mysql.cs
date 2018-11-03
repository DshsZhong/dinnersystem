using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dinnersys_import
{
    class mysql
    {
        MySqlConnection conn;
        int year;

        public mysql(string password, int year)
        {
            string dbHost = "localhost";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = password;//資料庫使用者密碼
            string dbName = "dinnersys";//資料庫名稱

            string connStr = "charset=utf8;SslMode=none;server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            conn.Open();

            this.year = year;
            init_class(year.ToString());
        }

        public void init_class(string year)
        {
            MySqlCommand cmd = conn.CreateCommand();
            for (int i = 1; i <= 3; i++)
            {
                cmd.CommandText = "CALL init_class(" + i.ToString() + " ," + year + ");";
                cmd.ExecuteNonQuery();
                
                for(int j = 1;j <= 25;j++)
                {
                    if(j >= 10)
                        update_data(i.ToString() + j.ToString() + "50", i.ToString() + j.ToString());
                    else
                        update_data(i.ToString() + "0" + j.ToString() + "50", i.ToString() + "0" + j.ToString());
                }
            }
            
        }

        public void do_person(string school_id ,string birthday ,string seat_id ,string name)
        {
            if(check_exist(school_id))
            {
                update_data(school_id, (Int32.Parse(seat_id) / 100).ToString());
            }
            else
            {
                insert_data(seat_id, school_id, name, birthday);
            }
        }

        bool check_exist(string school_id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT U.id FROM users AS U ,user_information AS UI WHERE U.info_id = UI.id AND UI.school_id = " + school_id, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool exist = reader.HasRows;
            reader.Close();
            return exist;
        }

        string get_login_id(string school_id, string seat_id)
        {
            int minguo = year - 1911;
            switch (seat_id[0])
            {
                case '1':
                    minguo -= 0;
                    break;
                case '2':
                    minguo -= 1;
                    break;
                case '3':
                    minguo -= 2;
                    break;
            }

            minguo %= 100;
            if (minguo < 10)
                return "0" + minguo.ToString() + school_id;
            else
                return minguo.ToString() + school_id;
        }

        void insert_data(string seat_id, string school_id, string name, string birthday)
        {
            int class_no = Int32.Parse(seat_id) / 100;
            int grade = Int32.Parse(seat_id) / 10000;
            string password = Int32.Parse(birthday.Replace("/", "")).ToString();
            string login_id = get_login_id(school_id, seat_id);

            string sql = "CALL make_user(NULL, '" + name + "' ,'0905-098-503' ,FALSE , 'UNKNOWN'" +
                ",(SELECT C.id FROM `dinnersys`.`class` as C WHERE C.class_no = " + class_no + " AND C.year =  " + year + ")" +
                ",'" + class_no + "', '" + school_id + "', '" + seat_id + "','pcic30th@gmail.com' ,'" + birthday + "'," +
                "'" + login_id + "' ,'" + password + "' ," +
                "3, '" + year + "')";

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        void update_data(string school_id, string new_classno)
        {
           string sql = "UPDATE users ,user_information " +
                "SET users.class_id = (SELECT C.id FROM `dinnersys`.`class` as C WHERE C.class_no = '" + new_classno + "' AND C.year =  " + year + ")," +
                "user_information.class_id = '" + new_classno + "'," +
                "users.year = '" + year + "'" +
                "WHERE users.info_id = user_information.id " +
                "AND user_information.school_id = '" + school_id + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
