using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimuladorDeSeguros.Codigo_MASTER_PAGE
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica se os dados da simulação estão na Session
                if (Session["Nome"] != null && Session["DataNascimento"] != null && Session["CPF"] != null && Session["TipoSeguro"] != null && Session["ValorSeguro"] != null)
                {
                    lblNome.Text = Session["Nome"].ToString();
                    lblDataNascimento.Text = Session["DataNascimento"].ToString();
                    lblCPF.Text = Session["CPF"].ToString();
                    lblTipoSeguro.Text = Session["TipoSeguro"].ToString();
                    lblValorSeguro.Text = Session["ValorSeguro"].ToString();
                }
                else
                {
                    // Se não houver dados na Session, redireciona para a página de formulário
                    Response.Redirect("Form.aspx");
                }
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            // Volta para a página de formulário
            Response.Redirect("Form.aspx");
        }
    }
}
