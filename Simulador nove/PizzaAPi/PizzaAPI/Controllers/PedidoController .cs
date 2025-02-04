using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Repository;
using PizzaAPI.Context;




using PizzaAPI.Request;

namespace MinhaPrimeiraAPI.controller
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IPizzaRepository pizzaRepository;

        public PedidoController(IPedidoRepository pedidoRepository, IPizzaRepository pizzaRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.pizzaRepository = pizzaRepository;
        }

        // CRUD de pedidos

        // POST api/pedido
        [HttpPost]
        public IActionResult Add([FromBody] PedidoRequest pedidoRequest)
        {
            var pedido = pedidoRepository.Add(pedidoRequest);
            return Ok(pedido);
        }

        // PUT api/pedido/{id}
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] PedidoRequest pedidoRequest)
        {
            var pedido = pedidoRepository.Update(id, pedidoRequest);
            return pedido == null ? NotFound() : Ok(pedido);
        }

        // GET api/pedido
        [HttpGet]
        public IActionResult GetAll()
        {
            var pedidos = pedidoRepository.GetAll();
            return Ok(pedidos);
        }

        // GET api/pedido/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var pedido = pedidoRepository.Get(id);
            return pedido == null ? NotFound() : Ok(pedido);
        }

        // DELETE api/pedido/{id}
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            pedidoRepository.Delete(id);
            return Ok();
        }

        // POST api/pedido/calcular-tempo
        [HttpPost("calcular-tempo")]
        public async Task<IActionResult> CalcularTempo([FromBody] PedidoRequest pedidoRequest)
        {
            int tempoTotal = 0;

            // Loop para calcular o tempo total
            foreach (var pizzaId in pedidoRequest.PizzasIds)
            {
                var pizza = await pizzaRepository.Get(pizzaId); // Usar 'await' para esperar o resultado da Task
                if (pizza == null)
                    return BadRequest($"Pizza com ID {pizzaId} não encontrada.");

                tempoTotal += pizza.TempoDePreparo; // Acessando a propriedade 'TempoDePreparo'
            }

            return Ok(new { TempoTotal = tempoTotal });
        }

    }
}
