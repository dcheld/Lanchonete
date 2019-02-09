﻿using Pedido.Dominio.Servico;
using Xunit;

namespace Pedido.Dominio.Teste
{
    public class PromocaoItemMuitoQueijoTest
    {
        private PromocaoItemMuitoQueijo promocao = new PromocaoItemMuitoQueijo();
       
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 1.5)]
        [InlineData(4, 1.5)]
        [InlineData(5, 1.5)]
        [InlineData(6, 3)]
        public void DescotoMuitaCarne(int quantidadeHamburgerCarne, decimal valorDesconto)
        {
            var pedido = ObterPedido(quantidadeHamburgerCarne);
            promocao.Calcular(pedido);
            Assert.Equal(valorDesconto, promocao.Desconto);
        }

        private Pedido ObterPedido(int quantidadeHamburgerCarne)
        {
            var pedido = new Pedido();
            pedido.Adicionar(IngredienteFactory.Queijo(), quantidadeHamburgerCarne);

            return pedido;
        }
    }
}