using PizzaAPI.Modelos;

namespace PizzaAPI.Modelos
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public List<PedidosPizzas> Itens { get; set; }
    }
}
