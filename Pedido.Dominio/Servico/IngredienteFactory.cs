using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Dominio.Servico
{
    public class IngredienteFactory
    {
        public enum IngredienteEnum
        {
            Alface = 1,
            Bacon,
            HamburgerCarne,
            Ovo,
            Queijo
        }

        public static Ingrediente Alface()
        {
            return new Ingrediente((int)IngredienteEnum.Alface, "Alface", 0.40m);
        }

        public static Ingrediente Bacon()
        {
            return new Ingrediente((int)IngredienteEnum.Bacon, "Bacon", 2.00m);
        }

        public static Ingrediente HamburgerCarne()
        {
            return new Ingrediente((int)IngredienteEnum.HamburgerCarne, "Hamburger de carne", 3.00m);
        }

        public static Ingrediente Ovo()
        {
            return new Ingrediente((int)IngredienteEnum.Ovo, "Ovo", 0.80m);
        }

        public static Ingrediente Queijo()
        {
            return new Ingrediente((int)IngredienteEnum.Queijo, "Queijo", 1.50m);
        }
    }
}
