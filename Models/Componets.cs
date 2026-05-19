namespace APBDTask9.Models;

public class Componets
{
    public char Code { get; set; }
    public string Name { get; set; }
    public string Desciption { get; set; }
    public int ComponentManufactorId { get; set; }
    public int ComponentTypeId { get; set; }
    
    
    public IEnumerable<PCComponets> PcComponets { get; set; } = [];
    
}