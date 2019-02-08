namespace bank_server
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.show_data = new System.Windows.Forms.DataGridView();
            this.activate = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Timestamp_Delay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openLog = new System.Windows.Forms.Button();
            this.start_session = new System.Windows.Forms.Button();
            this.running_due = new System.Windows.Forms.Label();
            this.writes = new System.Windows.Forms.Label();
            this.reads = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.log_location = new System.Windows.Forms.TextBox();
            this.local_ip = new System.Windows.Forms.TextBox();
            this.protocol_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.db_name = new System.Windows.Forms.TextBox();
            this.init_database = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.virtual_client = new System.Windows.Forms.GroupBox();
            this.force_delay = new System.Windows.Forms.TrackBar();
            this.force_delay_label = new System.Windows.Forms.Label();
            this.money_table = new System.Windows.Forms.TextBox();
            this.openMoneyTable = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.allow_write = new System.Windows.Forms.CheckBox();
            this.db_password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.db_account = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.show_data)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.virtual_client.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.force_delay)).BeginInit();
            this.SuspendLayout();
            // 
            // show_data
            // 
            this.show_data.AllowUserToAddRows = false;
            this.show_data.AllowUserToDeleteRows = false;
            this.show_data.AllowUserToOrderColumns = true;
            this.show_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.show_data.Location = new System.Drawing.Point(6, 66);
            this.show_data.Name = "show_data";
            this.show_data.RowTemplate.Height = 24;
            this.show_data.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.show_data.Size = new System.Drawing.Size(755, 326);
            this.show_data.TabIndex = 0;
            // 
            // activate
            // 
            this.activate.Enabled = false;
            this.activate.Location = new System.Drawing.Point(203, 21);
            this.activate.Name = "activate";
            this.activate.Size = new System.Drawing.Size(104, 39);
            this.activate.TabIndex = 2;
            this.activate.Text = "啟動插件";
            this.activate.UseVisualStyleBackColor = true;
            this.activate.Click += new System.EventHandler(this.activate_Click);
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(419, 21);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(114, 39);
            this.close.TabIndex = 3;
            this.close.Text = "暫停插件";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.show_data);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Controls.Add(this.activate);
            this.groupBox1.Location = new System.Drawing.Point(39, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 398);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "繳款功能";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Timestamp_Delay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.openLog);
            this.groupBox2.Controls.Add(this.start_session);
            this.groupBox2.Controls.Add(this.running_due);
            this.groupBox2.Controls.Add(this.writes);
            this.groupBox2.Controls.Add(this.reads);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.log_location);
            this.groupBox2.Controls.Add(this.local_ip);
            this.groupBox2.Controls.Add(this.protocol_password);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(39, 613);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 128);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系統資訊";
            // 
            // Timestamp_Delay
            // 
            this.Timestamp_Delay.Location = new System.Drawing.Point(323, 57);
            this.Timestamp_Delay.Name = "Timestamp_Delay";
            this.Timestamp_Delay.Size = new System.Drawing.Size(127, 22);
            this.Timestamp_Delay.TabIndex = 13;
            this.Timestamp_Delay.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "時戳延遲(s) :";
            // 
            // openLog
            // 
            this.openLog.Location = new System.Drawing.Point(375, 83);
            this.openLog.Name = "openLog";
            this.openLog.Size = new System.Drawing.Size(75, 23);
            this.openLog.TabIndex = 11;
            this.openLog.Text = "開啟";
            this.openLog.UseVisualStyleBackColor = true;
            this.openLog.Click += new System.EventHandler(this.openLog_Click);
            // 
            // start_session
            // 
            this.start_session.Location = new System.Drawing.Point(478, 32);
            this.start_session.Name = "start_session";
            this.start_session.Size = new System.Drawing.Size(86, 69);
            this.start_session.TabIndex = 9;
            this.start_session.Text = "啟動連線";
            this.start_session.UseVisualStyleBackColor = true;
            this.start_session.Click += new System.EventHandler(this.start_session_Click);
            // 
            // running_due
            // 
            this.running_due.AutoSize = true;
            this.running_due.Location = new System.Drawing.Point(596, 85);
            this.running_due.Name = "running_due";
            this.running_due.Size = new System.Drawing.Size(59, 12);
            this.running_due.TabIndex = 8;
            this.running_due.Text = "啟動時間: ";
            // 
            // writes
            // 
            this.writes.AutoSize = true;
            this.writes.Location = new System.Drawing.Point(596, 57);
            this.writes.Name = "writes";
            this.writes.Size = new System.Drawing.Size(83, 12);
            this.writes.TabIndex = 7;
            this.writes.Text = "累計繳款次數: ";
            // 
            // reads
            // 
            this.reads.AutoSize = true;
            this.reads.Location = new System.Drawing.Point(596, 28);
            this.reads.Name = "reads";
            this.reads.Size = new System.Drawing.Size(83, 12);
            this.reads.TabIndex = 6;
            this.reads.Text = "累計讀取次數: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "紀錄檔位置: ";
            // 
            // log_location
            // 
            this.log_location.Location = new System.Drawing.Point(99, 85);
            this.log_location.Name = "log_location";
            this.log_location.Size = new System.Drawing.Size(270, 22);
            this.log_location.TabIndex = 5;
            this.log_location.Text = "D:\\dinnersys.log";
            // 
            // local_ip
            // 
            this.local_ip.Location = new System.Drawing.Point(99, 28);
            this.local_ip.Name = "local_ip";
            this.local_ip.ReadOnly = true;
            this.local_ip.Size = new System.Drawing.Size(351, 22);
            this.local_ip.TabIndex = 4;
            // 
            // protocol_password
            // 
            this.protocol_password.Location = new System.Drawing.Point(99, 57);
            this.protocol_password.Name = "protocol_password";
            this.protocol_password.Size = new System.Drawing.Size(127, 22);
            this.protocol_password.TabIndex = 2;
            this.protocol_password.Text = "Fei Yu GGYY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "協定密碼: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本機ip位置:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "資料庫名稱:";
            // 
            // db_name
            // 
            this.db_name.Location = new System.Drawing.Point(99, 49);
            this.db_name.Name = "db_name";
            this.db_name.Size = new System.Drawing.Size(127, 22);
            this.db_name.TabIndex = 4;
            this.db_name.Text = "coop";
            // 
            // init_database
            // 
            this.init_database.Enabled = false;
            this.init_database.Location = new System.Drawing.Point(248, 52);
            this.init_database.Name = "init_database";
            this.init_database.Size = new System.Drawing.Size(151, 68);
            this.init_database.TabIndex = 9;
            this.init_database.Text = "連結資料庫";
            this.init_database.UseVisualStyleBackColor = true;
            this.init_database.Click += new System.EventHandler(this.init_database_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.virtual_client);
            this.groupBox3.Controls.Add(this.allow_write);
            this.groupBox3.Controls.Add(this.db_password);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.db_account);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.init_database);
            this.groupBox3.Controls.Add(this.db_name);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(39, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 165);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "連結資訊";
            // 
            // virtual_client
            // 
            this.virtual_client.Controls.Add(this.force_delay);
            this.virtual_client.Controls.Add(this.force_delay_label);
            this.virtual_client.Controls.Add(this.money_table);
            this.virtual_client.Controls.Add(this.openMoneyTable);
            this.virtual_client.Controls.Add(this.label10);
            this.virtual_client.Location = new System.Drawing.Point(456, 49);
            this.virtual_client.Name = "virtual_client";
            this.virtual_client.Size = new System.Drawing.Size(296, 103);
            this.virtual_client.TabIndex = 11;
            this.virtual_client.TabStop = false;
            this.virtual_client.Text = "虛擬客戶端";
            // 
            // force_delay
            // 
            this.force_delay.Enabled = false;
            this.force_delay.LargeChange = 1;
            this.force_delay.Location = new System.Drawing.Point(104, 52);
            this.force_delay.Maximum = 1000;
            this.force_delay.Name = "force_delay";
            this.force_delay.Size = new System.Drawing.Size(186, 45);
            this.force_delay.TabIndex = 21;
            this.force_delay.Value = 1000;
            this.force_delay.Scroll += new System.EventHandler(this.force_delay_Scroll);
            // 
            // force_delay_label
            // 
            this.force_delay_label.AutoSize = true;
            this.force_delay_label.Location = new System.Drawing.Point(6, 70);
            this.force_delay_label.Name = "force_delay_label";
            this.force_delay_label.Size = new System.Drawing.Size(104, 12);
            this.force_delay_label.TabIndex = 20;
            this.force_delay_label.Text = "強制延遲(1000ms): ";
            // 
            // money_table
            // 
            this.money_table.Location = new System.Drawing.Point(59, 23);
            this.money_table.Name = "money_table";
            this.money_table.Size = new System.Drawing.Size(153, 22);
            this.money_table.TabIndex = 12;
            this.money_table.Text = "D:\\dinnersysetm\\bank_server\\money_table.xlsx";
            // 
            // openMoneyTable
            // 
            this.openMoneyTable.Location = new System.Drawing.Point(218, 23);
            this.openMoneyTable.Name = "openMoneyTable";
            this.openMoneyTable.Size = new System.Drawing.Size(72, 23);
            this.openMoneyTable.TabIndex = 18;
            this.openMoneyTable.Text = "開啟";
            this.openMoneyTable.UseVisualStyleBackColor = true;
            this.openMoneyTable.Click += new System.EventHandler(this.openMoneyTable_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "金額表: ";
            // 
            // allow_write
            // 
            this.allow_write.AutoSize = true;
            this.allow_write.Location = new System.Drawing.Point(560, 21);
            this.allow_write.Name = "allow_write";
            this.allow_write.Size = new System.Drawing.Size(108, 16);
            this.allow_write.TabIndex = 14;
            this.allow_write.Text = "允許寫入資料庫";
            this.allow_write.UseVisualStyleBackColor = true;
            this.allow_write.CheckedChanged += new System.EventHandler(this.allow_write_CheckedChanged);
            // 
            // db_password
            // 
            this.db_password.Location = new System.Drawing.Point(99, 105);
            this.db_password.Name = "db_password";
            this.db_password.Size = new System.Drawing.Size(127, 22);
            this.db_password.TabIndex = 13;
            this.db_password.Text = "project";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "資料庫密碼:";
            // 
            // db_account
            // 
            this.db_account.Location = new System.Drawing.Point(99, 77);
            this.db_account.Name = "db_account";
            this.db_account.Size = new System.Drawing.Size(127, 22);
            this.db_account.TabIndex = 11;
            this.db_account.Text = "project";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "資料庫帳號:";
            // 
            // Updater
            // 
            this.Updater.Interval = 1000;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 753);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "午餐系統繳款插件";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.show_data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.virtual_client.ResumeLayout(false);
            this.virtual_client.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.force_delay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView show_data;
        private System.Windows.Forms.Button activate;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button start_session;
        private System.Windows.Forms.Label running_due;
        private System.Windows.Forms.Label writes;
        private System.Windows.Forms.Label reads;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox log_location;
        private System.Windows.Forms.TextBox local_ip;
        private System.Windows.Forms.TextBox protocol_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox db_name;
        private System.Windows.Forms.Button init_database;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox db_password;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox db_account;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox allow_write;
        private System.Windows.Forms.Button openLog;
        private System.Windows.Forms.GroupBox virtual_client;
        private System.Windows.Forms.TextBox money_table;
        private System.Windows.Forms.Button openMoneyTable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.Label force_delay_label;
        private System.Windows.Forms.TextBox Timestamp_Delay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar force_delay;
    }
}

