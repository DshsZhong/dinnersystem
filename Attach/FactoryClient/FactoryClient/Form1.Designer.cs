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
            this.download_menu = new System.Windows.Forms.Button();
            this.upload_menu = new System.Windows.Forms.Button();
            this.menu_file = new System.Windows.Forms.TextBox();
            this.Scale = new System.Windows.Forms.GroupBox();
            this.open_scale = new System.Windows.Forms.Button();
            this.scale_file = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scale_end = new System.Windows.Forms.DateTimePicker();
            this.scale_start = new System.Windows.Forms.DateTimePicker();
            this.download_scale = new System.Windows.Forms.Button();
            this.Custom = new System.Windows.Forms.GroupBox();
            this.open_custom = new System.Windows.Forms.Button();
            this.custom_file = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.custom_end = new System.Windows.Forms.DateTimePicker();
            this.custom_start = new System.Windows.Forms.DateTimePicker();
            this.download_custom = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.WebBrowser();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.refresh = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.Money = new System.Windows.Forms.GroupBox();
            this.open_money = new System.Windows.Forms.Button();
            this.money_file = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.money_end = new System.Windows.Forms.DateTimePicker();
            this.money_start = new System.Windows.Forms.DateTimePicker();
            this.download_money = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.Scale.SuspendLayout();
            this.Custom.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.Money.SuspendLayout();
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
            this.Menu.Controls.Add(this.download_menu);
            this.Menu.Controls.Add(this.upload_menu);
            this.Menu.Controls.Add(this.menu_file);
            this.Menu.Controls.Add(this.open_menu);
            this.Menu.Location = new System.Drawing.Point(12, 12);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(329, 83);
            this.Menu.TabIndex = 1;
            this.Menu.TabStop = false;
            this.Menu.Text = "更新菜單";
            // 
            // download_menu
            // 
            this.download_menu.Location = new System.Drawing.Point(164, 49);
            this.download_menu.Name = "download_menu";
            this.download_menu.Size = new System.Drawing.Size(159, 23);
            this.download_menu.TabIndex = 4;
            this.download_menu.Text = "下載菜單";
            this.download_menu.UseVisualStyleBackColor = true;
            this.download_menu.Click += new System.EventHandler(this.download_menu_Click);
            // 
            // upload_menu
            // 
            this.upload_menu.Location = new System.Drawing.Point(6, 49);
            this.upload_menu.Name = "upload_menu";
            this.upload_menu.Size = new System.Drawing.Size(152, 23);
            this.upload_menu.TabIndex = 3;
            this.upload_menu.Text = "上傳菜單";
            this.upload_menu.UseVisualStyleBackColor = true;
            this.upload_menu.Click += new System.EventHandler(this.upload_menu_Click);
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
            this.Scale.Controls.Add(this.open_scale);
            this.Scale.Controls.Add(this.scale_file);
            this.Scale.Controls.Add(this.label2);
            this.Scale.Controls.Add(this.label1);
            this.Scale.Controls.Add(this.scale_end);
            this.Scale.Controls.Add(this.scale_start);
            this.Scale.Controls.Add(this.download_scale);
            this.Scale.Location = new System.Drawing.Point(12, 169);
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(329, 109);
            this.Scale.TabIndex = 2;
            this.Scale.TabStop = false;
            this.Scale.Text = "輸出規模化點單";
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
            this.scale_file.Location = new System.Drawing.Point(87, 77);
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
            this.Custom.Controls.Add(this.open_custom);
            this.Custom.Controls.Add(this.custom_file);
            this.Custom.Controls.Add(this.label3);
            this.Custom.Controls.Add(this.label4);
            this.Custom.Controls.Add(this.custom_end);
            this.Custom.Controls.Add(this.custom_start);
            this.Custom.Controls.Add(this.download_custom);
            this.Custom.Location = new System.Drawing.Point(12, 339);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(329, 109);
            this.Custom.TabIndex = 7;
            this.Custom.TabStop = false;
            this.Custom.Text = "輸出精緻化點單";
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
            this.custom_file.Location = new System.Drawing.Point(87, 77);
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
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(6, 50);
            this.preview.MinimumSize = new System.Drawing.Size(20, 20);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(313, 547);
            this.preview.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.refresh);
            this.groupBox4.Controls.Add(this.preview);
            this.groupBox4.Location = new System.Drawing.Point(361, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(325, 603);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "系統預覽";
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(6, 21);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(313, 23);
            this.refresh.TabIndex = 11;
            this.refresh.Text = "重新整理";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 21);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(296, 51);
            this.button9.TabIndex = 12;
            this.button9.Text = "開啟模型";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.button9);
            this.groupBox6.Location = new System.Drawing.Point(692, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(308, 603);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "分析器";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox6);
            this.groupBox9.Controls.Add(this.button13);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Location = new System.Drawing.Point(6, 417);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(296, 84);
            this.groupBox9.TabIndex = 24;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "載入歷史資料";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(69, 21);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(221, 22);
            this.textBox6.TabIndex = 14;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 49);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(284, 27);
            this.button13.TabIndex = 13;
            this.button13.Text = "載入歷史資料";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "資料位置 :";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox4);
            this.groupBox8.Controls.Add(this.button10);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Location = new System.Drawing.Point(6, 507);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(296, 84);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "載入模型";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(69, 21);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(221, 22);
            this.textBox4.TabIndex = 14;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 49);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(284, 27);
            this.button10.TabIndex = 13;
            this.button10.Text = "載入模型";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "模型位置 :";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button12);
            this.groupBox7.Controls.Add(this.textBox5);
            this.groupBox7.Controls.Add(this.progressBar2);
            this.groupBox7.Controls.Add(this.dateTimePicker5);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.dateTimePicker6);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.button11);
            this.groupBox7.Location = new System.Drawing.Point(6, 166);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(296, 175);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "下載歷史資料";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 105);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(71, 23);
            this.button12.TabIndex = 23;
            this.button12.Text = "選擇檔案";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(83, 106);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(207, 22);
            this.textBox5.TabIndex = 22;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(6, 21);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(284, 23);
            this.progressBar2.TabIndex = 21;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Location = new System.Drawing.Point(63, 50);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(227, 22);
            this.dateTimePicker5.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "終止日期";
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Location = new System.Drawing.Point(63, 78);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(227, 22);
            this.dateTimePicker6.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "起始日期";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 134);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(284, 31);
            this.button11.TabIndex = 18;
            this.button11.Text = "下載歷史資料";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // Money
            // 
            this.Money.Controls.Add(this.open_money);
            this.Money.Controls.Add(this.money_file);
            this.Money.Controls.Add(this.label9);
            this.Money.Controls.Add(this.label10);
            this.Money.Controls.Add(this.money_end);
            this.Money.Controls.Add(this.money_start);
            this.Money.Controls.Add(this.download_money);
            this.Money.Location = new System.Drawing.Point(12, 506);
            this.Money.Name = "Money";
            this.Money.Size = new System.Drawing.Size(329, 109);
            this.Money.TabIndex = 8;
            this.Money.TabStop = false;
            this.Money.Text = "輸出金額報表";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 627);
            this.Controls.Add(this.Money);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Custom);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.Menu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Scale.ResumeLayout(false);
            this.Scale.PerformLayout();
            this.Custom.ResumeLayout(false);
            this.Custom.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.Money.ResumeLayout(false);
            this.Money.PerformLayout();
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
        private System.Windows.Forms.WebBrowser preview;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button download_menu;
        private System.Windows.Forms.GroupBox Money;
        private System.Windows.Forms.Button open_money;
        private System.Windows.Forms.TextBox money_file;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker money_end;
        private System.Windows.Forms.DateTimePicker money_start;
        private System.Windows.Forms.Button download_money;
    }
}

