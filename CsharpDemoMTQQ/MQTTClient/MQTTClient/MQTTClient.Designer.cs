namespace MQTTClient
{
    partial class MQTTClient
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
            this.btnSubScribe = new System.Windows.Forms.Button();
            this.txtSub = new System.Windows.Forms.RichTextBox();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.txtPub = new System.Windows.Forms.RichTextBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.txtTheme = new System.Windows.Forms.RichTextBox();
            this.ttt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubScribe
            // 
            this.btnSubScribe.Location = new System.Drawing.Point(322, 11);
            this.btnSubScribe.Name = "btnSubScribe";
            this.btnSubScribe.Size = new System.Drawing.Size(97, 35);
            this.btnSubScribe.TabIndex = 0;
            this.btnSubScribe.Text = "Subscribe";
            this.btnSubScribe.UseVisualStyleBackColor = true;
            this.btnSubScribe.Click += new System.EventHandler(this.btnSubScribe_Click);
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(12, 12);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(283, 34);
            this.txtSub.TabIndex = 1;
            this.txtSub.Text = "";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(12, 68);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(407, 280);
            this.txtMsg.TabIndex = 2;
            this.txtMsg.Text = "";
            // 
            // txtPub
            // 
            this.txtPub.Location = new System.Drawing.Point(12, 404);
            this.txtPub.Name = "txtPub";
            this.txtPub.Size = new System.Drawing.Size(283, 34);
            this.txtPub.TabIndex = 4;
            this.txtPub.Text = "";
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(322, 403);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(97, 35);
            this.btnPublish.TabIndex = 3;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(136, 363);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(283, 34);
            this.txtTheme.TabIndex = 5;
            this.txtTheme.Text = "";
            // 
            // ttt
            // 
            this.ttt.AutoSize = true;
            this.ttt.Location = new System.Drawing.Point(47, 366);
            this.ttt.Name = "ttt";
            this.ttt.Size = new System.Drawing.Size(37, 15);
            this.ttt.TabIndex = 6;
            this.ttt.Text = "主题";
            // 
            // MQTTClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 450);
            this.Controls.Add(this.ttt);
            this.Controls.Add(this.txtTheme);
            this.Controls.Add(this.txtPub);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.btnSubScribe);
            this.Name = "MQTTClient";
            this.Text = "MQTT Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubScribe;
        private System.Windows.Forms.RichTextBox txtSub;
        private System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.RichTextBox txtPub;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.RichTextBox txtTheme;
        private System.Windows.Forms.Label ttt;
    }
}

