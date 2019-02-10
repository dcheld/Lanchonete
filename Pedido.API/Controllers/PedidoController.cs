using Microsoft.AspNetCore.Mvc;
using Pedido.Dominio;
using Pedido.Dominio.Interface;
using System.Collections.Generic;

namespace Pedido.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedidoService pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        [HttpGet]
        public IEnumerable<Dominio.Pedido> Get()
        {
            //return pedidoService.ObterLanches();
            return null;
        }

        [HttpPost]
        public void Post([FromBody] string lanche)
        {
            //pedidoService.FecharPedido(new Dominio.Pedido(lanche), null);
        }
    }
}