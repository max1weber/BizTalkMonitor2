namespace BizTalk.Monitor.Web.Models.ChartTypes
{
    public class Dataset
        {
            public string label { get; set; }
            public int[] data { get; set; }
            public string[] backgroundColor { get; set; }
            public string[] borderColor { get; set; }
            public int borderWidth { get; set; }
        }

    
}
