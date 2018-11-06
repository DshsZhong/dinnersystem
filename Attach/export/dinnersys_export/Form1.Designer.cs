namespace dinnersys_export
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
            this.export = new System.Windows.Forms.Button();
            this.account = new System.Windows.Forms.MaskedTextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.history = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(205, 231);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(225, 63);
            this.export.TabIndex = 0;
            this.export.Text = "輸出資料";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // account
            // 
            this.account.Location = new System.Drawing.Point(178, 62);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(100, 22);
            this.account.TabIndex = 1;
            this.account.Text = "q020705349";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(436, 62);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 22);
            this.password.TabIndex = 2;
            this.password.Text = "qazwsx7";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(178, 133);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(145, 22);
            this.start.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "合作社帳號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "合作社密碼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "起始輸出日期";
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(436, 133);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(145, 22);
            this.end.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "終止輸出日期";
            // 
            // history
            // 
            this.history.AutoSize = true;
            this.history.Checked = true;
            this.history.CheckState = System.Windows.Forms.CheckState.Checked;
            this.history.Location = new System.Drawing.Point(633, 133);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(120, 16);
            this.history.TabIndex = 9;
            this.history.Text = "擷取實際歷史資料";
            this.history.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.history);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.end);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.password);
            this.Controls.Add(this.account);
            this.Controls.Add(this.export);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button export;
        private System.Windows.Forms.MaskedTextBox account;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.DateTimePicker start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker end;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox history;
    }
}

