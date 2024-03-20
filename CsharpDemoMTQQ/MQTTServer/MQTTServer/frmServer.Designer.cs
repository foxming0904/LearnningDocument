namespace MQTTServer
{
    partial class frmServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDisaable = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnable = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbTheme = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbClient = new System.Windows.Forms.ComboBox();
            this.txtMeg = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDisaable
            // 
            this.btnDisaable.Location = new System.Drawing.Point(165, 244);
            this.btnDisaable.Name = "btnDisaable";
            this.btnDisaable.Size = new System.Drawing.Size(94, 29);
            this.btnDisaable.TabIndex = 0;
            this.btnDisaable.Text = "Disable";
            this.btnDisaable.UseVisualStyleBackColor = true;
            this.btnDisaable.Click += new System.EventHandler(this.btnDisaable_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbbTheme);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.btnDisaable);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtProt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbClient);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 292);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(43, 244);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(94, 29);
            this.btnEnable.TabIndex = 12;
            this.btnEnable.Text = "Enable";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Theme";
            // 
            // cbbTheme
            // 
            this.cbbTheme.FormattingEnabled = true;
            this.cbbTheme.Items.AddRange(new object[] {
            "全部"});
            this.cbbTheme.Location = new System.Drawing.Point(108, 189);
            this.cbbTheme.Name = "cbbTheme";
            this.cbbTheme.Size = new System.Drawing.Size(151, 28);
            this.cbbTheme.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Client";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(108, 122);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(151, 27);
            this.txtPass.TabIndex = 8;
            this.txtPass.Text = "test";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 89);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 27);
            this.txtName.TabIndex = 6;
            this.txtName.Text = "fox";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username";
            // 
            // txtProt
            // 
            this.txtProt.Location = new System.Drawing.Point(108, 56);
            this.txtProt.Name = "txtProt";
            this.txtProt.Size = new System.Drawing.Size(151, 27);
            this.txtProt.TabIndex = 4;
            this.txtProt.Text = "1533";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(108, 23);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(151, 27);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // cbbClient
            // 
            this.cbbClient.FormattingEnabled = true;
            this.cbbClient.Location = new System.Drawing.Point(108, 155);
            this.cbbClient.Name = "cbbClient";
            this.cbbClient.Size = new System.Drawing.Size(151, 28);
            this.cbbClient.TabIndex = 0;
            // 
            // txtMeg
            // 
            this.txtMeg.Location = new System.Drawing.Point(330, 24);
            this.txtMeg.Name = "txtMeg";
            this.txtMeg.Size = new System.Drawing.Size(549, 280);
            this.txtMeg.TabIndex = 2;
            this.txtMeg.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(785, 275);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 319);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtMeg);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmServer";
            this.Text = "MQTT Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnDisaable;
        private GroupBox groupBox1;
        private Button btnEnable;
        private Label label6;
        private ComboBox cbbTheme;
        private Label label5;
        private TextBox txtPass;
        private Label label4;
        private TextBox txtName;
        private Label label3;
        private TextBox txtProt;
        private Label label2;
        private TextBox txtIP;
        private Label label1;
        private ComboBox cbbClient;
        private RichTextBox txtMeg;
        private Button btnClear;
    }
}