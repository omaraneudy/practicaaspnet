<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Presentacion.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upProducto" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <h1 class="text-center">Productos</h1>
                <hr />
                <div class="form-group text-right">
                    <asp:LinkButton ID="lbNuevo" runat="server" CssClass="btn btn-primary" OnClick="lbNuevo_Click" CausesValidation="false">Nuevo</asp:LinkButton>
                    <asp:LinkButton ID="lbModificar" runat="server" CssClass="btn btn-primary" Visible="false" OnClick="lbModificar_Click" CausesValidation="false">Modificar</asp:LinkButton>
                    <asp:LinkButton ID="lbGrabar" runat="server" CssClass="btn btn-primary" Visible="false" OnClick="lbGrabar_Click">Grabar </asp:LinkButton>
                    <asp:LinkButton ID="lbCancelar" runat="server" CssClass="btn btn-primary" Visible="false" OnClick="lbCancelar_Click" CausesValidation="false">Cancelar</asp:LinkButton>
                    <asp:LinkButton ID="lbEliminar" runat="server" CssClass="btn btn-primary" Visible="false" OnClick="lbEliminar_Click" CausesValidation="false">Eliminar</asp:LinkButton>
                    <asp:LinkButton ID="lbReporteProducto" runat="server" CssClass="btn btn-primary" Visible="true" OnClick="lbReporteProducto_Click" CausesValidation="false">Reporte</asp:LinkButton>

                </div>
                <div class="well">

                    <div id="div_error" runat="server" visible="false"></div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Mantenimiento Productos</h3>

                        </div>
                        <div class="panel-body">
                            <div class="col-xs-12 col-lg-2">
                                <div class="form-group">

                                    <label class="control-label">Código producto</label>
                                    <asp:TextBox ID="txtCodigoProducto" CssClass="form-control" runat="server" OnTextChanged="txtCodigoProducto_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte_codigo_producto" runat="server" FilterType="Numbers"
                                        TargetControlID="txtCodigoProducto" />

                                </div>
                            </div>
                            <div class="col-xs-12 col-lg-2">
                                <div class="form-group">

                                    <label class="control-label">Nombre Producto</label>
                                    <asp:TextBox ID="txtNombreProducto" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNombreProducto" runat="server" ControlToValidate="txtNombreProducto"
                                        ErrorMessage="Debe llenar este campo" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <ajax:FilteredTextBoxExtender ID="fte_nombre" runat="server" FilterMode="InvalidChars" FilterType="Custom"
                                        TargetControlID="txtNombreProducto" InvalidChars="0123456789" />
                                </div>
                            </div>
                            <div class="col-xs-12  col-sm-4 col-md-5 col-lg-3">
                                <div class="form-group">

                                    <label class="control-label">Precio</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio"
                                        ErrorMessage="No debe dejar este campo vacio" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" FilterType="Custom"
                                        TargetControlID="txtPrecio" ValidChars="0123456789." />
                                </div>

                            </div>
                            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                <div class="form-group">
                                    <label class="control-label">Estado</label>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="ckbEstado" runat="server" Text="Habilitar" Enabled="false" Checked="true" />
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2">
                            <div class="form-group">
                                <label class="control-label">Buscar por nombre</label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <asp:CheckBox ID="cbActivarBusqueda" runat="server" OnCheckedChanged="cbActivarBusqueda_CheckedChanged" AutoPostBack="true" />
                                    </span>
                                    <asp:TextBox ID="txtBuscarProducto" runat="server" CssClass="form-control" OnTextChanged="txtBuscarProducto_TextChanged"
                                        AutoPostBack="true" Enabled="false">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 form-group">
                            <label class="">Estado de producto</label>
                               <div class="radio">
                                <label>
                                    <asp:RadioButton ID="rbTodos" runat="server" Text="Todos" GroupName="estado"  Checked="true" 
                                        OnCheckedChanged="rbEstadoActivo_CheckedChanged" AutoPostBack="true"/>
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <asp:RadioButton ID="rbEstadoActivo" runat="server" Text="Activo" GroupName="estado" 
                                        OnCheckedChanged="rbEstadoActivo_CheckedChanged" AutoPostBack="true"/>
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <asp:RadioButton ID="rbEstadoInactivo" runat="server" Text="Inactivo" GroupName="estado" 
                                        OnCheckedChanged="rbEstadoInactivo_CheckedChanged" AutoPostBack="true"  />
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Listado productos</h3>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="false"
                                DataKeyNames="id_producto" AllowPaging="true" CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvProducto_SelectedIndexChanged"
                                EmptyDataText="No hay datos para mostrar" OnPageIndexChanging="gvProducto_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="id_producto" />
                                    <asp:BoundField HeaderText="Nombre producto" DataField="nombre_producto" />
                                    <asp:BoundField HeaderText="Precio" DataField="precio" />
                                    <asp:BoundField HeaderText="Estado" DataField="estado_producto" />

                                </Columns>
                                <PagerSettings Mode="Numeric" Position="Bottom" PageButtonCount="10" />

                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
