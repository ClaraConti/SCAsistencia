<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaAlumno.aspx.cs" Inherits="SistemaControlAsistencia.frmSistemaAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Visualización de Faltas</h2>

        <div class="form-group">
            <asp:Label Text="Seleccione el curso para ver sus faltas" runat="server" CssClass="h5"></asp:Label>
            <asp:DropDownList ID="ddlCursos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCursos_SelectedIndexChanged" CssClass="form-control">
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:GridView runat="server" ID="gvFaltas" CssClass="table table-striped" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="FechaFalta" HeaderText="Fecha de Falta" />
                    <asp:BoundField DataField="Curso" HeaderText="Curso" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="form-group">
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>
