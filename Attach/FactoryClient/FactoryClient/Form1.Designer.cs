namespace FactoryClient
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
            this.open_menu = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.GroupBox();
            this.Menu_Progress_Show = new System.Windows.Forms.Label();
            this.Menu_Progress = new System.Windows.Forms.ProgressBar();
            this.download_menu = new System.Windows.Forms.Button();
            this.upload_menu = new System.Windows.Forms.Button();
            this.menu_file = new System.Windows.Forms.TextBox();
            this.Scale = new System.Windows.Forms.GroupBox();
            this.Scale_Progress_Show = new System.Windows.Forms.Label();
            this.Scale_Progress = new System.Windows.Forms.ProgressBar();
            this.open_scale = new System.Windows.Forms.Button();
            this.scale_file = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scale_end = new System.Windows.Forms.DateTimePicker();
            this.scale_start = new System.Windows.Forms.DateTimePicker();
            this.download_scale = new System.Windows.Forms.Button();
            this.Custom = new System.Windows.Forms.GroupBox();
            this.Custom_Progress_Show = new System.Windows.Forms.Label();
            this.Custom_Progress = new System.Windows.Forms.ProgressBar();
            this.open_custom = new System.Windows.Forms.Button();
            this.custom_file = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.custom_end = new System.Windows.Forms.DateTimePicker();
            this.custom_start = new System.Windows.Forms.DateTimePicker();
            this.download_custom = new System.Windows.Forms.Button();
            this.Money = new System.Windows.Forms.GroupBox();
            this.Money_Progress_Show = new System.Windows.Forms.Label();
            this.open_money = new System.Windows.Forms.Button();
            this.Money_Progress = new System.Windows.Forms.ProgressBar();
            this.money_file = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.money_end = new System.Windows.Forms.DateTimePicker();
            this.money_start = new System.Windows.Forms.DateTimePicker();
            this.download_money = new System.Windows.Forms.Button();
            this.analysiser = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.user = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.Update_Progress = new System.Windows.Forms.ProgressBar();
            this.Update_Progress_Show = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.Scale.SuspendLayout();
            this.Custom.SuspendLayout();
            this.Money.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // open_menu
            // 
            this.open_menu.Location = new System.Drawing.Point(8, 28);
            this.open_menu.Margin = new System.Windows.Forms.Padding(4);
            this.open_menu.Name = "open_menu";
            this.open_menu.Size = new System.Drawing.Size(100, 31);
            this.open_menu.TabIndex = 0;
            this.open_menu.Text = "選擇檔案";
            this.open_menu.UseVisualStyleBackColor = true;
            this.open_menu.Click += new System.EventHandler(this.open_menu_Click);
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.Menu_Progress_Show);
            this.Menu.Controls.Add(this.Menu_Progress);
            this.Menu.Controls.Add(this.download_menu);
            this.Menu.Controls.Add(this.upload_menu);
            this.Menu.Controls.Add(this.menu_file);
            this.Menu.Controls.Add(this.open_menu);
            this.Menu.Location = new System.Drawing.Point(16, 16);
            this.Menu.Margin = new System.Windows.Forms.Padding(4);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(4);
            this.Menu.Size = new System.Drawing.Size(439, 138);
            this.Menu.TabIndex = 1;
            this.Menu.TabStop = false;
            this.Menu.Text = "更新菜單";
            // 
            // Menu_Progress_Show
            // 
            this.Menu_Progress_Show.AutoSize = true;
            this.Menu_Progress_Show.Location = new System.Drawing.Point(5, 109);
            this.Menu_Progress_Show.Name = "Menu_Progress_Show";
            this.Menu_Progress_Show.Size = new System.Drawing.Size(88, 17);
            this.Menu_Progress_Show.TabIndex = 6;
            this.Menu_Progress_Show.Text = "目前進度:0%";
            // 
            // Menu_Progress
            // 
            this.Menu_Progress.Location = new System.Drawing.Point(116, 103);
            this.Menu_Progress.Name = "Menu_Progress";
            this.Menu_Progress.Size = new System.Drawing.Size(313, 23);
            this.Menu_Progress.TabIndex = 5;
            // 
            // download_menu
            // 
            this.download_menu.Location = new System.Drawing.Point(219, 65);
            this.download_menu.Margin = new System.Windows.Forms.Padding(4);
            this.download_menu.Name = "download_menu";
            this.download_menu.Size = new System.Drawing.Size(212, 31);
            this.download_menu.TabIndex = 4;
            this.download_menu.Text = "下載菜單";
            this.download_menu.UseVisualStyleBackColor = true;
            this.download_menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // upload_menu
            // 
            this.upload_menu.Location = new System.Drawing.Point(8, 65);
            this.upload_menu.Margin = new System.Windows.Forms.Padding(4);
            this.upload_menu.Name = "upload_menu";
            this.upload_menu.Size = new System.Drawing.Size(203, 31);
            this.upload_menu.TabIndex = 3;
            this.upload_menu.Text = "上傳菜單";
            this.upload_menu.UseVisualStyleBackColor = true;
            this.upload_menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // menu_file
            // 
            this.menu_file.Location = new System.Drawing.Point(116, 28);
            this.menu_file.Margin = new System.Windows.Forms.Padding(4);
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(313, 22);
            this.menu_file.TabIndex = 1;
            this.menu_file.Text = "D:\\菜單.xlsx";
            // 
            // Scale
            // 
            this.Scale.Controls.Add(this.Scale_Progress_Show);
            this.Scale.Controls.Add(this.Scale_Progress);
            this.Scale.Controls.Add(this.open_scale);
            this.Scale.Controls.Add(this.scale_file);
            this.Scale.Controls.Add(this.label2);
            this.Scale.Controls.Add(this.label1);
            this.Scale.Controls.Add(this.scale_end);
            this.Scale.Controls.Add(this.scale_start);
            this.Scale.Controls.Add(this.download_scale);
            this.Scale.Location = new System.Drawing.Point(16, 162);
            this.Scale.Margin = new System.Windows.Forms.Padding(4);
            this.Scale.Name = "Scale";
            this.Scale.Padding = new System.Windows.Forms.Padding(4);
            this.Scale.Size = new System.Drawing.Size(439, 175);
            this.Scale.TabIndex = 2;
            this.Scale.TabStop = false;
            this.Scale.Text = "輸出規模化點單";
            // 
            // Scale_Progress_Show
            // 
            this.Scale_Progress_Show.AutoSize = true;
            this.Scale_Progress_Show.Location = new System.Drawing.Point(8, 147);
            this.Scale_Progress_Show.Name = "Scale_Progress_Show";
            this.Scale_Progress_Show.Size = new System.Drawing.Size(88, 17);
            this.Scale_Progress_Show.TabIndex = 8;
            this.Scale_Progress_Show.Text = "目前進度:0%";
            // 
            // Scale_Progress
            // 
            this.Scale_Progress.Location = new System.Drawing.Point(119, 141);
            this.Scale_Progress.Name = "Scale_Progress";
            this.Scale_Progress.Size = new System.Drawing.Size(313, 23);
            this.Scale_Progress.TabIndex = 7;
            // 
            // open_scale
            // 
            this.open_scale.Location = new System.Drawing.Point(8, 103);
            this.open_scale.Margin = new System.Windows.Forms.Padding(4);
            this.open_scale.Name = "open_scale";
            this.open_scale.Size = new System.Drawing.Size(100, 31);
            this.open_scale.TabIndex = 6;
            this.open_scale.Text = "選擇檔案";
            this.open_scale.UseVisualStyleBackColor = true;
            this.open_scale.Click += new System.EventHandler(this.open_scale_Click);
            // 
            // scale_file
            // 
            this.scale_file.Location = new System.Drawing.Point(119, 107);
            this.scale_file.Margin = new System.Windows.Forms.Padding(4);
            this.scale_file.Name = "scale_file";
            this.scale_file.Size = new System.Drawing.Size(205, 22);
            this.scale_file.TabIndex = 5;
            this.scale_file.Text = "D:\\規模化報表.xlsx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "終止日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "起始日期";
            // 
            // scale_end
            // 
            this.scale_end.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.scale_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.scale_end.Location = new System.Drawing.Point(100, 65);
            this.scale_end.Margin = new System.Windows.Forms.Padding(4);
            this.scale_end.Name = "scale_end";
            this.scale_end.Size = new System.Drawing.Size(329, 22);
            this.scale_end.TabIndex = 2;
            // 
            // scale_start
            // 
            this.scale_start.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.scale_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.scale_start.Location = new System.Drawing.Point(100, 28);
            this.scale_start.Margin = new System.Windows.Forms.Padding(4);
            this.scale_start.Name = "scale_start";
            this.scale_start.Size = new System.Drawing.Size(329, 22);
            this.scale_start.TabIndex = 1;
            // 
            // download_scale
            // 
            this.download_scale.Location = new System.Drawing.Point(331, 103);
            this.download_scale.Margin = new System.Windows.Forms.Padding(4);
            this.download_scale.Name = "download_scale";
            this.download_scale.Size = new System.Drawing.Size(100, 31);
            this.download_scale.TabIndex = 0;
            this.download_scale.Text = "下載點單";
            this.download_scale.UseVisualStyleBackColor = true;
            this.download_scale.Click += new System.EventHandler(this.download_scale_Click);
            // 
            // Custom
            // 
            this.Custom.Controls.Add(this.Custom_Progress_Show);
            this.Custom.Controls.Add(this.Custom_Progress);
            this.Custom.Controls.Add(this.open_custom);
            this.Custom.Controls.Add(this.custom_file);
            this.Custom.Controls.Add(this.label3);
            this.Custom.Controls.Add(this.label4);
            this.Custom.Controls.Add(this.custom_end);
            this.Custom.Controls.Add(this.custom_start);
            this.Custom.Controls.Add(this.download_custom);
            this.Custom.Location = new System.Drawing.Point(16, 350);
            this.Custom.Margin = new System.Windows.Forms.Padding(4);
            this.Custom.Name = "Custom";
            this.Custom.Padding = new System.Windows.Forms.Padding(4);
            this.Custom.Size = new System.Drawing.Size(439, 191);
            this.Custom.TabIndex = 7;
            this.Custom.TabStop = false;
            this.Custom.Text = "輸出精緻化點單";
            // 
            // Custom_Progress_Show
            // 
            this.Custom_Progress_Show.AutoSize = true;
            this.Custom_Progress_Show.Location = new System.Drawing.Point(8, 158);
            this.Custom_Progress_Show.Name = "Custom_Progress_Show";
            this.Custom_Progress_Show.Size = new System.Drawing.Size(88, 17);
            this.Custom_Progress_Show.TabIndex = 10;
            this.Custom_Progress_Show.Text = "目前進度:0%";
            // 
            // Custom_Progress
            // 
            this.Custom_Progress.Location = new System.Drawing.Point(116, 152);
            this.Custom_Progress.Name = "Custom_Progress";
            this.Custom_Progress.Size = new System.Drawing.Size(313, 23);
            this.Custom_Progress.TabIndex = 9;
            // 
            // open_custom
            // 
            this.open_custom.Location = new System.Drawing.Point(8, 103);
            this.open_custom.Margin = new System.Windows.Forms.Padding(4);
            this.open_custom.Name = "open_custom";
            this.open_custom.Size = new System.Drawing.Size(100, 31);
            this.open_custom.TabIndex = 6;
            this.open_custom.Text = "選擇檔案";
            this.open_custom.UseVisualStyleBackColor = true;
            this.open_custom.Click += new System.EventHandler(this.open_custom_Click);
            // 
            // custom_file
            // 
            this.custom_file.Location = new System.Drawing.Point(119, 107);
            this.custom_file.Margin = new System.Windows.Forms.Padding(4);
            this.custom_file.Name = "custom_file";
            this.custom_file.Size = new System.Drawing.Size(205, 22);
            this.custom_file.TabIndex = 5;
            this.custom_file.Text = "D:\\精緻化報表.xlsx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "終止日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "起始日期";
            // 
            // custom_end
            // 
            this.custom_end.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.custom_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.custom_end.Location = new System.Drawing.Point(100, 65);
            this.custom_end.Margin = new System.Windows.Forms.Padding(4);
            this.custom_end.Name = "custom_end";
            this.custom_end.Size = new System.Drawing.Size(329, 22);
            this.custom_end.TabIndex = 2;
            // 
            // custom_start
            // 
            this.custom_start.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.custom_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.custom_start.Location = new System.Drawing.Point(100, 28);
            this.custom_start.Margin = new System.Windows.Forms.Padding(4);
            this.custom_start.Name = "custom_start";
            this.custom_start.Size = new System.Drawing.Size(329, 22);
            this.custom_start.TabIndex = 1;
            // 
            // download_custom
            // 
            this.download_custom.Location = new System.Drawing.Point(331, 103);
            this.download_custom.Margin = new System.Windows.Forms.Padding(4);
            this.download_custom.Name = "download_custom";
            this.download_custom.Size = new System.Drawing.Size(100, 31);
            this.download_custom.TabIndex = 0;
            this.download_custom.Text = "下載點單";
            this.download_custom.UseVisualStyleBackColor = true;
            this.download_custom.Click += new System.EventHandler(this.download_custom_Click);
            // 
            // Money
            // 
            this.Money.Controls.Add(this.Money_Progress_Show);
            this.Money.Controls.Add(this.open_money);
            this.Money.Controls.Add(this.Money_Progress);
            this.Money.Controls.Add(this.money_file);
            this.Money.Controls.Add(this.label9);
            this.Money.Controls.Add(this.label10);
            this.Money.Controls.Add(this.money_end);
            this.Money.Controls.Add(this.money_start);
            this.Money.Controls.Add(this.download_money);
            this.Money.Location = new System.Drawing.Point(16, 558);
            this.Money.Margin = new System.Windows.Forms.Padding(4);
            this.Money.Name = "Money";
            this.Money.Padding = new System.Windows.Forms.Padding(4);
            this.Money.Size = new System.Drawing.Size(439, 183);
            this.Money.TabIndex = 8;
            this.Money.TabStop = false;
            this.Money.Text = "輸出金額報表";
            // 
            // Money_Progress_Show
            // 
            this.Money_Progress_Show.AutoSize = true;
            this.Money_Progress_Show.Location = new System.Drawing.Point(8, 147);
            this.Money_Progress_Show.Name = "Money_Progress_Show";
            this.Money_Progress_Show.Size = new System.Drawing.Size(88, 17);
            this.Money_Progress_Show.TabIndex = 12;
            this.Money_Progress_Show.Text = "目前進度:0%";
            // 
            // open_money
            // 
            this.open_money.Location = new System.Drawing.Point(8, 103);
            this.open_money.Margin = new System.Windows.Forms.Padding(4);
            this.open_money.Name = "open_money";
            this.open_money.Size = new System.Drawing.Size(100, 31);
            this.open_money.TabIndex = 6;
            this.open_money.Text = "選擇檔案";
            this.open_money.UseVisualStyleBackColor = true;
            this.open_money.Click += new System.EventHandler(this.open_money_Click);
            // 
            // Money_Progress
            // 
            this.Money_Progress.Location = new System.Drawing.Point(116, 141);
            this.Money_Progress.Name = "Money_Progress";
            this.Money_Progress.Size = new System.Drawing.Size(313, 23);
            this.Money_Progress.TabIndex = 11;
            // 
            // money_file
            // 
            this.money_file.Location = new System.Drawing.Point(116, 103);
            this.money_file.Margin = new System.Windows.Forms.Padding(4);
            this.money_file.Name = "money_file";
            this.money_file.Size = new System.Drawing.Size(205, 22);
            this.money_file.TabIndex = 5;
            this.money_file.Text = "D:\\金額報表.xlsx";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 75);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "終止日期";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 37);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "起始日期";
            // 
            // money_end
            // 
            this.money_end.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.money_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.money_end.Location = new System.Drawing.Point(100, 65);
            this.money_end.Margin = new System.Windows.Forms.Padding(4);
            this.money_end.Name = "money_end";
            this.money_end.Size = new System.Drawing.Size(329, 22);
            this.money_end.TabIndex = 2;
            // 
            // money_start
            // 
            this.money_start.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.money_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.money_start.Location = new System.Drawing.Point(100, 28);
            this.money_start.Margin = new System.Windows.Forms.Padding(4);
            this.money_start.Name = "money_start";
            this.money_start.Size = new System.Drawing.Size(329, 22);
            this.money_start.TabIndex = 1;
            // 
            // download_money
            // 
            this.download_money.Location = new System.Drawing.Point(331, 103);
            this.download_money.Margin = new System.Windows.Forms.Padding(4);
            this.download_money.Name = "download_money";
            this.download_money.Size = new System.Drawing.Size(100, 31);
            this.download_money.TabIndex = 0;
            this.download_money.Text = "下載報表";
            this.download_money.UseVisualStyleBackColor = true;
            this.download_money.Click += new System.EventHandler(this.download_money_Click);
            // 
            // analysiser
            // 
            this.analysiser.Location = new System.Drawing.Point(8, 28);
            this.analysiser.Margin = new System.Windows.Forms.Padding(4);
            this.analysiser.Name = "analysiser";
            this.analysiser.Size = new System.Drawing.Size(395, 50);
            this.analysiser.TabIndex = 12;
            this.analysiser.Text = "啟動分析器";
            this.analysiser.UseVisualStyleBackColor = true;
            this.analysiser.Click += new System.EventHandler(this.analysiser_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.analysiser);
            this.groupBox6.Location = new System.Drawing.Point(463, 16);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(411, 550);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "分析器";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Update_Progress_Show);
            this.groupBox1.Controls.Add(this.Update_Progress);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.user);
            this.groupBox1.Location = new System.Drawing.Point(463, 573);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 168);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "其他功能";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(21, 37);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(78, 17);
            this.user.TabIndex = 0;
            this.user.Text = "現在廠商為";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(8, 75);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(395, 38);
            this.update.TabIndex = 1;
            this.update.Text = "更新程式";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // Update_Progress
            // 
            this.Update_Progress.Location = new System.Drawing.Point(111, 126);
            this.Update_Progress.Name = "Update_Progress";
            this.Update_Progress.Size = new System.Drawing.Size(292, 23);
            this.Update_Progress.TabIndex = 2;
            // 
            // Update_Progress_Show
            // 
            this.Update_Progress_Show.AutoSize = true;
            this.Update_Progress_Show.Location = new System.Drawing.Point(5, 132);
            this.Update_Progress_Show.Name = "Update_Progress_Show";
            this.Update_Progress_Show.Size = new System.Drawing.Size(88, 17);
            this.Update_Progress_Show.TabIndex = 13;
            this.Update_Progress_Show.Text = "目前進度:0%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 753);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Money);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.Custom);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.Menu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "午餐系統廠商管理前端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Scale.ResumeLayout(false);
            this.Scale.PerformLayout();
            this.Custom.ResumeLayout(false);
            this.Custom.PerformLayout();
            this.Money.ResumeLayout(false);
            this.Money.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open_menu;
        private System.Windows.Forms.GroupBox Menu;
        private System.Windows.Forms.Button upload_menu;
        private System.Windows.Forms.TextBox menu_file;
        private System.Windows.Forms.GroupBox Scale;
        private System.Windows.Forms.Button open_scale;
        private System.Windows.Forms.TextBox scale_file;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker scale_end;
        private System.Windows.Forms.DateTimePicker scale_start;
        private System.Windows.Forms.Button download_scale;
        private System.Windows.Forms.GroupBox Custom;
        private System.Windows.Forms.Button open_custom;
        private System.Windows.Forms.TextBox custom_file;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker custom_end;
        private System.Windows.Forms.DateTimePicker custom_start;
        private System.Windows.Forms.Button download_custom;
        private System.Windows.Forms.Button download_menu;
        private System.Windows.Forms.GroupBox Money;
        private System.Windows.Forms.Button open_money;
        private System.Windows.Forms.TextBox money_file;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker money_end;
        private System.Windows.Forms.DateTimePicker money_start;
        private System.Windows.Forms.Button download_money;
        private System.Windows.Forms.ProgressBar Menu_Progress;
        private System.Windows.Forms.Label Menu_Progress_Show;
        private System.Windows.Forms.Label Scale_Progress_Show;
        private System.Windows.Forms.ProgressBar Scale_Progress;
        private System.Windows.Forms.Label Custom_Progress_Show;
        private System.Windows.Forms.ProgressBar Custom_Progress;
        private System.Windows.Forms.Label Money_Progress_Show;
        private System.Windows.Forms.ProgressBar Money_Progress;
        private System.Windows.Forms.Button analysiser;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label Update_Progress_Show;
        private System.Windows.Forms.ProgressBar Update_Progress;
    }
}

