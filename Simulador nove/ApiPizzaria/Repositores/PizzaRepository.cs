using ApiPizzaria.Context;
using ApiPizzaria.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiPizzaria.Repositores
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzariaContext _context;

        public PizzaRepository(PizzariaContext context) // Injeta o contexto no repositório
        {
            _context = context;
        }

        public Pizza Add(PizzaRequest pizzaRequest)
        {
            var pizza = new Pizza
            {
                Sabor = pizzaRequest.Sabor,
                TempoPreparo = pizzaRequest.TempoPreparo
            };

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
            return pizza;
        }

        public List<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza? GetById(int id)
        {
            return _context.Pizzas.Find(id);
        }

        public List<Pizza> GetByName(string nome)
        {
            return _context.Pizzas
                .Where(p => p.Sabor.Contains(nome))
                .ToList();
        }

        public Pizza? Update(int id, PizzaRequest pizzaRequest)
        {
            var existingPizza = _context.Pizzas.Find(id);
            if (existingPizza != null)
            {
                existingPizza.Sabor = pizzaRequest.Sabor;
                existingPizza.TempoPreparo = pizzaRequest.TempoPreparo;

                _context.Pizzas.Update(existingPizza);
                _context.SaveChanges();
                return existingPizza;
            }
            return null;
        }

        public void Delete(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            if (pizza == null)
            {
                throw new KeyNotFoundException("Sabor de pizza não encontrado.");
            }

            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }
    }
}
