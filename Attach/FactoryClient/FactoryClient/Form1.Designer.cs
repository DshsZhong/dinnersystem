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
            this.Other = new System.Windows.Forms.GroupBox();
            this.Update_Progress_Show = new System.Windows.Forms.Label();
            this.Update_Progress = new System.Windows.Forms.ProgressBar();
            this.update = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logout = new System.Windows.Forms.Button();
            this.Error_Report = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.Scale.SuspendLayout();
            this.Custom.SuspendLayout();
            this.Money.SuspendLayout();
            this.Other.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // open_menu
            // 
            this.open_menu.Location = new System.Drawing.Point(6, 21);
            this.open_menu.Name = "open_menu";
            this.open_menu.Size = new System.Drawing.Size(75, 23);
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
            this.Menu.Location = new System.Drawing.Point(12, 12);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(329, 104);
            this.Menu.TabIndex = 1;
            this.Menu.TabStop = false;
            this.Menu.Text = "更新菜單";
            // 
            // Menu_Progress_Show
            // 
            this.Menu_Progress_Show.AutoSize = true;
            this.Menu_Progress_Show.Location = new System.Drawing.Point(4, 82);
            this.Menu_Progress_Show.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Menu_Progress_Show.Name = "Menu_Progress_Show";
            this.Menu_Progress_Show.Size = new System.Drawing.Size(71, 12);
            this.Menu_Progress_Show.TabIndex = 6;
            this.Menu_Progress_Show.Text = "目前進度:0%";
            // 
            // Menu_Progress
            // 
            this.Menu_Progress.Location = new System.Drawing.Point(87, 77);
            this.Menu_Progress.Margin = new System.Windows.Forms.Padding(2);
            this.Menu_Progress.Name = "Menu_Progress";
            this.Menu_Progress.Size = new System.Drawing.Size(235, 17);
            this.Menu_Progress.TabIndex = 5;
            // 
            // download_menu
            // 
            this.download_menu.Location = new System.Drawing.Point(164, 49);
            this.download_menu.Name = "download_menu";
            this.download_menu.Size = new System.Drawing.Size(159, 23);
            this.download_menu.TabIndex = 4;
            this.download_menu.Text = "下載菜單";
            this.download_menu.UseVisualStyleBackColor = true;
            this.download_menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // upload_menu
            // 
            this.upload_menu.Location = new System.Drawing.Point(6, 49);
            this.upload_menu.Name = "upload_menu";
            this.upload_menu.Size = new System.Drawing.Size(152, 23);
            this.upload_menu.TabIndex = 3;
            this.upload_menu.Text = "上傳菜單";
            this.upload_menu.UseVisualStyleBackColor = true;
            this.upload_menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // menu_file
            // 
            this.menu_file.Location = new System.Drawing.Point(87, 21);
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(236, 22);
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
            this.Scale.Location = new System.Drawing.Point(12, 122);
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(329, 131);
            this.Scale.TabIndex = 2;
            this.Scale.TabStop = false;
            this.Scale.Text = "輸出規模化點單";
            // 
            // Scale_Progress_Show
            // 
            this.Scale_Progress_Show.AutoSize = true;
            this.Scale_Progress_Show.Location = new System.Drawing.Point(6, 110);
            this.Scale_Progress_Show.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Scale_Progress_Show.Name = "Scale_Progress_Show";
            this.Scale_Progress_Show.Size = new System.Drawing.Size(71, 12);
            this.Scale_Progress_Show.TabIndex = 8;
            this.Scale_Progress_Show.Text = "目前進度:0%";
            // 
            // Scale_Progress
            // 
            this.Scale_Progress.Location = new System.Drawing.Point(89, 106);
            this.Scale_Progress.Margin = new System.Windows.Forms.Padding(2);
            this.Scale_Progress.Name = "Scale_Progress";
            this.Scale_Progress.Size = new System.Drawing.Size(235, 17);
            this.Scale_Progress.TabIndex = 7;
            // 
            // open_scale
            // 
            this.open_scale.Location = new System.Drawing.Point(6, 77);
            this.open_scale.Name = "open_scale";
            this.open_scale.Size = new System.Drawing.Size(75, 23);
            this.open_scale.TabIndex = 6;
            this.open_scale.Text = "選擇檔案";
            this.open_scale.UseVisualStyleBackColor = true;
            this.open_scale.Click += new System.EventHandler(this.open_scale_Click);
            // 
            // scale_file
            // 
            this.scale_file.Location = new System.Drawing.Point(89, 80);
            this.scale_file.Name = "scale_file";
            this.scale_file.Size = new System.Drawing.Size(155, 22);
            this.scale_file.TabIndex = 5;
            this.scale_file.Text = "D:\\規模化報表.xlsx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "終止日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "起始日期";
            // 
            // scale_end
            // 
            this.scale_end.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.scale_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.scale_end.Location = new System.Drawing.Point(75, 49);
            this.scale_end.Name = "scale_end";
            this.scale_end.Size = new System.Drawing.Size(248, 22);
            this.scale_end.TabIndex = 2;
            // 
            // scale_start
            // 
            this.scale_start.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.scale_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.scale_start.Location = new System.Drawing.Point(75, 21);
            this.scale_start.Name = "scale_start";
            this.scale_start.Size = new System.Drawing.Size(248, 22);
            this.scale_start.TabIndex = 1;
            // 
            // download_scale
            // 
            this.download_scale.Location = new System.Drawing.Point(248, 77);
            this.download_scale.Name = "download_scale";
            this.download_scale.Size = new System.Drawing.Size(75, 23);
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
            this.Custom.Location = new System.Drawing.Point(12, 262);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(329, 143);
            this.Custom.TabIndex = 7;
            this.Custom.TabStop = false;
            this.Custom.Text = "輸出精緻化點單";
            // 
            // Custom_Progress_Show
            // 
            this.Custom_Progress_Show.AutoSize = true;
            this.Custom_Progress_Show.Location = new System.Drawing.Point(6, 118);
            this.Custom_Progress_Show.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Custom_Progress_Show.Name = "Custom_Progress_Show";
            this.Custom_Progress_Show.Size = new System.Drawing.Size(71, 12);
            this.Custom_Progress_Show.TabIndex = 10;
            this.Custom_Progress_Show.Text = "目前進度:0%";
            // 
            // Custom_Progress
            // 
            this.Custom_Progress.Location = new System.Drawing.Point(87, 114);
            this.Custom_Progress.Margin = new System.Windows.Forms.Padding(2);
            this.Custom_Progress.Name = "Custom_Progress";
            this.Custom_Progress.Size = new System.Drawing.Size(235, 17);
            this.Custom_Progress.TabIndex = 9;
            // 
            // open_custom
            // 
            this.open_custom.Location = new System.Drawing.Point(6, 77);
            this.open_custom.Name = "open_custom";
            this.open_custom.Size = new System.Drawing.Size(75, 23);
            this.open_custom.TabIndex = 6;
            this.open_custom.Text = "選擇檔案";
            this.open_custom.UseVisualStyleBackColor = true;
            this.open_custom.Click += new System.EventHandler(this.open_custom_Click);
            // 
            // custom_file
            // 
            this.custom_file.Location = new System.Drawing.Point(89, 80);
            this.custom_file.Name = "custom_file";
            this.custom_file.Size = new System.Drawing.Size(155, 22);
            this.custom_file.TabIndex = 5;
            this.custom_file.Text = "D:\\精緻化報表.xlsx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "終止日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "起始日期";
            // 
            // custom_end
            // 
            this.custom_end.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.custom_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.custom_end.Location = new System.Drawing.Point(75, 49);
            this.custom_end.Name = "custom_end";
            this.custom_end.Size = new System.Drawing.Size(248, 22);
            this.custom_end.TabIndex = 2;
            // 
            // custom_start
            // 
            this.custom_start.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.custom_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.custom_start.Location = new System.Drawing.Point(75, 21);
            this.custom_start.Name = "custom_start";
            this.custom_start.Size = new System.Drawing.Size(248, 22);
            this.custom_start.TabIndex = 1;
            // 
            // download_custom
            // 
            this.download_custom.Location = new System.Drawing.Point(248, 77);
            this.download_custom.Name = "download_custom";
            this.download_custom.Size = new System.Drawing.Size(75, 23);
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
            this.Money.Location = new System.Drawing.Point(12, 418);
            this.Money.Name = "Money";
            this.Money.Size = new System.Drawing.Size(329, 137);
            this.Money.TabIndex = 8;
            this.Money.TabStop = false;
            this.Money.Text = "輸出金額報表";
            // 
            // Money_Progress_Show
            // 
            this.Money_Progress_Show.AutoSize = true;
            this.Money_Progress_Show.Location = new System.Drawing.Point(6, 110);
            this.Money_Progress_Show.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Money_Progress_Show.Name = "Money_Progress_Show";
            this.Money_Progress_Show.Size = new System.Drawing.Size(71, 12);
            this.Money_Progress_Show.TabIndex = 12;
            this.Money_Progress_Show.Text = "目前進度:0%";
            // 
            // open_money
            // 
            this.open_money.Location = new System.Drawing.Point(6, 77);
            this.open_money.Name = "open_money";
            this.open_money.Size = new System.Drawing.Size(75, 23);
            this.open_money.TabIndex = 6;
            this.open_money.Text = "選擇檔案";
            this.open_money.UseVisualStyleBackColor = true;
            this.open_money.Click += new System.EventHandler(this.open_money_Click);
            // 
            // Money_Progress
            // 
            this.Money_Progress.Location = new System.Drawing.Point(87, 106);
            this.Money_Progress.Margin = new System.Windows.Forms.Padding(2);
            this.Money_Progress.Name = "Money_Progress";
            this.Money_Progress.Size = new System.Drawing.Size(235, 17);
            this.Money_Progress.TabIndex = 11;
            // 
            // money_file
            // 
            this.money_file.Location = new System.Drawing.Point(87, 77);
            this.money_file.Name = "money_file";
            this.money_file.Size = new System.Drawing.Size(155, 22);
            this.money_file.TabIndex = 5;
            this.money_file.Text = "D:\\金額報表.xlsx";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "終止日期";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "起始日期";
            // 
            // money_end
            // 
            this.money_end.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.money_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.money_end.Location = new System.Drawing.Point(75, 49);
            this.money_end.Name = "money_end";
            this.money_end.Size = new System.Drawing.Size(248, 22);
            this.money_end.TabIndex = 2;
            // 
            // money_start
            // 
            this.money_start.CustomFormat = "yyyy/MM/dd-HH:mm:ss";
            this.money_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.money_start.Location = new System.Drawing.Point(75, 21);
            this.money_start.Name = "money_start";
            this.money_start.Size = new System.Drawing.Size(248, 22);
            this.money_start.TabIndex = 1;
            // 
            // download_money
            // 
            this.download_money.Location = new System.Drawing.Point(248, 77);
            this.download_money.Name = "download_money";
            this.download_money.Size = new System.Drawing.Size(75, 23);
            this.download_money.TabIndex = 0;
            this.download_money.Text = "下載報表";
            this.download_money.UseVisualStyleBackColor = true;
            this.download_money.Click += new System.EventHandler(this.download_money_Click);
            // 
            // Other
            // 
            this.Other.Controls.Add(this.Update_Progress_Show);
            this.Other.Controls.Add(this.Update_Progress);
            this.Other.Controls.Add(this.update);
            this.Other.Location = new System.Drawing.Point(347, 458);
            this.Other.Margin = new System.Windows.Forms.Padding(2);
            this.Other.Name = "Other";
            this.Other.Padding = new System.Windows.Forms.Padding(2);
            this.Other.Size = new System.Drawing.Size(308, 97);
            this.Other.TabIndex = 13;
            this.Other.TabStop = false;
            this.Other.Text = "其他功能";
            // 
            // Update_Progress_Show
            // 
            this.Update_Progress_Show.AutoSize = true;
            this.Update_Progress_Show.Location = new System.Drawing.Point(4, 69);
            this.Update_Progress_Show.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Update_Progress_Show.Name = "Update_Progress_Show";
            this.Update_Progress_Show.Size = new System.Drawing.Size(71, 12);
            this.Update_Progress_Show.TabIndex = 13;
            this.Update_Progress_Show.Text = "目前進度:0%";
            // 
            // Update_Progress
            // 
            this.Update_Progress.Location = new System.Drawing.Point(84, 64);
            this.Update_Progress.Margin = new System.Windows.Forms.Padding(2);
            this.Update_Progress.Name = "Update_Progress";
            this.Update_Progress.Size = new System.Drawing.Size(219, 17);
            this.Update_Progress.TabIndex = 2;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(7, 26);
            this.update.Margin = new System.Windows.Forms.Padding(2);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(296, 28);
            this.update.TabIndex = 1;
            this.update.Text = "更新程式";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(12, 28);
            this.user.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(65, 12);
            this.user.TabIndex = 0;
            this.user.Text = "現在廠商為";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logout);
            this.groupBox1.Controls.Add(this.user);
            this.groupBox1.Location = new System.Drawing.Point(347, 360);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(308, 94);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用者";
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(6, 54);
            this.logout.Margin = new System.Windows.Forms.Padding(2);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(296, 26);
            this.logout.TabIndex = 1;
            this.logout.Text = "登出";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // Error_Report
            // 
            this.Error_Report.Location = new System.Drawing.Point(347, 35);
            this.Error_Report.Name = "Error_Report";
            this.Error_Report.Size = new System.Drawing.Size(309, 320);
            this.Error_Report.TabIndex = 14;
            this.Error_Report.Text = "";
            this.Error_Report.TextChanged += new System.EventHandler(this.Error_Report_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "錯誤報告";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 565);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Error_Report);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Other);
            this.Controls.Add(this.Money);
            this.Controls.Add(this.Custom);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.Menu);
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
            this.Other.ResumeLayout(false);
            this.Other.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox Other;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label Update_Progress_Show;
        private System.Windows.Forms.ProgressBar Update_Progress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.RichTextBox Error_Report;
        private System.Windows.Forms.Label label5;
    }
}

