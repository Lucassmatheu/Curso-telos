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


namespace GerenciamentodePecasdeVeículos
{
    public partial class Form1 : Form
    {
        private PecaData pecaData;

        public Form1()
        {
            InitializeComponent();
            pecaData = new PecaData();
           
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
                        // Criar a nova peça
                        var peca = new Peca
                        {
                            Nome = txtNome.Text,
                            Fabricante = txtFabricante.Text,
                            TipoVeiculo = txtTipoVeiculo.Text,
                            Categoria = txtCategoria.Text,
                            PrecoCompra = decimal.Parse(txtPrecoCompra.Text),
                            PrecoVenda = decimal.Parse(txtPrecoVenda.Text),
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

    }
}
