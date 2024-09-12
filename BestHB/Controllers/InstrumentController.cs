using BestHB.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BestHB.Controllers;

[Route("api/instrument")]
public class InstrumentController(IRepository instrumentInfoRepository) : Controller
{
    [HttpGet]
    [Route("{symbol}")]
    public async Task<IActionResult> Get([FromRoute] string symbol)
    {
        try
        {
            return Ok(await instrumentInfoRepository.Get(symbol));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}