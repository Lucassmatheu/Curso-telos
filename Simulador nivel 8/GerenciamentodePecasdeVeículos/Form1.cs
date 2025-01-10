using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NHibernate.Loader.Custom.CustomLoader;
using GerenciamentodePecasdeVeículos.Produto;
using GerenciamentodePecasdeVeículos.ConfigDb;
using System.Data.SqlClient;
using System.Data.SqlClient;



namespace GerenciamentodePecasdeVeículos
{
    public partial class Form1 : Form
    {
        private PecaData pecaData;

        public Form1()
        {
            InitializeComponent();
            pecaData = new PecaData();

            Button btnIrParaVendas = new Button
            {
                Text = "Ir para Vendas",
                Location = new Point(20, 350), // Posição no formulário
                Size = new Size(120, 40) // Tamanho do botão
            };
            // Adiciona o botão ao formulário
            this.Controls.Add(btnIrParaVendas);

            // Vincula o evento de clique
            btnIrParaVendas.Click += btnTelaVendas_Click;

        }
        private void dgvPecas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a linha clicada é válida
            if (e.RowIndex >= 0)
            {
                // Obtem a linha clicada
                DataGridViewRow row = dgvPecas.Rows[e.RowIndex];

                // Preenche os campos com os valores da linha selecionada
                txtNome.Text = row.Cells[1].Value?.ToString(); // Substitua 1 pelo índice da coluna Nome
                txtFabricante.Text = row.Cells[2].Value?.ToString(); // Substitua 2 pelo índice da coluna Fabricante
                txtTipoVeiculo.Text = row.Cells[3].Value?.ToString(); // Substitua 3 pelo índice da coluna TipoVeiculo
                txtCategoria.Text = row.Cells[4].Value?.ToString(); // Substitua 4 pelo índice da coluna Categoria
                txtPrecoCompra.Text = row.Cells[5].Value?.ToString(); // Substitua 5 pelo índice da coluna PrecoCompra
                txtPrecoVenda.Text = row.Cells[6].Value?.ToString(); // Substitua 6 pelo índice da coluna PrecoVenda
                txtQuantidade.Text = row.Cells[7].Value?.ToString(); // Substitua 7 pelo índice da coluna Quantidade
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifique se há uma linha selecionada no DataGridView
                if (dgvPecas.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvPecas.SelectedRows[0].Cells["Id"].Value);

                    // Validação dos campos para garantir que estão preenchidos corretamente
                    if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                        string.IsNullOrWhiteSpace(txtFabricante.Text) ||
                        string.IsNullOrWhiteSpace(txtTipoVeiculo.Text) ||
                        string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                        string.IsNullOrWhiteSpace(txtPrecoCompra.Text) ||
                        string.IsNullOrWhiteSpace(txtPrecoVenda.Text) ||
                        string.IsNullOrWhiteSpace(txtQuantidade.Text))
                    {
                        MessageBox.Show("Todos os campos devem ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Garantir que os valores numéricos são válidos
                    if (!decimal.TryParse(txtPrecoCompra.Text, out decimal precoCompra) ||
                        !decimal.TryParse(txtPrecoVenda.Text, out decimal precoVenda) ||
                        !int.TryParse(txtQuantidade.Text, out int quantidade))
                    {
                        MessageBox.Show("Verifique os valores inseridos nos campos de preço e quantidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Conexão com o banco de dados usando a string de conexão fornecida
                    string connectionString = "Data Source=PCLUCAS\\SQLEXPRESS;Initial Catalog=EstoqueVeiculos;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Query para atualizar os dados no banco
                        string query = @"UPDATE Pecas 
                                 SET Nome = @Nome,
                                     Fabricante = @Fabricante,
                                     TipoVeiculo = @TipoVeiculo,
                                     Categoria = @Categoria,
                                     PrecoCompra = @PrecoCompra,
                                     PrecoVenda = @PrecoVenda,
                                     Quantidade = @Quantidade
                                 WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                            cmd.Parameters.AddWithValue("@Fabricante", txtFabricante.Text);
                            cmd.Parameters.AddWithValue("@TipoVeiculo", txtTipoVeiculo.Text);
                            cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                            cmd.Parameters.AddWithValue("@PrecoCompra", precoCompra);
                            cmd.Parameters.AddWithValue("@PrecoVenda", precoVenda);
                            cmd.Parameters.AddWithValue("@Quantidade", quantidade);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Peça atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recarregar os dados no DataGridView
                    CarregarDados();
                }
                else
                {
                    MessageBox.Show("Selecione uma peça para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao atualizar peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                string connectionString = "Data Source=PCLUCAS\\SQLEXPRESS;Initial Catalog=EstoqueVeiculos;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Pecas";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPecas.DataSource = dt;

                        // Configurar as colunas do DataGridView
                        dgvPecas.Columns["Id"].HeaderText = "ID";
                        dgvPecas.Columns["Nome"].HeaderText = "Nome da Peça";
                        dgvPecas.Columns["Fabricante"].HeaderText = "Fabricante";
                        dgvPecas.Columns["TipoVeiculo"].HeaderText = "Tipo de Veículo";
                        dgvPecas.Columns["Categoria"].HeaderText = "Categoria";
                        dgvPecas.Columns["PrecoCompra"].HeaderText = "Preço de Compra";
                        dgvPecas.Columns["PrecoVenda"].HeaderText = "Preço de Venda";
                        dgvPecas.Columns["Quantidade"].HeaderText = "Quantidade em Estoque";
                        dgvPecas.Columns["PecaVendida"].HeaderText = "Quantidade Vendida";
                        dgvPecas.Columns["Status"].HeaderText = "Status";

                        ;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
            try
            {
                using (var session = sessionfac.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        // Validar a quantidade
                        if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade < 0)
                        {
                            MessageBox.Show("Por favor, insira uma quantidade válida.");
                            return;
                        }

                        // Criar a nova peça
                        var peca = new Peca
                        {
                            Nome = txtNome.Text,
                            Fabricante = txtFabricante.Text,
                            TipoVeiculo = txtTipoVeiculo.Text,
                            Categoria = txtCategoria.Text,
                            PrecoCompra = decimal.Parse(txtPrecoCompra.Text),
                            PrecoVenda = decimal.Parse(txtPrecoVenda.Text),
                            Quantidade = quantidade, // Salva a quantidade
                            Status = "Disponível"
                        };

                        // Salvar no banco
                        session.Save(peca);
                        transaction.Commit();
                        MessageBox.Show("Peça cadastrada com sucesso!");

                        // Limpar os campos
                        txtNome.Clear();
                        txtFabricante.Clear();
                        txtTipoVeiculo.Clear();
                        txtCategoria.Clear();
                        txtPrecoCompra.Clear();
                        txtPrecoVenda.Clear();
                        txtQuantidade.Clear();

                        // Atualizar a tabela
                        AtualizarTabela();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar peça: {ex.Message}");
            }
        }


        private void AtualizarTabela()
        {
            var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
            try
            {
                using (var session = sessionfac.OpenSession())
                {
                    var pecas = session.Query<Peca>().ToList(); // Consulta todas as peças
                    dgvPecas.DataSource = pecas; // Atualiza o DataGridView com a lista de peças
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }



        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
            try
            {
                using (var session = sessionfac.OpenSession())
                {
                    // Começa uma consulta básica
                    var query = session.Query<Peca>().AsQueryable();

                    // Adiciona filtros com base nos campos preenchidos
                    if (!string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        query = query.Where(p => p.Nome.Contains(txtNome.Text));
                    }

                    if (!string.IsNullOrWhiteSpace(txtFabricante.Text))
                    {
                        query = query.Where(p => p.Fabricante.Contains(txtFabricante.Text));
                    }

                    if (!string.IsNullOrWhiteSpace(txtTipoVeiculo.Text))
                    {
                        query = query.Where(p => p.TipoVeiculo.Contains(txtTipoVeiculo.Text));
                    }

                    if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
                    {
                        query = query.Where(p => p.Categoria.Contains(txtCategoria.Text));
                    }

                    if (decimal.TryParse(txtPrecoCompra.Text, out var precoCompra))
                    {
                        query = query.Where(p => p.PrecoCompra == precoCompra);
                    }

                    if (decimal.TryParse(txtPrecoVenda.Text, out var precoVenda))
                    {
                        query = query.Where(p => p.PrecoVenda == precoVenda);
                    }

                    // Executa a consulta e atualiza o DataGridView
                    var resultado = query.ToList();
                    dgvPecas.DataSource = resultado;

                    if (resultado.Count == 0)
                    {
                        MessageBox.Show("Nenhuma peça encontrada com os critérios informados.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar peças: {ex.Message}");
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPecas.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
            {
                var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
                try
                {
                    // Obtém o Id da peça selecionada
                    int id = (int)dgvPecas.SelectedRows[0].Cells["Id"].Value;

                    using (var session = sessionfac.OpenSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            // Busca a peça pelo Id
                            var peca = session.Get<Peca>(id);

                            if (peca != null)
                            {
                                session.Delete(peca); // Exclui a peça
                                transaction.Commit();

                                MessageBox.Show("Peça excluída com sucesso!");

                                // Atualizar o DataGridView
                                AtualizarTabela();
                            }
                            else
                            {
                                MessageBox.Show("Peça não encontrada.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir peça: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma peça para excluir.");
            }
        }
        private void btnTelaVendas_Click(object sender, EventArgs e)
        {
            // Abre o formulário de vendas
            FormVendas formVendas = new FormVendas();
            formVendas.Show();
        }

        private void dgvPecas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
