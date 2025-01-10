using SistemaGerenciamentoBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Threading;

namespace SistemaGerenciamentoBiblioteca.Dados
{
    public class RepositorioLivro
    {
        private readonly string _caminhoArquivo;
        private static readonly object _lock = new object(); // Para controle de concorrência

        public RepositorioLivro(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo ?? throw new ArgumentNullException(nameof(caminhoArquivo));
        }

        private string CaminhoArquivo
        {
            get
            {
                return _caminhoArquivo;
            }
        }

        public List<Livro> ObterTodosLivros()
        {
            lock (_lock)
            {
                if (!File.Exists(CaminhoArquivo))
                    return new List<Livro>();

                using (var stream = new FileStream(CaminhoArquivo, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(List<Livro>));
                    return (List<Livro>)serializer.Deserialize(stream);
                }
            }
        }

        public void SalvarLivros(List<Livro> livros)
        {
            lock (_lock)
            {
                using (var stream = new FileStream(CaminhoArquivo, FileMode.Create))
                {
                    var serializer = new XmlSerializer(typeof(List<Livro>));
                    serializer.Serialize(stream, livros);
                }
            }
        }

        public void AtualizarLivro(Livro livro)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();
                var livroExistente = livros.FirstOrDefault(l => l.Id == livro.Id);
                if (livroExistente != null)
                {
                    livroExistente.Titulo = livro.Titulo;
                    livroExistente.Autor = livro.Autor;
                    livroExistente.ISBN = livro.ISBN;
                    livroExistente.Paginas = livro.Paginas;
                    livroExistente.Edicao = livro.Edicao;
                    livroExistente.Disponivel = livro.Disponivel;
                    livroExistente.Quantidade = livro.Quantidade;

                    SalvarLivros(livros);
                }
                else
                {
                    throw new InvalidOperationException("Livro não encontrado para atualização.");
                }
            }
        }

        public void AdicionarLivro(Livro livro)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();
                livros.Add(livro);
                SalvarLivros(livros);
            }
        }

        public void AdicionarLivro(Livro livro, int quantidade)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();

                for (int i = 0; i < quantidade; i++)
                {
                    var novaCopia = new Livro
                    {
                        Id = Guid.NewGuid(),
                        Titulo = livro.Titulo,
                        Autor = livro.Autor,
                        ISBN = livro.ISBN,
                        Paginas = livro.Paginas,
                        Edicao = livro.Edicao,
                        Quantidade = 1,
                        Disponivel = true
                    };

                    livros.Add(novaCopia);
                }

                SalvarLivros(livros);
            }
        }

        public List<Livro> ObterLivrosPorTitulo(string titulo)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();
                return livros.Where(l => l.Titulo.IndexOf(titulo, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
        }

        public void ExcluirLivro(Guid livroId)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();
                var livro = livros.FirstOrDefault(l => l.Id == livroId);

                if (livro != null)
                {
                    livros.Remove(livro);
                    SalvarLivros(livros);
                }
                else
                {
                    throw new InvalidOperationException("Livro não encontrado para exclusão.");
                }
            }
        }

        public Livro ObterLivroPorId(Guid livroId)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();
                return livros.FirstOrDefault(l => l.Id == livroId);
            }
        }

        public void EmprestarLivro(Guid livroId)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();
                var livro = livros.FirstOrDefault(l => l.Id == livroId);

                if (livro != null)
                {
                    if (livro.Quantidade > 0 && livro.Disponivel)
                    {
                        livro.Quantidade--;
                        livro.Disponivel = livro.Quantidade > 0;
                        SalvarLivros(livros);
                    }
                    else
                    {
                        throw new InvalidOperationException("Nenhuma cópia disponível para empréstimo.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Livro não encontrado para empréstimo.");
                }
            }
        }

        public void DevolverLivro(Guid livroId)
        {
            lock (_lock)
            {
                var livros = ObterTodosLivros();
                var livro = livros.FirstOrDefault(l => l.Id == livroId);

                if (livro != null && !livro.Disponivel)
                {
                    livro.Quantidade++;
                    livro.Disponivel = true;
                    SalvarLivros(livros);
                }
                else
                {
                    throw new InvalidOperationException("Livro não encontrado ou já está disponível.");
                }
            }
        }
    }
}
