using DesafioCnab.Domain.DTO;
using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioCnab.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransacoesController : ControllerBase
{
    protected readonly ILogger<TransacoesController> _logger;
    protected readonly ITransacoesService _transacoesService;

    public TransacoesController(ILogger<TransacoesController> logger, ITransacoesService transacoesService)
    {
        _transacoesService = transacoesService;
        _logger = logger;
    }

    [HttpGet("")]
    public async Task<ActionResult<TransacoesPorLojaDto>> GetTransacoesPorLoja(string nomeLoja)
    {
        try
        {
            return new ObjectResult(await _transacoesService.GetTransacoesPorLoja(nomeLoja));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}