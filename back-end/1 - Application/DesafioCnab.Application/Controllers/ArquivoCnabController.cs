using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioCnab.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArquivoCnabController : ControllerBase
{
    protected readonly ICnabFileService _fileService;

    public ArquivoCnabController(ICnabFileService fileService)
    {
        _fileService = fileService;
    }
    
    [HttpPost("upload")]
    public async Task<ActionResult<Transacao>> UploadFile([FromForm]IFormFile formFile)
    {
        using var stream = formFile.OpenReadStream();
        var result = await _fileService.ProcessarArquivo(stream);
        return new ObjectResult(result);
    }
}