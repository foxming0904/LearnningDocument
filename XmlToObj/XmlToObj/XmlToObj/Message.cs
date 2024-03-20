using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToObj1
{
    /// <summary>
    /// XML消息头
    /// </summary> 
    public class Header
    {
        /// <summary>
        /// 消息名称
        /// </summary>
        public string MESSAGENAME { get; set; }
        /// <summary>
        /// 响应消息必须发送请求消息中包含的事务Id格式：时间戳，17位
        /// </summary>
        public string TRANSACTIONID { get; set; }
        /// <summary>
        /// 发送消息的应用程序
        /// </summary>
        public string ORIGIN { get; set; }
        /// <summary>
        /// 工厂名称
        /// </summary>
        public string FACTORY { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AREA { get; set; }
        /// <summary>
        /// 工具类型
        /// </summary>
        public string TOOLTYPE { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string TOOLNAME { get; set; }
        /// <summary>
        /// 腔体
        /// </summary>
        public string CHAMBER_ID { get; set; }
    }




    /// <summary>
    /// SVID 集合
    /// </summary>
    public class SVID_LIST
    {
        /// <summary>
        /// SVID
        /// </summary>
        public List<string> SVID { get; set; } 
    }

    /// <summary>
    /// 参数节点
    /// </summary> 
    public class TRACE_DATA
    {
        /// <summary>
        /// Data ID
        /// </summary>
        public string SVID { get; set; }
        /// <summary>
        /// Data VALUE
        /// </summary>
        public string VALUE { get; set; }
    }


    /// <summary>
    /// 事件数据节点
    /// </summary> 
    public class EVENT_DATA
    {
        /// <summary>
        /// Data ID
        /// </summary>
        public string DVID { get; set; }
        /// <summary>
        /// Data VALUE
        /// </summary>
        public string VALUE { get; set; }
    }

    /// <summary>
    /// DATA_LIST
    /// </summary> 
    public class DATA_LIST
    {
        /// <summary>
        /// 参数节点集合
        /// </summary>
        public List<TRACE_DATA> TRACE_DATA { get; set; }
        /// <summary>
        /// 数据节点集合
        /// </summary>
        public List<EVENT_DATA> EVENT_DATA { get; set; }
    }


    /// <summary>
    /// XML消息体
    /// </summary> 
    public class Body
    {
        /// <summary>
        /// Reserve Column
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 跟踪请求ID
        /// </summary>
        public string TRID { get; set; }
        /// <summary>
        /// 参数组的数据收集速率  以毫秒为单位指定
        /// </summary>
        public string DATA_RATE { get; set; }
        /// <summary>
        /// 报告组大小
        /// </summary>
        public string REPGSZ { get; set; }
        /// <summary>
        /// SVID LIST
        /// </summary>
        public SVID_LIST SVID_LIST { get; set; }
        /// <summary>
        /// DATA_LIST
        /// </summary>
        public DATA_LIST DATA_LIST { get; set; }
        /// <summary>
        /// 报警码字节
        /// </summary>
        public string ALCD { get; set; }
        /// <summary>
        /// 报警ID
        /// </summary>
        public string ALID { get; set; }
        /// <summary>
        /// 报警文本
        /// </summary>
        public string ALTX { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string COMMENT { get; set; }
    }

    /// <summary>
    /// 返回值对象
    /// </summary>
    public class @Return
    {
        /// <summary>
        /// 一个请求的返回代码。所有的回复邮件都应该有此项目。
        /// “0”：成功
        /// 其他：错误代码
        /// </summary>
        public string RETURNCODE { get; set; }
        /// <summary>
        /// 当返回代码不为零时的错误描述如果有的话，EAP提供与每个错误代码对应的自己的错误消息。
        /// </summary>
        public string RETURNMESSAGE { get; set; }
    }

    /// <summary>
    /// Root
    /// </summary>
    public class Message
    {
        public Header Header { get; set; }

        public Body Body { get; set; }

        public @Return @Return { get; set; }
    }



}
