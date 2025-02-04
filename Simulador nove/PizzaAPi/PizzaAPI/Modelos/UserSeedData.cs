using Microsoft.EntityFrameworkCore;
using PizzaAPI.Modelos;

namespace PizzaAPI.Data
{
    public static class UserSeedData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Nome);
            
            // Criando usuários com 'Role'
            modelBuilder.Entity<User>().HasData(
                new User { Nome = "cozinheiro", Password = "senhaCozinheiro123", Role = "Cozinheiro" },
                new User { Nome = "garcom", Password = "senhaGarcom123", Role = "Garçom" }
            );
        }
    }
}
