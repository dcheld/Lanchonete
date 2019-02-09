using System;
using System.Linq;
using Pedido.Dominio.Dominio;
using Pedido.Dominio.Interface;

namespace Pedido.Dominio.Servico
{
    public class PromocaoItemLight : IPromocaoItem
    {
        public int IdPromocao => 1;
        private Pedido pedido;

        private decimal Percentual = 0.1m;
        public decimal Desconto { get; private set; }

        public void Calcular(Pedido pedido)
        {
            this.pedido = pedido;
            if(TemAlface() && !TemBacon())
            {
                Desconto = pedido.ValorItem * Percentual;
                pedido.AdicionarPromocao(this);
            }
        }

        private bool TemAlface()
        {
            int idIngredienteAlface = (int)IngredienteEnum.Alface;
            return pedido.PedidoItens.Any(item => item.Ingrediente.Id == idIngredienteAlface);
        }
        
        private bool TemBacon()
        {
            int idIngredienteBacon = (int)IngredienteEnum.Bacon;
            return pedido.PedidoItens.Any(item => item.Ingrediente.Id == idIngredienteBacon);
        }
    }
}