using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace dinnersys_import
{
    public partial class Form1 : Form
    {
        excel reader;
        mysql writer;
        Dictionary<string, string> row;
        bool success = true;
        Thread t;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Activate();
            writer = new mysql(password.Text, Int32.Parse(year.Text));
            reader = new excel(openFileDialog1.FileName);

            success = true;
            dataGridView1.Columns.Add("school_id", "學號");
            dataGridView1.Columns.Add("name", "姓名");
            dataGridView1.Columns.Add("birthday", "生日");
            dataGridView1.Columns.Add("seat_id", "座號");
            dataGridView1.Columns.Add("status", "匯入狀態");

            t = new Thread(new ThreadStart(loop));
            t.Priority = ThreadPriority.BelowNormal;
            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "C:\\Users\\lawre\\Desktop";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
        }

        void loop()
        {
            while(true)
            {
                Application.DoEvents();

                row = reader.get_row();
                if (row == null)
                {
                    writer = null;
                    reader = null;
                    GC.Collect();
                    if (!success) MessageBox.Show("有資料匯入失敗");
                    break;
                }
                else
                {
                    string seat = row["座號"].Replace(" ", "");
                    string seat_id = row["班級"].Replace(" ", "") + (seat.Length == 1 ? "0" + seat : seat);
                    string name = row["姓名"];
                    string birth = row["生日"];
                    string unique_id = row["學號"];
                    bool current_success = true;

                    try
                    {
                        writer.do_person(unique_id, birth, seat_id, name);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        dataGridView1.Rows.Add(unique_id, name, birth, seat_id, "匯入成功");
                    }
                    catch (Exception ex)
                    {
                        current_success = false;
                        dataGridView1.Rows.Add(unique_id, name, birth, seat_id, "匯入失敗");                        
                    }
                    success |= current_success;
                }
            }
            t.Abort();
        }
    }
}
