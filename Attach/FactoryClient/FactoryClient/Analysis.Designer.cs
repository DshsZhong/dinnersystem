namespace FactoryClient
{
    partial class Analysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.main_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Build = new System.Windows.Forms.Button();
            this.Cost_Sum = new System.Windows.Forms.Label();
            this.People_Sum = new System.Windows.Forms.Label();
            this.Ternary = new System.Windows.Forms.TrackBar();
            this.Ternary_Show = new System.Windows.Forms.Label();
            this.Gradient_Show = new System.Windows.Forms.Label();
            this.Gradient = new System.Windows.Forms.TrackBar();
            this.Pool_Size = new System.Windows.Forms.TrackBar();
            this.Pool_Show = new System.Windows.Forms.Label();
            this.Predict_Model = new System.Windows.Forms.GroupBox();
            this.show_model = new System.Windows.Forms.Button();
            this.Confidence_Interval = new System.Windows.Forms.TrackBar();
            this.Confidence_Standard = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Long_Time = new System.Windows.Forms.Button();
            this.Show_Datetime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Dish_Name = new System.Windows.Forms.ComboBox();
            this.Running_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Running_Status = new System.Windows.Forms.GroupBox();
            this.Running_Progress = new System.Windows.Forms.Label();
            this.Running_Task = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Download_Progress_Text = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.End_Date = new System.Windows.Forms.DateTimePicker();
            this.Download = new System.Windows.Forms.Button();
            this.Start_Date = new System.Windows.Forms.DateTimePicker();
            this.Making_Model = new System.Windows.Forms.GroupBox();
            this.Model_Status = new System.Windows.Forms.GroupBox();
            this.Model_Trustable = new System.Windows.Forms.Label();
            this.Order_Sum = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.GroupBox();
            this.Export_Excel = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Open_Excel = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Other = new System.Windows.Forms.GroupBox();
            this.Back = new System.Windows.Forms.Button();
            this.User = new System.Windows.Forms.Label();
            this.Classify = new System.Windows.Forms.GroupBox();
            this.Semi_Classify = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Classify_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label19 = new System.Windows.Forms.Label();
            this.Classification = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ternary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gradient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pool_Size)).BeginInit();
            this.Predict_Model.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Confidence_Interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Running_Chart)).BeginInit();
            this.Running_Status.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Making_Model.SuspendLayout();
            this.Model_Status.SuspendLayout();
            this.Export.SuspendLayout();
            this.Other.SuspendLayout();
            this.Classify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Classify_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // main_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.main_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.main_chart.Legends.Add(legend1);
            this.main_chart.Location = new System.Drawing.Point(6, 99);
            this.main_chart.Name = "main_chart";
            this.main_chart.Size = new System.Drawing.Size(739, 377);
            this.main_chart.TabIndex = 0;
            this.main_chart.Text = "chart1";
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(73, 21);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(215, 23);
            this.Build.TabIndex = 4;
            this.Build.Text = "建立模型";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // Cost_Sum
            // 
            this.Cost_Sum.AutoSize = true;
            this.Cost_Sum.Location = new System.Drawing.Point(6, 29);
            this.Cost_Sum.Name = "Cost_Sum";
            this.Cost_Sum.Size = new System.Drawing.Size(71, 12);
            this.Cost_Sum.TabIndex = 5;
            this.Cost_Sum.Text = "損失函數和: ";
            // 
            // People_Sum
            // 
            this.People_Sum.AutoSize = true;
            this.People_Sum.Location = new System.Drawing.Point(6, 89);
            this.People_Sum.Name = "People_Sum";
            this.People_Sum.Size = new System.Drawing.Size(92, 12);
            this.People_Sum.TabIndex = 7;
            this.People_Sum.Text = "參與模型總人數:";
            // 
            // Ternary
            // 
            this.Ternary.Location = new System.Drawing.Point(123, 113);
            this.Ternary.Maximum = 50;
            this.Ternary.Minimum = 10;
            this.Ternary.Name = "Ternary";
            this.Ternary.Size = new System.Drawing.Size(218, 45);
            this.Ternary.TabIndex = 8;
            this.Ternary.Value = 10;
            // 
            // Ternary_Show
            // 
            this.Ternary_Show.AutoSize = true;
            this.Ternary_Show.Location = new System.Drawing.Point(13, 113);
            this.Ternary_Show.Name = "Ternary_Show";
            this.Ternary_Show.Size = new System.Drawing.Size(80, 12);
            this.Ternary_Show.TabIndex = 9;
            this.Ternary_Show.Text = "三分搜迭代量:";
            // 
            // Gradient_Show
            // 
            this.Gradient_Show.AutoSize = true;
            this.Gradient_Show.Location = new System.Drawing.Point(13, 169);
            this.Gradient_Show.Name = "Gradient_Show";
            this.Gradient_Show.Size = new System.Drawing.Size(95, 12);
            this.Gradient_Show.TabIndex = 10;
            this.Gradient_Show.Text = "梯度上升迭代量: ";
            // 
            // Gradient
            // 
            this.Gradient.Location = new System.Drawing.Point(123, 169);
            this.Gradient.Maximum = 50;
            this.Gradient.Minimum = 10;
            this.Gradient.Name = "Gradient";
            this.Gradient.Size = new System.Drawing.Size(218, 45);
            this.Gradient.TabIndex = 11;
            this.Gradient.Value = 10;
            // 
            // Pool_Size
            // 
            this.Pool_Size.Location = new System.Drawing.Point(123, 62);
            this.Pool_Size.Maximum = 300;
            this.Pool_Size.Minimum = 10;
            this.Pool_Size.Name = "Pool_Size";
            this.Pool_Size.Size = new System.Drawing.Size(218, 45);
            this.Pool_Size.TabIndex = 13;
            this.Pool_Size.Value = 20;
            // 
            // Pool_Show
            // 
            this.Pool_Show.AutoSize = true;
            this.Pool_Show.Location = new System.Drawing.Point(13, 62);
            this.Pool_Show.Name = "Pool_Show";
            this.Pool_Show.Size = new System.Drawing.Size(71, 12);
            this.Pool_Show.TabIndex = 12;
            this.Pool_Show.Text = "執行池大小: ";
            // 
            // Predict_Model
            // 
            this.Predict_Model.Controls.Add(this.show_model);
            this.Predict_Model.Controls.Add(this.Confidence_Interval);
            this.Predict_Model.Controls.Add(this.Confidence_Standard);
            this.Predict_Model.Controls.Add(this.label13);
            this.Predict_Model.Controls.Add(this.label12);
            this.Predict_Model.Controls.Add(this.Long_Time);
            this.Predict_Model.Controls.Add(this.Show_Datetime);
            this.Predict_Model.Controls.Add(this.label8);
            this.Predict_Model.Controls.Add(this.label7);
            this.Predict_Model.Controls.Add(this.Dish_Name);
            this.Predict_Model.Controls.Add(this.main_chart);
            this.Predict_Model.Enabled = false;
            this.Predict_Model.Location = new System.Drawing.Point(12, 259);
            this.Predict_Model.Name = "Predict_Model";
            this.Predict_Model.Size = new System.Drawing.Size(751, 482);
            this.Predict_Model.TabIndex = 14;
            this.Predict_Model.TabStop = false;
            this.Predict_Model.Text = "預測模型";
            // 
            // show_model
            // 
            this.show_model.Location = new System.Drawing.Point(276, 47);
            this.show_model.Margin = new System.Windows.Forms.Padding(2);
            this.show_model.Name = "show_model";
            this.show_model.Size = new System.Drawing.Size(93, 23);
            this.show_model.TabIndex = 14;
            this.show_model.Text = "顯示資料";
            this.show_model.UseVisualStyleBackColor = true;
            this.show_model.Click += new System.EventHandler(this.show_model_Click);
            // 
            // Confidence_Interval
            // 
            this.Confidence_Interval.Location = new System.Drawing.Point(70, 46);
            this.Confidence_Interval.Margin = new System.Windows.Forms.Padding(2);
            this.Confidence_Interval.Name = "Confidence_Interval";
            this.Confidence_Interval.Size = new System.Drawing.Size(199, 45);
            this.Confidence_Interval.TabIndex = 20;
            // 
            // Confidence_Standard
            // 
            this.Confidence_Standard.Location = new System.Drawing.Point(545, 49);
            this.Confidence_Standard.Name = "Confidence_Standard";
            this.Confidence_Standard.Size = new System.Drawing.Size(200, 22);
            this.Confidence_Standard.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(480, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 12);
            this.label13.TabIndex = 18;
            this.label13.Text = "信心水平:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "誤差區間:";
            // 
            // Long_Time
            // 
            this.Long_Time.Location = new System.Drawing.Point(276, 16);
            this.Long_Time.Name = "Long_Time";
            this.Long_Time.Size = new System.Drawing.Size(93, 23);
            this.Long_Time.TabIndex = 5;
            this.Long_Time.Text = "估測長期狀態";
            this.Long_Time.UseVisualStyleBackColor = true;
            // 
            // Show_Datetime
            // 
            this.Show_Datetime.Location = new System.Drawing.Point(71, 19);
            this.Show_Datetime.Name = "Show_Datetime";
            this.Show_Datetime.Size = new System.Drawing.Size(200, 22);
            this.Show_Datetime.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "日期: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(480, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "餐點名稱: ";
            // 
            // Dish_Name
            // 
            this.Dish_Name.FormattingEnabled = true;
            this.Dish_Name.Location = new System.Drawing.Point(545, 21);
            this.Dish_Name.Name = "Dish_Name";
            this.Dish_Name.Size = new System.Drawing.Size(200, 20);
            this.Dish_Name.TabIndex = 1;
            // 
            // Running_Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.Running_Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Running_Chart.Legends.Add(legend2);
            this.Running_Chart.Location = new System.Drawing.Point(6, 45);
            this.Running_Chart.Name = "Running_Chart";
            this.Running_Chart.Size = new System.Drawing.Size(259, 191);
            this.Running_Chart.TabIndex = 15;
            this.Running_Chart.Text = "chart2";
            // 
            // Running_Status
            // 
            this.Running_Status.Controls.Add(this.Running_Progress);
            this.Running_Status.Controls.Add(this.Running_Task);
            this.Running_Status.Controls.Add(this.Running_Chart);
            this.Running_Status.Enabled = false;
            this.Running_Status.Location = new System.Drawing.Point(844, 10);
            this.Running_Status.Name = "Running_Status";
            this.Running_Status.Size = new System.Drawing.Size(272, 243);
            this.Running_Status.TabIndex = 16;
            this.Running_Status.TabStop = false;
            this.Running_Status.Text = "運行狀態";
            // 
            // Running_Progress
            // 
            this.Running_Progress.AutoSize = true;
            this.Running_Progress.Location = new System.Drawing.Point(124, 18);
            this.Running_Progress.Name = "Running_Progress";
            this.Running_Progress.Size = new System.Drawing.Size(56, 12);
            this.Running_Progress.TabIndex = 17;
            this.Running_Progress.Text = "執行進度:";
            // 
            // Running_Task
            // 
            this.Running_Task.AutoSize = true;
            this.Running_Task.Location = new System.Drawing.Point(13, 18);
            this.Running_Task.Name = "Running_Task";
            this.Running_Task.Size = new System.Drawing.Size(56, 12);
            this.Running_Task.TabIndex = 16;
            this.Running_Task.Text = "執行任務:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Download_Progress_Text);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.End_Date);
            this.groupBox3.Controls.Add(this.Download);
            this.groupBox3.Controls.Add(this.Start_Date);
            this.groupBox3.Location = new System.Drawing.Point(769, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 140);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "下載資料";
            // 
            // Download_Progress_Text
            // 
            this.Download_Progress_Text.AutoSize = true;
            this.Download_Progress_Text.Location = new System.Drawing.Point(121, 29);
            this.Download_Progress_Text.Name = "Download_Progress_Text";
            this.Download_Progress_Text.Size = new System.Drawing.Size(146, 12);
            this.Download_Progress_Text.TabIndex = 23;
            this.Download_Progress_Text.Text = "目前進度:  等待資料下載中";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 99);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 22;
            this.label21.Text = "終止日期";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 18;
            this.label20.Text = "起始日期";
            // 
            // End_Date
            // 
            this.End_Date.Location = new System.Drawing.Point(73, 92);
            this.End_Date.Name = "End_Date";
            this.End_Date.Size = new System.Drawing.Size(268, 22);
            this.End_Date.TabIndex = 21;
            // 
            // Download
            // 
            this.Download.Location = new System.Drawing.Point(6, 24);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(75, 23);
            this.Download.TabIndex = 19;
            this.Download.Text = "下載資料";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // Start_Date
            // 
            this.Start_Date.Location = new System.Drawing.Point(73, 64);
            this.Start_Date.Name = "Start_Date";
            this.Start_Date.Size = new System.Drawing.Size(268, 22);
            this.Start_Date.TabIndex = 20;
            // 
            // Making_Model
            // 
            this.Making_Model.Controls.Add(this.Build);
            this.Making_Model.Controls.Add(this.Pool_Size);
            this.Making_Model.Controls.Add(this.Pool_Show);
            this.Making_Model.Controls.Add(this.Ternary);
            this.Making_Model.Controls.Add(this.Ternary_Show);
            this.Making_Model.Controls.Add(this.Gradient);
            this.Making_Model.Controls.Add(this.Gradient_Show);
            this.Making_Model.Enabled = false;
            this.Making_Model.Location = new System.Drawing.Point(769, 405);
            this.Making_Model.Name = "Making_Model";
            this.Making_Model.Size = new System.Drawing.Size(347, 224);
            this.Making_Model.TabIndex = 22;
            this.Making_Model.TabStop = false;
            this.Making_Model.Text = "製作模型";
            // 
            // Model_Status
            // 
            this.Model_Status.Controls.Add(this.Model_Trustable);
            this.Model_Status.Controls.Add(this.Order_Sum);
            this.Model_Status.Controls.Add(this.Cost_Sum);
            this.Model_Status.Controls.Add(this.People_Sum);
            this.Model_Status.Enabled = false;
            this.Model_Status.Location = new System.Drawing.Point(12, 12);
            this.Model_Status.Name = "Model_Status";
            this.Model_Status.Size = new System.Drawing.Size(143, 241);
            this.Model_Status.TabIndex = 23;
            this.Model_Status.TabStop = false;
            this.Model_Status.Text = "模型狀態";
            // 
            // Model_Trustable
            // 
            this.Model_Trustable.AutoSize = true;
            this.Model_Trustable.Location = new System.Drawing.Point(6, 212);
            this.Model_Trustable.Name = "Model_Trustable";
            this.Model_Trustable.Size = new System.Drawing.Size(95, 12);
            this.Model_Trustable.TabIndex = 22;
            this.Model_Trustable.Text = "模型可信度指標: ";
            // 
            // Order_Sum
            // 
            this.Order_Sum.AutoSize = true;
            this.Order_Sum.Location = new System.Drawing.Point(6, 112);
            this.Order_Sum.Name = "Order_Sum";
            this.Order_Sum.Size = new System.Drawing.Size(68, 12);
            this.Order_Sum.TabIndex = 8;
            this.Order_Sum.Text = "累計點單數:";
            // 
            // Export
            // 
            this.Export.Controls.Add(this.Export_Excel);
            this.Export.Controls.Add(this.textBox5);
            this.Export.Controls.Add(this.label16);
            this.Export.Controls.Add(this.textBox4);
            this.Export.Controls.Add(this.label15);
            this.Export.Controls.Add(this.Open_Excel);
            this.Export.Controls.Add(this.textBox3);
            this.Export.Controls.Add(this.label14);
            this.Export.Enabled = false;
            this.Export.Location = new System.Drawing.Point(161, 13);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(224, 240);
            this.Export.TabIndex = 24;
            this.Export.TabStop = false;
            this.Export.Text = "輸出模型資料";
            // 
            // Export_Excel
            // 
            this.Export_Excel.Location = new System.Drawing.Point(9, 28);
            this.Export_Excel.Name = "Export_Excel";
            this.Export_Excel.Size = new System.Drawing.Size(209, 23);
            this.Export_Excel.TabIndex = 22;
            this.Export_Excel.Text = "輸出報表";
            this.Export_Excel.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(83, 208);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(135, 22);
            this.textBox5.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 211);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "信心水平:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(83, 180);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(135, 22);
            this.textBox4.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 12);
            this.label15.TabIndex = 20;
            this.label15.Text = "誤差區間:";
            // 
            // Open_Excel
            // 
            this.Open_Excel.Location = new System.Drawing.Point(9, 57);
            this.Open_Excel.Name = "Open_Excel";
            this.Open_Excel.Size = new System.Drawing.Size(209, 23);
            this.Open_Excel.TabIndex = 2;
            this.Open_Excel.Text = "開啟檔案";
            this.Open_Excel.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(83, 152);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(135, 22);
            this.textBox3.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "資料表位置: ";
            // 
            // Other
            // 
            this.Other.Controls.Add(this.Back);
            this.Other.Controls.Add(this.User);
            this.Other.Location = new System.Drawing.Point(769, 635);
            this.Other.Name = "Other";
            this.Other.Size = new System.Drawing.Size(347, 106);
            this.Other.TabIndex = 20;
            this.Other.TabStop = false;
            this.Other.Text = "其他";
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(6, 64);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(335, 23);
            this.Back.TabIndex = 1;
            this.Back.Text = "回到上一頁";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Location = new System.Drawing.Point(13, 31);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(71, 12);
            this.User.TabIndex = 0;
            this.User.Text = "現在使用者: ";
            // 
            // Classify
            // 
            this.Classify.Controls.Add(this.Semi_Classify);
            this.Classify.Controls.Add(this.label2);
            this.Classify.Controls.Add(this.label1);
            this.Classify.Controls.Add(this.Classify_Chart);
            this.Classify.Controls.Add(this.label19);
            this.Classify.Controls.Add(this.Classification);
            this.Classify.Enabled = false;
            this.Classify.Location = new System.Drawing.Point(393, 13);
            this.Classify.Name = "Classify";
            this.Classify.Size = new System.Drawing.Size(445, 240);
            this.Classify.TabIndex = 25;
            this.Classify.TabStop = false;
            this.Classify.Text = "分配圖";
            // 
            // Semi_Classify
            // 
            this.Semi_Classify.Enabled = false;
            this.Semi_Classify.FormattingEnabled = true;
            this.Semi_Classify.Items.AddRange(new object[] {
            "高一",
            "高二",
            "高三",
            "其他"});
            this.Semi_Classify.Location = new System.Drawing.Point(346, 15);
            this.Semi_Classify.Margin = new System.Windows.Forms.Padding(2);
            this.Semi_Classify.Name = "Semi_Classify";
            this.Semi_Classify.Size = new System.Drawing.Size(92, 20);
            this.Semi_Classify.TabIndex = 21;
            this.Semi_Classify.SelectedIndexChanged += new System.EventHandler(this.Semi_Classify_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "年級: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 19;
            // 
            // Classify_Chart
            // 
            chartArea3.Name = "ChartArea1";
            this.Classify_Chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.Classify_Chart.Legends.Add(legend3);
            this.Classify_Chart.Location = new System.Drawing.Point(6, 42);
            this.Classify_Chart.Name = "Classify_Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Classify_Chart.Series.Add(series1);
            this.Classify_Chart.Size = new System.Drawing.Size(433, 192);
            this.Classify_Chart.TabIndex = 18;
            this.Classify_Chart.Text = "chart3";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(32, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 12);
            this.label19.TabIndex = 1;
            this.label19.Text = "分類依據:";
            // 
            // Classification
            // 
            this.Classification.FormattingEnabled = true;
            this.Classification.Items.AddRange(new object[] {
            "班級",
            "年級",
            "每周",
            "每月"});
            this.Classification.Location = new System.Drawing.Point(101, 15);
            this.Classification.Name = "Classification";
            this.Classification.Size = new System.Drawing.Size(107, 20);
            this.Classification.TabIndex = 0;
            this.Classification.SelectedIndexChanged += new System.EventHandler(this.Classification_SelectedIndexChanged);
            // 
            // Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 761);
            this.Controls.Add(this.Classify);
            this.Controls.Add(this.Other);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Model_Status);
            this.Controls.Add(this.Making_Model);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Running_Status);
            this.Controls.Add(this.Predict_Model);
            this.Name = "Analysis";
            this.Text = "Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ternary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gradient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pool_Size)).EndInit();
            this.Predict_Model.ResumeLayout(false);
            this.Predict_Model.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Confidence_Interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Running_Chart)).EndInit();
            this.Running_Status.ResumeLayout(false);
            this.Running_Status.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Making_Model.ResumeLayout(false);
            this.Making_Model.PerformLayout();
            this.Model_Status.ResumeLayout(false);
            this.Model_Status.PerformLayout();
            this.Export.ResumeLayout(false);
            this.Export.PerformLayout();
            this.Other.ResumeLayout(false);
            this.Other.PerformLayout();
            this.Classify.ResumeLayout(false);
            this.Classify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Classify_Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart main_chart;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.Label Cost_Sum;
        private System.Windows.Forms.Label People_Sum;
        private System.Windows.Forms.TrackBar Ternary;
        private System.Windows.Forms.Label Ternary_Show;
        private System.Windows.Forms.Label Gradient_Show;
        private System.Windows.Forms.TrackBar Gradient;
        private System.Windows.Forms.TrackBar Pool_Size;
        private System.Windows.Forms.Label Pool_Show;
        private System.Windows.Forms.GroupBox Predict_Model;
        private System.Windows.Forms.Button Long_Time;
        private System.Windows.Forms.DateTimePicker Show_Datetime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Dish_Name;
        private System.Windows.Forms.DataVisualization.Charting.Chart Running_Chart;
        private System.Windows.Forms.GroupBox Running_Status;
        private System.Windows.Forms.Label Running_Progress;
        private System.Windows.Forms.Label Running_Task;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker End_Date;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.DateTimePicker Start_Date;
        private System.Windows.Forms.GroupBox Making_Model;
        private System.Windows.Forms.GroupBox Model_Status;
        private System.Windows.Forms.TextBox Confidence_Standard;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Download_Progress_Text;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label Model_Trustable;
        private System.Windows.Forms.Label Order_Sum;
        private System.Windows.Forms.GroupBox Export;
        private System.Windows.Forms.Button Export_Excel;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button Open_Excel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox Other;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.GroupBox Classify;
        private System.Windows.Forms.DataVisualization.Charting.Chart Classify_Chart;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox Classification;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Semi_Classify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar Confidence_Interval;
        private System.Windows.Forms.Button show_model;
    }
}