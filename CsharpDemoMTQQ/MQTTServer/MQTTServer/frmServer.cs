using MQTTnet;
using MQTTnet.Core.Adapter;
using MQTTnet.Core.Diagnostics;
using MQTTnet.Core.Protocol;
using MQTTnet.Core.Server;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace MQTTServer
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private static MqttServer mqttServer = null;
        private static Settings settings = null;

        /// <summary>
        /// Enable MQTT Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnable_Click(object sender, EventArgs e)
        {
            settings = new Settings()
            {
                IP = txtIP.Text.Trim(),
                Port = int.Parse(txtProt.Text.Trim()),
                UserName = txtName.Text.Trim(),
                Password = txtPass.Text.Trim(),
            };
            new Thread(EnableMQTT).Start();
        }

        private void EnableMQTT()
        {
            if (mqttServer == null)
            {
                try
                {
                    var options = new MqttServerOptions()
                    {
                        ConnectionValidator = c =>
                        {
                            return MqttConnectReturnCode.ConnectionAccepted;
                        },

                    };
                    //注册服务
                    mqttServer = new MqttServerFactory().CreateMqttServer(options) as MqttServer;
                    mqttServer.ApplicationMessageReceived += MqttServer_ApplicationMessageReceived;
                    mqttServer.ClientConnected += MqttServer_ClientConnected;
                    mqttServer.ClientDisconnected += MqttServer_ClientDisconnected;

                }
                catch (Exception ex)
                {
                    txtMeg.Text += (ex.Message + "\r\n");
                }

                mqttServer.StartAsync();
                txtMeg.AppendText("MQTT服务启动成功！" + Environment.NewLine);
                IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
                string myip = IpEntry.AddressList[1].ToString();

                txtMeg.AppendText(myip+Environment.NewLine);

            }
        }

        /// <summary>
        /// Disable MQTT Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisaable_Click(object sender, EventArgs e)
        {
            if (mqttServer != null)
            {
                mqttServer.StopAsync();
                txtMeg.Text += ("MQTT服务停止成功！");
                mqttServer = null;
            }

        }


        private void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            txtMeg.AppendText($"客户端[{e.Client.ClientId}]已连接，协议版本：{e.Client.ProtocolVersion}\r\n");
        }

        private void MqttServer_ClientDisconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            txtMeg.AppendText($"客户端[{e.Client.ClientId}]已断开连接！\r\n");
        }

        private void MqttServer_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            txtMeg.AppendText($"客户端[{e.ClientId}]>> 主题：{e.ApplicationMessage.Topic} 负荷：{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} Qos：{e.ApplicationMessage.QualityOfServiceLevel} 保留：{e.ApplicationMessage.Retain}\r\n");
        }

        private static void MqttNetTrace_TraceMessagePublished(object sender, MqttNetTraceMessagePublishedEventArgs e)
        {
            /*Console.WriteLine($">> 线程ID：{e.ThreadId} 来源：{e.Source} 跟踪级别：{e.Level} 消息: {e.Message}");
            if (e.Exception != null)
            {
                Console.WriteLine(e.Exception);
            }*/
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMeg.Clear();
        }
    }

    public class Settings
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> Clients { get; set; }
        public List<string> Theme { get; set; }
    }
}