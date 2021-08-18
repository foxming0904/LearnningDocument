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

namespace ChatDemo
{
    public partial class MainFrm : Form
    {
        /// <summary>
        /// 客户端socket队列
        /// </summary>
        List<Socket> ClientProxSocketList = new List<Socket>();

        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //创建Socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定端口IP
            socket.Bind(new IPEndPoint(IPAddress.Parse(txtIP.Text), Convert.ToInt32(txtPort.Text)));

            //开启监听
            socket.Listen(10); //链接2等待队列  最多链接数 超出返回错误

            //开始接收客户端的链接
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.AcceptClientConnect), socket);


        }

        public void AcceptClientConnect(object socket)
        {
            var serverSocket = (Socket)socket;

            AppendTextToTxtMsg("服务器开启接受链接...");
            while (true)
            {
                var proxSocket = serverSocket.Accept();
                this.AppendTextToTxtMsg($"客户端:{proxSocket.RemoteEndPoint.ToString()}链接...");
                ClientProxSocketList.Add(proxSocket);

                //接收当前链接的客户端消息
                //proxSocket.Receive();
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceveData), proxSocket);
            }
        }

        /// <summary>
        /// 接收客户端的消息
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
                    StopContnet(proxSocket);
                }
                if (len <= 0)
                {
                    //正常退出
                    AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 退出...");
                    ClientProxSocketList.Remove(proxSocket);
                    StopContnet(proxSocket);
                    return;
                }
                //接收消息写入文本框
                var str = Encoding.Default.GetString(data, 0, len);
                AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} \r\n  {str}");
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
            foreach (var proxSocket in ClientProxSocketList)
            {
                if (proxSocket.Connected)
                {
                    byte[] data = Encoding.Default.GetBytes(txtSendMsg.Text);
                    proxSocket.Send(data, data.Length, SocketFlags.None);

                }
            }
        }

        /// <summary>
        /// 关闭服务链接
        /// </summary>
        private void StopContnet(Socket proxSocket)
        {
            try
            {
                if (proxSocket.Connected)
                {
                    proxSocket.Shutdown(SocketShutdown.Both);
                    proxSocket.Close(100);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
