<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaAuxiliar.aspx.cs" Inherits="SistemaControlAsistencia.frmSistemaAuxiliar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-group">
        <label for="ddlCurso">Seleccionar Curso:</label>
        <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged">
            <asp:ListItem Text="Seleccionar Curso" Value=""></asp:ListItem>
        </asp:DropDownList>
    </div>
    
    <div class="form-group">
        <label for="ddlMes">Seleccionar Mes:</label>
        <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccionar Mes" Value=""></asp:ListItem>
            <asp:ListItem Text="Enero" Value="1"></asp:ListItem>
            <asp:ListItem Text="Febrero" Value="2"></asp:ListItem>
            <asp:ListItem Text="Marzo" Value="3"></asp:ListItem>
            <asp:ListItem Text="Abril" Value="4"></asp:ListItem>
            <asp:ListItem Text="Mayo" Value="5"></asp:ListItem>
            <asp:ListItem Text="Junio" Value="6"></asp:ListItem>
            <asp:ListItem Text="Julio" Value="7"></asp:ListItem>
            <asp:ListItem Text="Agosto" Value="8"></asp:ListItem>
            <asp:ListItem Text="Septiembre" Value="9"></asp:ListItem>
            <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
            <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
            <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
        </asp:DropDownList>
    </div>

    
    <div class="form-group">
        <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-primary" OnClick="btnGenerarReporte_Click" />
    </div>

    <asp:GridView ID="gvReporteAsistencia" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NombreAlumno" HeaderText="Alumno" />
            <asp:BoundField DataField="Mes" HeaderText="Mes" />
            <asp:BoundField DataField="Presentes" HeaderText="Presentes" />
            <asp:BoundField DataField="Faltas" HeaderText="Faltas" />
        </Columns>
    </asp:GridView>

   
    <div class="form-group">
        <h3>Alumnos Inscritos en el Curso</h3>
        <asp:GridView ID="gvAlumnosInscritos" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="NombreAlumno" HeaderText="Alumno" />
            </Columns>
        </asp:GridView>
    </div>

    
   
  
    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info"></asp:Label>
</asp:Content>
