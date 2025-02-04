namespace GerenciamentodePecasdeVeículos
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar; // Botão Editar
        private System.Windows.Forms.DataGridView dgvPecas;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.TextBox txtTipoVeiculo;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtPrecoCompra;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.Label lblTipoVeiculo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecoCompra;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.Label lblQuantidade;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgvPecas = new System.Windows.Forms.DataGridView();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.txtTipoVeiculo = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtPrecoCompra = new System.Windows.Forms.TextBox();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.lblTipoVeiculo = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblPrecoCompra = new System.Windows.Forms.Label();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPecas)).BeginInit();
            this.SuspendLayout();

            // txtQuantidade
            this.txtQuantidade.Location = new System.Drawing.Point(120, 270);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(200, 20);
            this.txtQuantidade.TabIndex = 10;

            // lblQuantidade
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(30, 270);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 17;
            this.lblQuantidade.Text = "Quantidade:";

            // btnCadastrar
            this.btnCadastrar.Location = new System.Drawing.Point(120, 409);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(100, 30);
            this.btnCadastrar.TabIndex = 0;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);

            // btnConsultar
            this.btnConsultar.Location = new System.Drawing.Point(256, 409);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 30);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(400, 409);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 30);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // btnEditar
            this.btnEditar.Location = new System.Drawing.Point(540, 409);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // dgvPecas
            this.dgvPecas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPecas.Location = new System.Drawing.Point(371, 30);
            this.dgvPecas.Name = "dgvPecas";
            this.dgvPecas.Size = new System.Drawing.Size(640, 200);
            this.dgvPecas.TabIndex = 3;
            this.dgvPecas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPecas_CellContentClick);

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(120, 30);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 20);
            this.txtNome.TabIndex = 4;

            // txtFabricante
            this.txtFabricante.Location = new System.Drawing.Point(120, 70);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(200, 20);
            this.txtFabricante.TabIndex = 5;

            // txtTipoVeiculo
            this.txtTipoVeiculo.Location = new System.Drawing.Point(120, 110);
            this.txtTipoVeiculo.Name = "txtTipoVeiculo";
            this.txtTipoVeiculo.Size = new System.Drawing.Size(200, 20);
            this.txtTipoVeiculo.TabIndex = 6;

            // txtCategoria
            this.txtCategoria.Location = new System.Drawing.Point(120, 150);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(200, 20);
            this.txtCategoria.TabIndex = 7;

            // txtPrecoCompra
            this.txtPrecoCompra.Location = new System.Drawing.Point(120, 190);
            this.txtPrecoCompra.Name = "txtPrecoCompra";
            this.txtPrecoCompra.Size = new System.Drawing.Size(200, 20);
            this.txtPrecoCompra.TabIndex = 8;

            // txtPrecoVenda
            this.txtPrecoVenda.Location = new System.Drawing.Point(120, 230);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(200, 20);
            this.txtPrecoVenda.TabIndex = 9;

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(30, 30);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 11;
            this.lblNome.Text = "Nome:";

            // lblFabricante
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(30, 70);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(60, 13);
            this.lblFabricante.TabIndex = 12;
            this.lblFabricante.Text = "Fabricante:";

            // lblTipoVeiculo
            this.lblTipoVeiculo.AutoSize = true;
            this.lblTipoVeiculo.Location = new System.Drawing.Point(30, 110);
            this.lblTipoVeiculo.Name = "lblTipoVeiculo";
            this.lblTipoVeiculo.Size = new System.Drawing.Size(71, 13);
            this.lblTipoVeiculo.TabIndex = 13;
            this.lblTipoVeiculo.Text = "Tipo Veículo:";
            var colPecasVendidas = new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "PecasVendidas",
                HeaderText = "Peças Vendidas",
                DataPropertyName = "PecaVendida"
            };
            this.dgvPecas.Columns.Add(colPecasVendidas);
            // lblCategoria
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(30, 150);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 14;
            this.lblCategoria.Text = "Categoria:";

            // lblPrecoCompra
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.Location = new System.Drawing.Point(30, 190);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(77, 13);
            this.lblPrecoCompra.TabIndex = 15;
            this.lblPrecoCompra.Text = "Preço Compra:";

            // lblPrecoVenda
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Location = new System.Drawing.Point(30, 230);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(72, 13);
            this.lblPrecoVenda.TabIndex = 16;
            this.lblPrecoVenda.Text = "Preço Venda:";

            // Form1
            this.ClientSize = new System.Drawing.Size(1452, 648);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvPecas);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.txtTipoVeiculo);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtPrecoCompra);
            this.Controls.Add(this.txtPrecoVenda);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.lblTipoVeiculo);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblPrecoCompra);
            this.Controls.Add(this.lblPrecoVenda);
            this.Name = "Form1";
            this.Text = "Gerenciamento de Peças";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPecas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
