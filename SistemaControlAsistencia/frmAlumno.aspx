<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAlumno.aspx.cs" Inherits="SistemaControlAsistencia.frmAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Mantenimiento de la tabla Alumno</h2>

        <div class="form-group">
            <label for="txtNombre" class="control-label">Nombre</label>
            <asp:RequiredFieldValidator ID="rvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Obligatorio nombre" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCursoGrado" class="control-label">Curso/Grado</label>
            <asp:RequiredFieldValidator ID="rvCursoGrado" runat="server" ControlToValidate="txtCursoGrado" ErrorMessage="Obligatorio curso/grado" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtCursoGrado" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNivel" class="control-label">Nivel</label>
            <asp:RequiredFieldValidator ID="rvNivel" runat="server" ControlToValidate="txtNivel" ErrorMessage="Obligatorio nivel" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtNivel" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTelefono" class="control-label">Teléfono</label>
            <asp:RequiredFieldValidator ID="rvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Obligatorio teléfono" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCodUsuario" class="control-label">CodUsuario</label>
            <asp:RequiredFieldValidator ID="rvCodUsuario" runat="server" ControlToValidate="txtCodUsuario" ErrorMessage="Obligatorio codusuario" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtCodUsuario" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtDireccion" class="control-label">Dirección</label>
            <asp:RequiredFieldValidator ID="rvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Obligatorio dirección" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Agregar"/>
            <br />
        </div>

        <div class="form-group">
            <asp:ValidationSummary ID="vsAgregar" runat="server" ValidationGroup="Agregar" />
        </div>

        
        <div class="form-group">
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" Placeholder="Buscar por nombre"></asp:TextBox>
            <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
            <asp:Button Text="Ver Todos los Alumnos" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        </div>

        <div class="form-group">
            <asp:GridView runat="server" ID="gvAlumno" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvAlumno_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="CursoGrado" HeaderText="Curso/Grado" />
                    <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="CodUsuario" HeaderText="CodUsuario" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdAlumno") %>' CssClass="btn btn-warning" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdAlumno") %>' CssClass="btn btn-danger" OnClientClick="return confirm('¿Está seguro de que desea eliminar este alumno?');"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>
    </div>
</asp:Content>
