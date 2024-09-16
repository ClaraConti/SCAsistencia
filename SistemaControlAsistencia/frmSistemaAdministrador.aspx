<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaAdministrador.aspx.cs" Inherits="SistemaControlAsistencia.frmSistemaAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bienvenido Admin al sistema</h1>
    <div class="container mt-5">
        <asp:Button runat="server" ID="btnCerrar" Text="Cerrar sesión" OnClick="btnCerrar_Click" CssClass="btn btn-danger" />
    </div>

    <asp:Label ID="lblAdministrador" runat="server" CssClass="mt-3"></asp:Label>
    
    <div class="mt-4">
        <asp:Button runat="server" ID="btnCrudAlumno" Text="CRUD Alumno" OnClick="btnCrudAlumno_Click" CssClass="btn btn-primary" />
        <asp:Button runat="server" ID="btnCrudAuxiliar" Text="CRUD Auxiliar" OnClick="btnCrudAuxiliar_Click" CssClass="btn btn-secondary" />
        <asp:Button runat="server" ID="btnCrudDocente" Text="CRUD Docente" OnClick="btnCrudDocente_Click" CssClass="btn btn-success" />
        <asp:Button runat="server" ID="btnCrudAsistencia" Text="CRUD Asistencia" OnClick="btnCrudAsistencia_Click" CssClass="btn btn-warning" />
    </div>
</asp:Content>
