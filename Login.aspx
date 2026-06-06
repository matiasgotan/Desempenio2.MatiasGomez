<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAnonimo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Desempenio2.MatiasGomez.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContenedor" runat="server">
        <h2>Login de Usuario</h2>
        <br />

        Ingrese su Mail de usuario:
        <asp:TextBox ID="txtMail" runat="server" Width="227px" TextMode="Email"  Placeholder="nombre@dominio.com"></asp:TextBox>
        
        
        <asp:RequiredFieldValidator ID="rfvMailLogin" runat="server" 
            ControlToValidate="txtMail" 
            ErrorMessage="El correo es requerido para ingresar." 
            ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        
        
        <asp:RegularExpressionValidator ID="revMailLogin" runat="server" 
            ControlToValidate="txtMail" 
            ErrorMessage="Formato de correo inválido." 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
        
        <br />
        <br />
        
        <asp:Button ID="Ingresar" runat="server" Text="Ingresar" OnClick="Ingresar_Click" />
        
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
