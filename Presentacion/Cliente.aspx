<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Presentacion.DiseñoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upPaginaCliente" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <div>
                    <h1 class="text-center">Página clientes</h1>
                    <hr />
                    <div class="form-group text-right">
                        <asp:LinkButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" OnClick="btnNuevo_Click" CausesValidation="false"></asp:LinkButton>
                        <asp:LinkButton ID="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-primary" Visible="false" OnClick="btnGrabar_Click"></asp:LinkButton>
                        <asp:LinkButton ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" Visible="false" OnClick="btnModificar_Click" CausesValidation="false"></asp:LinkButton>
                        <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" Visible="false" OnClick="btnCancelar_Click" CausesValidation="false"></asp:LinkButton>
                    </div>
                    <div class="well">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title text-center">Mantenimiento Clientes</h3>
                                <div id="div_error" runat="server" visible="false"></div>
                            </div>
                            <div class="panel-body">
                                <div class="col-xs-12 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Código</label>
                                        <asp:TextBox ID="txtCodigoCliente" runat="server" CssClass="form-control" OnTextChanged="txtCodigoCliente_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="fte_id_cliente" runat="server" TargetControlID="txtCodigoCliente"
                                            FilterType="Numbers" />
                                    </div>
                                </div>

                                <div class="col-xs-12 col-lg-3">
                                    <div class="form-group">
                                        <label class="control-label">Nombre</label>
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtNombre" ID="rfvNombre" runat="server" ForeColor="Red"
                                            ErrorMessage="No puede dejar este campo vacio"></asp:RequiredFieldValidator>
                                        <%--  <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                                            ErrorMessage="Debe Insertar un nombre" ></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-lg-3">
                                    <div class="form-group">
                                        <label class="control-label">Dirección</label>
                                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtDireccion" ID="rfvDireccion" runat="server" ForeColor="Red"
                                            ErrorMessage="No puede dejar este campo vacio"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Teléfono</label>
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="10" Enabled="false" >
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtTelefono" ID="rfvTelefono" runat="server" ForeColor="Red"
                                            ErrorMessage="No puede dejar este campo vacio"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Fecha Creado</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">#</span>
                                            <asp:TextBox ID="txtFechaCreado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            <span class="input-group-btn"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group clearfix"></div>
                                <div class="col-xs-12 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Sexo</label>
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButton ID="rbFemenino" runat="server" Text="Femenino" GroupName="sexo" Enabled="false" />
                                            </label>
                                        </div>
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButton ID="rbMasculino" runat="server" Text="Masculino" GroupName="sexo" Enabled="false" Checked="true" />
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-xs-12 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Notificación</label>
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox ID="ckbActivarNotificacion" runat="server" Text="Activar" Enabled="false" />
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-lg-2">
                                    <div class="form-group">
                                        <label class="control-label">Estado cliente</label>
                                        <asp:DropDownList ID="ddlEstadoCliente" runat="server" CssClass="form-control" Enabled="false">
                                            <asp:ListItem Value="A">Activo</asp:ListItem>
                                            <asp:ListItem Value="I">Nulo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-xs-12 col-lg-2">
                                        <label class="control-label">Comentario</label>
                                        <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Rows="2"
                                            Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="">
                                <label class="control-label">Filtrar por estado</label>
                                <asp:DropDownList ID="ddlFiltrarEstado" runat="server" CssClass="form-control"
                                    OnSelectedIndexChanged="ddlFiltrarEstado_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="A">Activo</asp:ListItem>
                                    <asp:ListItem Value="I">Nulo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        </br>
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title text-center">Listado clientes</h3>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <asp:GridView ID="gvCliente" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" DataKeyNames="id_cli"
                                        AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvCliente_SelectedIndexChanged" AllowPaging="true"
                                        EmptyDataText="No hay datos para mostrar"
                                        OnPageIndexChanging="gvCliente_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField HeaderText="Código" DataField="id_cli" />
                                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                            <asp:BoundField HeaderText="Dirección" DataField="direccion" />
                                            <asp:BoundField HeaderText="Teléfono" DataField="telefono" />
                                            <asp:BoundField HeaderText="Fecha Registrado" DataField="fechacreado" />
                                            <asp:BoundField HeaderText="Sexo" DataField="sexo" />
                                            <asp:BoundField HeaderText="Estado" DataField="estado" />
                                            <asp:BoundField HeaderText="Notificación" DataField="notificacion" />
                                            <%-- <asp:BoundField HeaderText="Comentario" DataField="comentario" />--%>
                                        </Columns>

                                        <PagerSettings Mode="Numeric" Position="Bottom" PageButtonCount="10" />

                                        <PagerStyle CssClass="pagination-ys" />

                                        <%--   <PagerTemplate>
                                            <ul class="pagination">

                                            </ul>
                                        </PagerTemplate>--%>
                                        <%--                               <PagerTemplate>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 70%">
                                                        <asp:Label ID="Páginas"
                                                            ForeColor="Blue"
                                                            Text="Selecciona una página:"
                                                            runat="server"></asp:Label>
                                                        <asp:DropDownList ID="ddlPage"
                                                            AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPage_SelectedIndexChanged"
                                                            runat="server">
                                                        </asp:DropDownList>
                                                        <asp:LinkButton ID="lnkPagina" runat="server">

                                                        </asp:LinkButton>
                                                    </td>
                                                    <td style="width: 70%; text-align: right">
                                                        <asp:Label ID="lblPaginaActual"
                                                            ForeColor="Blue"
                                                            runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </PagerTemplate>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>






</asp:Content>
