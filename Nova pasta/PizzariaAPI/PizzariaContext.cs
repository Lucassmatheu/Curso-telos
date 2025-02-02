using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data
{
    public class PizzariaContext : DbContext
    {
        public PizzariaContext(DbContextOptions<PizzariaContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
    }
}
