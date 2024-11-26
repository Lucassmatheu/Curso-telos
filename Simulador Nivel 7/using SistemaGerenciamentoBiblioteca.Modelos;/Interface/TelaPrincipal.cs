using SistemaGerenciamentoBiblioteca.Controladores;
using SistemaGerenciamentoBiblioteca.Modelos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaGerenciamentoBiblioteca.Interface
{
    public partial class TelaPrincipal : Form
    {
        private readonly ControleLivro _controle;

        // Construtor
        public TelaPrincipal(ControleLivro controle)
        {
            _controle = controle;
            InitializeComponent(); // Certifique-se que isso esteja presente para inicializar os componentes
        }

        // Método para carregar livros na interface
        private void CarregarLivros()
        {
            var livros = _controle.ObterTodosLivros();
            dgvLivros.DataSource = livros.Select(l => new
            {
                l.Id,
                l.Titulo,
                l.Autor,
                l.ISBN,
                l.Paginas,
                l.Edicao,
                Disponibilidade = l.Disponivel ? "Disponível" : "Indisponível"
            }).ToList();
        }

        // Evento de clique para adicionar um livro
        private void btnAdicionarLivro_Click(object sender, EventArgs e)
        {
            var livro = new Livro
            {
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                ISBN = txtISBN.Text,
                Paginas = int.Parse(txtPaginas.Text),
                Edicao = int.Parse(txtEdicao.Text)
            };

            _controle.AdicionarLivro(livro);
            CarregarLivros();
        }

        // Evento de clique para remover um livro
        private void btnRemoverLivro_Click(object sender, EventArgs e)
        {
            if (dgvLivros.CurrentRow != null)
            {
                var id = (Guid)dgvLivros.CurrentRow.Cells["Id"].Value;
                _controle.RemoverLivro(id);
                CarregarLivros();
            }
        }

        // Evento de carregamento da tela
        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            CarregarLivros();
        }
    }
}
