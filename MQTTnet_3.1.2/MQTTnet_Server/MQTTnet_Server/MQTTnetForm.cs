using MQTTnet.Server;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client.Receiving;
using System.Runtime.Remoting.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MQTTnet_Server
{
    public partial class MQTTnetForm : Form
    {
        public MQTTnetForm()
        {
            InitializeComponent();
        }
        //服务obj
        private MqttServer mqttServer = null;
        //消息队列
        private List<MqttApplicationMessage> messages = new List<MqttApplicationMessage>();
        private List<string> topics = new List<string>();

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStart_Click(object sender, EventArgs e)
        {
            #region 配置信息
            var port = Convert.ToInt32(txtPort.Text.Trim());   //端口号
            var clientId = cbbClientID.Text.Trim();   //连接的ID
            var username = txtUsername.Text.Trim();   //用户名
            var password = txtPassword.Text.Trim();   //密码
            #endregion 配置信息

            //构造连接实例
            if (mqttServer == null)
            {
                var optionBuilder = new MqttServerOptionsBuilder()
                 .WithPersistentSessions()   //持续会话
                .WithDefaultEndpointPort(port)  //设置port
                .WithClientId(clientId) 
                //拦截客户端发送的消息
                .WithApplicationMessageInterceptor(c =>
                {
                    if (c.ClientId.Length < 3)
                    {
                        c.AcceptPublish = false;
                        return;
                    }
                })
                //拦截订阅
                .WithSubscriptionInterceptor(c =>
                {
                    if (c.ClientId.Length < 3)
                    {
                        c.AcceptSubscription = false;
                        return;
                    }
                })
                //连接验证
                .WithConnectionValidator(c =>
                {
                    if (c.ClientId.Length < 3) //验证ID
                    {
                        c.ReasonCode = MqttConnectReasonCode.ClientIdentifierNotValid;
                        return;
                    }


                    //如果设置了用户名密码就验证否则只做非空验证
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        if (!c.Username.Equals(username) || !c.Password.Equals(password))//验证用户名密码
                        {
                            c.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                            return;
                        }
                    }
                    else
                    {
                        if (c.Username.Length < 4 && c.Password.Length < 4)//验证用户名密码
                        {
                            c.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                            return;
                        }
                    }



                    c.ReasonCode = MqttConnectReasonCode.Success;
                });

                mqttServer = new MqttFactory().CreateMqttServer() as MqttServer;  //注册服务 

                #region 注册mqttServer相关事件
                //服务开始
                mqttServer.StartedHandler = new MqttServerStartedHandlerDelegate(OnMqttServerStarted);
                //服务停止
                mqttServer.StoppedHandler = new MqttServerStoppedHandlerDelegate(OnMqttServerStopped);
                //客户端连接
                mqttServer.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(OnMqttServerClientConnected);
                //客户端断开连接（此事件会覆盖拦截器）
                mqttServer.ClientDisconnectedHandler = new MqttServerClientDisconnectedHandlerDelegate(OnMqttServerClientDisconnected);
                //客户端订阅
                mqttServer.ClientSubscribedTopicHandler = new MqttServerClientSubscribedTopicHandlerDelegate(OnMqttServerClientSubscribedTopic);
                //客户端取消订阅
                mqttServer.ClientUnsubscribedTopicHandler = new MqttServerClientUnsubscribedTopicHandlerDelegate(OnMqttServerClientUnsubscribedTopic);
                //服务端收到消息
                mqttServer.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnMqttServerApplicationMessageReceived);
                #endregion mqttServer事件 

                //开启服务
                await mqttServer.StartAsync(optionBuilder.Build());

            }
        }
        /// <summary>
        /// 关闭服务·
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStop_Click(object sender, EventArgs e)
        {
            if (mqttServer != null)
            {
                mqttServer.Dispose();
                await mqttServer.StopAsync();
                mqttServer = null;
            }
            else
            {
                await AppendMsg("服务未开启");
            }
        }

        /// <summary>
        /// 服务开始
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void OnMqttServerStarted(EventArgs e)
        {
            await AppendMsg("服务开启");
        }
        /// <summary>
        /// 服务停止
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void OnMqttServerStopped(EventArgs e)
        {
            await AppendMsg("服务停止");
        }
        /// <summary>
        /// /客户端断开连接
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void OnMqttServerClientDisconnected(MqttServerClientDisconnectedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                cbbClientID.Items.Remove(e.ClientId);
            }));
            await AppendMsg($"{e.ClientId}断开服务");
        }
        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void OnMqttServerClientConnected(MqttServerClientConnectedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                cbbClientID.Items.Add(e.ClientId);
            }));
            await AppendMsg($"{e.ClientId}连接服务");
        }
        /// <summary>
        /// 客户端取消订阅
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void OnMqttServerClientUnsubscribedTopic(MqttServerClientUnsubscribedTopicEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                topics.Remove(e.TopicFilter.ToString());
                cbbTheme.Items.Remove(e.TopicFilter);
            }));
            await AppendMsg($"{e.ClientId}取消订阅【{e.TopicFilter}】");
        }
        /// <summary>
        /// 客户端订阅
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void OnMqttServerClientSubscribedTopic(MqttServerClientSubscribedTopicEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                topics.Add(e.TopicFilter.ToString());
                cbbTheme.Items.Add(e.TopicFilter.Topic);
            }));
            await AppendMsg($"{e.ClientId}订阅主题【{e.TopicFilter.Topic}】");
        }
        /// <summary>
        /// 服务端收到消息
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void OnMqttServerApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            await AppendMsg($"客户端[{e.ClientId}]>> Topic[{e.ApplicationMessage.Topic}] Payload[{Encoding.UTF8.GetString(e.ApplicationMessage.Payload ?? new byte[] { })}] Qos[{e.ApplicationMessage.QualityOfServiceLevel}] Retain[{e.ApplicationMessage.Retain}]");
        }

        /// <summary>
        /// 服务器发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSend_Click(object sender, EventArgs e)
        {
            var topic = this.cbbTheme.Text;
            //服务器向客户端发送消息
            var res = await mqttServer.PublishAsync(new MqttApplicationMessage()
            {
                Topic = topic,
                QualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce,
                Retain = false,
                Payload = Encoding.UTF8.GetBytes(txtSend.Text)
            });
            await AppendMsg(res.ReasonCode.ToString());
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
    }
}
