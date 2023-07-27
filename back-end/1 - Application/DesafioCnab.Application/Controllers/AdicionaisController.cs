using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCnab.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionaisController : BaseController<Adicional, IService<Adicional>>
    {
        public AdicionaisController(IService<Adicional> service) : base(service) { }
    }
}