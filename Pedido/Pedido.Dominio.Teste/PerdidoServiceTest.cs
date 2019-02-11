using NSubstitute;
using Pedido.Dominio.Fabrica;
using Pedido.Dominio.Interface;
using Pedido.Dominio.Service;
using System.Collections.Generic;
using Xunit;

namespace Pedido.Dominio.Teste
{
    public class PerdidoServiceTest
    {
        private IPromocaoCalculadora promocaoCalculadora = Substitute.For<IPromocaoCalculadora>();
        private Inflacao inflacao = Substitute.For<Inflacao>();
        private Lanche lanche;

        public PerdidoServiceTest()
        {
            lanche = new Lanche(1000, "meu lanche", new List<LancheItem>()
            {
                LancheItemFactory.Alface(),
                LancheItemFactory.Bacon(),
                LancheItemFactory.HamburgerCarne(),
            });
        }

        [Fact]
        public void FecharPedido()
        {
            var pedidoService = new PedidoService(promocaoCalculadora);
            var pedido = new Pedido(lanche);

            pedidoService.FecharPedido(pedido, inflacao);
            Assert.Equal(5.4m, pedido.Total);
        }

        [Theory]
        [InlineData(8.40, 1)]
        [InlineData(11.40, 2)]
        public void AdicionarIngrediente(decimal valor, int quantidadeHamburgerCarne)
        {
            var pedidoService = new PedidoService(promocaoCalculadora);
            var pedido = new Pedido(lanche);

            pedido.Adicionar(LancheItemFactory.HamburgerCarne(quantidadeHamburgerCarne));
            pedidoService.FecharPedido(pedido, inflacao);
            Assert.Equal(valor, pedido.Total);
        }

        [Theory]
        [InlineData(11.4, 1)]
        [InlineData(8.4, 2)]
        [InlineData(5.4, 3)]
        [InlineData(2.4, 4)]
        [InlineData(2.4, 5)]
        [InlineData(2.4, 10)]
        public void RemoverIngrediente(decimal valor, int quantidadeHamburgerCarneRemover)
        {
            var pedidoService = new PedidoService(promocaoCalculadora);
            var pedido = new Pedido(lanche);

            pedido.Adicionar(LancheItemFactory.HamburgerCarne(3));
            pedidoService.FecharPedido(pedido, inflacao);
            Assert.Equal(14.4M, pedido.Total);

            pedido.Remover(LancheItemFactory.HamburgerCarne(quantidadeHamburgerCarneRemover));
            pedidoService.FecharPedido(pedido, inflacao);
            Assert.Equal(valor, pedido.Total);
        }
    }
}