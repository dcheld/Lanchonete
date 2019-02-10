using System.Collections.Generic;

namespace Pedido.Dominio.Fabrica
{
    public static class LancheFactory
    {
        public enum LanchesEnum
        {
            XBacon = 1,
            XBurger,
            XEgg,
            XEggBacon,
        }

        public static Lanche XBacon()
        {
            var itens = new List<LancheItem>()
            {
                LancheItemFactory.Bacon(),
                LancheItemFactory.HamburgerCarne(),
                LancheItemFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XBacon, "X-Bacon", itens);
        }

        public static Lanche XBurger()
        {
            var itens = new List<LancheItem>()
            {
                LancheItemFactory.HamburgerCarne(),
                LancheItemFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XBurger, "X-Burger", itens);
        }

        public static Lanche XEgg()
        {
            var itens = new List<LancheItem>()
            {
                LancheItemFactory.Ovo(),
                LancheItemFactory.HamburgerCarne(),
                LancheItemFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XEgg, "X-Egg", itens);
        }

        public static Lanche XEggBacon()
        {
            var itens = new List<LancheItem>()
            {
                LancheItemFactory.Bacon(),
                LancheItemFactory.Ovo(),
                LancheItemFactory.HamburgerCarne(),
                LancheItemFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XEggBacon, "X-Egg Bacon", itens);
        }
    }
}