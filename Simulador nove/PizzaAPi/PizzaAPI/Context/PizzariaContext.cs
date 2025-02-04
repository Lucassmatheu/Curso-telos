using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Modelos;

namespace PizzaAPI.Context
{
    public class PizzariaContext : DbContext
    {
        public PizzariaContext(DbContextOptions<PizzariaContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<PedidosPizzas> PedidosPizzas { get; set; }

        // Unindo as duas definições do método OnModelCreating em uma única
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração das chaves primárias
            modelBuilder.Entity<User>().HasKey(u => u.Nome);
            modelBuilder.Entity<PedidosPizzas>().HasKey(pp => new { pp.PedidoId, pp.PizzaId });

            // Chamando a classe UserSeedData para popular os dados iniciais
            UserSeedData.SeedData(modelBuilder);
        }
    }
}
