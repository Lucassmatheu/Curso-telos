using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGerenciamentoBiblioteca.Modelos
{
    public class Livro
    {
        public Guid Id { get; set; } // ID de 32 dígitos, normalmente utilizado como um GUID padrão
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int Paginas { get; set; }
        public int Edicao { get; set; }
        public bool Disponivel { get; set; }
        public int Quantidade { get; set; }

        // Método para gerar um ID curto (6 dígitos) usando Guid
        public Livro()
        {
            // Gera um ID único para cada novo livro
            Id = Guid.NewGuid();
        }
    }
}
