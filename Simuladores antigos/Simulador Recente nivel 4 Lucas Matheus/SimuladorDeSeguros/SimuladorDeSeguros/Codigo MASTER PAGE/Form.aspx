<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Codigo_MASTER_PAGE/MasterPage.master" CodeBehind="Form.aspx.cs" Inherits="SimuladorDeSeguros.Codigo_MASTER_PAGE.Form" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Simulação de Seguro</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    
    <div>
        <label for="txtNome">Nome:</label>
        <asp:TextBox ID="txtNome" runat="server" />
        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" ErrorMessage="Nome é obrigatório" ForeColor="Red" />
    </div>

    <div>
        <label for="calDataNascimento">Data de Nascimento:</label>
        <asp:TextBox ID="txtDataNascimento" runat="server" />
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDataNascimento" Format="dd/MM/yyyy" />
        <asp:RequiredFieldValidator ID="rfvDataNascimento" runat="server" ControlToValidate="txtDataNascimento" ErrorMessage="Data de nascimento é obrigatória" ForeColor="Red" />
    </div>

    <div>
        <label for="txtCPF">CPF:</label>
        <asp:TextBox ID="txtCPF" runat="server" />
        <asp:RegularExpressionValidator ID="revCPF" runat="server" ControlToValidate="txtCPF" ValidationExpression="\d{3}\.\d{3}\.\d{3}-\d{2}" ErrorMessage="CPF inválido" ForeColor="Red" />
    </div>

    <div>
        <label for="ddlTipoSeguro">Tipo de Seguro:</label>
        <asp:DropDownList ID="ddlTipoSeguro" runat="server">
            <asp:ListItem Text="Seguro de vida" Value="vida" />
            <asp:ListItem Text="Seguro de morte acidental" Value="morte_acidental" />
            <asp:ListItem Text="Seguro contra acidentes pessoais" Value="acidentes_pessoais" />
            <asp:ListItem Text="Seguro de saúde" Value="saude" />
            <asp:ListItem Text="Seguro de automóvel" Value="automovel" />
            <asp:ListItem Text="Seguro residencial" Value="residencial" />
            <asp:ListItem Text="Seguro patrimonial" Value="patrimonial" />
            <asp:ListItem Text="Seguro empresarial" Value="empresarial" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTipoSeguro" runat="server" ControlToValidate="ddlTipoSeguro" InitialValue="" ErrorMessage="Selecione um tipo de seguro" ForeColor="Red" />
    </div>

    <asp:Button ID="btnCalcular" runat="server" Text="Calcular Seguro" OnClick="btnCalcular_Click" />
</asp:Content>
