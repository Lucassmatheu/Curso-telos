<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaConsultarLivros.aspx.cs" Inherits="SimuladorGerenciamentoBiblioteca.TelaConsultarLivros" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consultar Livros</title>
</head>
<body>
    <form id="formConsultar" runat="server">
        <!-- ScriptManager dentro do form -->
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div>
            <!-- Botões de consulta e cadastro -->
            <asp:Button ID="btnCadastroLivro" runat="server" Text="Cadastrar Livro" OnClick="btnCadastroLivro_Click" />
            <asp:Button ID="btnConsultarLivros" runat="server" Text="Consultar Livros" OnClick="btnConsultarLivros_Click" />

            <br /><br />

            <!-- Controles de entrada de dados para consulta de livro -->
            <asp:Label ID="lblTitulo" runat="server" Text="Título:" />
            <asp:TextBox ID="txtTitulo" runat="server" />
            <br />

            <asp:Label ID="lblAutor" runat="server" Text="Autor:" />
            <asp:TextBox ID="txtAutor" runat="server" />
            <br />

            <asp:Label ID="lblISBN" runat="server" Text="ISBN:" />
            <asp:TextBox ID="txtISBN" runat="server" />
            <br />

            <asp:Label ID="lblPaginas" runat="server" Text="Páginas:" />
            <asp:TextBox ID="txtPaginas" runat="server" />
            <br />

            <asp:Label ID="lblEdicao" runat="server" Text="Edição:" />
            <asp:TextBox ID="txtEdicao" runat="server" />
            <br />

            <!-- GridView para exibir os livros -->
            <asp:GridView ID="dgvLivros" runat="server" AutoGenerateColumns="True" EmptyDataText="Nenhum livro encontrado." />
        </div>
    </form>
</body>
</html>
