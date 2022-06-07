<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Wikia.top" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="contenedor">
        <h1>TOP-MEJORES MANGAS</h1>
        <div class="textos">     
            <asp:Repeater ID="rpDatos" runat="server">
            <ItemTemplate>
                <div class="texto">
                    <h3><%#Eval("cod") %></h3>
                    <p><%#Eval("nom") %></p>
         
                </div>
            </ItemTemplate>
        </asp:Repeater>     
        </div> 
    </div>
</asp:Content>
