using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Datos;
using MultiFuncion;
using AjaxControlToolkit;

namespace Presentacion
{
    public partial class DiseñoWeb : System.Web.UI.Page
    {
        DCliente clie = new DCliente();

        Convertidor convertidor = new Convertidor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridView();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            LimpiarCampos();
            MostrarBtn(false, true, true, false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);
            MostrarBtn(true, false, false, false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            txtCodigoCliente.Enabled = false;
            MostrarBtn(false, true, true, false);
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            ECliente eCliente = new ECliente();
            string estado = null;

            try
            {
                estado = ddlEstadoCliente.SelectedValue.ToString();

                eCliente.id_cli = convertidor.IntParse(txtCodigoCliente.Text);
                eCliente.nombre = txtNombre.Text;
                eCliente.direccion = txtDireccion.Text;
                eCliente.telefono = txtTelefono.Text;
                eCliente.sexo = rbFemenino.Checked ? "f" : "m";
                eCliente.estado = estado;
                eCliente.notificacion = ckbActivarNotificacion.Checked ? "S" : "N";
                eCliente.comentario = txtComentario.Text;

                if (eCliente.id_cli == 0)
                {
                    eCliente.id_cli = clie.ICliente(eCliente);
                }
                else
                {
                    clie.UCliente(eCliente);
                }

                ConsultarCliente(eCliente.id_cli);
                LlenarGridView();
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        public void LimpiarCampos()
        {
            txtCodigoCliente.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtFechaCreado.Text = "";
            txtComentario.Text = "";
            ckbActivarNotificacion.Checked = false;
            rbFemenino.Checked = false;
            rbMasculino.Checked = true;
        }

        private void HabilitarCampos(bool estado)
        {
            txtCodigoCliente.Enabled = !estado;
            txtNombre.Enabled = estado;
            txtDireccion.Enabled = estado;
            txtTelefono.Enabled = estado;
            rbFemenino.Enabled = estado;
            rbMasculino.Enabled = estado;
            ddlEstadoCliente.Enabled = estado;
            ckbActivarNotificacion.Enabled = estado;
            txtComentario.Enabled = estado;
        }

        private void LlenarGridView()
        {
            try
            {
                string estado = ddlFiltrarEstado.SelectedValue.ToString();

                DataTable dt = clie.ListarCliente(estado);
                gvCliente.DataSource = dt;
                gvCliente.DataBind();
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
                    txtCodigoCliente.Text = dt.Rows[0]["id_cli"].ToString();
                    txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                    txtDireccion.Text = dt.Rows[0]["direccion"].ToString();
                    txtTelefono.Text = dt.Rows[0]["telefono"].ToString();
                    txtFechaCreado.Text = dt.Rows[0]["fechacreado"].ToString();
                    rbFemenino.Checked = dt.Rows[0]["sexo"].ToString() == "f";
                    rbMasculino.Checked = dt.Rows[0]["sexo"].ToString() != "f";

                    ddlEstadoCliente.SelectedValue = dt.Rows[0]["estado"].ToString();
                    txtComentario.Text = dt.Rows[0]["comentario"].ToString();

                    ckbActivarNotificacion.Checked = dt.Rows[0]["notificacion"].ToString() == "S";
                }
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        private void MostrarBtn(bool nuevo, bool guardar, bool cancelar, bool modificar)
        {
            btnNuevo.Visible = nuevo;
            btnGrabar.Visible = guardar;
            btnCancelar.Visible = cancelar;
            btnModificar.Visible = modificar;
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int codigo = convertidor.IntParse(txtCodigoCliente.Text.Trim());
                ConsultarCliente(codigo);

            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codigo = convertidor.IntParse(gvCliente.SelectedDataKey["id_cli"].ToString());

                ConsultarCliente(codigo);
                HabilitarCampos(false);
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }

        protected void gvCliente_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvCliente.BottomPagerRow;

            LinkButton pagina = (LinkButton)pagerRow.Cells[0].FindControl("lnkPagina");
            DropDownList listaPagina = (DropDownList)pagerRow.Cells[0].FindControl("ddlPage");
            Label lblPagina = (Label)pagerRow.Cells[0].FindControl("lblPaginaActual");

            if (listaPagina != null)
            {

                for (int i = 0; i < gvCliente.PageCount; i++)
                {
                    int numeroPagina = i + 1;
                    ListItem item = new ListItem(numeroPagina.ToString());

                    if (i == gvCliente.PageIndex)
                    {
                        item.Selected = true;

                    }

                    listaPagina.Items.Add(item);
                }
            }

            if (lblPagina != null)
            {
                int paginaActual = gvCliente.PageIndex + 1;

                lblPagina.Text = "Página " + paginaActual.ToString() +
                    " de " + gvCliente.PageCount.ToString();
            }
        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvCliente.BottomPagerRow;

            DropDownList listaPagina = (DropDownList)pagerRow.Cells[0].FindControl("ddlPage");

            gvCliente.PageIndex = listaPagina.SelectedIndex;
            DataTable dt = clie.ListarCliente("A");
        }

        protected void gvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCliente.PageIndex = e.NewPageIndex;

            LlenarGridView();
        }

        protected void ddlFiltrarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGridView();
        }

        private void ConsultarCliente(int idCliente)
        {
            try
            {
                LimpiarCampos();
                HabilitarCampos(false);
                DataTable dt = clie.SCliente(idCliente);

                if (dt.Rows.Count > 0)
                {
                    LlenarCampos(dt);
                    MostrarBtn(false, false, true, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Cliente no encontrado.')", true);
                }
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Error. " + ex.Message;
                div_error.Visible = true;
            }
        }
    }
}