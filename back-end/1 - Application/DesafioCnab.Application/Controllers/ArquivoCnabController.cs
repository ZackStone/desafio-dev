using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioCnab.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArquivoCnabController : ControllerBase
{
    protected readonly ILogger<ArquivoCnabController> _logger;
    protected readonly ICnabFileService _fileService;

    public ArquivoCnabController(ILogger<ArquivoCnabController> logger, ICnabFileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
    }

    [HttpPost("upload")]
    public async Task<ActionResult<Transacao>> UploadFile([FromForm] IFormFile formFile)
    {
        try
        {
            using var stream = formFile.OpenReadStream();
            var result = await _fileService.ProcessarArquivo(stream);
            return new ObjectResult(result);
        }
        catch (ValidationException ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}