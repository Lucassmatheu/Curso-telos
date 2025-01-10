namespace GerenciamentodePecasdeVeículos
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
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

            // btnCadastrar
            this.btnCadastrar.Location = new System.Drawing.Point(30, 220);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(100, 30);
            this.btnCadastrar.TabIndex = 0;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);

            // btnConsultar
            this.btnConsultar.Location = new System.Drawing.Point(150, 220);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 30);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(270, 220);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 30);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // dgvPecas
            this.dgvPecas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPecas.Location = new System.Drawing.Point(30, 270);
            this.dgvPecas.Name = "dgvPecas";
            this.dgvPecas.Size = new System.Drawing.Size(600, 200);
            this.dgvPecas.TabIndex = 3;

            // Labels and TextBoxes
            // Nome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(30, 30);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(39, 13);
            this.lblNome.TabIndex = 4;
            this.lblNome.Text = "Nome:";
            this.txtNome.Location = new System.Drawing.Point(100, 30);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 20);
            this.txtNome.TabIndex = 5;

            // Fabricante
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(30, 60);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(61, 13);
            this.lblFabricante.TabIndex = 6;
            this.lblFabricante.Text = "Fabricante:";
            this.txtFabricante.Location = new System.Drawing.Point(100, 60);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(200, 20);
            this.txtFabricante.TabIndex = 7;

            // Tipo Veículo
            this.lblTipoVeiculo.AutoSize = true;
            this.lblTipoVeiculo.Location = new System.Drawing.Point(30, 90);
            this.lblTipoVeiculo.Name = "lblTipoVeiculo";
            this.lblTipoVeiculo.Size = new System.Drawing.Size(64, 13);
            this.lblTipoVeiculo.TabIndex = 8;
            this.lblTipoVeiculo.Text = "Tipo Veículo:";
            this.txtTipoVeiculo.Location = new System.Drawing.Point(100, 90);
            this.txtTipoVeiculo.Name = "txtTipoVeiculo";
            this.txtTipoVeiculo.Size = new System.Drawing.Size(200, 20);
            this.txtTipoVeiculo.TabIndex = 9;

            // Categoria
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(30, 120);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 10;
            this.lblCategoria.Text = "Categoria:";
            this.txtCategoria.Location = new System.Drawing.Point(100, 120);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(200, 20);
            this.txtCategoria.TabIndex = 11;

            // Preço Compra
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.Location = new System.Drawing.Point(30, 150);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(76, 13);
            this.lblPrecoCompra.TabIndex = 12;
            this.lblPrecoCompra.Text = "Preço Compra:";
            this.txtPrecoCompra.Location = new System.Drawing.Point(100, 150);
            this.txtPrecoCompra.Name = "txtPrecoCompra";
            this.txtPrecoCompra.Size = new System.Drawing.Size(200, 20);
            this.txtPrecoCompra.TabIndex = 13;

            // Preço Venda
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Location = new System.Drawing.Point(30, 180);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(70, 13);
            this.lblPrecoVenda.TabIndex = 14;
            this.lblPrecoVenda.Text = "Preço Venda:";
            this.txtPrecoVenda.Location = new System.Drawing.Point(100, 180);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(200, 20);
            this.txtPrecoVenda.TabIndex = 15;

            // Form1
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnExcluir);
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
            this.Text = "Gerenciamento de Peças de Veículos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPecas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dgvPecas;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.TextBox txtTipoVeiculo;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtPrecoCompra;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.Label lblTipoVeiculo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecoCompra;
        private System.Windows.Forms.Label lblPrecoVenda;

    }
}

