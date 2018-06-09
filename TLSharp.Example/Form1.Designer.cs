namespace TLSharp.Example
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtReceiveNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grLogin = new System.Windows.Forms.GroupBox();
            this.grMessage = new System.Windows.Forms.GroupBox();
            this.grLogin.SuspendLayout();
            this.grMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(18, 89);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(311, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(18, 70);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(199, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.Text = "+84906841595";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 36);
            this.button2.TabIndex = 0;
            this.button2.Text = "1. GET CODE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnGetCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(18, 122);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(199, 20);
            this.txtCode.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(243, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 47);
            this.button3.TabIndex = 0;
            this.button3.Text = "2. LOGIN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtReceiveNumber
            // 
            this.txtReceiveNumber.Location = new System.Drawing.Point(18, 37);
            this.txtReceiveNumber.Name = "txtReceiveNumber";
            this.txtReceiveNumber.Size = new System.Drawing.Size(199, 20);
            this.txtReceiveNumber.TabIndex = 2;
            this.txtReceiveNumber.Text = "+84906841595";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SDT Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Telegram Code via SMS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Phone Receive";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Message";
            // 
            // grLogin
            // 
            this.grLogin.Controls.Add(this.label2);
            this.grLogin.Controls.Add(this.label1);
            this.grLogin.Controls.Add(this.txtCode);
            this.grLogin.Controls.Add(this.txtNumber);
            this.grLogin.Controls.Add(this.button3);
            this.grLogin.Controls.Add(this.button2);
            this.grLogin.Location = new System.Drawing.Point(48, 33);
            this.grLogin.Name = "grLogin";
            this.grLogin.Size = new System.Drawing.Size(392, 151);
            this.grLogin.TabIndex = 7;
            this.grLogin.TabStop = false;
            this.grLogin.Text = "groupBox1";
            // 
            // grMessage
            // 
            this.grMessage.Controls.Add(this.label4);
            this.grMessage.Controls.Add(this.label3);
            this.grMessage.Controls.Add(this.txtReceiveNumber);
            this.grMessage.Controls.Add(this.txtMessage);
            this.grMessage.Controls.Add(this.button1);
            this.grMessage.Location = new System.Drawing.Point(48, 203);
            this.grMessage.Name = "grMessage";
            this.grMessage.Size = new System.Drawing.Size(392, 170);
            this.grMessage.TabIndex = 8;
            this.grMessage.TabStop = false;
            this.grMessage.Text = "groupBox2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 447);
            this.Controls.Add(this.grMessage);
            this.Controls.Add(this.grLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grLogin.ResumeLayout(false);
            this.grLogin.PerformLayout();
            this.grMessage.ResumeLayout(false);
            this.grMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtReceiveNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grLogin;
        private System.Windows.Forms.GroupBox grMessage;
    }
}

