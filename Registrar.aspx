<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAnonimo.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Desempenio2.MatiasGomez.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContenedor" runat="server"> 
    <h2>Formulario de Registro</h2>
    <br />
    
    Ingrese su nombre de usuario (Email):
    <asp:TextBox ID="txtMail" runat="server" TextMode="Email" Width="227px" Placeholder="nombre@dominio.com"></asp:TextBox>
    
   
    <asp:RequiredFieldValidator ID="rfvMail" runat="server" 
        ControlToValidate="txtMail" 
        ErrorMessage="El correo es obligatorio." 
        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    
   
    &nbsp;<asp:RegularExpressionValidator 
        ID="revMail" 
        runat="server" 
        ControlToValidate="txtMail" 
        ErrorMessage="Formato de correo inválido." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ForeColor="Red" 
        Display="Dynamic"></asp:RegularExpressionValidator>
    
    <br />
    <br />
    
    Seleccione su tipo de usuario:
    <asp:DropDownList ID="tipoUsuario" runat="server" AutoPostBack="True">
        <asp:ListItem>Publicador</asp:ListItem>
        <asp:ListItem>Votante</asp:ListItem>
    </asp:DropDownList>
    
    <br />
    <br />
    
 
    Seleccione el color de fondo del formulario:
    <asp:DropDownList ID="ddlColor" runat="server" AutoPostBack="True" 
    OnSelectedIndexChanged="ddlColor_SelectedIndexChanged">
        <asp:ListItem Text="Amarillo" Value="#FFFFE0"></asp:ListItem>
        <asp:ListItem Text="Gris Claro" Value="#F0F0F0"></asp:ListItem>
        <asp:ListItem Text="Azul Claro" Value="#E6F2FF"></asp:ListItem>
    </asp:DropDownList>
    
    <br />
    <br />
    

    <asp:Button ID="Registrar" runat="server" Text="Registrar" OnClick="Registrar_Click" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
</asp:Content>