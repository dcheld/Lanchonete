using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pedido.Dominio;
using Pedido.Dominio.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pedido.API.Controllers
{
    [Route("api/[controller]")]
    public class LancheController : Controller
    {
        private readonly ILancheService lancheService;

        public LancheController(ILancheService lancheService)
        {
            this.lancheService = lancheService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Lanche> Get()
        {
            return lancheService.ObterLanches();
        }
    }
}
