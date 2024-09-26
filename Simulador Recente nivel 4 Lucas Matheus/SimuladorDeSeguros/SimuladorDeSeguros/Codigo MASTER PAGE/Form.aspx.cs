using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimuladorDeSeguros.Codigo_MASTER_PAGE
{
    public partial class Form : System.Web.UI.Page
    {
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            // Armazenando dados na sessão para a página de resultado
            Session["Nome"] = txtNome.Text;
            Session["DataNascimento"] = txtDataNascimento.Text;
            Session["CPF"] = txtCPF.Text;
            Session["TipoSeguro"] = ddlTipoSeguro.SelectedItem.Text;

            // Redirecionando para a página de resultado
            Response.Redirect("Result.aspx");
        }
    }
}