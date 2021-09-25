<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="Presentacion.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/Factura.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upFactura" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <div>
                    <h1 class="text-center">Factura</h1>
                    <hr />
                    <div class="form-group text-right">
                        <asp:LinkButton ID="lbNuevo" runat="server" CssClass="btn btn-primary" OnClick="lbNuevo_Click"
                            CausesValidation="false">Nuevo</asp:LinkButton>
                        <asp:LinkButton ID="lbModificar" runat="server" CssClass="btn btn-primary" OnClick="lbModificar_Click" Visible="false"
                            CausesValidation="false">Modificar</asp:LinkButton>
                        <asp:LinkButton ID="lbGrabar" runat="server" CssClass="btn btn-primary" OnClick="lbGrabar_Click"
                            CausesValidation="true" Visible="false">Grabar</asp:LinkButton>
                        <asp:LinkButton ID="lbCancelar" runat="server" CssClass="btn btn-primary" OnClick="lbCancelar_Click"
                            CausesValidation="false" Visible="false">Cancelar</asp:LinkButton>
                    </div>
                    <div class="well">
                        <div class="panel panel-primary">
                            <div id="div_error" runat="server"></div>
                            <div class="panel-heading">
                                <h3 class="panel-title text-center">Crear facturas</h3>
                            </div>
                            <div class="panel-body">

                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-lg-offset-8">
                                    <div class="form-group">
                                        <label class="control-label">Fecha</label>
                                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control date" Enabled="false"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2  ">
                                    <div class="form-group">
                                        <label class="control-label">Código de factura</label>
                                        <asp:TextBox ID="txtIdFactura" runat="server" CssClass="form-control"
                                            OnTextChanged="txtIdFactura_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="fte_codigo_factura" runat="server" FilterType="Numbers"
                                            TargetControlID="txtIdFactura" />
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Código de cliente</label>
                                        <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" Enabled="false"
                                            OnTextChanged="txtIdCliente_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtIdCliente" ID="rfvIdCliente" runat="server" ForeColor="Red"
                                            ErrorMessage="No puede dejar este campo vacio"></asp:RequiredFieldValidator>
                                        <ajax:FilteredTextBoxExtender ID="fte_codigo_cliente" runat="server" FilterType="Numbers"
                                            TargetControlID="txtIdCliente" />

                                    </div>
                                </div>
                                <%--                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Código de producto</label>
                                        <asp:TextBox ID="txtIdProducto" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>--%>


                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                    <div class="form-group">
                                        <label class="control-label">Nombre de cliente</label>
                                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Estado</label>
                                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" Enabled="false">
                                            <asp:ListItem Text="Activa" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="Nula" Value="I"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Balance</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">$</span>
                                            <asp:TextBox ID="txtBalance" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Valor</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">$</span>
                                            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title text-center">Detalle productos
                                </h3>
                            </div>
                            <div class="panel-body">

                                <div class="form-group">
                                    <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                        <div class="input-group">

                                            <asp:DropDownList ID="ddlListaProductos" runat="server" CssClass="form-control dropdown" Enabled="false">
                                                <asp:ListItem Text="Producto prueba"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="lbAgregarProducto" runat="server"
                                                CssClass="input-group-addon btn btn-primary btn-xs" Enabled="false"
                                                OnClick="lbAgregarProducto_Click">Agregar</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-offset-10">
                                        <div class="form-group ">
                                            <label class="control-label">Suma Total</label>
                                            <asp:TextBox ID="txtTotalSuperior" runat="server" CssClass="form-control input-sm" Enabled="false" ClientIDMode="Predictable"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group clearfix"></div>
                                <br />
                                <div class="form-group">
                                    <div>
                                        <asp:GridView ID="gvDetalleVenta" runat="server"
                                            EmptyDataText="No hay datos para mostrar" AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered table-hover" Enabled="false"
                                            DataKeyNames="id_re_factura_producto, id_factura, id_producto, nombre_producto"
                                            OnRowDataBound="gvDetalleVenta_RowDataBound" OnSelectedIndexChanged="gvDetalleVenta_SelectedIndexChanged"
                                            OnRowDeleting="gvDetalleVenta_RowDeleting">
                                            <Columns>
                                                <asp:BoundField HeaderText="Código" DataField="id_producto" HeaderStyle-Width="5" />
                                                <asp:BoundField HeaderText="Descripción" HeaderStyle-Width="15" DataField="nombre_producto" />
                                                <asp:TemplateField HeaderText="Cantidad" HeaderStyle-Width="10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control input-sm"
                                                            ClientIDMode="Predictable"
                                                            onkeyup="CalcularTotal(this.id)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="txtCantidad"
                                                            ErrorMessage="Debe llenar este campo" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <ajax:FilteredTextBoxExtender ID="fte_cantidad" runat="server" FilterMode="ValidChars" FilterType="Custom"
                                                            TargetControlID="txtCantidad" ValidChars="0123456789." />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Precio" HeaderStyle-Width="10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control input-sm"
                                                            ClientIDMode="Predictable"
                                                            onkeyup="CalcularTotal(this.id)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio"
                                                            ErrorMessage="Debe llenar este campo" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <ajax:FilteredTextBoxExtender ID="fte_precio" runat="server" FilterMode="ValidChars" FilterType="Custom"
                                                            TargetControlID="txtPrecio" ValidChars="0123456789." />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total" HeaderStyle-Width="10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control input-sm" Enabled="false"
                                                            ClientIDMode="Predictable"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Width="10">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblEliminar" runat="server" CssClass="btn btn-danger btn-xs"
                                                            CommandName="select" onkeyup="CalcularTotal(this.id)"> Quitar</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                        <%--<asp:TextBox ID="txt_total_filas" runat="server" CssClass="form-control hidden" Enabled="true"></asp:TextBox>--%>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
