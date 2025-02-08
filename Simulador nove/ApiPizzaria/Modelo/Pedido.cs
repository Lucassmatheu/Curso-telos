using ApiPizzaria.Modelo;
using System;
using System.Collections.Generic;

namespace ApiPizzaria.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }  // Identificador único do pedido
        public DateTime DataHora { get; set; } = DateTime.Now;  // Data e hora do pedido
        public required string ClienteNome { get; set; }  // Nome do cliente
        public PedidoStatus Status { get; set; } = PedidoStatus.EmAndamento;  // Status do pedido (Ex: "Em andamento", "Finalizado", "Cancelado")
        public decimal Total { get; set; }  // Valor total do pedido

        // Relação com os itens do pedido (1 pedido pode ter vários itens)
        //public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}
