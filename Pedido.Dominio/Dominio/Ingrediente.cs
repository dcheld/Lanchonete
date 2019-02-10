namespace Pedido.Dominio
{
    public class Ingrediente
    {
        public Ingrediente(int id, string nome, decimal valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
    }
}