<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaAuxiliar.aspx.cs" Inherits="SistemaControlAsistencia.frmSistemaAuxiliar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="form-group">
        <label for="ddlNivel">Seleccionar Nivel:</label>
        <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged">
            <asp:ListItem Text="Seleccionar Nivel" Value=""></asp:ListItem>
            <asp:ListItem Text="Primaria" Value="Primaria"></asp:ListItem>
            <asp:ListItem Text="Secundaria" Value="Secundaria"></asp:ListItem>
        </asp:DropDownList>
    </div>

   
    <div class="form-group">
        <label for="ddlGrado">Seleccionar Grado:</label>
        <asp:DropDownList ID="ddlGrado" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
   
        <div class="form-group">
            <label for="ddlAsignatura">Seleccionar Asignatura:</label>
            <asp:DropDownList ID="ddlAsignatura" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>



    <div class="form-group">
        <label for="ddlTrimestre">Seleccionar Trimestre:</label>
        <asp:DropDownList ID="ddlTrimestre" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccionar Trimestre" Value=""></asp:ListItem>
            <asp:ListItem Text="1er Trimestre" Value="1er Trimestre"></asp:ListItem>
            <asp:ListItem Text="2do Trimestre" Value="2do Trimestre"></asp:ListItem>
            <asp:ListItem Text="3er Trimestre" Value="3er Trimestre"></asp:ListItem>
        </asp:DropDownList>
    </div>

    
    <div class="form-group">
        <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-primary" OnClick="btnGenerarReporte_Click" />
    </div>

    
   <asp:GridView ID="gvReporteAsistencia" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NombreAlumno" HeaderText="Alumno" />
            <asp:BoundField DataField="CursoGrado" HeaderText="Curso" />
            <asp:BoundField DataField="Asignatura" HeaderText="Asignatura" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
        </Columns>
    </asp:GridView>

  


    <div class="form-group">
    
    </div>

    
    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info"></asp:Label>

</asp:Content>
