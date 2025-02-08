using Microsoft.AspNetCore.Mvc;
using ApiPizzaria.Service;
using ApiPizzaria.Modelos;
using System.Collections.Generic;
using ApiPizzaria.Modelo;

namespace ApiPizzaria.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        private readonly List<Pizza> _todasAsPizzas;

        public PedidoController()
        {
            _pedidoService = new PedidoService();

            // Simulando um banco de dados de pizzas (substitua pelo seu banco real)
            _todasAsPizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Sabor = "Calabresa", TempoPreparo = 20 },
                new Pizza { Id = 2, Sabor = "Mussarela", TempoPreparo = 15 },
                new Pizza { Id = 3, Sabor = "Frango com Catupiry", TempoPreparo = 25 }
            };
        }

        [HttpPost("solicitar")]
        public ActionResult<List<Pedido>> SolicitarPedidos([FromBody] List<PedidoRequest> pedidos)
        {
            var resposta = _pedidoService.SolicitarPedidos(pedidos, _todasAsPizzas);

            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }

    }
}
