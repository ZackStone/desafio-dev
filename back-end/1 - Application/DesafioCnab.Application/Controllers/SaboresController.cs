using DesafioCnab.Domain.Entities;
using DesafioCnab.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCnab.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaboresController : BaseController<Sabor, IService<Sabor>>
    {
        public SaboresController(IService<Sabor> service) : base(service) { }
    }
}