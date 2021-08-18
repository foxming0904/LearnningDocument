using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();
        }
        public Socket ClientSocket { get; set; }
        /// <summary>
        ///  链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConn_Click(object sender, EventArgs e)
        {
            //客户端链接服务端
            //创建Socket对象
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ClientSocket = socket;

            //链接服务器
            try
            {
                socket.Connect(IPAddress.Parse(txtIP.Text), Convert.ToInt32(txtPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败，重新操作... 错误信息:" + ex.Message);
                Thread.Sleep(500);
                btnConn_Click(this, e);
                return;
            }

            //发送消息，接受消息
            Thread thread = new Thread(new ParameterizedThreadStart(ReceveData));
            thread.IsBackground = true;
            thread.Start(ClientSocket);
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="socket"></param>
        public void ReceveData(object socket)
        {
            var proxSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception)
                {
                    //异常退出
                    AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 异常退出...");
                    StopContnet();
                }
                if (len <= 0)
                {
                    //正常退出
                    AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 退出...");
                    StopContnet();
                    return;
                }

                //判断头部字节  区别发送的类型   :  1字符串   2闪屏   3文件
                switch (data[0])
                {
                    case 1:            //接收消息写入文本框            
                        var str = ProcessReceiveString(data);
                        AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} \r\n  {str}");
                        break;
                    case 2:          //接收闪屏
                        Shake();
                        break;
                    case 3:
                        break;
                }

            }
        }

        /// <summary>
        /// 闪屏调用
        /// </summary>
        public void Shake()
        {
            //原始窗体位置
            Point oldLocation = this.Location;
            Random r = new Random();
            this.Invoke(new Action(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    this.Location = new Point(r.Next(oldLocation.X - 5, oldLocation.X + 5), r.Next(oldLocation.Y - 5, oldLocation.Y + 5));
                    Thread.Sleep(20);
                    this.Location = oldLocation;
                }
            })); 
        }
        /// <summary>
        /// 处理接收到的字符串
        /// </summary>
        private string ProcessReceiveString(byte[] data)
        {
            //把实际的字符串拿到 
            return Encoding.Default.GetString(data, 1, data.Length - 1);
        }
        /// <summary>
        /// 关闭服务链接
        /// </summary>
        private void StopContnet()
        {
            try
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Shutdown(SocketShutdown.Both);
                    ClientSocket.Close(100);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 文本框添加数据
        /// </summary>
        public void AppendTextToTxtMsg(string txt)
        {
            if (txtAllMsg.InvokeRequired)
            {
                //异步方法
                txtAllMsg.BeginInvoke(new Action<string>(s =>
                {
                    this.txtAllMsg.Text = string.Format("{0}\r\n{1}", txt, txtAllMsg.Text);
                }), txt);

                //同步方法
                //txtAllMsg.Invoke(new Action<string>(s =>
                //{
                //    this.txtAllMsg.Text = string.Format("{0}\r\n{1}", txt, txtAllMsg.Text);
                //}), txt);
            }
            else
            {
                this.txtAllMsg.Text = string.Format("{0}\r\n{1}", txt, txtAllMsg.Text);
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ClientSocket.Connected)
            {
                byte[] data = Encoding.Default.GetBytes(txtSendMsg.Text);
                ClientSocket.Send(data, data.Length, SocketFlags.None);
                AppendTextToTxtMsg($"{ClientSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} \r\n  {txtSendMsg.Text}");
                txtSendMsg.Text = string.Empty;
            }
        }
    }
}
