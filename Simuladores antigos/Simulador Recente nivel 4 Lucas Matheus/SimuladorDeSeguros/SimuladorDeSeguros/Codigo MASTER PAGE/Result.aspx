<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="SimuladorDeSeguros.Codigo_MASTER_PAGE.Result" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Resultado da Simulação</h2>
    
    <div>
        <label>Nome:</label>
        <asp:Label ID="lblNome" runat="server" />
    </div>

    <div>
        <label>Data de Nascimento:</label>
        <asp:Label ID="lblDataNascimento" runat="server" />
    </div>

    <div>
        <label>CPF:</label>
        <asp:Label ID="lblCPF" runat="server" />
    </div>

    <div>
        <label>Tipo de Seguro Selecionado:</label>
        <asp:Label ID="lblTipoSeguro" runat="server" />
    </div>

    <div>
        <label>Valor do Seguro:</label>
        <asp:Label ID="lblValorSeguro" runat="server" />
    </div>

    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
</asp:Content>
