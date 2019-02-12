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
    public delegate void UpdateProgress(int value);
    public partial class Form1 : Form
    {
        Request req;
        public Form1(Request req)
        {
            InitializeComponent();
            this.req = req;
            user.Text = "現在廠商為: " + req.uname;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00.1");
            scale_start.Value = custom_start.Value = money_start.Value = today;
            scale_end.Value = custom_end.Value = money_end.Value = today.AddDays(1);
            menu_file.Text = AppDomain.CurrentDomain.BaseDirectory + "菜單.xlsx";
            scale_file.Text = AppDomain.CurrentDomain.BaseDirectory + "規模化報表.xlsx";
            custom_file.Text = AppDomain.CurrentDomain.BaseDirectory + "精緻化報表.xlsx";
            money_file.Text = AppDomain.CurrentDomain.BaseDirectory + "金額報表.xlsx";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
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
        private void open_menu_Click(object sender, EventArgs e) { menu_file.Text = OpenFile(); }
        private void open_scale_Click(object sender, EventArgs e) { scale_file.Text = OpenFile(); }
        private void open_custom_Click(object sender, EventArgs e) { custom_file.Text = OpenFile(); }
        private void open_money_Click(object sender, EventArgs e) { money_file.Text = OpenFile(); }
        #endregion

        private void menu_Click(object sender, EventArgs e)
        {
            void original()
            {
                Menu.Enabled = true;
                Menu_Progress_Show.Text = "目前進度:0%";
                Menu_Progress.Value = 0;
            }
            Menu.Enabled = false;
            Task.Run(() =>
            {
                try
                {
                    ExcelStream excel = new ExcelStream(menu_file.Text);
                    Update_Menu menu_update = new Update_Menu(req, excel);
                    UpdateProgress progress = new UpdateProgress((int value) =>
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            Menu_Progress.Value = value;
                            Menu_Progress_Show.Text = "目前進度:" + value.ToString() + "%";
                        }));
                    });
                    if (sender.Equals(download_menu)) menu_update.Download(progress);
                    else menu_update.Upload(progress);
                    excel.Close();
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show(sender.Equals(download_menu) ? "下載完成" : "上載完成");
                    }));
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show(ex.Message);
                    }));
                }
            });
        }

        private void download_scale_Click(object sender, EventArgs e)
        {
            void original()
            {
                Scale.Enabled = true;
                Scale_Progress_Show.Text = "目前進度:0%";
                Scale_Progress.Value = 0;
            }
            Scale.Enabled = false;
            Task.Run(() =>
            {
                try
                {
                    ExcelStream excel = new ExcelStream(scale_file.Text);
                    Scale_Report menu_update = new Scale_Report(req, excel);
                    menu_update.Download(scale_start.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                        scale_end.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                        new UpdateProgress((int value) =>
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                Scale_Progress.Value = value;
                                Scale_Progress_Show.Text = "目前進度:" + value.ToString() + "%";
                            }));
                        }));
                    excel.Close();
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show("下載完成");
                    }));
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show(ex.Message);
                    }));
                }
            });
        }

        private void download_custom_Click(object sender, EventArgs e)
        {
            void original()
            {
                Custom.Enabled = true;
                Custom_Progress_Show.Text = "目前進度:0%";
                Custom_Progress.Value = 0;
            }
            Custom.Enabled = false;
            Task.Run(() =>
            {
                try
                {
                    ExcelStream excel = new ExcelStream(custom_file.Text);
                    Custom_Report custom_update = new Custom_Report(req, excel);
                    custom_update.Download(custom_start.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                        custom_end.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                        new UpdateProgress((int value) =>
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                Custom_Progress.Value = value;
                                Custom_Progress_Show.Text = "目前進度:" + value.ToString() + "%";
                            }));
                        }));
                    excel.Close();
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show("下載完成");
                    }));
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show(ex.Message);
                    }));
                }
            });
        }

        private void download_money_Click(object sender, EventArgs e)
        {
            void original()
            {
                Money.Enabled = true;
                Money_Progress_Show.Text = "目前進度:0%";
                Money_Progress.Value = 0;
            }
            Money.Enabled = false;
            Task.Run(() =>
            {
                try
                {
                    ExcelStream excel = new ExcelStream(money_file.Text);
                    Money_Report money_update = new Money_Report(req, excel);
                    money_update.Download(money_start.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                        money_end.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                        new UpdateProgress((int value) =>
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                Money_Progress.Value = value;
                                Money_Progress_Show.Text = "目前進度:" + value.ToString() + "%";
                            }));
                        }));
                    excel.Close();
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show("下載完成");
                    }));
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        original();
                        MessageBox.Show(ex.Message);
                    }));
                }
            });
        }

        private void analysiser_Click(object sender, EventArgs e) { MessageBox.Show("敬請期待新功能"); }

        private void update_Click(object sender, EventArgs e)
        {
            void original()
            {
                update.Enabled = true;
                Update_Progress_Show.Text = "目前進度:0%";
                Update_Progress.Value = 0;
            }

            update.Enabled = false;
            Task.Run(() =>
            {
                Update_Program updater = new Update_Program(req, (int value) =>
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        Update_Progress_Show.Text = "目前進度:" + value.ToString() + "%";
                        Update_Progress.Value = value;
                    }));
                });
                if (updater.Updatable)
                {
                    updater.Update();
                    Invoke((MethodInvoker)(() => original()));
                    MessageBox.Show("成功更新，重新啟動前端");
                    updater.Finish();
                }
                else
                {
                    MessageBox.Show("無須更新");
                    Invoke((MethodInvoker)(() => original()));
                }
            });
        }
    }
}
