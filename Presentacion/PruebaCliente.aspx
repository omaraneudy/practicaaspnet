<%@ Page Title="Cliente" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PruebaCliente.aspx.cs" Inherits="Presentacion.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <label>Código:</label>
        <asp:TextBox ID="txtCodigoCli" runat="server" OnTextChanged="txtCodigoCli_TextChanged" Enabled="true" AutoPostBack="true"></asp:TextBox>
        <label>Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" Enabled="false" MaxLength="30"></asp:TextBox>
        <label>Dirección:</label>
        <asp:TextBox ID="txtDireccion" runat="server" Enabled="false" MaxLength="40"></asp:TextBox>
        <label>Teléfono:</label>
        <asp:TextBox ID="txtTelefono" runat="server" Enabled="false" MaxLength="10"></asp:TextBox>
        <label>Fecha Creación:</label>
        <asp:TextBox ID="txtFechaCreacion" runat="server" Enabled="false"></asp:TextBox>
        <asp:Button ID="btnAgregar" Text="Agregar" runat="server" OnClick="btnAgregar_Click" UseSubmitBehavior="false" CausesValidation="false" />
        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" Visible="false" OnClick="btnGuardar_Click" UseSubmitBehavior="false" CausesValidation="false" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="false" OnClick="btnModificar_Click" UseSubmitBehavior="false" CausesValidation="false" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="btnActualizar_Click" UseSubmitBehavior="false" CausesValidation="false" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelar_Click" UseSubmitBehavior="false" CausesValidation="false" />

        <asp:RadioButton ID="rbMasculino" runat="server" Text="Masculino" GroupName="sexo" Enabled="false" Checked="true" />
        <asp:RadioButton ID="rbFemenino" runat="server" Text="Femenino" GroupName="sexo" Enabled="false" />
        <asp:DropDownList ID="ddlEstado" runat="server">
            <asp:ListItem Value="A">Activo</asp:ListItem>
            <asp:ListItem Value="I">Nulo</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lblEstado" Text="----" runat="server"></asp:Label>

    </div>

    <div>
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" DataKeyNames="id_cli" 
            OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="id_cli"/>
                <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                <asp:BoundField HeaderText="Dirección" DataField="direccion" />
                <asp:BoundField HeaderText="Teléfono" DataField="telefono" />
                <asp:BoundField HeaderText="Fecha Registrado" DataField="fechacreado" />
                <asp:BoundField HeaderText="Sexo" DataField="sexo" />
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
