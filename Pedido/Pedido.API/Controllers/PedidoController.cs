using Microsoft.AspNetCore.Mvc;
using Pedido.API.Factory;
using Pedido.API.Model;
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
            return pedidoService.ObterPedidos();
        }

        [HttpPost]
        public void Post([FromBody] LancheViewModel lancheModel)
        {
            var lanche = LancheFactory.Criar(lancheModel);
            pedidoService.FecharPedido(new Dominio.Pedido(lanche), null);
        }
    }
}