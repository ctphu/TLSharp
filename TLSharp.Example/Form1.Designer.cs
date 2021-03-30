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
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btStart = new System.Windows.Forms.Button();
            this.tbReceipt = new System.Windows.Forms.TextBox();
            this.grLogin.SuspendLayout();
            this.grMessage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 71);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(11, 87);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(264, 22);
            this.txtMessage.TabIndex = 3;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(11, 40);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(264, 22);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.Text = "+855974980728";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "1. GET CODE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnGetCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(11, 87);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(264, 22);
            this.txtCode.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(292, 71);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 38);
            this.button3.TabIndex = 3;
            this.button3.Text = "2. LOGIN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtReceiveNumber
            // 
            this.txtReceiveNumber.Location = new System.Drawing.Point(11, 40);
            this.txtReceiveNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceiveNumber.Name = "txtReceiveNumber";
            this.txtReceiveNumber.Size = new System.Drawing.Size(264, 22);
            this.txtReceiveNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "SDT Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Telegram Code via SMS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Phone Receive";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
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
            this.grLogin.Location = new System.Drawing.Point(13, 13);
            this.grLogin.Margin = new System.Windows.Forms.Padding(4);
            this.grLogin.Name = "grLogin";
            this.grLogin.Padding = new System.Windows.Forms.Padding(4);
            this.grLogin.Size = new System.Drawing.Size(474, 129);
            this.grLogin.TabIndex = 0;
            this.grLogin.TabStop = false;
            this.grLogin.Text = "Auth";
            // 
            // grMessage
            // 
            this.grMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grMessage.Controls.Add(this.tbUserName);
            this.grMessage.Controls.Add(this.label5);
            this.grMessage.Controls.Add(this.label4);
            this.grMessage.Controls.Add(this.label3);
            this.grMessage.Controls.Add(this.txtReceiveNumber);
            this.grMessage.Controls.Add(this.txtMessage);
            this.grMessage.Controls.Add(this.button1);
            this.grMessage.Location = new System.Drawing.Point(500, 13);
            this.grMessage.Margin = new System.Windows.Forms.Padding(4);
            this.grMessage.Name = "grMessage";
            this.grMessage.Padding = new System.Windows.Forms.Padding(4);
            this.grMessage.Size = new System.Drawing.Size(474, 129);
            this.grMessage.TabIndex = 1;
            this.grMessage.TabStop = false;
            this.grMessage.Text = "Send";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(294, 40);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(159, 22);
            this.tbUserName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "UserName";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Controls.Add(this.tbReceipt);
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 423);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receipt";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 21);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(116, 38);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbReceipt
            // 
            this.tbReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceipt.Location = new System.Drawing.Point(12, 65);
            this.tbReceipt.Multiline = true;
            this.tbReceipt.Name = "tbReceipt";
            this.tbReceipt.Size = new System.Drawing.Size(929, 340);
            this.tbReceipt.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grMessage);
            this.Controls.Add(this.grLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grLogin.ResumeLayout(false);
            this.grLogin.PerformLayout();
            this.grMessage.ResumeLayout(false);
            this.grMessage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbReceipt;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label5;
    }
}

