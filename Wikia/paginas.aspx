<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="paginas.aspx.cs" Inherits="Wikia.paginas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="contenedor">
        <h1>PAGINAS PARA VER MANGA</h1>
        <div class="textos">     
            <asp:Repeater ID="rpDatos" runat="server">
            <ItemTemplate>
                <div class="texto">
                    <h3><%#Eval("cod") %></h3>
                    
                    <a href=<%#Eval("link") %>>
                        <p><%#Eval("pagina") %></p>
                    </a>
         
                </div>
            </ItemTemplate>
        </asp:Repeater>     
        </div> 
    </div>
</asp:Content>
