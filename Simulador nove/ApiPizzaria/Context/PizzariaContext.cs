using ApiPizzaria.Modelos; // Para acessar classes como Usuario, Pizza, Pedido, etc.
using ApiPizzaria.Context; // Para acessar PizzariaContext
using Microsoft.AspNetCore.Authorization; // Para usar [Authorize]
using Microsoft.EntityFrameworkCore; // Para usar DbContext
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;


namespace ApiPizzaria.Context

{
    public class PizzariaContext : DbContext
    {
        public PizzariaContext(DbContextOptions<PizzariaContext> options) : base(options) { }

        // Definição das DbSets
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidosPizzas> PedidosPizzas { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<Pizza>()
         //.Property(p => p.Preco)
         //.HasDefaultValue(0); // Define 0 como valor padrão

            modelBuilder.Entity<Pizza>()
                .Property(p => p.TempoPreparo)
                .HasColumnType("int");

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Total)
                .HasColumnType("decimal(10,2)");

            base.OnModelCreating(modelBuilder);
        }

        // Configuração do modelo e das chaves primárias
        // Configuração do modelo e das chaves primárias
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Definir que UserLoginDto não é uma entidade do banco de dados
        //    modelBuilder.Entity<Usuario>().HasNoKey();

        //    // Outras configurações
        //    modelBuilder.Entity<Pizza>().ToTable("Pizzas");
        //    modelBuilder.Entity<Pizza>().HasKey(p => p.Id);
        //    modelBuilder.Entity<Pizza>().Property(p => p.Sabor).IsRequired();
        //    modelBuilder.Entity<Pizza>().Property(p => p.TempoDePreparo).IsRequired();

        //    modelBuilder.Entity<PedidosPizzas>().HasKey(pp => new { pp.PedidoId, pp.PizzaId });
        //}

    }
}
