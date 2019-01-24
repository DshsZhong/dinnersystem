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

namespace bank_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            dinnersys_ip.Enabled = log_location.Enabled = openLog.Enabled = false;
        }

        private void init_database_Click(object sender, EventArgs e)
        {
            activate_read.Enabled = activate_write.Enabled = true;
            close.Enabled = db_account.Enabled = db_name.Enabled = false;
            db_password.Enabled = allow_write.Enabled = process.Enabled = false;
            money_table.Enabled = openMoneyTable.Enabled = false;
        }

        private void activate_read_Click(object sender, EventArgs e)
        {
            activate_read.Enabled = false;
            close.Enabled = true;
        }

        private void activate_write_Click(object sender, EventArgs e)
        {
            activate_write.Enabled = false;
            close.Enabled = true;
        }

        private void close_Click(object sender, EventArgs e)
        {
            activate_read.Enabled = activate_write.Enabled = true;
            close.Enabled = false;
        }

        private void allow_write_CheckedChanged(object sender, EventArgs e)
        {
            virtual_client.Enabled = !allow_write.Checked;
        }

        private void openMoneyTable_Click(object sender, EventArgs e)
        {
            money_table.Text = open_file();
        }
    }
}
