using Kolos2Poprawa.Exceptions;
using Kolos2Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2Poprawa.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharactersController(IDbService _dbService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            //FIX THIS REMEBER
            //
            var result = await _dbService.GetCharacterItems(id);
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