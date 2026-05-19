namespace APBDTask9.Models;

public class PCComponets
{
    public int PCId { get; set; }
    public char ComponetCode { get; set; }
    public int ComponetAmount { get; set; }
   
    public Componets Component { get; set; }
    
}