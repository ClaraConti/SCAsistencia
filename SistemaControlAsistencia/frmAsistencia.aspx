<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsistencia.aspx.cs" Inherits="SistemaControlAsistencia.frmAsistencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Registrar Asistencia</h2>

       
        <div class="form-group">
            <label for="ddlCurso" class="control-label">Seleccionar Curso</label>
            <asp:DropDownList ID="ddlCurso" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
        </div>
        

        <div class="form-group">
            <h3>Calendario de Asistencia</h3>
            <asp:Calendar ID="calAsistencia" runat="server" OnSelectionChanged="calAsistencia_SelectionChanged" CssClass="calendar" />
           
        </div>
        <div>
             <asp:Label ID="lblFechaSeleccionada" runat="server" CssClass="alert alert-info"></asp:Label>
        </div>
        <p>
            ----------------------------------------------------------------
        </p>
       
        <div class="form-group">
            <label for="gvAlumnos" class="control-label">Alumnos en el Curso</label>
            <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdAlumno">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:TemplateField HeaderText="Asistencia">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAsistencia" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        
        <div class="form-group">
            <asp:Button ID="btnRegistrarAsistencia" runat="server" Text="Registrar Asistencia" OnClick="btnRegistrarAsistencia_Click" CssClass="btn btn-primary" />
        </div>

        
        <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info"></asp:Label>

       
        <div class="form-group">
            <h3>Asistencia Registrada</h3>
            <asp:GridView ID="gvAsistenciaRegistrada" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NombreAlumno" HeaderText="Alumno" />
                    <asp:BoundField DataField="Estado" HeaderText="Asistencia" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
