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
            promocao.Calcular(pedido);
            Assert.NotEqual(0, promocao.Desconto);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        public void SemDescontoQuandoNaoTemAlfaceOuTemBacon(int quantidadeAlface, int quantidadeBacon)
        {
            var pedido = ObterPedido(quantidadeAlface, quantidadeBacon);
            promocao.Calcular(pedido);
            Assert.Equal(0, promocao.Desconto);
        }

        private Pedido ObterPedido(int quantidadeAlface, int quantidadeBacon)
        {
            var pedido = new Pedido();
            pedido.Adicionar(IngredienteFactory.Alface(), quantidadeAlface);
            pedido.Adicionar(IngredienteFactory.Bacon(), quantidadeBacon);
            pedido.Adicionar(IngredienteFactory.HamburgerCarne(), 1);
            pedido.Adicionar(IngredienteFactory.Queijo(), 1);
            pedido.Calcular();

            return pedido;
        }
    }
}
