using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Media;
using System.Diagnostics;

namespace bank_server
{
    public partial class Form1 : Form
    {
        Main_Controller controller;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("行為"));
            table.Columns.Add(new DataColumn("POS帳號"));
            table.Columns.Add(new DataColumn("扣款額"));
            table.Columns.Add(new DataColumn("時間"));
            table.Columns.Add(new DataColumn("回傳值"));
            show_data.DataSource = table;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        string open_file()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.FileName;
            else
                return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show_Local_Ip();
        }

        private void Show_Local_Ip()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return;
            string strHostName = Dns.GetHostName(), ip = "";
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            foreach (IPAddress ipaddress in iphostentry.AddressList)
                if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ip += ipaddress.ToString() + " / ";
            local_ip.Text = ip.Remove(ip.Length - 3);
        }

        private void openLog_Click(object sender, EventArgs e)
        {
            log_location.Text = open_file();
        }

        private void start_session_Click(object sender, EventArgs e)
        {
            init_database.Enabled = true;
            protocol_password.Enabled = log_location.Enabled = openLog.Enabled = false;
            Timestamp_Delay.Enabled = start_session.Enabled = false;
        }

        private void init_database_Click(object sender, EventArgs e)
        {
            force_delay.Enabled = activate.Enabled = true;
            close.Enabled = db_account.Enabled = db_name.Enabled = false;
            db_password.Enabled = init_database.Enabled = false;
            Database db = new Database(db_account.Text, db_name.Text, db_password.Text);
            Writing w = new Writing();
            Reading r = new Reading(db);
            controller = new Main_Controller(protocol_password.Text, Timestamp_Delay.Text, r, w, show_data, log_location.Text);
            Updater.Enabled = true;
        }

        private void activate_Click(object sender, EventArgs e)
        {
            close.Enabled = true;
            notified = activate.Enabled = false;
            controller.Start();
        }

        private void close_Click(object sender, EventArgs e)
        {
            activate.Enabled = true;
            close.Enabled = false;
            controller.Stop();
        }

        int running_seconds = 0;
        bool notified = false;
        SoundPlayer player;
        private void Updater_Tick(object sender, EventArgs e)
        {
            running_seconds += 1;
            int seconds = running_seconds;
            int day = seconds / 24 / 60 / 60; seconds -= day * 24 * 60 * 60;
            int hours = seconds / 60 / 60; seconds -= hours * 60 * 60;
            int minutes = seconds / 60; seconds -= minutes * 60;
            string show = day.ToString() + "天" + hours.ToString() + "小時" + minutes + "分鐘" + seconds + "秒";
            running_due.Text = "啟動時間: " + show;
            writes.Text = "累計繳款次數: " + controller.Writes.ToString();
            reads.Text = "累計讀取次數: " + controller.Reads.ToString();

            if (!controller.Alive && !notified)
            {
                player  = new SoundPlayer();
                player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\music.wav";
                player.PlayLooping();
                notified = true;
            }
            if (!controller.Alive && close.Enabled)
            {
                activate.Enabled = true;
                close.Enabled = false;
                controller.Stop();
                MessageBox.Show("繳款時發生問題，緊急關閉系統");
                player.Stop();
                player = null;
            }
        }

        private void force_delay_Scroll(object sender, EventArgs e)
        {
            controller.writer.presser.Delay = force_delay.Value;
            force_delay_label.Text = "強制延遲(" + force_delay.Value.ToString() + "ms): ";
        }
    }
}
