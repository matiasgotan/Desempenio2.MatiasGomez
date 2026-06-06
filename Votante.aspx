<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVotante.Master" AutoEventWireup="true" CodeBehind="Votante.aspx.cs" Inherits="Desempenio2.MatiasGomez.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContenedor" runat="server">
    <h2>Bienvenido, Votante</h2>
    <br />
    <h2>Panel Votante - Galería de Imágenes</h2>
    <br />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    
                    <asp:BoundField DataField="nombreImagen" HeaderText="Nombre de Imagen" />
                    
                    <asp:TemplateField HeaderText="Visualización">
                        <ItemTemplate>
                            <asp:Image ID="imgVoto" runat="server" ImageUrl='<%# "~/images/" + Eval("nombreArchivo") %>' Width="120px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Acción">
                        <ItemTemplate>
                            <asp:Button ID="btnVotar" runat="server" CommandName="Votar" CommandArgument='<%# Eval("id") %>' Text="👍 Votar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <br />
            
            <asp:Label ID="lblVotos" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>

                <h3>Mis votos realizados en esta sesión:</h3>
            <asp:BulletedList ID="blHistorialVotos" runat="server">
            </asp:BulletedList>


        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
</asp:Content>
