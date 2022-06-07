<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Wikia._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="contenedor">
        <h1>¿QUE ES EL MANGA?</h1>
    </div>
    <div class="contenedor">
        <div class="texto">     
            <asp:Repeater ID="rpDatos" runat="server">
            <ItemTemplate>
                <div class="producto">
                    <h3><%#Eval("texto") %></h3>

                    <img class="img-logo" src="image/mangamix.jpg"/>

                </div>
            </ItemTemplate>
        </asp:Repeater>     
        </div> 
    </div>
  
</asp:Content>
