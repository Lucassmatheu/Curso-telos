using System;
using System.Linq;
using System.Web.UI.WebControls;
using SistemaGerenciamentoBiblioteca.Dados;
using SistemaGerenciamentoBiblioteca.Modelos;

namespace SimuladorGerenciamentoBiblioteca
{
    public partial class TelaCadastroLivro : System.Web.UI.Page
    {
        private RepositorioLivro db; // Removida a inicialização aqui

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicializa a instância do repositório dentro do método Page_Load
            db = new RepositorioLivro(Server.MapPath("~/App_Data/livros.xml"));
            if (!IsPostBack)
            {
                BindGrid(); // Carrega os dados na grid quando a página é carregada pela primeira vez
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int paginas;
            int edicao;
            bool disponivel;
            int quantidadeCopias;

            if (!int.TryParse(txtPaginas.Text, out paginas))
            {
                lblMensagem.Text = "Por favor, insira um número válido para a quantidade de páginas.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return;
            }

            if (!int.TryParse(txtEdicao.Text, out edicao))
            {
                lblMensagem.Text = "Por favor, insira um número válido para a edição.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return;
            }

            if (!bool.TryParse(ddlDisponibilidade.SelectedValue, out disponivel))
            {
                lblMensagem.Text = "Por favor, selecione uma opção válida para a disponibilidade.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return;
            }

            if (!int.TryParse(txtQuantidadeCopias.Text, out quantidadeCopias) || quantidadeCopias <= 0)
            {
                lblMensagem.Text = "Por favor, insira um número válido para a quantidade de cópias (maior que 0).";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return;
            }

            for (int i = 0; i < quantidadeCopias; i++)
            {
                var livro = new Livro
                {
                    Id = Guid.NewGuid(),
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    ISBN = txtISBN.Text,
                    Paginas = paginas,
                    Edicao = edicao,
                    Disponivel = disponivel,
                    Quantidade = 1
                };

                db.AdicionarLivro(livro);
            }

            lblMensagem.Text = "Livros cadastrados com sucesso!";
            lblMensagem.ForeColor = System.Drawing.Color.Green;
            lblMensagem.Visible = true;

            LimparCampos();
            BindGrid();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        //protected void btnPesquisar_Click(object sender, EventArgs e)
        //{
        //    string termoPesquisa = txtPesquisa.Text;
        //    var livros = db.ObterLivrosPorTitulo(termoPesquisa);
        //    dgvLivros.DataSource = livros;
        //    dgvLivros.DataBind();
        //}

        protected void dgvLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                try
                {
                    if (Guid.TryParse(e.CommandArgument.ToString(), out Guid livroId))
                    {
                        var livro = db.ObterLivroPorId(livroId);

                        if (livro != null)
                        {
                            db.ExcluirLivro(livroId);
                            lblMensagem.Text = "Livro excluído com sucesso!";
                            lblMensagem.ForeColor = System.Drawing.Color.Green;
                            lblMensagem.Visible = true;
                            BindGrid(); // Atualiza a GridView
                        }
                        else
                        {
                            lblMensagem.Text = "Livro não encontrado.";
                            lblMensagem.ForeColor = System.Drawing.Color.Red;
                            lblMensagem.Visible = true;
                        }
                    }
                    else
                    {
                        lblMensagem.Text = "Erro ao processar o ID do livro.";
                        lblMensagem.ForeColor = System.Drawing.Color.Red;
                        lblMensagem.Visible = true;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    lblMensagem.Text = ex.Message;
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Visible = true;
                }
            }
            else if (e.CommandName == "Emprestar")
            {
                try
                {
                    if (Guid.TryParse(e.CommandArgument.ToString(), out Guid livroId))
                    {
                        var livro = db.ObterLivroPorId(livroId);

                        if (livro != null && livro.Disponivel && livro.Quantidade > 0)
                        {
                            livro.Quantidade--;
                            if (livro.Quantidade == 0)
                            {
                                livro.Disponivel = false;
                            }
                            db.AtualizarLivro(livro);
                            lblMensagem.Text = "Livro emprestado com sucesso!";
                            lblMensagem.ForeColor = System.Drawing.Color.Green;
                            lblMensagem.Visible = true;
                            BindGrid(); // Atualiza a GridView
                        }
                        else
                        {
                            lblMensagem.Text = "Livro indisponível para empréstimo.";
                            lblMensagem.ForeColor = System.Drawing.Color.Red;
                            lblMensagem.Visible = true;
                        }
                    }
                    else
                    {
                        lblMensagem.Text = "Erro ao processar o ID do livro.";
                        lblMensagem.ForeColor = System.Drawing.Color.Red;
                        lblMensagem.Visible = true;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    lblMensagem.Text = ex.Message;
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Visible = true;
                }
            }
            else if (e.CommandName == "Devolver")
            {
                try
                {
                    if (Guid.TryParse(e.CommandArgument.ToString(), out Guid livroId))
                    {
                        var livro = db.ObterLivroPorId(livroId);

                        if (livro != null)
                        {
                            livro.Quantidade++;
                            if (!livro.Disponivel)
                            {
                                livro.Disponivel = true;
                            }
                            db.AtualizarLivro(livro);
                            lblMensagem.Text = "Livro devolvido com sucesso!";
                            lblMensagem.ForeColor = System.Drawing.Color.Green;
                            lblMensagem.Visible = true;
                            BindGrid(); // Atualiza a GridView
                        }
                        else
                        {
                            lblMensagem.Text = "Livro não encontrado.";
                            lblMensagem.ForeColor = System.Drawing.Color.Red;
                            lblMensagem.Visible = true;
                        }
                    }
                    else
                    {
                        lblMensagem.Text = "Erro ao processar o ID do livro.";
                        lblMensagem.ForeColor = System.Drawing.Color.Red;
                        lblMensagem.Visible = true;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    lblMensagem.Text = ex.Message;
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Visible = true;
                }
            }
        }

        protected void dgvLivros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var livro = (Livro)e.Row.DataItem;
                var btnEmprestar = (Button)e.Row.FindControl("btnEmprestar");

                if (btnEmprestar != null)
                {
                    // Verifica se o livro está disponível e se há cópias para emprestar
                    if (!livro.Disponivel || livro.Quantidade <= 0)
                    {
                        btnEmprestar.Enabled = false;
                        btnEmprestar.Text = "Indisponível";
                    }
                    else
                    {
                        btnEmprestar.Enabled = true;
                        btnEmprestar.Text = "Emprestar";
                    }
                }
            }
        }

        private void BindGrid()
        {
            var livros = db.ObterTodosLivros();
            dgvLivros.DataSource = livros;
            dgvLivros.DataBind();
        }

        private void LimparCampos()
        {
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtISBN.Text = "";
            txtPaginas.Text = "";
            txtEdicao.Text = "";
            txtQuantidadeCopias.Text = "";
            ddlDisponibilidade.SelectedIndex = 0;
        }
    }
}
