namespace PizzariaAPI.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public decimal Total { get; set; }
        public StatusPedido Status { get; set; } = StatusPedido.Recebido;
    }
}

