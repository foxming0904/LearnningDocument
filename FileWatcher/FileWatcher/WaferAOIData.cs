public class Rootobject
{
    public string id { get; set; }
    public string type { get; set; }
    public int sumQty { get; set; }
    public int sumlossQty { get; set; }
    public int sumpassQty { get; set; }
    public double sumpassRate { get; set; }
    public string workOrder { get; set; }
    public LotNOItem[] items { get; set; }
}

public class LotNOItem
{
    public string lossQty { get; set; }
    public string passQty { get; set; }
    public string passRate { get; set; }
    public string waferSerial { get; set; }
    public string lossCode { get; set; }
}
