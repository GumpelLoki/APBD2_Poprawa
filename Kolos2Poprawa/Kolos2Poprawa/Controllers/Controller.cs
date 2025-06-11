using Kolos2Poprawa.Exceptions;
using Kolos2Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2Poprawa.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Controller(IDbService _dbService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            //FIX THIS REMEBER
            //await _dbService.
            var result = 5;
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}