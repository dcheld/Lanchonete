using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Dominio.Servico
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
            var itens = new List<Ingrediente>()
            {
                IngredienteFactory.Bacon(),
                IngredienteFactory.HamburgerCarne(),
                IngredienteFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XBacon, "X-Bacon", itens);
        }
        
        public static Lanche XBurger()
        {
            var itens = new List<Ingrediente>()
            {
                IngredienteFactory.HamburgerCarne(),
                IngredienteFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XBacon, "X-Burger", itens);
        }

        public static Lanche XEgg()
        {
            var itens = new List<Ingrediente>()
            {
                IngredienteFactory.Ovo(),
                IngredienteFactory.HamburgerCarne(),
                IngredienteFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XBacon, "X-Egg", itens);
        }

        public static Lanche XEggBacon()
        {
            var itens = new List<Ingrediente>()
            {
                IngredienteFactory.Bacon(),
                IngredienteFactory.Ovo(),
                IngredienteFactory.HamburgerCarne(),
                IngredienteFactory.Queijo(),
            };

            return new Lanche((int)LanchesEnum.XBacon, "X-Egg Bacon", itens);
        }
    }
}
