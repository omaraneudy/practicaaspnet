using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using MultiFuncion;
using System.Data;
using Datos;

namespace Presentacion
{
    public partial class Factura : System.Web.UI.Page
    {

        Convertidor convertidor = new Convertidor();
        DFactura DFactura = new DFactura();
        DProducto dProducto = new DProducto();
        Dre_factura_producto dre_Factura_Producto = new Dre_factura_producto();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarListaProducto();
                txtFecha.Text = DateTime.Now.ToShortDateString();
            }
        }

        protected void txtIdFactura_TextChanged(object sender, EventArgs e)
        {
            if (txtIdFactura.Text != "" && txtIdFactura.Text != null)
            {
                int codigo = convertidor.IntParse(txtIdFactura.Text);

                DataTable dtFactura = new DataTable();
                DataTable dtDetalle = new DataTable();
                dtFactura = DFactura.SFactura(codigo);
                dtDetalle = dre_Factura_Producto.SREFacturaProducto(codigo);
                LlenarCampos(dtFactura);
                MostrarBotones(false, true, false, true);
                LlenarGridDetalle(dtDetalle);
            }
            else
            {
                DataTable dt = new DataTable();
                LimpiarCampos();
                LlenarGridDetalle(dt);
                MostrarBotones(true, false, false, false);
            }
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            MostrarBotones(false, false, true, true);
            HabilitarCampos(true);
            LimpiarCampos();
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {

            HabilitarCampos(false);
            LimpiarCampos();
            MostrarBotones(true, false, false, false);
            DataTable dt = new DataTable();
            LlenarGridDetalle(dt);
        }

        protected void lbGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                EFactura eFactura = new EFactura();
                Ere_factura_producto ere_Factura_Producto = new Ere_factura_producto();

                eFactura.id_factura = convertidor.IntParse(txtIdFactura.Text);
                eFactura.id_cliente = convertidor.IntParse(txtIdCliente.Text);

                if (eFactura.id_factura == 0)
                {
                    txtIdFactura.Text = DFactura.IFactura(eFactura).ToString();

                    dtDetalle = ConvertirGvDetalleEnTabla();

                    dre_Factura_Producto.IREFacturaProductoTabla(dtDetalle);

                    string mensaje = "alert('¡La factura se ha creado correctamente!');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), Guid.NewGuid().ToString(), mensaje, true);
                }
                else
                {
                    DFactura.UFactura(eFactura);
                    dre_Factura_Producto.DREFacturaProducto(convertidor.IntParse(txtIdFactura.Text));
                    dtDetalle = ConvertirGvDetalleEnTabla();

                    dre_Factura_Producto.IREFacturaProductoTabla(dtDetalle);

                    string mensaje = "alert('¡La factura se ha actualizado correctamente!');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), Guid.NewGuid().ToString(), mensaje, true);
                }

                MostrarBotones(false, true, false, true);
                HabilitarCampos(false);
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('no se ha podido insertar debido a {ex}');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        protected void lbModificar_Click(object sender, EventArgs e)
        {
            MostrarBotones(false, false, true, true);
            HabilitarCampos(true);
        }

        private void LlenarCampos(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    txtIdFactura.Text = dt.Rows[0]["id_factura"].ToString();
                    txtIdCliente.Text = dt.Rows[0]["id_cliente"].ToString();
                    LlenarCliente(convertidor.IntParse(txtIdCliente.Text));
                    txtFecha.Text = dt.Rows[0]["fecha"].ToString();
                }
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('no se ha podido llenar los campos debido a {ex}')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        protected void gvDetalleVenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = e.Row.DataItem as DataRowView;

                TextBox txtCantidad = e.Row.FindControl("txtCantidad") as TextBox;
                TextBox txtPrecio = e.Row.FindControl("txtPrecio") as TextBox;
                TextBox txtTotal = e.Row.FindControl("txtTotal") as TextBox;

                txtCantidad.Text = dRow["cantidad"].ToString();
                txtPrecio.Text = dRow["precio"].ToString();
                txtTotal.Text = dRow["total"].ToString();
            }
        }
        private void LlenarGridProducto()
        {
            int codigo = convertidor.IntParse(txtIdFactura.Text);
            try
            {
                if (codigo > 0)
                {
                    DataTable dt = new DataTable();
                    dt = dre_Factura_Producto.SREFacturaProducto(codigo);
                    gvDetalleVenta.DataSource = dt;
                    gvDetalleVenta.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void LlenarFooterGrid()
        {
            TextBox txtSumaTotal = new TextBox();
            gvDetalleVenta.FooterRow.Cells[3].Text = "Total";
            txtSumaTotal.ID = "txtSumaTotal";
            txtSumaTotal.ClientIDMode = ClientIDMode.Predictable;
            txtSumaTotal.Enabled = false;
            txtSumaTotal.CssClass = "form-control input-sm";
            gvDetalleVenta.FooterRow.Cells[4].Controls.Add(txtSumaTotal);
            txtSumaTotal = gvDetalleVenta.FindControl("txtSumaTotal") as TextBox;
        }

        private void SumaTotal()
        {
            double sumaTotal = 0;
            double apoyo = 0;
            TextBox txtTotal = new TextBox();
            TextBox txtSumaTotal = new TextBox();

            for (int i = 0; i < gvDetalleVenta.Rows.Count; i++)
            {
                txtTotal = gvDetalleVenta.Rows[i].FindControl("txtTotal") as TextBox;
                apoyo = convertidor.DoubleParse(txtTotal.Text);
                sumaTotal += apoyo;
            }
            txtSumaTotal = gvDetalleVenta.FooterRow.FindControl("txtSumaTotal") as TextBox;
            txtSumaTotal.Text = sumaTotal.ToString();
        }

        private void LlenarGridDetalle(DataTable dt)
        {
            try
            {
                TextBox txtCantidad = new TextBox();
                txtCantidad = gvDetalleVenta.FindControl("txtCantidad") as TextBox;
                //int cantidad = 1;
                gvDetalleVenta.DataSource = dt;
                gvDetalleVenta.DataBind();

                double suma = convertidor.DoubleParse(dt.Compute("sum(total)", ""));
                LlenarFooterGrid();
                TextBox txtSumaTotal = gvDetalleVenta.FooterRow.FindControl("txtSumaTotal") as TextBox;
                txtSumaTotal.Text = suma.ToString();
                SumaTotal();
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('Error debido a {ex}')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        private void LlenarCamposCliente(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    txtNombreCliente.Text = dt.Rows[0]["nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('No se ha podido llenar el nombre de cliente debido a {ex}')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        private void MostrarBotones(bool nuevo, bool modificar, bool grabar, bool cancelar)
        {
            try
            {
                lbNuevo.Visible = nuevo;
                lbModificar.Visible = modificar;
                lbGrabar.Visible = grabar;
                lbCancelar.Visible = cancelar;
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('No se han podido mostrar los botones debido a {ex}')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);

            }
        }
        private void HabilitarCampos(bool estado)
        {
            try
            {
                txtIdFactura.Enabled = !estado;
                txtIdCliente.Enabled = estado;
                //txtValor.Enabled = estado;
                //txtNombreCliente.Enabled = estado;
                if (estado)
                {
                    txtFecha.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtFecha.Text = "";
                }
                gvDetalleVenta.Enabled = estado;
                ddlListaProductos.Enabled = estado;
                lbAgregarProducto.Enabled = estado;
                //txtPrecio.Enabled = estado;
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('No se han podido habilitar los campos debido a {ex}')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        protected void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            LlenarCliente(convertidor.IntParse(txtIdCliente.Text));
        }

        private void LimpiarCampos()
        {
            txtIdFactura.Text = "";
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtFecha.Text = "";
        }

        private void LlenarCliente(int codigo)
        {
            DCliente dCliente = new DCliente();
            DataTable dt = dCliente.SCliente(codigo);
            LlenarCamposCliente(dt);
        }

        private void LlenarListaProducto()
        {
            try
            {
                DataTable dt = dProducto.SListaProducto();

                ddlListaProductos.DataSource = dt;
                ddlListaProductos.DataValueField = "id_producto";
                ddlListaProductos.DataTextField = "nombre_producto";
                ddlListaProductos.DataBind();
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('No se han podido llenar la lista de producto debido a {ex}')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        protected void lbAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = convertidor.IntParse(ddlListaProductos.SelectedValue);
                double precio = 0;
                double cantidad = 0;
                bool productoEncontrado = false;
                DataTable dtProducto = dProducto.SProducto(idProducto);
                DataTable dtDetalle = ConvertirGvDetalleEnTabla();
                DataRow nuevaFila = dtDetalle.NewRow();

                cantidad = 1;

                TextBox txtCantidad = new TextBox();
                int codigo = 0;

                foreach (DataRow filaProductoActual in dtDetalle.Rows)
                {
                    codigo = convertidor.IntParse(filaProductoActual["id_producto"]);


                    if (codigo == idProducto)
                    {
                        cantidad = convertidor.IntParse(filaProductoActual["cantidad"]) + 1;
                        precio = convertidor.DoubleParse(filaProductoActual["precio"]);
                        filaProductoActual["cantidad"] = cantidad;
                        filaProductoActual["total"] = precio * cantidad;
                        dtDetalle.AcceptChanges();
                        productoEncontrado = true;
                        break;
                    }
                }

                if (productoEncontrado == false)
                {
                    precio = convertidor.DoubleParse(dtProducto.Rows[0]["precio"]);
                    nuevaFila["id_re_factura_producto"] = 0;
                    nuevaFila["id_factura"] = convertidor.IntParse(txtIdFactura.Text);
                    nuevaFila["id_producto"] = idProducto;
                    nuevaFila["nombre_producto"] = dtProducto.Rows[0]["nombre_producto"];
                    nuevaFila["precio"] = precio;
                    nuevaFila["cantidad"] = cantidad;

                    nuevaFila["total"] = precio * cantidad;
                    dtDetalle.Rows.Add(nuevaFila);
                }

                LlenarGridDetalle(dtDetalle);
                SumaTotal();

            }
            catch (Exception ex)
            {
                string mensaje = $"alert('No se ha podido agregar producto debido a {ex}');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        protected DataTable ConvertirGvDetalleEnTabla()
        {
            DataTable dtDetalle = AgregarColumnasTabla<Ere_factura_producto>();
            DataRow dRow;
            TextBox txtCantidad = new TextBox();
            TextBox txtPrecio = new TextBox();
            TextBox txtTotal = new TextBox();
            int idFactura = convertidor.IntParse(txtIdFactura.Text);

            foreach (GridViewRow gvRow in gvDetalleVenta.Rows)
            {
                txtCantidad = gvRow.FindControl("txtCantidad") as TextBox;
                txtPrecio = gvRow.FindControl("txtPrecio") as TextBox;
                txtTotal = gvRow.FindControl("txtTotal") as TextBox;

                dRow = dtDetalle.NewRow();

                dRow["id_re_factura_producto"] = gvDetalleVenta.DataKeys[gvRow.RowIndex]["id_re_factura_producto"];
                dRow["id_factura"] = idFactura;
                dRow["id_producto"] = gvDetalleVenta.DataKeys[gvRow.RowIndex]["id_producto"];
                dRow["nombre_producto"] = gvDetalleVenta.DataKeys[gvRow.RowIndex]["nombre_producto"];
                dRow["precio"] = convertidor.DoubleParse(txtPrecio.Text);
                dRow["cantidad"] = convertidor.DoubleParse(txtCantidad.Text);
                dRow["total"] = convertidor.DoubleParse(txtTotal.Text);

                dtDetalle.Rows.Add(dRow);
            }

            return dtDetalle;
        }

        public DataTable AgregarColumnasTabla<T>()
        {
            DataTable dt = new DataTable();
            var propiedades = typeof(T).GetProperties();
            dt.Columns.AddRange(propiedades.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            return dt;
        }

        protected void lblEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void gvDetalleVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = gvDetalleVenta.SelectedIndex;
                DataTable dtDetalle = ConvertirGvDetalleEnTabla();

                if (dtDetalle.Rows.Count > 0)
                {
                    dtDetalle.Rows.RemoveAt(fila);
                    LlenarGridDetalle(dtDetalle);
                }
            }
            catch (Exception ex)
            {
                string mensaje = $"alert('Error debido a {ex}');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), mensaje, Guid.NewGuid().ToString(), true);
            }
        }

        protected void gvDetalleVenta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }
    }
}