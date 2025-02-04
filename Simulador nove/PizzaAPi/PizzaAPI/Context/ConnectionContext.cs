using Microsoft.EntityFrameworkCore;
using PizzaAPI.Modelos;



namespace PizzaAPI.Context
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        // Configuração do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               "Server=localhost\\SQLEXPRESS;" +
               "Database=PizzariaDB;" +
               "User Id=pizzaria_user;" +
               "Password=NovaSenhaSegura123!;" +
               "TrustServerCertificate=True;"
            );
        }
    }
}
