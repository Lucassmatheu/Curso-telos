//using System;
//using SistemaGerenciamentoBiblioteca.Dados;
//using SistemaGerenciamentoBiblioteca.Modelos;

//namespace SimuladorGerenciamentoBiblioteca
//{
//    public partial class TelaConsultarLivros : System.Web.UI.Page
//    {
//        protected void btnConsultarLivros_Click(object sender, EventArgs e)
//        {
//            // Chama o repositório para obter todos os livros
//            var repositorio = new RepositorioLivro();
//            var livros = repositorio.ObterTodosLivros();

//            // Filtra os livros conforme os dados informados
//            if (!string.IsNullOrEmpty(txtTitulo.Text))
//            {
//                livros = livros.FindAll(l => l.Titulo.Contains(txtTitulo.Text));
//            }
//            if (!string.IsNullOrEmpty(txtAutor.Text))
//            {
//                livros = livros.FindAll(l => l.Autor.Contains(txtAutor.Text));
//            }
//            if (!string.IsNullOrEmpty(txtISBN.Text))
//            {
//                livros = livros.FindAll(l => l.ISBN.Contains(txtISBN.Text));
//            }
//            if (!string.IsNullOrEmpty(txtPaginas.Text) && int.TryParse(txtPaginas.Text, out int paginas))
//            {
//                livros = livros.FindAll(l => l.Paginas == paginas);
//            }
//            if (!string.IsNullOrEmpty(txtEdicao.Text) && int.TryParse(txtEdicao.Text, out int edicao))
//            {
//                livros = livros.FindAll(l => l.Edicao == edicao);
//            }

//            // Bind os livros encontrados no GridView
//            dgvLivros.DataSource = livros;
//            dgvLivros.DataBind();
//        }

//        protected void btnCadastroLivro_Click(object sender, EventArgs e)
//        {
//            // Redireciona para a tela de cadastro de livro
//            Response.Redirect("~/TelaCadastroLivro.aspx");
//        }
//    }
//}
