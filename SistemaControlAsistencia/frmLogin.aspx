<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="SistemaControlAsistencia.frmLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de Sesión - Control de Asistencia</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Iniciar Sesión</h2>
            <div>
                <label for="txtUsuario">Usuario:</label>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Contraseña:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnIniciar" runat="server" Text="Iniciar Sesión" OnClick="btnIniciar_Click" />
            </div>
            <div>
                <asp:CheckBox ID="chkRecordatorio" runat="server" Text="Recordarme la próxima vez" />
            </div>
            <div>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
