<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaCadastroLivro.aspx.cs" Inherits="SimuladorGerenciamentoBiblioteca.TelaCadastroLivro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastrar e Consultar Livro</title>
</head>
<body>
    <form id="formCadastro" runat="server">
        <div>
            <!-- Campos para o cadastro do livro -->
            <asp:Label ID="lblTitulo" runat="server" Text="Título:" AssociatedControlID="txtTitulo"></asp:Label>
            <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" InitialValue="" ErrorMessage="Campo obrigatório" ForeColor="Red" /><br />

            <asp:Label ID="lblAutor" runat="server" Text="Autor:" AssociatedControlID="txtAutor"></asp:Label>
            <asp:TextBox ID="txtAutor" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAutor" runat="server" ControlToValidate="txtAutor" InitialValue="" ErrorMessage="Campo obrigatório" ForeColor="Red" /><br />

            <asp:Label ID="lblISBN" runat="server" Text="ISBN:" AssociatedControlID="txtISBN"></asp:Label>
            <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvISBN" runat="server" ControlToValidate="txtISBN" InitialValue="" ErrorMessage="Campo obrigatório" ForeColor="Red" /><br />

            <asp:Label ID="lblPaginas" runat="server" Text="Páginas:" AssociatedControlID="txtPaginas"></asp:Label>
            <asp:TextBox ID="txtPaginas" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPaginas" runat="server" ControlToValidate="txtPaginas" InitialValue="" ErrorMessage="Campo obrigatório" ForeColor="Red" /><br />

            <asp:Label ID="lblEdicao" runat="server" Text="Edição:" AssociatedControlID="txtEdicao"></asp:Label>
            <asp:TextBox ID="txtEdicao" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEdicao" runat="server" ControlToValidate="txtEdicao" InitialValue="" ErrorMessage="Campo obrigatório" ForeColor="Red" /><br />

            <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade de Cópias:" AssociatedControlID="txtQuantidadeCopias"></asp:Label>
            <asp:TextBox ID="txtQuantidadeCopias" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvQuantidade" runat="server" ControlToValidate="txtQuantidadeCopias" InitialValue="" ErrorMessage="Campo obrigatório" ForeColor="Red" /><br />

            <asp:Label ID="lblDisponibilidade" runat="server" Text="Disponibilidade:" AssociatedControlID="ddlDisponibilidade"></asp:Label>
            <asp:DropDownList ID="ddlDisponibilidade" runat="server">
                <asp:ListItem Text="Disponível" Value="true"></asp:ListItem>
                <asp:ListItem Text="Indisponível" Value="false"></asp:ListItem>
            </asp:DropDownList><br />

            <!-- Botões para Cadastrar e Consultar Livros -->
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar Livros" OnClick="btnConsultar_Click" /><br /><br />

            <!-- Label para exibir a mensagem de sucesso -->
            <asp:Label ID="lblMensagem" runat="server" ForeColor="Green" Visible="false"></asp:Label>

            <!-- Campos para Pesquisa -->
          


            <!-- GridView para exibir os resultados da pesquisa -->
            <asp:GridView ID="dgvLivros" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" OnRowCommand="dgvLivros_RowCommand" EmptyDataText="Nenhum livro encontrado.">
                <Columns>
                      <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" SortExpression="Titulo" />
                    <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                    <asp:BoundField DataField="Paginas" HeaderText="Páginas" SortExpression="Paginas" />
                    <asp:BoundField DataField="Edicao" HeaderText="Edição" SortExpression="Edicao" />
                    <asp:BoundField DataField="Quantidade" HeaderText="Quantidade de Cópias" SortExpression="Quantidade" />
                    <asp:BoundField DataField="Disponivel" HeaderText="Disponibilidade" SortExpression="Disponivel" />

                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="Excluir" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Tem certeza que deseja excluir este livro?');" />
                            <asp:Button ID="btnEmprestar" runat="server" Text="Emprestar" CommandName="Emprestar" CommandArgument='<%# Eval("Id") %>' />
                            <asp:Button ID="btnDevolver" runat="server" Text="Devolver" CommandName="Devolver" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
