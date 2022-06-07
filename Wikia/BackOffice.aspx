<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackOffice.aspx.cs" Inherits="Wikia.BackOffice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h1 style = "font-size:30px; color: #fff; width: 100%; text-align:center">Editar información del sitio</h1>

    <!--Tabla Concepto-->
    <div class="contenedor-backoffice" style=" display:flex; justify-content: center ">
        <div style="background-color: #fff; padding: 10px; width: 600px">
            <h2  style = "font-size:20px"">Editar Concepto</h2>
            <asp:TextBox ID="txtInformacion" runat="server" Width="500px" Height="150px" TextMode="MultiLine"></asp:TextBox>
            <br/>
            <asp:Button ID="btnEditarInformación" runat="server" Text="Editar información" OnClick="ActualizarInformacion"/>
        </div>
    </div>
    <br />
    <br />

    <!--Tabla Links-->
    <div class="contenedor-backoffice" style=" display:flex; justify-content: center ">
        <div style="background-color: #fff; padding: 10px; width: 600px">
             <h2  style = "font-size:20px; width:600px">Editar Links</h2>
            <asp:DropDownList ID="cbSitios" runat="server"></asp:DropDownList><asp:Button ID="btnLlenarSitio" runat="server" Text="Llenar" OnClick="LlenarSitio" />
            <h3 style =" font-size: 18px">Datos</h3>
            <asp:TextBox ID="txtCodigoPagina" runat="server"></asp:TextBox><asp:Label ID="Label1" runat="server" Text=" Código del sitio"></asp:Label><br /><br />
            <asp:TextBox ID="txtNombrePagina" runat="server"></asp:TextBox><asp:Label ID="Label2" runat="server" Text=" Nombre del sitio"></asp:Label><br /><br />
            <asp:TextBox ID="txtLinkPagina" runat="server"></asp:TextBox><asp:Label ID="Label3" runat="server" Text=" Link del sitio"></asp:Label><br /><br />
            <asp:Button ID="btnEditarLink" runat="server" Text="Editar link" OnClick="ActualizarLink" />
            <asp:Button ID="btnEliminarLink" runat="server" Text="Eliminar link" OnClick="EliminarLink" />
            <asp:Button ID="btnCrearLink" runat="server" Text="Crear link" OnClick="CrearLink" />
        </div>
     </div>
    <br />
    <br />

    <!--Tabla Tipos de manga-->
    <div class="contenedor-backoffice" style="display:flex; justify-content: center">
        <div style="background-color: #fff; padding: 10px; width: 600px">
            <h2 style = "font-size:20px">Editar Tipos de Magas</h2>
            <asp:DropDownList ID="cbTipos" runat="server"></asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Llenar" OnClick="LlenarTipo" />
            <h3 style =" font-size: 18px">Datos</h3>
            <asp:TextBox ID="txtCodigoTipo" runat="server"></asp:TextBox><asp:Label ID="Label4" runat="server" Text=" Código"></asp:Label><br /><br />
            <asp:TextBox ID="txtNombreTipo" runat="server"></asp:TextBox><asp:Label ID="Label5" runat="server" Text=" Nombre"></asp:Label><br /><br />
            <asp:Label ID="Label9" runat="server" Text=" Descripción" ForeColor="White"></asp:Label><br />
            <asp:TextBox ID="txtDescripcion" runat="server" Width="500px" Height="150px" TextMode="MultiLine"></asp:TextBox><br /><br />
            <asp:Button ID="btnEditarTipo" runat="server" Text="Editar tipo" OnClick="ActualizarTipo"/>
            <asp:Button ID="btnEliminarTipo" runat="server" Text="Eliminar Tipo" OnClick="EliminarTipo"/>
            <asp:Button ID="btnCrearTipo" runat="server" Text="Crear tipo" OnClick="CrearTipo"/>
        </div>
    </div>
    <br />
    <br />

    <!--Tabla Mangas-->
    <div class="contenedor-backoffice" style="display:flex; justify-content: center;margin: 0 0 20px 0">
        <div style="background-color: #fff; padding: 10px; width:600px">
            <h2 style = "font-size:20px">Editar Mangas</h2>
            <asp:DropDownList ID="cbMangas" runat="server"></asp:DropDownList><asp:Button ID="Button2" runat="server" Text="Llenar" OnClick="LlenarManga" />
            <br />
            <h3 style =" font-size: 18px">Datos</h3>
            <asp:TextBox ID="txtCoidigoManga" runat="server"></asp:TextBox><asp:Label ID="Label7" runat="server" Text=" Código"></asp:Label><br /><br />
            <asp:TextBox ID="txtNombreManga" runat="server"></asp:TextBox><asp:Label ID="Label8" runat="server" Text=" Nombre"></asp:Label><br /><br />
            <asp:Button ID="btnEditarMangas" runat="server" Text="Editar Manga" OnClick="ActualizarManga"/>
            <asp:Button ID="btnEliminarManga" runat="server" Text="Eliminar Manga" OnClick="EliminarManga"/>
            <asp:Button ID="btnCrearManga" runat="server" Text="Crear Manga" OnClick="CrearManga"/>
         </div>
    </div>
</asp:Content>
