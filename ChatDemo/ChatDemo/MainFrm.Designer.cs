namespace ChatDemo
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtAllMsg = new System.Windows.Forms.TextBox();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnShake = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(101, 42);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(164, 28);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.0.112";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(359, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(120, 28);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "50000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(541, 43);
            this.btnStart.Name = "btnStart";
            this.btnStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStart.Size = new System.Drawing.Size(75, 27);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtAllMsg
            // 
            this.txtAllMsg.Location = new System.Drawing.Point(53, 99);
            this.txtAllMsg.Multiline = true;
            this.txtAllMsg.Name = "txtAllMsg";
            this.txtAllMsg.Size = new System.Drawing.Size(563, 318);
            this.txtAllMsg.TabIndex = 5;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(53, 444);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(438, 28);
            this.txtSendMsg.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(541, 444);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 28);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnShake
            // 
            this.btnShake.Location = new System.Drawing.Point(310, 489);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(75, 28);
            this.btnShake.TabIndex = 8;
            this.btnShake.Text = "Shake";
            this.btnShake.UseVisualStyleBackColor = true;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(416, 489);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 28);
            this.btnFile.TabIndex = 9;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 543);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnShake);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.txtAllMsg);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtAllMsg;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.Button btnFile;
    }
}

