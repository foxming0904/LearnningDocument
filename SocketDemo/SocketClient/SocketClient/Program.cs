using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1:创建socket
            Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //2:向服务器端发送连接请求
            Console.WriteLine("向服务器端发送连接请求");//
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");//IPAddress.Parse可以把string类型的ip地址转化为ipAddress型
            EndPoint point = new IPEndPoint(ipaddress, 7788);//通过ip地址和端口号定位要连接的服务器端
            tcpClient.Connect(point);//建立连接
            Console.WriteLine("连接到服务器");//
       
                //3:接收服务器端发来的消息
                byte[] data = new byte[1000];
                int length = tcpClient.Receive(data);//这里的byte数组用来接收数据,返回值length表示接收的数据长度
                string message = Encoding.UTF8.GetString(data, 0, length);//把字节数组转化为字符串
                Console.WriteLine("接收到服务器端的消息：" + message);
     while (true)
            {
                //4:向服务器端发送消息            
                string messageToServer = Console.ReadLine();
                //   Console.WriteLine("向服务器端发送消息：" + messageToServer);//
                tcpClient.Send(Encoding.UTF8.GetBytes(messageToServer));//向服务器端发送消息
            }



            Console.ReadKey();
        }
    }
}
