namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Ships;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class ShipsController : ControllerBase
{
    private IShipService _shipService;

    public ShipsController(IShipService shipService)
    {
        _shipService = shipService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ships = await _shipService.GetAll();
        return Ok(ships);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ship = await _shipService.GetById(id);
        return Ok(ship);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRequest model)
    {
        await _shipService.Create(model);
        return Ok(new { message = "Ship created successfully" });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest model)
    {
        await _shipService.Update(id, model);
        return Ok(new { message = "Ship updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _shipService.Delete(id);
        return Ok(new { message = "Ship deleted successfully" });
    }
}