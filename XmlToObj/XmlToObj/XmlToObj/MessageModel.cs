using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToObj
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。

    /// <summary>
    /// Root
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Message
    {

        private MessageHeader headerField;

        private MessageBody bodyField;

        private MessageReturn returnField;

        ///  <summary>
        ///  XML消息头
        /// </summary> 
        public MessageHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <summary>
        ///  XML消息体
        /// </summary> 
        public MessageBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }

        /// <summary>
        /// 返回值对象
        /// </summary>
        public MessageReturn Return
        {
            get
            {
                return this.returnField;
            }
            set
            {
                this.returnField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MessageHeader
    {
        private string mESSAGENAMEField;

        private string tRANSACTIONIDField;

        private string oRIGINField;

        private string fACTORYField;

        private string aREAField;

        private string tOOLTYPEField;

        private string tOOLNAMEField;

        private string cHAMBER_IDField;

        /// <summary>
        /// 消息名称
        /// </summary>
        public string MESSAGENAME
        {
            get
            {
                return this.mESSAGENAMEField;
            }
            set
            {
                this.mESSAGENAMEField = value;
            }
        }

        /// <summary>
        /// 响应消息必须发送请求消息中包含的事务Id格式：时间戳，17位
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string TRANSACTIONID
        {
            get
            {
                return this.tRANSACTIONIDField;
            }
            set
            {
                this.tRANSACTIONIDField = value;
            }
        }

        /// <summary>
        /// 发送消息的应用程序
        /// </summary>
        public string ORIGIN
        {
            get
            {
                return this.oRIGINField;
            }
            set
            {
                this.oRIGINField = value;
            }
        }

        /// <summary>
        /// 工厂名称
        /// </summary>
        public string FACTORY
        {
            get
            {
                return this.fACTORYField;
            }
            set
            {
                this.fACTORYField = value;
            }
        }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string AREA
        {
            get
            {
                return this.aREAField;
            }
            set
            {
                this.aREAField = value;
            }
        }

        /// <summary>
        /// 工具类型
        /// </summary>
        public string TOOLTYPE
        {
            get
            {
                return this.tOOLTYPEField;
            }
            set
            {
                this.tOOLTYPEField = value;
            }
        }

        /// <summary>
        /// 工具名称
        /// </summary>
        public string TOOLNAME
        {
            get
            {
                return this.tOOLNAMEField;
            }
            set
            {
                this.tOOLNAMEField = value;
            }
        }

        /// <summary>
        /// 腔体
        /// </summary>
        public string CHAMBER_ID
        {
            get
            {
                return this.cHAMBER_IDField;
            }
            set
            {
                this.cHAMBER_IDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MessageBody
    {

        private string rEMARKField;

        private string tRIDField;

        private string dATA_RATEField;

        private string rEPGSZField;

        private string[] sVID_LISTField;

        private MessageBodyDATA_LIST dATA_LISTField;

        private string aLCDField;

        private string aLIDField;

        private string aLTXField;

        private string cOMMENTField;

        /// <summary>
        /// Reserve Column
        /// 冗余字段 后期再改
        /// </summary>
        public string REMARK
        {
            get
            {
                return this.rEMARKField;
            }
            set
            {
                this.rEMARKField = value;
            }
        }

        /// <summary>
        /// 跟踪请求ID
        /// </summary>
        public string TRID
        {
            get
            {
                return this.tRIDField;
            }
            set
            {
                this.tRIDField = value;
            }
        }

        /// <summary>
        /// 参数组的数据收集速率  以毫秒为单位指定
        /// </summary>
        public string DATA_RATE
        {
            get
            {
                return this.dATA_RATEField;
            }
            set
            {
                this.dATA_RATEField = value;
            }
        }

        /// <summary>
        /// 报告组大小
        /// </summary>
        public string REPGSZ
        {
            get
            {
                return this.rEPGSZField;
            }
            set
            {
                this.rEPGSZField = value;
            }
        }

        /// <summary>
        /// SVID LIST
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("SVID", IsNullable = false)]
        public string[] SVID_LIST
        {
            get
            {
                return this.sVID_LISTField;
            }
            set
            {
                this.sVID_LISTField = value;
            }
        }

        /// <summary>
        /// DATA_LIST
        /// </summary>
        public MessageBodyDATA_LIST DATA_LIST
        {
            get
            {
                return this.dATA_LISTField;
            }
            set
            {
                this.dATA_LISTField = value;
            }
        }

        /// <summary>
        /// 报警码字节
        /// </summary>
        public string ALCD
        {
            get
            {
                return this.aLCDField;
            }
            set
            {
                this.aLCDField = value;
            }
        }

        /// <summary>
        /// 报警ID
        /// </summary>
        public string ALID
        {
            get
            {
                return this.aLIDField;
            }
            set
            {
                this.aLIDField = value;
            }
        }

        /// <summary>
        /// 报警文本
        /// </summary>
        public string ALTX
        {
            get
            {
                return this.aLTXField;
            }
            set
            {
                this.aLTXField = value;
            }
        }

        /// <summary>
        /// 注释
        /// </summary>
        public string COMMENT
        {
            get
            {
                return this.cOMMENTField;
            }
            set
            {
                this.cOMMENTField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MessageBodyDATA_LIST
    {

        private MessageBodyDATA_LISTTRACE_DATA[] tRACE_DATAField;

        private MessageBodyDATA_LISTEVENT_DATA[] eVENT_DATAField;

        /// <summary>
        /// 参数节点
        /// </summary> 
        [System.Xml.Serialization.XmlElementAttribute("TRACE_DATA")]
        public MessageBodyDATA_LISTTRACE_DATA[] TRACE_DATA
        {
            get
            {
                return this.tRACE_DATAField;
            }
            set
            {
                this.tRACE_DATAField = value;
            }
        }

        /// <summary>
        /// 事件数据节点
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("EVENT_DATA")]
        public MessageBodyDATA_LISTEVENT_DATA[] EVENT_DATA
        {
            get
            {
                return this.eVENT_DATAField;
            }
            set
            {
                this.eVENT_DATAField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MessageBodyDATA_LISTTRACE_DATA
    {

        private string sVIDField;

        private string vALUEField;

        /// <remarks/>
        public string SVID
        {
            get
            {
                return this.sVIDField;
            }
            set
            {
                this.sVIDField = value;
            }
        }

        /// <remarks/>
        public string VALUE
        {
            get
            {
                return this.vALUEField;
            }
            set
            {
                this.vALUEField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MessageBodyDATA_LISTEVENT_DATA
    {

        private string dVIDField;

        private string vALUEField;

        /// <remarks/>
        public string DVID
        {
            get
            {
                return this.dVIDField;
            }
            set
            {
                this.dVIDField = value;
            }
        }

        /// <remarks/>
        public string VALUE
        {
            get
            {
                return this.vALUEField;
            }
            set
            {
                this.vALUEField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MessageReturn
    {

        private string rETURNCODEField;

        private string rETURNMESSAGEField;

        /// <remarks/>
        public string RETURNCODE
        {
            get
            {
                return this.rETURNCODEField;
            }
            set
            {
                this.rETURNCODEField = value;
            }
        }

        /// <remarks/>
        public string RETURNMESSAGE
        {
            get
            {
                return this.rETURNMESSAGEField;
            }
            set
            {
                this.rETURNMESSAGEField = value;
            }
        }
    }


}
