using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace FolderAccessTester
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        //富文本添加信息
        private void RichTextBoxAdd(string content)
        {
            rhPanel.AppendText($"{content}\r\n");
        }

        // 检查是否能够访问指定文件夹
        private bool CanAccessFolder(string folderPath)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                directoryInfo.GetFiles();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        //用文件资源管理器打开文件夹
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                RichTextBoxAdd($"Error opening folder: {path}" + ex.Message);
            }
        }


        //通过用户名密码、域访问获取文件夹下的文件列表
        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();

            // 判断是否能够获取文件列表
            if (CanAccessFolder(path))
            {
                // 可以获取文件列表，则直接获取并打印文件名
                RichTextBoxAdd("直接访问...");
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] files = directoryInfo.GetFiles();
                RichTextBoxAdd($"文件数量:{files.Length}");
                foreach (FileInfo file in files)
                {
                    RichTextBoxAdd(file.Name);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    //使用用户名密码域访问
                    NetworkCredential credentials;
                    if (!string.IsNullOrEmpty(txtDomain.Text))
                    {
                        credentials = new NetworkCredential("username", "password", txtDomain.Text.Trim());
                        RichTextBoxAdd("通过用户名密码/域访问...");

                    }
                    else
                    {
                        credentials = new NetworkCredential("username", "password", txtDomain.Text.Trim());
                        RichTextBoxAdd("通过用户名密码访问...");
                    }

                    DirectoryInfo directoryInfoWithCredentials = new DirectoryInfo(path);
                    FileInfo[] files = directoryInfoWithCredentials.GetFiles("*.*", SearchOption.AllDirectories);
                    RichTextBoxAdd($"文件数量:{files.Length}");
                    foreach (FileInfo file in files)
                    {
                        RichTextBoxAdd(file.Name);
                    }
                }
            }
        }




    }
}
