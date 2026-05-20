using APBDTask9.Data;
using APBDTask9.DTOs;
using APBDTask9.Models;
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

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPcCompopnentsById(int id)
    {
        var pc = await _dbContext.PCs.Include(pc => pc.PcComponets).ThenInclude(pcComponets => pcComponets.Component)
            .FirstOrDefaultAsync(pc=>pc.Id == id);

        if (pc == null)
            return NotFound();

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

    [HttpPost]
    public async Task<IActionResult> AddPc([FromBody] AddPcRequest request)
    {
        if (string.IsNullOrEmpty(request.Name))
            return BadRequest("Name is required");
        
        var pc = new PCs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock,
        };
        
        await _dbContext.AddAsync(pc);
        await _dbContext.SaveChangesAsync();


        var response = new PcGetAllResponse
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
        };
        
        return CreatedAtAction(nameof(GetPcCompopnentsById), new { id = pc.Id },response);

    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePc(int id)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null)
            return NotFound();

        _dbContext.PCs.Remove(pc);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePc([FromBody] UpdatePcRequest request,int id)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);
        
        if(pc == null)
            return NotFound();
        
        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;

        _dbContext.Update(pc);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
    
    
    
    
    
    
    
    
}