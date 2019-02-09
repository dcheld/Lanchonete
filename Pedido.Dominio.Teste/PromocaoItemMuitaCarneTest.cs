using Pedido.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pedido.Dominio.Teste
{
    public class PromocaoItemMuitaCarneTest
    {
        private PromocaoItemMuitaCarne promocao = new PromocaoItemMuitaCarne();

        public PromocaoItemMuitaCarneTest()
        {
        }

       
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 3)]
        [InlineData(4, 3)]
        [InlineData(5, 3)]
        [InlineData(6, 6)]
        public void DescotoMuitaCarne(int quantidadeHamburgerCarne, decimal valorDesconto)
        {
            var pedido = ObterPedido(quantidadeHamburgerCarne);
            promocao.Calcular(pedido);
            Assert.Equal(valorDesconto, promocao.Desconto);
        }

        private Pedido ObterPedido(int quantidadeHamburgerCarne)
        {
            var pedido = new Pedido();
            pedido.Adicionar(IngredienteFactory.HamburgerCarne(), quantidadeHamburgerCarne);

            return pedido;
        }
    }
}
