<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tipos.aspx.cs" Inherits="Wikia.tipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="contenedor">
        <h1>Generos De Manga</h1>
        <div class="textos">     
            <asp:Repeater ID="rpDatos" runat="server">
            <ItemTemplate>
                <div class="texto">
                    <h3><%#Eval("genero") %></h3>
                    <p><%#Eval("descripcion") %></p>
         
                </div>
            </ItemTemplate>
        </asp:Repeater>     
        </div> 
    </div>
</asp:Content>
