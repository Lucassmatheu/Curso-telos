using SistemaGerenciamentoBiblioteca.Dados;
using SistemaGerenciamentoBiblioteca.Modelos;
using System;
using System.Collections.Generic;

namespace SistemaGerenciamentoBiblioteca.Controladores
{
    public class ControleLivro
    {
        private readonly RepositorioLivro _repositorio;

        public ControleLivro(RepositorioLivro repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Livro> ObterTodosLivros() => _repositorio.ObterTodosLivros();

        public void AdicionarLivro(Livro livro)
        {
            var livros = _repositorio.ObterTodosLivros();
            livros.Add(livro);
            _repositorio.SalvarLivros(livros);
        }

        public void AtualizarLivro(Guid id, Livro livroAtualizado)
        {
            var livros = _repositorio.ObterTodosLivros();
            var livro = livros.Find(l => l.Id == id);
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

        public void RemoverLivro(Guid id)
        {
            var livros = _repositorio.ObterTodosLivros();
            livros.RemoveAll(l => l.Id == id);
            _repositorio.SalvarLivros(livros);
        }

        public void EmprestarLivro(Guid id)
        {
            var livros = _repositorio.ObterTodosLivros();
            var livro = livros.Find(l => l.Id == id);
            if (livro != null && livro.Disponivel)
            {
                livro.Disponivel = false;
                _repositorio.SalvarLivros(livros);
            }
        }

        public void DevolverLivro(Guid id)
        {
            var livros = _repositorio.ObterTodosLivros();
            var livro = livros.Find(l => l.Id == id);
            if (livro != null && !livro.Disponivel)
            {
                livro.Disponivel = true;
                _repositorio.SalvarLivros(livros);
            }
        }
    }
}
