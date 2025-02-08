using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiPizzaria.Modelos;
using ApiPizzaria.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiPizzaria.Controllers
{
    [ApiController] // ✅ Corrigido: Agora está corretamente na classe principal
    [Route("api/pizzas")] // ✅ Corrigido: Aplica a rota na classe
    public class PizzasController : ControllerBase
    {
        // Injeção de dependência - banco de dados
        private readonly PizzariaContext _context;

        // Construtor da classe
        public PizzasController(PizzariaContext context)
        {
            _context = context;
        }

        // ✅ Endpoint para criar uma pizza
        [HttpPost("Criar")]
        [Authorize(Roles = "cozinheiro")]
        public ActionResult Add([FromBody] PizzaRequest pizzaRequest)
        {
            if (pizzaRequest == null || string.IsNullOrEmpty(pizzaRequest.Sabor))
            {
                return BadRequest("Os dados da pizza são obrigatórios.");
            }
            var pizza = new Pizza
            {
                Sabor = pizzaRequest.Sabor,
                TempoPreparo = pizzaRequest.TempoPreparo
            };
           

            _context.Pizzas.Add(pizza); 
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
        }

        // ✅ Endpoint para atualizar uma pizza
        [HttpPut("{id}")]
        [Authorize(Roles = "cozinheiro")]
        public ActionResult Update(int id, [FromBody] Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }
            _context.Entry(pizza).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // ✅ Retornar todas as pizzas
        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> GetPizzas()
        {
            return _context.Pizzas.ToList();
        }

        // ✅ Endpoint para buscar uma pizza específica pelo ID
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Pizza> GetPizza(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            if (pizza == null) return NotFound();
            return pizza;
        }

        // ✅ Endpoint para deletar uma pizza
        [HttpDelete("{id}")]
        [Authorize(Roles = "cozinheiro")]
        public ActionResult DeletePizza(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            if (pizza == null) return NotFound();
            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
            return NoContent();
        }

        // ✅ Endpoint para calcular o tempo do pedido
        [HttpPost("pedido")]
        [Authorize]
        public ActionResult CalcularTempoPedido([FromBody] List<string> sabores)
        {
            if (sabores == null || !sabores.Any())
            {
                return BadRequest("A lista de sabores não pode estar vazia.");
            }

            // Verificar se todos os sabores existem no banco de dados
            var pizzasEncontradas = _context.Pizzas.Where(p => sabores.Contains(p.Sabor)).ToList();

            if (pizzasEncontradas.Count != sabores.Count)
            {
                return BadRequest("Um ou mais sabores do pedido estão em falta.");
            }

            // Calcular o tempo total de preparo
            var tempoTotal = pizzasEncontradas.Sum(p => p.TempoPreparo);

            return Ok(new
            {
                Mensagem = "Pedido processado com sucesso.",
                TempoTotalPreparo = tempoTotal
            });
        }
    }
}
