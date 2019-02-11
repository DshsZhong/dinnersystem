using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Globalization;

namespace FactoryClient
{
    public partial class Form1 : Form
    {
        Request req;
        public Form1(Request req)
        {
            InitializeComponent();
            this.req = req;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            scale_start.Value = custom_start.Value = money_start.Value = today;
            scale_end.Value = custom_end.Value = money_end.Value = today.AddDays(1);
        }

        #region open_file
        string OpenFile()
        {
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    path = openFileDialog.FileName;
            }
            return path;
        }

        private void open_menu_Click(object sender, EventArgs e)
        {
            menu_file.Text = OpenFile();
        }

        private void open_scale_Click(object sender, EventArgs e)
        {
            scale_file.Text = OpenFile();
        }

        private void open_custom_Click(object sender, EventArgs e)
        {
            custom_file.Text = OpenFile();
        }

        private void open_money_Click(object sender, EventArgs e)
        {
            money_file.Text = OpenFile();
        }
        #endregion

        private void download_menu_Click(object sender, EventArgs e)
        {
            Menu.Enabled = false;
            Task.Run(() =>
            {
                Update_Menu menu_update = new Update_Menu(req, new ExcelStream(menu_file.Text));
                menu_update.Download();
                Invoke((MethodInvoker)(() => { Menu.Enabled = true; }));
            });
        }

        private void upload_menu_Click(object sender, EventArgs e)
        {
            Menu.Enabled = false;
            Task.Run(() =>
            {
                Update_Menu menu_update = new Update_Menu(req, new ExcelStream(menu_file.Text));
                menu_update.Upload();
                Invoke((MethodInvoker)(() => { Menu.Enabled = true; } ));
            });
        }

        private void download_scale_Click(object sender, EventArgs e)
        {
            Scale_Report scale = new Scale_Report(req, new ExcelStream(scale_file.Text));
            Scale.Enabled = false;
            Task.Run(() =>
            {
                scale.Download(scale_start.Value.ToString("yyyy-MM-dd hh:mm:ss"), scale_end.Value.ToString("yyyy-MM-dd hh:mm:ss"));
                Invoke((MethodInvoker)(() => { Scale.Enabled = true; }));
            });
        }

        private void download_custom_Click(object sender, EventArgs e)
        {
            Custom_Report custom = new Custom_Report(req, new ExcelStream(custom_file.Text));
            Custom.Enabled = false;
            Task.Run(() =>
            {
                custom.Download(custom_start.Value.ToString("yyyy-MM-dd hh:mm:ss"), custom_end.Value.ToString("yyyy-MM-dd hh:mm:ss"));
                Invoke((MethodInvoker)(() => { Custom.Enabled = true; }));
            });
        }

        private void download_money_Click(object sender, EventArgs e)
        {
            Money_Report money = new Money_Report(req, new ExcelStream(money_file.Text));
            Money.Enabled = false;
            Task.Run(() =>
            {
                money.Download(money_start.Value.ToString("yyyy-MM-dd hh:mm:ss"), money_end.Value.ToString("yyyy-MM-dd hh:mm:ss"));
                Invoke((MethodInvoker)(() => { Money.Enabled = true; }));
            });
        }
    }
}
