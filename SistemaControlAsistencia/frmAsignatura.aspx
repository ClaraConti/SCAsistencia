<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsignatura.aspx.cs" Inherits="SistemaControlAsistencia.frmAsignatura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Mantenimiento de la tabla Asignatura</h2>

        <div class="form-group">
            <label for="txtNombreAsignatura" class="control-label">Nombre Asignatura</label>
            <asp:RequiredFieldValidator ID="rvNombreAsignatura" runat="server" ControlToValidate="txtNombreAsignatura" ErrorMessage="Obligatorio nombre de la asignatura" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtNombreAsignatura" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label for="txtDescripcion" class="control-label">Descripción</label>
            <asp:RequiredFieldValidator ID="rvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Obligatorio descripción" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlDocente" class="control-label">Docente</label>
            <asp:DropDownList runat="server" ID="ddlDocente" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Agregar" Visible="false"/>
            <br />
        </div>

        <div class="form-group">
            <asp:ValidationSummary ID="vsAgregar" runat="server" ValidationGroup="Agregar" />
        </div>

        <div class="form-group">
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" Placeholder="Buscar por nombre de asignatura"></asp:TextBox>
            <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
            <asp:Button Text="Ver Todas las Asignaturas" runat="server" ID="btnVerTodas" CssClass="btn btn-primary" OnClick="btnVerTodas_Click"/>
        </div>

        <div class="form-group">
            <asp:GridView runat="server" ID="gvAsignatura" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvAsignatura_RowCommand" DataKeyNames="IdAsignatura">
                <Columns>
                    <asp:BoundField DataField="NombreAsignatura" HeaderText="Nombre Asignatura" />
                    <asp:BoundField DataField="DescripcionAsignatura" HeaderText="Descripción" />
                    <asp:BoundField DataField="DocenteNombre" HeaderText="Docente" /> 
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdAsignatura") %>' CssClass="btn btn-warning" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdAsignatura") %>' CssClass="btn btn-danger" OnClientClick="return confirm('¿Está seguro de que desea eliminar esta asignatura?');"/>
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
