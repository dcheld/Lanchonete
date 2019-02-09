using Pedido.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pedido.Dominio
{
    public class Pedido
    {
        public decimal ValorItem { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public decimal Valor { get; private set; }
        public Inflacao inflacao;
        
        private IList<IPromocaoItem> PromocaoItems { get; set; } = new List<IPromocaoItem>();

        private IList<PedidoItem> _pedidoItems = new List<PedidoItem>();
        public IReadOnlyList<PedidoItem> PedidoItens => new ReadOnlyCollection<PedidoItem>(_pedidoItems);


        public Pedido()
        {

        }

        public Pedido(Lanche lanche)
        {
            foreach (var ingrediente in lanche.Ingredientes)
                Adicionar(new PedidoItem(ingrediente));
        }

        public void Adicionar(Ingrediente ingrediente, int quantidade)
        {
            if(quantidade > 0)
                Adicionar(new PedidoItem(ingrediente, quantidade));
        }

        public void Adicionar(PedidoItem pedidoItem)
        {
            var pedidoItemExitente = _pedidoItems.FirstOrDefault(f => f.Ingrediente.Id == pedidoItem.Ingrediente.Id);
            if (pedidoItemExitente != null)
                pedidoItemExitente.Adicionar(pedidoItem.Quantidade);
            else
                _pedidoItems.Add(pedidoItem);
        }

        internal void AdicionarPromocao(IPromocaoItem promocaoItem)
        {
            if (promocaoItem != null && !PromocaoItems.Any(a => a.IdPromocao == promocaoItem.IdPromocao))
                PromocaoItems.Add(promocaoItem);
        }

        public void Remover (Ingrediente ingrediente, int quantidade)
        {
            var pedidoItemExitente = _pedidoItems.FirstOrDefault(f => f.Ingrediente.Id == ingrediente.Id);
            if (pedidoItemExitente != null)
                pedidoItemExitente.Remover(quantidade);
        }



        #region Calculos
        public void Calcular()
        {
            CalcularItem();
            CalcularDesconto();
            CalcularTotal();
        }

        private void CalcularItem()
        {
            ValorItem = 0;
            foreach (var item in _pedidoItems)
            {
                item.Calcular();
                ValorItem += item.Valor;
            }
        }

        private void CalcularDesconto()
        {
            ValorDesconto = 0;
            foreach (var promocao in PromocaoItems)
            {
                promocao.Calcular(this);
                ValorDesconto = promocao.Desconto;
            }
        }

        private void CalcularTotal()
        {
            Valor = ValorItem - ValorDesconto;
            if (inflacao != null)
                Valor += inflacao.Valor;
        }

        public void Aplicar(Inflacao inflacao)
        {
            this.inflacao = inflacao;
            inflacao.Calcular(this);
        }
        #endregion
    }
}
