using APBDTask9.Data;
using APBDTask9.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBDTask9.Controllers;


[ApiController]
[Route("api/PCs")]
public class PcController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    
    public PcController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPCs()
    {
        var pcs = await _dbContext.PCs.ToListAsync();
        
        var response = pcs.Select(pc => new PcGetAllResponse
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,

        });
        
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPcCompopnentsById(int id)
    {
        var pc = await _dbContext.PCs.Include(pc => pc.PcComponets).ThenInclude(pcComponets => pcComponets.Component)
            .FirstOrDefaultAsync(pc=>pc.Id == id);
        
        if(pc == null)
            return  NotFound();

        var response = pc.PcComponets.Select(pcc =>
            new PcGetComponentsResponse
            {
                Code = pcc.Component.Code,
                Name = pcc.Component.Name,
                Description = pcc.Component.Description,
                ComponentTypeId = pcc.Component.ComponentTypeId,
                ComponentManufactorId = pcc.Component.ComponentManufactorId,
                Amount = pcc.ComponetAmount
            });
        
        return Ok(response);
    }
    
    
    
}