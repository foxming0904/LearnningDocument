using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.WebSockets;

namespace SocketServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建Socket
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                // 绑定Ip地址和端口号 
                IPAddress ipaddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
                EndPoint point = new IPEndPoint(ipaddress, 7788);//IPEndPoint类是对ip端口做了一层封装的类
                socket.Bind(point);

                socket.Listen(20);//最大连接数
                Console.WriteLine("Listen...");
                using (Socket ClientSocket = socket.Accept())
                {
                    //暂停当前线程知道有客户端连接进来才进行下面的代码,返回客户端的socket
                    Console.WriteLine("有客户端连入");/// 

                    //使用返回的socket向客户端发送消息
                    var ipp = (IPEndPoint)ClientSocket.RemoteEndPoint;
                    string welcome = "welcome to you"+ipp.Address.ToString();
                   // Console.WriteLine("向客户端发送消息" + welcome);///
                    byte[] str = Encoding.UTF8.GetBytes(welcome);//利用这个方法将string型转化为byte型数组
                    ClientSocket.Send(str);//向客户端发送欢迎信息
                    while (true)
                    {
                    //接收客户端发来的消息
                    byte[] data = new byte[1000];
                    int length = ClientSocket.Receive(data);
                    string receiveMessage = Encoding.UTF8.GetString(data, 0, length);
                    Console.WriteLine("收到客户端发来的消息：" + receiveMessage);
                    }

                }
            }
            Console.ReadKey();
        }
    }
}
