using SistemaGerenciamentoBiblioteca.Dados;
using SistemaGerenciamentoBiblioteca.Modelos;
using System;
using System.Collections.Generic;

namespace SistemaGerenciamentoBiblioteca.Controladores
{
    public class ControleLivro
    {
        private readonly RepositorioLivro _repositorio;

        // Construtor que recebe o repositório de livros
        public ControleLivro(RepositorioLivro repositorio)
        {
            _repositorio = repositorio;
        }

        // Obtém todos os livros do repositório
        public List<Livro> ObterTodosLivros() => _repositorio.ObterTodosLivros();

        // Adiciona um novo livro ao repositório (uma única cópia)
        public void AdicionarLivro(Livro livro)
        {
            var livros = _repositorio.ObterTodosLivros();
            livros.Add(livro);
            _repositorio.SalvarLivros(livros);
        }

        // Adiciona múltiplas cópias de um livro ao repositório
     


        public void AdicionarLivro(Livro livro, int quantidade)
        {
            var livros = _repositorio.ObterTodosLivros();

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

            _repositorio.SalvarLivros(livros);
        }

        // Atualiza as informações de um livro específico
        public void AtualizarLivro(Guid id, Livro livroAtualizado)
        {
            var livros = _repositorio.ObterTodosLivros();
            var livro = livros.Find(l => l.Id == id); // Corrigido para comparar Guid

            if (livro != null)
            {
                livro.Titulo = livroAtualizado.Titulo;
                livro.Autor = livroAtualizado.Autor;
                livro.ISBN = livroAtualizado.ISBN;
                livro.Paginas = livroAtualizado.Paginas;
                livro.Edicao = livroAtualizado.Edicao;
                _repositorio.SalvarLivros(livros);
            }
        }

        // Remove um livro do repositório
        public void RemoverLivro(Guid id)
        {
            var livros = _repositorio.ObterTodosLivros();
            livros.RemoveAll(l => l.Id == id); // Corrigido para comparar Guid
            _repositorio.SalvarLivros(livros);
        }

        // Marca um livro como emprestado, alterando seu status de disponibilidade e quantidade
        public void EmprestarLivro(Guid id)
        {
            var livros = _repositorio.ObterTodosLivros();
            var livro = livros.Find(l => l.Id == id); // Corrigido para comparar Guid
            if (livro != null)
            {
                // Verifica se há cópias disponíveis para empréstimo
                if (livro.Quantidade > 0 && livro.Disponivel)
                {
                    livro.Quantidade--; // Reduz a quantidade de cópias disponíveis
                    livro.Disponivel = livro.Quantidade > 0; // Atualiza a disponibilidade com base na quantidade

                    _repositorio.SalvarLivros(livros);
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

        // Marca um livro como devolvido, alterando seu status de disponibilidade e quantidade
        public void DevolverLivro(Guid id)
        {
            var livros = _repositorio.ObterTodosLivros();
            var livro = livros.Find(l => l.Id == id); // Corrigido para comparar Guid
            if (livro != null && !livro.Disponivel)
            {
                livro.Quantidade++; // Aumenta a quantidade de cópias disponíveis
                livro.Disponivel = true; // Define como disponível
                _repositorio.SalvarLivros(livros);
            }
            else
            {
                throw new InvalidOperationException("Livro não encontrado ou já está disponível.");
            }
        }
    }
}
