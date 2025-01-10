using GerenciamentodePecasdeVeículos.ConfigDb;
using GerenciamentodePecasdeVeículos.Produto;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GerenciamentodePecasdeVeículos
{
    public partial class FormVendas : Form
    {
        private string connectionStr = "Data Source=PCLUCAS\\SQLEXPRESS;Initial Catalog=EstoqueVeiculos;Integrated Security=True;";

        public FormVendas()
        {
            InitializeComponent();
        }

        private void FormVendas_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                string query = "SELECT Nome, Fabricante, TipoVeiculo, Categoria, PrecoVenda, Quantidade FROM Pecas";

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvItensVenda.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT Nome, Fabricante, TipoVeiculo, Categoria, PrecoVenda, Quantidade FROM Pecas WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(txtNomeFiltro.Text))
                {
                    query += " AND Nome LIKE @nome";
                }
                if (!string.IsNullOrWhiteSpace(txtTipoVeiculoFiltro.Text))
                {
                    query += " AND TipoVeiculo LIKE @tipoVeiculo";
                }

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (!string.IsNullOrWhiteSpace(txtNomeFiltro.Text))
                        cmd.Parameters.AddWithValue("@nome", $"%{txtNomeFiltro.Text}%");
                    if (!string.IsNullOrWhiteSpace(txtTipoVeiculoFiltro.Text))
                        cmd.Parameters.AddWithValue("@tipoVeiculo", $"%{txtTipoVeiculoFiltro.Text}%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvItensVenda.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItensVenda.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, selecione um produto para confirmar a venda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow linhaSelecionada = dgvItensVenda.SelectedRows[0];
                string nomeProduto = linhaSelecionada.Cells["Nome"].Value.ToString();
                int quantidadeEstoque = Convert.ToInt32(linhaSelecionada.Cells["Quantidade"].Value);
                decimal precoVenda = Convert.ToDecimal(linhaSelecionada.Cells["PrecoVenda"].Value);

                if (!int.TryParse(txtQuantidade.Text, out int quantidadeVendida) || quantidadeVendida <= 0)
                {
                    MessageBox.Show("A quantidade vendida deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (quantidadeVendida > quantidadeEstoque)
                {
                    MessageBox.Show("Quantidade vendida maior que o estoque disponível.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal total = precoVenda * quantidadeVendida;

                string updateQuery = "UPDATE Pecas SET Quantidade = Quantidade - @quantidadeVendida WHERE Nome = @nomeProduto";

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@quantidadeVendida", quantidadeVendida);
                    cmd.Parameters.AddWithValue("@nomeProduto", nomeProduto);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Venda confirmada!\nProduto: {nomeProduto}\nQuantidade Vendida: {quantidadeVendida}\nTotal: R$ {total:N2}",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao confirmar venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItensVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvItensVenda.Rows[e.RowIndex];
                txtPrecoVenda.Text = row.Cells["PrecoVenda"].Value.ToString();
                txtQuantidade.Text = row.Cells["Quantidade"].Value.ToString();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
