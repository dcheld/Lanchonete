using Pedido.API.Model;
using Pedido.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Pedido.API.Fabrica
{
    public static class LancheFactory
    {
        public static Lanche Criar(LancheViewModel lancheModel)
        {
            return new Lanche(lancheModel.Id, lancheModel.Nome, LancheItemFactory.Criar(lancheModel.LancheItens));
        }
    }

    public static class LancheItemFactory
    {
        public static LancheItem Criar(LancheItemViewModel lancheItemModel)
        {
            return new LancheItem(IngredienteFactory.Criar(lancheItemModel.Ingrediente), lancheItemModel.Quantidade);
        }

        public static IList<LancheItem> Criar(IList<LancheItemViewModel> lancheItemModel)
        {
            return lancheItemModel.Select(s => Criar(s)).ToList();
        }
    }

    public static class IngredienteFactory
    {
        public static Ingrediente Criar(IngredienteViewModel ingredienteModel)
        {
            return new Ingrediente(ingredienteModel.Id, ingredienteModel.Nome, ingredienteModel.Valor);
        }
    }
}