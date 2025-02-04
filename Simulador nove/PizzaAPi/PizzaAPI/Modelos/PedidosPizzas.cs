using PizzaAPI.Modelos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaAPI.Modelos
{
    public class PedidosPizzas
    {
        [Key] // ✅ Define o Id como chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public Pedidos Pedido { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
