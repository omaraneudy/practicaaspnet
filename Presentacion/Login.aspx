<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <title>Iniciar sesión</title>
</head>
<body>
    <div class="well center-block" style="max-width: 400px">
        <div class="panel panel-primary">
            <div id="div_error" runat="server" visible="false"></div>
            <div class="panel-heading">
                <h3 class="panel-title text-center">Hola</h3>
            </div>
            <div class="panel-body">
                <form id="form1" runat="server">

                    <div class="form-group-sm">
                        <label class="control-label text-center">Usuario</label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <div class="form-group-sm">
                            <label class="control-label text-center">Contraseña</label>
                            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" >
                        <asp:LinkButton ID="lkbIniciarSesion" runat="server" CssClass="btn btn-primary btn-block"
                             OnClick="lkbIniciarSesion_Click">Iniciar sesión</asp:LinkButton>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
