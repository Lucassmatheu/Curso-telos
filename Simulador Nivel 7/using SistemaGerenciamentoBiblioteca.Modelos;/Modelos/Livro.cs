using System;

namespace SistemaGerenciamentoBiblioteca.Modelos
{
    public class Livro
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Identificador único
        public string Titulo { get; set; } 
        public string Autor { get; set; } 
        public string ISBN { get; set; } 
        public int Paginas { get; set; } 
        public int Edicao { get; set; } 
        public bool Disponivel { get; set; } = true; // Status de disponibilidade
    }
}
