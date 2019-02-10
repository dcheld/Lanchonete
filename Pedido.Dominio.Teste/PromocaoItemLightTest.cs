using Pedido.Dominio.Fabrica;
using Pedido.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pedido.Dominio.Teste
{
    public class PromocaoItemLightTest
    {
        private PromocaoItemLight promocao = new PromocaoItemLight();

        public PromocaoItemLightTest()
        {
        }

        [Fact]
        public void Desconto10PorCento()
        {
            var pedido = ObterPedido(1, 0);
            Assert.NotEqual(0, pedido.Desconto);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        public void SemDescontoQuandoNaoTemAlfaceOuTemBacon(int quantidadeAlface, int quantidadeBacon)
        {
            var pedido = ObterPedido(quantidadeAlface, quantidadeBacon);
           
            Assert.Equal(0, pedido.Desconto);
        }

        private Pedido ObterPedido(int quantidadeAlface, int quantidadeBacon)
        {
            var pedido = new Pedido();
            pedido.Adicionar(LancheItemFactory.Alface(quantidadeAlface));
            pedido.Adicionar(LancheItemFactory.Bacon(quantidadeBacon));
            pedido.Adicionar(LancheItemFactory.HamburgerCarne(1));
            pedido.Adicionar(LancheItemFactory.Queijo(1));
            promocao.Registrar(pedido);
            pedido.Calcular();

            return pedido;
        }
    }
}
