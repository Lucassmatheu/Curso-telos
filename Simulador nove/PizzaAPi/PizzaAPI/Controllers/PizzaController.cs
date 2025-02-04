using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Context;


using PizzaAPI.Modelos;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // 🔹 Garante que apenas usuários autenticados podem acessar
    public class PizzaController : ControllerBase
    {
        private readonly PizzariaContext _context;

        public PizzaController(PizzariaContext context)
        {
            _context = context;
        }

        // ✅ Permitir que o garçom veja os sabores de pizza sem erro 401
        [HttpGet]
        [AllowAnonymous] // 🔹 Remove autenticação para qualquer usuário ver a lista de pizzas
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
         
            try
            {
                var pizzas = await _context.Pizzas.ToListAsync();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor: " + ex.Message);
            }
            return await _context.Pizzas.ToListAsync();
        }

        // ✅ Permitir que apenas o cozinheiro gerencie pizzas
        [HttpPost]
        [Authorize(Roles = "cozinheiro")] // 🔹 Apenas o cozinheiro pode criar pizzas
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPizzas), new { id = pizza.Id }, pizza);
        }
        
    }
}
