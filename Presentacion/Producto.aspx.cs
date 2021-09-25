using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Entidades;
using MultiFuncion;

namespace Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DProducto DProducto = new DProducto();
        Convertidor convertidor = new Convertidor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void gvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codigo = convertidor.IntParse(gvProducto.SelectedDataKey["id_producto"].ToString());
                ConsultaProducto(codigo);

            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                HabilitarCampos(true);
                LimpiarCampos();
                MostrarBotones(false, false, true, true,false);
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void lbModificar_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarBotones(false, false, true, true,false);
                HabilitarCampos(true);
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
                HabilitarCampos(false);
                MostrarBotones(true, false, false, false,false);
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void lbGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                EProducto eProducto = new EProducto();
                eProducto.id_producto = convertidor.IntParse(txtCodigoProducto.Text);
                eProducto.nombre_producto = txtNombreProducto.Text;
                eProducto.precio = convertidor.DoubleParse(txtPrecio.Text);
                eProducto.estado_producto = ckbEstado.Checked ? "A" : "I";

                if (eProducto.id_producto == 0)
                {

                    eProducto.id_producto = DProducto.IProducto(eProducto);
                    string Mensaje = "alert('¡Datos guardados con exito!');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), Guid.NewGuid().ToString(), Mensaje, true);

                }
                else
                {

                    DProducto.UProducto(eProducto);
                    string mensaje = "alert('El producto fue actualizado');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), Guid.NewGuid().ToString(), mensaje, true);
                }


                ConsultaProducto(eProducto.id_producto);
                LlenarGrid();

            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        private void HabilitarCampos(bool estado)
        {
            try
            {
                txtCodigoProducto.Enabled = !estado;
                ckbEstado.Enabled = estado;
                txtNombreProducto.Enabled = estado;
                txtPrecio.Enabled = estado;
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        private void LlenarGrid()
        {
            try
            {
                string nombre = "";
                if (cbActivarBusqueda.Checked)
                {
                     nombre = txtBuscarProducto.Text;
                }
                else
                {
                    txtBuscarProducto.Text = "";
                }
                
                string estado = "";

                if (rbTodos.Checked == true)
                {
                    estado = "";
                }
                else
                {
                    estado = rbEstadoActivo.Checked ? "A" : "I";
                }
                DataTable dt = new DataTable();
                dt = DProducto.SListaProducto(estado, nombre);
                gvProducto.DataSource = dt;
                gvProducto.DataBind();
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        private void LlenarCampos(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    txtCodigoProducto.Text = dt.Rows[0]["id_producto"].ToString();
                    txtNombreProducto.Text = dt.Rows[0]["nombre_producto"].ToString();
                    txtPrecio.Text = convertidor.DoubleParse(dt.Rows[0]["precio"].ToString()).ToString();
                    ckbEstado.Checked = dt.Rows[0]["estado_producto"].ToString() == "A";
                }
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        private void MostrarBotones(bool nuevo, bool modificar, bool grabar, bool cancelar, bool eliminar)
        {
            try
            {
                lbNuevo.Visible = nuevo;
                lbModificar.Visible = modificar;
                lbGrabar.Visible = grabar;
                lbCancelar.Visible = cancelar;
                lbEliminar.Visible = eliminar;
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        private void ConsultaProducto(int idProducto)
        {
            try
            {
                LimpiarCampos();
                HabilitarCampos(false);
                DataTable dt = new DataTable();
                dt = DProducto.SProducto(idProducto);
                if (dt.Rows.Count > 0)
                {
                    MostrarBotones(false, true, false, true,true);
                    LlenarCampos(dt);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Producto no encontrado.')", true);
                }
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int codigo = convertidor.IntParse(txtCodigoProducto.Text);
                ConsultaProducto(codigo);

            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        private void LimpiarCampos()
        {
            try
            {
                txtCodigoProducto.Text = "";
                txtNombreProducto.Text = "";
                txtPrecio.Text = "";
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvProducto.PageIndex = e.NewPageIndex;

                LlenarGrid();
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            LlenarGrid();

        }

        protected void cbActivarBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtBuscarProducto.Enabled = !txtBuscarProducto.Enabled;
                //cbActivarBusqueda.Checked = false ? txtBuscarProducto.Text == ""();
                if (cbActivarBusqueda.Checked == false)
                {
                    txtBuscarProducto.Text = "";
                    LlenarGrid();
                }
            }
            catch(Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }

        }

        protected void rbEstadoActivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarGrid();
            }
            catch(Exception ex)
            {
                
            }
        }

        protected void rbEstadoInactivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarGrid();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = convertidor.IntParse(txtCodigoProducto.Text);
                DProducto.DelProducto(codigo);
                LimpiarCampos();
                MostrarBotones(true, false, false, false, false);

                string mensaje = "alert('¡Producto borrado correctamente')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), Guid.NewGuid().ToString(), mensaje, true);
                LlenarGrid();

            }
            catch(Exception ex)
            {
                div_error.InnerText = "Error. " + ex;
                div_error.Visible = !div_error.Visible;
            }
        }
    }
}