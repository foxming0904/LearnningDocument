using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Protocol;

namespace MQTTnet_Client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        //MQTTnet
        private MqttClient mqttClient = null;

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIP.Text) || string.IsNullOrEmpty(txtPort.Text) || string.IsNullOrEmpty(txtClientID.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtTheme.Text))
            {
                await AppendMsg("配置信息有误");
                return;
            }
            #region 配置信息
            var ip = txtIP.Text.Trim();   //IP
            var port = Convert.ToInt32(txtPort.Text.Trim());   //端口号
            var clientId = txtClientID.Text.Trim();   //Client ID
            var username = txtUsername.Text.Trim();   //用户名
            var password = txtPassword.Text.Trim();   //密码
            var theme = txtTheme.Text.Trim();
            #endregion 配置信息 

            //配置client
            var option = new MqttClientOptionsBuilder()
                .WithCommunicationTimeout(new TimeSpan(0, 0, 0, 20))
                .WithTcpServer(ip, port)
                .WithClientId(clientId)
                //  .WithCleanSession(false)
                .WithCredentials(username, password).Build();


            //注册
            mqttClient = new MqttFactory().CreateMqttClient() as MqttClient;

            mqttClient.UseApplicationMessageReceivedHandler(async c =>
            {
                await AppendMsg("Server published" + "\r\n" + Encoding.UTF8.GetString(c.ApplicationMessage.Payload));
            });

            //重连
            mqttClient.UseDisconnectedHandler(async c =>
            {
                if (!mqttClient.IsConnected)
                {
                    await AppendMsg("重新连接Server...");
                    await mqttClient.ReconnectAsync();
                    if (mqttClient.IsConnected)
                    {
                        await mqttClient.SubscribeAsync(theme);
                        await AppendMsg("重连成功！");
                    }
                };
            });

            try
            {
                //连接
                await mqttClient.ConnectAsync(option);
                //订阅
              await mqttClient.SubscribeAsync(theme);
            }
            catch (Exception ex)
            {
                await AppendMsg(ex.Message);
            }



        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            var theme = txtTheme.Text.Trim();
            await mqttClient.UnsubscribeAsync(theme);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        private async Task AppendMsg(string msg)
        {
            await Task.Run(() =>
            {
                this.Invoke(new EventHandler(delegate
                {
                    txtMsg.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff ") + msg + Environment.NewLine);
                }));
            });
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                txtMsg.Clear();
            }));
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string topic = txtTheme.Text.Trim();

            if (string.IsNullOrEmpty(topic))
            {
                await AppendMsg("发布主题不能为空！");
                return;
            }


            var obj = new { Amount = 108, Message = "Hello" };
            //byte[] buff;
            //MemoryStream ms = new MemoryStream();

            //IFormatter iFormatter = new BinaryFormatter();
            //iFormatter.Serialize(ms, obj);
            //buff = ms.GetBuffer();



            string inputString = txtSend.Text.Trim();
            //发布消息
            var msg = new MqttApplicationMessageBuilder()
                                            .WithTopic(topic)
                                            .WithPayload(inputString)
                                            .WithAtLeastOnceQoS()
                                             .WithRetainFlag(false).Build();
            var result = mqttClient.PublishAsync(msg);
            await AppendMsg(result.Result.ReasonCode.ToString());
        }


    }
}
