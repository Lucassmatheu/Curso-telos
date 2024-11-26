using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerenciamentoBiblioteca.Interface
{
    partial class TelaPrincipal
    {
        private System.Windows.Forms.DataGridView dgvLivros;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtPaginas;
        private System.Windows.Forms.TextBox txtEdicao;
        private System.Windows.Forms.Button btnAdicionarLivro;
        private System.Windows.Forms.Button btnRemoverLivro;

        private void InitializeComponent()
        {
            this.dgvLivros = new System.Windows.Forms.DataGridView();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtPaginas = new System.Windows.Forms.TextBox();
            this.txtEdicao = new System.Windows.Forms.TextBox();
            this.btnAdicionarLivro = new System.Windows.Forms.Button();
            this.btnRemoverLivro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLivros
            // 
            this.dgvLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivros.Location = new System.Drawing.Point(12, 12);
            this.dgvLivros.Name = "dgvLivros";
            this.dgvLivros.Size = new System.Drawing.Size(240, 150);
            this.dgvLivros.TabIndex = 0;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(0, 0);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 20);
            this.txtTitulo.TabIndex = 0;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(0, 0);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(100, 20);
            this.txtAutor.TabIndex = 0;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(0, 0);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(100, 20);
            this.txtISBN.TabIndex = 0;
            // 
            // txtPaginas
            // 
            this.txtPaginas.Location = new System.Drawing.Point(0, 0);
            this.txtPaginas.Name = "txtPaginas";
            this.txtPaginas.Size = new System.Drawing.Size(100, 20);
            this.txtPaginas.TabIndex = 0;
            // 
            // txtEdicao
            // 
            this.txtEdicao.Location = new System.Drawing.Point(0, 0);
            this.txtEdicao.Name = "txtEdicao";
            this.txtEdicao.Size = new System.Drawing.Size(100, 20);
            this.txtEdicao.TabIndex = 0;
            // 
            // btnAdicionarLivro
            // 
            this.btnAdicionarLivro.Location = new System.Drawing.Point(12, 180);
            this.btnAdicionarLivro.Name = "btnAdicionarLivro";
            this.btnAdicionarLivro.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarLivro.TabIndex = 1;
            this.btnAdicionarLivro.Text = "Adicionar";
            this.btnAdicionarLivro.UseVisualStyleBackColor = true;
            this.btnAdicionarLivro.Click += new System.EventHandler(this.btnAdicionarLivro_Click);
            // 
            // btnRemoverLivro
            // 
            this.btnRemoverLivro.Location = new System.Drawing.Point(100, 180);
            this.btnRemoverLivro.Name = "btnRemoverLivro";
            this.btnRemoverLivro.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverLivro.TabIndex = 2;
            this.btnRemoverLivro.Text = "Remover";
            this.btnRemoverLivro.UseVisualStyleBackColor = true;
            this.btnRemoverLivro.Click += new System.EventHandler(this.btnRemoverLivro_Click);
            // 
            // TelaPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(317, 302);
            this.Controls.Add(this.btnAdicionarLivro);
            this.Controls.Add(this.btnRemoverLivro);
            this.Controls.Add(this.dgvLivros);
            this.Name = "TelaPrincipal";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
