namespace FactoryClient
{
    partial class Login
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
            this.id = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.MaskedTextBox();
            this.Saver = new System.Windows.Forms.LinkLabel();
            this.SaveMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.id.Location = new System.Drawing.Point(85, 67);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(131, 22);
            this.id.TabIndex = 0;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(85, 123);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(97, 23);
            this.login_btn.TabIndex = 3;
            this.login_btn.Text = "登入";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "帳號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密碼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F);
            this.label3.Location = new System.Drawing.Point(66, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "廠商管理前端";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(85, 95);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(131, 22);
            this.password.TabIndex = 2;
            // 
            // Saver
            // 
            this.Saver.AutoSize = true;
            this.Saver.Font = new System.Drawing.Font("新細明體", 30F);
            this.Saver.Location = new System.Drawing.Point(50, 226);
            this.Saver.Name = "Saver";
            this.Saver.Size = new System.Drawing.Size(177, 40);
            this.Saver.TabIndex = 7;
            this.Saver.TabStop = true;
            this.Saver.Text = "問題回覆";
            this.Saver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Saver_LinkClicked);
            // 
            // SaveMe
            // 
            this.SaveMe.Location = new System.Drawing.Point(85, 152);
            this.SaveMe.Name = "SaveMe";
            this.SaveMe.Size = new System.Drawing.Size(131, 23);
            this.SaveMe.TabIndex = 8;
            this.SaveMe.Text = "系統掛了，快來救我";
            this.SaveMe.UseVisualStyleBackColor = true;
            this.SaveMe.Click += new System.EventHandler(this.SaveMe_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 186);
            this.Controls.Add(this.SaveMe);
            this.Controls.Add(this.Saver);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.id);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox password;
        private System.Windows.Forms.LinkLabel Saver;
        private System.Windows.Forms.Button SaveMe;
    }
}