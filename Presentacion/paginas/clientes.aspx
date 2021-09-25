<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="Presentacion.paginas.clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Clientes</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <label>Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <asp:Button ID="btnAgregar" Text="Agregar" runat="server" OnClick="btnAgregar_Click"/>
            
        </div>
    </form>
    
</body>
    
</html>
