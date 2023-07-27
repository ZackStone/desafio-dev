using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCnab.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TamanhosController : BaseController<Tamanho, IService<Tamanho>>
    {
        public TamanhosController(IService<Tamanho> service) : base(service) { }
    }
}