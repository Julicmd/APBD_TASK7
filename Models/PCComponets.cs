namespace APBDTask9.Models;

public class PcComponets
{
    public int PcId { get; set; }
    public char ComponentCode { get; set; }
    public int ComponetAmount { get; set; }
   
    public PCs Pc { get; set; }
    public Components Component { get; set; }
    
}