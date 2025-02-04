namespace GerenciamentodePecasdeVeículos
{
    partial class FormVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnConfirmarVenda;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dgvItensVenda;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblNomeFiltro;
        private System.Windows.Forms.TextBox txtNomeFiltro;
        private System.Windows.Forms.Label lblCategoriaFiltro;
        private System.Windows.Forms.TextBox txtCategoriaFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblTipoVeiculoFiltro;
        private System.Windows.Forms.TextBox txtTipoVeiculoFiltro;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.lblTipoVeiculoFiltro = new System.Windows.Forms.Label();
            this.txtTipoVeiculoFiltro = new System.Windows.Forms.TextBox();
            this.lblNomeFiltro = new System.Windows.Forms.Label();
            this.txtNomeFiltro = new System.Windows.Forms.TextBox();
            this.lblCategoriaFiltro = new System.Windows.Forms.Label();
            this.txtCategoriaFiltro = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnConfirmarVenda = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dgvItensVenda = new System.Windows.Forms.DataGridView();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeFiltro
            // 
            this.lblNomeFiltro.AutoSize = true;
            this.lblNomeFiltro.Location = new System.Drawing.Point(38, 8);
            this.lblNomeFiltro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomeFiltro.Name = "lblNomeFiltro";
            this.lblNomeFiltro.Size = new System.Drawing.Size(38, 13);
            this.lblNomeFiltro.TabIndex = 7;
            this.lblNomeFiltro.Text = "Nome:";
            // 
            // txtNomeFiltro
            // 
            this.txtNomeFiltro.Location = new System.Drawing.Point(75, 8);
            this.txtNomeFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeFiltro.Name = "txtNomeFiltro";
            this.txtNomeFiltro.Size = new System.Drawing.Size(114, 20);
            this.txtNomeFiltro.TabIndex = 8;
            // 
            // lblCategoriaFiltro
            // 
            this.lblCategoriaFiltro.AutoSize = true;
            this.lblCategoriaFiltro.Location = new System.Drawing.Point(225, 8);
            this.lblCategoriaFiltro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategoriaFiltro.Name = "lblCategoriaFiltro";
            this.lblCategoriaFiltro.Size = new System.Drawing.Size(84, 13);
            this.lblCategoriaFiltro.TabIndex = 9;
            this.lblCategoriaFiltro.Text = "Tipo de Veiculo:";
            // 
            // txtCategoriaFiltro
            // 
            this.txtCategoriaFiltro.Location = new System.Drawing.Point(313, 8);
            this.txtCategoriaFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategoriaFiltro.Name = "txtCategoriaFiltro";
            this.txtCategoriaFiltro.Size = new System.Drawing.Size(114, 20);
            this.txtCategoriaFiltro.TabIndex = 10;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(450, 8);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 24);
            this.btnFiltrar.TabIndex = 11;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnConfirmarVenda
            // 
            this.btnConfirmarVenda.Location = new System.Drawing.Point(38, 325);
            this.btnConfirmarVenda.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarVenda.Name = "btnConfirmarVenda";
            this.btnConfirmarVenda.Size = new System.Drawing.Size(112, 32);
            this.btnConfirmarVenda.TabIndex = 0;
            this.btnConfirmarVenda.Text = "Confirmar Venda";
            this.btnConfirmarVenda.UseVisualStyleBackColor = true;
            this.btnConfirmarVenda.Click += new System.EventHandler(this.btnConfirmarVenda_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(165, 325);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(112, 32);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dgvItensVenda
            // 
            this.dgvItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensVenda.Location = new System.Drawing.Point(38, 41);
            this.dgvItensVenda.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItensVenda.Name = "dgvItensVenda";
            this.dgvItensVenda.Size = new System.Drawing.Size(525, 228);
            this.dgvItensVenda.TabIndex = 2;
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Location = new System.Drawing.Point(38, 284);
            this.lblPrecoVenda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(87, 13);
            this.lblPrecoVenda.TabIndex = 3;
            this.lblPrecoVenda.Text = "Preço de Venda:";
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.Location = new System.Drawing.Point(112, 284);
            this.txtPrecoVenda.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(76, 20);
            this.txtPrecoVenda.TabIndex = 4;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(225, 284);
            this.lblQuantidade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 5;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(300, 284);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(76, 20);
            this.txtQuantidade.TabIndex = 6;
            // 
            // FormVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 406);
            this.Controls.Add(this.txtCategoriaFiltro);
            this.Controls.Add(this.lblCategoriaFiltro);
            this.Controls.Add(this.txtNomeFiltro);
            this.Controls.Add(this.lblNomeFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtPrecoVenda);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.dgvItensVenda);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnConfirmarVenda);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormVendas";
            this.Text = "Tela de Vendas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
