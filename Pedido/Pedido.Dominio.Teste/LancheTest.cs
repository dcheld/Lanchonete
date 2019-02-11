using Pedido.Dominio.Factory;
using Xunit;

namespace Pedido.Dominio.Teste
{
    public class LancheTest
    {
        [Fact]
        public void XBacon()
        {
            var lanche = LancheFactory.XBacon();
            var pedido = new Pedido(lanche);
            pedido.Calcular();
            Assert.Equal(6.50m, pedido.Total);
        }

        [Fact]
        public void XBurger()
        {
            var lanche = LancheFactory.XBurger();
            var pedido = new Pedido(lanche);
            pedido.Calcular();
            Assert.Equal(4.50m, pedido.Total);
        }

        [Fact]
        public void XEgg()
        {
            var lanche = LancheFactory.XEgg();
            var pedido = new Pedido(lanche);
            pedido.Calcular();
            Assert.Equal(5.30m, pedido.Total);
        }

        [Fact]
        public void XEggBacon()
        {
            var lanche = LancheFactory.XEggBacon();
            var pedido = new Pedido(lanche);
            pedido.Calcular();
            Assert.Equal(7.30m, pedido.Total);
        }
    }
}