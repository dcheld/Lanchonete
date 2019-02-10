using Microsoft.AspNetCore.Mvc;
using Pedido.Dominio;
using Pedido.Dominio.Interface;
using System.Collections.Generic;

namespace Pedido.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancheController : Controller
    {
        private readonly ILancheService lancheService;

        public LancheController(ILancheService lancheService)
        {
            this.lancheService = lancheService;
        }

        [HttpGet]
        public IEnumerable<Lanche> Get()
        {
            return lancheService.ObterLanches();
        }

        [HttpGet("[action]")]
        public IEnumerable<LancheItem> Itens()
        {
            return lancheService.ObterLancheItem();
        }
    }
}