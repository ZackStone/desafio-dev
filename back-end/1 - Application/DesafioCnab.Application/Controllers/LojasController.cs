using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioCnab.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LojasController : ControllerBase
{
    protected readonly ILogger<LojasController> _logger;
    protected readonly ILojaService _lojaService;

    public LojasController(ILogger<LojasController> logger, ILojaService lojaService)
    {
        _logger = logger;
        _lojaService = lojaService;
    }

    [HttpGet("")]
    public async Task<ActionResult<string[]>> GetLojas()
    {
        try
        {
            return new ObjectResult(await _lojaService.GetLojas());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}