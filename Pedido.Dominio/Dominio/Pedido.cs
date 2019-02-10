using Pedido.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pedido.Dominio
{
    public class Pedido
    {
        public int Id { get; private set; }
        public decimal Itens { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal Total { get; private set; }
        public Inflacao inflacao;

        private IList<IPromocaoItem> PromocaoItems { get; set; } = new List<IPromocaoItem>();

        private IList<LancheItem> _pedidoItems = new List<LancheItem>();
        public IReadOnlyList<LancheItem> PedidoItens => new ReadOnlyCollection<LancheItem>(_pedidoItems);

        public Pedido()
        {
            Random random = new Random();
            Id = random.Next();
        }

        public Pedido(Lanche lanche) : this()
        {
            foreach (var lancheItem in lanche.LancheItens)
                Adicionar(lancheItem);
        }

        public void Adicionar(Ingrediente ingrediente, int quantidade)
        {
            if (quantidade > 0)
                Adicionar(new LancheItem(ingrediente, quantidade));
        }

        public void Adicionar(LancheItem pedidoItem)
        {
            if (pedidoItem.Quantidade <= 0)
                return;

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

        public void Remover(LancheItem item)
        {
            var pedidoItemExitente = _pedidoItems.FirstOrDefault(f => f.Ingrediente.Id == item.Ingrediente.Id);
            if (pedidoItemExitente != null)
                pedidoItemExitente.Remover(item.Quantidade);
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
            Itens = 0;
            foreach (var item in _pedidoItems)
            {
                item.Calcular();
                Itens += item.Valor;
            }
        }

        private void CalcularDesconto()
        {
            Desconto = 0;
            foreach (var promocaoItem in PromocaoItems)
            {
                promocaoItem.Calcular();
                Desconto += promocaoItem.Desconto;
            }
        }

        private void CalcularTotal()
        {
            Total = Itens - Desconto;
            if (inflacao != null)
                Total += inflacao.Valor;
        }

        public void Aplicar(Inflacao inflacao)
        {
            this.inflacao = inflacao;
            inflacao?.Calcular(this);
        }

        #endregion Calculos
    }
}