<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublicador.Master" AutoEventWireup="true" CodeBehind="Publicador.aspx.cs" Inherits="Desempenio2.MatiasGomez.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContenedor" runat="server">
    <h2>Bienvenido, Publicador</h2>
    <br />
    <h2>Panel Publicador</h2>
        <label>
        Seleccione el Archivo (Solo .jpg / .jpeg):</label><br />
    <asp:FileUpload ID="fuImagen" runat="server" />
    &nbsp;
    &nbsp;&nbsp;<br />
        <br />

    
    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar Imagen" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Label ID="lblStatus" runat="server"></asp:Label>

        <br />
    <br />

    
    <label>Seleccione una imagen para Modificar o Eliminar:</label><br />
    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="300px" Height="150px"></asp:ListBox>
        <br />
    <br />
    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Cambiar Nombre" Width="178px" />
    &nbsp;&nbsp;

    <label>&nbsp;Nombre de la imagen a cambiar:</label>&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNombreImagen" runat="server" Width="250px"></asp:TextBox>
    <br />
    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" 
        OnClientClick="return confirm('¿Está seguro de que desea eliminar esta imagen de forma permanente? Se borrará también del servidor.');"
        Text="Eliminar Imagen" />
        <br />

    
        </div>
</asp:Content>
