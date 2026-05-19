namespace APBDTask9.Models;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string Name { get; set; }
    
    
    public IEnumerable<Componets> Components { get; set; }
}