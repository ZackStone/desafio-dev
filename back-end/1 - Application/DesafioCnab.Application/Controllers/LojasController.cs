using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioCnab.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LojasController : ControllerBase
{
    protected readonly ILojaService _lojaService;

    public LojasController(ILojaService lojaService)
    {
        _lojaService = lojaService;
    }

    [HttpGet("")]
    public async Task<ActionResult<string[]>> GetLojas() => new ObjectResult(await _lojaService.GetLojas());
}