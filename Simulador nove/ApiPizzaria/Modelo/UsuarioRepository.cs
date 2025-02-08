using ApiPizzaria.Modelos;
using PizzaAPI.Modelos;

namespace ApiPizzaria.Modelo
{
    public static class UsuarioRepository
    {
        public static Usuario Get(string nome, string PasswordHash)
        {
            var usuarios = new List<Usuario>();
            usuarios.Add(new Usuario { Id = 1, Nome = "Lucass", PasswordHash = "Lucas", Role = "garçom" });
            usuarios.Add(new Usuario { Id = 2, Nome = "Lucas", PasswordHash = "Lucas", Role = "cozinheiro" });

            return usuarios.FirstOrDefault(x =>
                x.Nome == nome
                && x.PasswordHash == PasswordHash);
        }
    }
}