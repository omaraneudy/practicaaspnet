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
    public partial class Cliente : System.Web.UI.Page
    {
        DCliente clie = new DCliente();

        Convertidor convertidor = new Convertidor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = clie.ListarCliente("A");
                LlenarGridView(dt);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true, false);
            LimpiarCampos();
            MostrarBtn(false, true, true, false, false);

        }

        public void LimpiarCampos()
        {
            txtCodigoCli.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtFechaCreacion.Text = "";
            lblEstado.Text = "----";
            rbFemenino.Checked = false;
            rbMasculino.Checked = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ECliente eCliente = new ECliente();
            string estado = null;

            estado = ddlEstado.SelectedValue.ToString();

            eCliente.id_cli = convertidor.IntParse(txtCodigoCli.Text);
            eCliente.nombre = txtNombre.Text;
            eCliente.direccion = txtDireccion.Text;
            eCliente.telefono = txtTelefono.Text;
            eCliente.sexo = rbFemenino.Checked ? "f" : "m";
            eCliente.estado = estado;

            if (eCliente.id_cli == 0)
            {
                eCliente.id_cli = clie.ICliente(eCliente);
                Response.Write("<script>Actualizado correctamente</script>");
            }
            else
            {
                clie.UCliente(eCliente);
            }



            //if (resp == true)
            //{
            //    Response.Write("<script>Insertado correctamente</script>");
            //    LimpiarCampos();
            //}
            //else
            //{
            //    Response.Write("<script>No se pudo insertar</script>");
            //}


            MostrarBtn(true, false, false, false, false);
            LimpiarCampos();
            HabilitarCampos(false, true);
            DataTable dt = clie.ListarCliente("A");

            LlenarGridView(dt);

        }

        private void HabilitarCampos(bool estado, bool cod)
        {
            txtCodigoCli.Enabled = cod;
            txtNombre.Enabled = estado;
            txtDireccion.Enabled = estado;
            txtTelefono.Enabled = estado;
            txtFechaCreacion.Enabled = false;
            rbFemenino.Enabled = estado;
            rbMasculino.Enabled = estado;
        }

        private void MostrarBtn(bool agregar, bool guardar, bool cancelar, bool modificar, bool actualizar)
        {
            btnAgregar.Visible = agregar;
            btnGuardar.Visible = guardar;
            btnCancelar.Visible = cancelar;
            btnModificar.Visible = modificar;
            btnActualizar.Visible = actualizar;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false, true);
            MostrarBtn(true, false, false, false, false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true, false);
            txtCodigoCli.Enabled = false;
            MostrarBtn(false, true, true, false, false);
        }

        private void LlenarGridView(DataTable dt)
        {
            gvClientes.DataSource = dt;
            gvClientes.DataBind();
        }

        protected void txtCodigoCli_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoCli.Text != "" && txtCodigoCli.Text != null)
            {

                int codigo = Convert.ToInt32(txtCodigoCli.Text);
                LimpiarCampos();
                LlenarCampos(codigo);
                MostrarBtn(false, false, true, true, false);
            }
            else
            {
                LimpiarCampos();
            }

        }
        private void LlenarCampos(int codigo)
        {
            DataTable dt = clie.SCliente(codigo);
            int filas = dt.Rows.Count;
            string sexo = null;

            if (filas > 0)
            {
                txtCodigoCli.Text = dt.Rows[0]["id_cli"].ToString();
                txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                txtDireccion.Text = dt.Rows[0]["direccion"].ToString();
                txtTelefono.Text = dt.Rows[0]["telefono"].ToString();
                txtFechaCreacion.Text = dt.Rows[0]["fechacreado"].ToString();
                sexo = dt.Rows[0]["sexo"].ToString();
                ddlEstado.SelectedValue = dt.Rows[0]["estado"].ToString();
                

                lblEstado.Text = dt.Rows[0]["estado"].ToString();

                LlenarRBT(sexo);

            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(gvClientes.SelectedDataKey["id_cli"].ToString());

            MostrarBtn(false, false, true, true, false);
            LlenarCampos(codigo);
            HabilitarCampos(false, false);
        }

        private void LlenarRBT(string sex)
        {
            if (sex == "f")
            {
                rbFemenino.Checked = true;
                rbMasculino.Checked = false;
            }

            else if (sex == "m")
            {
                rbMasculino.Checked = true;
                rbFemenino.Checked = false;
            }
            else
            {
                rbMasculino.Checked = false;
                rbFemenino.Checked = false;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //bool respuesta = false;
            ECliente eCliente = new ECliente();
            string estado = null;
            string sex = null;
            if (rbFemenino.Checked == true)
                sex = "f";

            if (rbMasculino.Checked == true)
                sex = "m";

            estado = ddlEstado.SelectedValue.ToString();

            eCliente.id_cli = Convert.ToInt32(txtCodigoCli.Text);
            eCliente.nombre = txtNombre.Text;
            eCliente.direccion = txtDireccion.Text;
            eCliente.telefono = txtTelefono.Text;
            eCliente.sexo = sex;
            eCliente.estado = estado;

            clie.UCliente(eCliente);

            //if (respuesta == true)
            //{
            Response.Write("<script>Actualizado correctamente</script>");
            LimpiarCampos();
            HabilitarCampos(false, true);
            MostrarBtn(true, false, false, false, false);

            DataTable dt = clie.ListarCliente("A");

            LlenarGridView(dt);
            //}
            //else
            //{
            Response.Write("<script>No se ha podido actualizar</script>");
            // }


        }
    }
}