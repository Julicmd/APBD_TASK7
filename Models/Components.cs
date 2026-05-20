namespace APBDTask9.Models;

public class Components
{
    public char Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ComponentManufactorId { get; set; }
    public int ComponentTypeId { get; set; }
    
    
    public ICollection<PcComponets> PcComponets { get; set; } = [];
    
}