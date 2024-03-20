
// 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Message
{

    private MessageHeader headerField;

    private MessageBody bodyField;

    private MessageReturn returnField;

    /// <remarks/>
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

    /// <remarks/>
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

    private string fACTORYField;

    private string aREAField;

    private string eQP_IDField;

    private string pRODUCT_IDField;

    private string lOT_IDField;

    private string lOT_TYPEField;

    private string mEASURE_EQP_IDField;

    private string mEASURE_RECIPE_IDField;

    private string oPERATION_IDField;

    private string pROCESSED_EQP_IDField;

    private string sTAGEField;

    private string wAFER_LISTField;

    private string sLOT_LISTField;

    private string cHAMBER_IDField;

    private string rECIPE_IDField;

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
    public string EQP_ID
    {
        get
        {
            return this.eQP_IDField;
        }
        set
        {
            this.eQP_IDField = value;
        }
    }


    /// <remarks/>
    public string PRODUCT_ID
    {
        get
        {
            return this.pRODUCT_IDField;
        }
        set
        {
            this.pRODUCT_IDField = value;
        }
    }

    /// <remarks/>
    public string LOT_ID
    {
        get
        {
            return this.lOT_IDField;
        }
        set
        {
            this.lOT_IDField = value;
        }
    }

    /// <remarks/>
    public string LOT_TYPE
    {
        get
        {
            return this.lOT_TYPEField;
        }
        set
        {
            this.lOT_TYPEField = value;
        }
    }

    /// <remarks/>
    public string MEASURE_EQP_ID
    {
        get
        {
            return this.mEASURE_EQP_IDField;
        }
        set
        {
            this.mEASURE_EQP_IDField = value;
        }
    }

    /// <remarks/>
    public string MEASURE_RECIPE_ID
    {
        get
        {
            return this.mEASURE_RECIPE_IDField;
        }
        set
        {
            this.mEASURE_RECIPE_IDField = value;
        }
    }

    /// <remarks/>
    public string OPERATION_ID
    {
        get
        {
            return this.oPERATION_IDField;
        }
        set
        {
            this.oPERATION_IDField = value;
        }
    }

    /// <remarks/>
    public string PROCESSED_EQP_ID
    {
        get
        {
            return this.pROCESSED_EQP_IDField;
        }
        set
        {
            this.pROCESSED_EQP_IDField = value;
        }
    }

    /// <remarks/>
    public string STAGE
    {
        get
        {
            return this.sTAGEField;
        }
        set
        {
            this.sTAGEField = value;
        }
    }

    /// <remarks/>
    public string WAFER_LIST
    {
        get
        {
            return this.wAFER_LISTField;
        }
        set
        {
            this.wAFER_LISTField = value;
        }
    }

    /// <remarks/>
    public string SLOT_LIST
    {
        get
        {
            return this.sLOT_LISTField;
        }
        set
        {
            this.sLOT_LISTField = value;
        }
    }

    /// <remarks/>
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

    /// <remarks/>
    public string RECIPE_ID
    {
        get
        {
            return this.rECIPE_IDField;
        }
        set
        {
            this.rECIPE_IDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MessageBody
{

    private MessageBodySubstrate[] measureDataField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Substrate", IsNullable = false)]
    public MessageBodySubstrate[] MeasureData
    {
        get
        {
            return this.measureDataField;
        }
        set
        {
            this.measureDataField = value;
        }
    }



    private MessageBodySubstrate[] processDataField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Substrate", IsNullable = false)]
    public MessageBodySubstrate[] ProcessData
    {
        get
        {
            return this.processDataField;
        }
        set
        {
            this.processDataField = value;
        }
    }



    private MessageBodyChamber[] chambersField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Chamber", IsNullable = false)]
    public MessageBodyChamber[] Chambers
    {
        get
        {
            return this.chambersField;
        }
        set
        {
            this.chambersField = value;
        }
    }

    private string wAFER_LISTField;

    /// <remarks/>
    public string WAFER_LIST
    {
        get
        {
            return this.wAFER_LISTField;
        }
        set
        {
            this.wAFER_LISTField = value;
        }
    }


    private string sLOT_LISTField;

    /// <remarks/>
    public string SLOT_LIST
    {
        get
        {
            return this.sLOT_LISTField;
        }
        set
        {
            this.sLOT_LISTField = value;
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

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MessageBodySubstrate
{

    private MessageBodySubstrateParameter[] parameterListField;

    private string waferidField;

    private string slotnoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("parameter", IsNullable = false)]
    public MessageBodySubstrateParameter[] ParameterList
    {
        get
        {
            return this.parameterListField;
        }
        set
        {
            this.parameterListField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string waferid
    {
        get
        {
            return this.waferidField;
        }
        set
        {
            this.waferidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string slotno
    {
        get
        {
            return this.slotnoField;
        }
        set
        {
            this.slotnoField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MessageBodySubstrateParameter
{

    private string nameField;

    private string typeField;

    private string valueField;

    private string stepField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string step
    {
        get
        {
            return this.stepField;
        }
        set
        {
            this.stepField = value;
        }
    }
}



/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MessageBodyChamber
{

    private MessageBodySubstrateParameter[] parameterListField;

    private string rUN_MODEField;

    private string sTATUSField;

    private string idField;

    public string RUN_MODE
    {
        get
        {
            return this.rUN_MODEField;
        }
        set
        {
            this.rUN_MODEField = value;
        }
    }

    public string STATUS
    {
        get
        {
            return this.sTATUSField;
        }
        set
        {
            this.sTATUSField = value;
        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("parameter", IsNullable = false)]
    public MessageBodySubstrateParameter[] ParameterList
    {
        get
        {
            return this.parameterListField;
        }
        set
        {
            this.parameterListField = value;
        }
    }



    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

}



