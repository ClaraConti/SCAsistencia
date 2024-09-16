<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAlumno.aspx.cs" Inherits="SistemaControlAsistencia.frmAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Mantenimiento de la tabla Alumno</h2>

        <div class="form-group">
            <label for="txtNombre" class="control-label">Nombre</label>
            <asp:RequiredFieldValidator ID="rvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre es obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTelefono" class="control-label">Telefono</label>
            <asp:RequiredFieldValidator ID="rvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Telefono es obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCodUsuario" class="control-label">CodUsuario</label>
            <asp:RequiredFieldValidator ID="rvCodUsuario" runat="server" ControlToValidate="txtCodUsuario" ErrorMessage="CodUsuario es obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtCodUsuario" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este alumno?');" ValidationGroup="Eliminar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Actualizar"/>
            <br />
        </div>
        <div class="form-group">
            <asp:ValidationSummary ID="vsEliminar" runat="server" ValidationGroup="Eliminar" />
            <asp:ValidationSummary ID="vsAgregar" runat="server" ValidationGroup="Agregar" />
            <asp:RequiredFieldValidator ID="rvBuscarNombre" runat="server" ControlToValidate="txtBuscar" ErrorMessage="Nombre es obligatorio para buscar" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Alumnos" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        <div class="form-group">
            <asp:GridView runat="server" ID="gvAlumno" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvAlumno_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>
    </div>
</asp:Content>
