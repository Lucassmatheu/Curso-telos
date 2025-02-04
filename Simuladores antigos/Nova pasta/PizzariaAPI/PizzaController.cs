using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.Models;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requer autenticação JWT
    public class PizzaController : ControllerBase
    {
        private readonly PizzariaContext _context;

        public PizzaController(PizzariaContext context)
        {
            _context = context;
        }

        // GET: api/Pizza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        // GET: api/Pizza/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return NotFound();

            return pizza;
        }

        // POST: api/Pizza
        [HttpPost]
        [Authorize(Roles = "cozinheiro")] // Apenas "cozinheiro" pode adicionar pizzas
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizza", new { id = pizza.Id }, pizza);
        }

        // PUT: api/Pizza/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "cozinheiro")] // Apenas "cozinheiro" pode atualizar pizzas
        public async Task<IActionResult> PutPizza(int id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pizzas.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Pizza/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "cozinheiro")] // Apenas "cozinheiro" pode excluir pizzas
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return NotFound();

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Pizza/calcular-pedido
        [HttpPost("calcular-pedido")]
        public async Task<ActionResult<int>> CalcularPedido([FromBody] List<int> ids)
        {
            var pizzas = await _context.Pizzas.Where(p => ids.Contains(p.Id)).ToListAsync();

            if (pizzas.Count != ids.Count)
                return BadRequest("Um dos sabores do pedido está em falta.");

            var tempoTotal = pizzas.Sum(p => p.TempoPreparo);
            return Ok(tempoTotal);
        }
    }
}
