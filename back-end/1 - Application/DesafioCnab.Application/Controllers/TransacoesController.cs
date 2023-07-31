using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioCnab.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransacoesController : ControllerBase
{
    protected readonly ITransacoesService _transacoesService;

    public TransacoesController(ITransacoesService transacoesService)
    {
        _transacoesService = transacoesService;
    }

    [HttpGet("")]
    public async Task<ActionResult<Transacao[]>> GetTransacoesPorLoja(string nomeLoja) => 
        new ObjectResult(await _transacoesService.GetTransacoesPorLoja(nomeLoja));
}