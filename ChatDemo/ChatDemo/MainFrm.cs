using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// <        /summary>
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
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData), proxSocket);
            }
        }
        /// <summary>
        /// 接收客户端的消息
        /// </summary>
        /// <param name="socket"></param>
        public void ReceiveData(object socket)
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
                //判断头部字节  区别发送的类型   :  1字符串   2闪屏   3文件
                switch (data[0])
                {
                    case 1:            //接收消息写入文本框
                        var str = ProcessReceiveString(data);
                        AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} \r\n  {str}");
                        break;
                    case 2:          //接收闪屏
                        Shake();
                        AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  发送了一个闪屏");
                        break;
                    case 3:
                        ProcessRecieveFile(data);
                        break;
                }
            }
        }

        /// <summary>
        /// 处理接受的文件
        /// </summary>
        public void ProcessRecieveFile(byte[] data)
        {
            this.Invoke(new Action(() =>
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (sfd.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                    byte[] fileData = new byte[data.Length - 1];
                    Buffer.BlockCopy(data, 1, fileData, 0, data.Length - 1);
                    File.WriteAllBytes(sfd.FileName, fileData);
                }
            }));

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
                    //对原始的数据加上协议的头部字节
                    byte[] result = new byte[data.Length + 1];
                    Buffer.BlockCopy(data, 0, result, 1, data.Length);
                    //发送
                    proxSocket.Send(data, data.Length, SocketFlags.None);
                    AppendTextToTxtMsg($"{proxSocket.RemoteEndPoint.ToString()}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} \r\n  {txtSendMsg.Text}");
                    txtSendMsg.Text = string.Empty;
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
        /// <summary>
        /// 发送闪屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShake_Click(object sender, EventArgs e)
        {
            foreach (var proxSocket in ClientProxSocketList)
            {
                if (proxSocket.Connected)
                {
                    proxSocket.Send(new byte[] { 2 }, SocketFlags.None);
                }
            }
        } 
        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFile_Click(object sender, EventArgs e)
        {
            foreach (var proxSocket in ClientProxSocketList)
            {
                if (!proxSocket.Connected)
                {
                    continue;
                }
                //把发送的文件读取出
                using (OpenFileDialog odf = new OpenFileDialog())
                {
                    if (odf.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    byte[] data = File.ReadAllBytes(odf.FileName);
                    byte[] result = new byte[data.Length + 1];
                    result[0] = 3;
                    Buffer.BlockCopy(data, 0, result, 1, result.Length-1);
                    proxSocket.Send(result, SocketFlags.None);
                }
            }
        }
    }
}
