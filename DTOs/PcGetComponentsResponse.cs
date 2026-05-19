namespace APBDTask9.DTOs;

public class PcGetComponentsResponse
{
    public char Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ComponentTypeId { get; set; }
    public int ComponentManufactorId { get; set; }
    public int Amount { get; set; }
}