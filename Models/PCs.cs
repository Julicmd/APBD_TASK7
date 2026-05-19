namespace APBDTask9.Models;

public class PCs
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public IEnumerable<PCComponets> PcComponets { get; set; } = [];
}