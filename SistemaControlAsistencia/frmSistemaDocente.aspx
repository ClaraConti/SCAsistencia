<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaDocente.aspx.cs" Inherits="SistemaControlAsistencia.frmSistemaDocente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bienvenido Docente al Sistema de Control de Asistencia</h1>
    
    <div class="container mt-5">
        <asp:Button runat="server" ID="btnCerrar" Text="Cerrar Sesión" OnClick="btnCerrar_Click" CssClass="btn btn-danger" />
        
        <h3 class="mt-3">Cursos Asignados</h3>
        <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="NombreCurso" HeaderText="Curso" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
            </Columns>
        </asp:GridView>
        
        <h3 class="mt-5">Registrar Asistencia</h3>
        <asp:DropDownList ID="ddlCursos" runat="server" CssClass="form-control mt-3" />
        <asp:Button runat="server" ID="btnRegistrarAsistencia" Text="Registrar Asistencia" OnClick="btnRegistrarAsistencia_Click" CssClass="btn btn-primary mt-3" />
    </div>
</asp:Content>
