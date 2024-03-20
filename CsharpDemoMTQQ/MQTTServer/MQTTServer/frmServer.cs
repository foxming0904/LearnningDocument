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
                    //ע�����
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
                txtMeg.AppendText("MQTT���������ɹ���" + Environment.NewLine);
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
                txtMeg.Text += ("MQTT����ֹͣ�ɹ���");
                mqttServer = null;
            }

        }


        private void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            txtMeg.AppendText($"�ͻ���[{e.Client.ClientId}]�����ӣ�Э��汾��{e.Client.ProtocolVersion}\r\n");
        }

        private void MqttServer_ClientDisconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            txtMeg.AppendText($"�ͻ���[{e.Client.ClientId}]�ѶϿ����ӣ�\r\n");
        }

        private void MqttServer_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            txtMeg.AppendText($"�ͻ���[{e.ClientId}]>> ���⣺{e.ApplicationMessage.Topic} ���ɣ�{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} Qos��{e.ApplicationMessage.QualityOfServiceLevel} ������{e.ApplicationMessage.Retain}\r\n");
        }

        private static void MqttNetTrace_TraceMessagePublished(object sender, MqttNetTraceMessagePublishedEventArgs e)
        {
            /*Console.WriteLine($">> �߳�ID��{e.ThreadId} ��Դ��{e.Source} ���ټ���{e.Level} ��Ϣ: {e.Message}");
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