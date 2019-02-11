using System.Collections.Generic;

namespace Pedido.Dominio.Factory
{
    public class LancheItemFactory
    {
        public enum IngredienteEnum
        {
            Alface = 1,
            Bacon,
            HamburgerCarne,
            Ovo,
            Queijo
        }

        public static LancheItem Alface(int quantidade = 1)
        {
            return new LancheItem((int)IngredienteEnum.Alface, "Alface", 0.40m, quantidade);
        }

        public static LancheItem Bacon(int quantidade = 1)
        {
            return new LancheItem((int)IngredienteEnum.Bacon, "Bacon", 2.00m, quantidade);
        }

        public static LancheItem HamburgerCarne(int quantidade = 1)
        {
            return new LancheItem((int)IngredienteEnum.HamburgerCarne, "Hamburger de carne", 3.00m, quantidade);
        }

        public static LancheItem Ovo(int quantidade = 1)
        {
            return new LancheItem((int)IngredienteEnum.Ovo, "Ovo", 0.80m, quantidade);
        }

        public static LancheItem Queijo(int quantidade = 1)
        {
            return new LancheItem((int)IngredienteEnum.Queijo, "Queijo", 1.50m, quantidade);
        }

        public static IList<LancheItem> Todos()
             => new List<LancheItem>
             {
                 Alface(),
                 Bacon(),
                 HamburgerCarne(),
                 Ovo(),
                 Queijo(),
             };
    }
}