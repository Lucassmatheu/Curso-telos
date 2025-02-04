using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private static List<Pedidos> pedidos = new List<Pedidos>();
        private static int proximoId = 1;

        // Criar um novo pedido
        [HttpPost]
        public IActionResult CriarPedido([FromBody] Pedidos novoPedido)
        {
            if (novoPedido == null || novoPedido.Pizzas.Count == 0)
                return BadRequest("O pedido deve conter pelo menos uma pizza.");

            novoPedido.Id = proximoId++;
            novoPedido.Total = novoPedido.Pizzas.Sum(p => p.TempoPreparo * 2); // Simulação de preço
            pedidos.Add(novoPedido);

            return CreatedAtAction(nameof(ObterPedidoPorId), new { id = novoPedido.Id }, novoPedido);
        }

        // Obter um pedido específico
        [HttpGet("{id}")]
        public IActionResult ObterPedidoPorId(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound("Pedido não encontrado.");
            return Ok(pedido);
        }

        // Listar todos os pedidos
        [HttpGet]
        public IActionResult ListarPedidos()
        {
            return Ok(pedidos);
        }

        // ✅ Atualizar status do pedido (PUT /api/Pedido/{id}/status)
        [HttpPut("{id}/status")]
        public IActionResult AtualizarStatusPedido(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound("Pedido não encontrado.");

            // Avançar para o próximo status
            if (pedido.Status != StatusPedido.Entregue)
            {
                pedido.Status++;
                return Ok(pedido);
            }

            return BadRequest("O pedido já está no status final.");
        }
    }
}
