using System;
using System.Collections.Generic;
using System.Linq;
using ApiPizzaria.Modelo;
using ApiPizzaria.Modelos;

namespace ApiPizzaria.Service
{
    public class PedidoService
    {
        private static int _idPedidoAtual = 1; // Gerador simples de ID para pedidos
        private static List<Pedido> _pedidos = new List<Pedido>(); // Lista de pedidos feitos

        public int CalcularTempoEntrega(int distancia)
        {
            if (distancia <= 0)
                throw new ArgumentException("A distância deve ser maior que zero.");

            return distancia * 10; // Exemplo: 10 minutos por km
        }

        public (bool Sucesso, string Mensagem, List<Pedido> Pedidos) SolicitarPedidos(List<PedidoRequest> pedidosRequest, List<Pizza> todasAsPizzas)
        {
            var listaPedidos = new List<Pedido>();

            foreach (var pedidoRequest in pedidosRequest)
            {
                if (pedidoRequest.PizzaIds == null || !pedidoRequest.PizzaIds.Any())
                {
                    return (false, "O pedido deve conter pelo menos uma pizza.", null);
                }

                var pizzasSolicitadas = todasAsPizzas
                    .Where(pizza => pedidoRequest.PizzaIds.Contains(pizza.Id))
                    .ToList();

                if (pizzasSolicitadas.Count != pedidoRequest.PizzaIds.Count)
                {
                    return (false, "Uma ou mais pizzas não foram encontradas no cardápio.", null);
                }

                decimal totalPedido = pizzasSolicitadas.Sum(p => 30.0m); // Simulando preço fixo

                var novoPedido = new Pedido
                {
                    Id = _idPedidoAtual++,
                    ClienteNome = pedidoRequest.ClienteNome,
                    Status = PedidoStatus.EmAndamento,
                    Total = totalPedido
                };

                listaPedidos.Add(novoPedido);
            }

            return (true, "Pedidos realizados com sucesso!", listaPedidos);
        }


    }
}
