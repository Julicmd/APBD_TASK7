namespace APBDTask9.Models;

public class ComponentManufacture
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string FullName { get; set; }
    public DateTime FoundationDate { get; set; }
    
    public IEnumerable<Componets> Components { get; set; }
}