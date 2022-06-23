using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultiFuncion;
using Datos;
using Entidades;
using System.Data;


namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        DUsuario dUsuario = new DUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lkbIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string usuario = txtNombreUsuario.Text;
                string contrasena = txtContrasena.Text;

                dt = dUsuario.SUsuario(usuario, contrasena);

                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Factura.aspx");
                }
                else
                {
                    string mensaje = "alert('Usuario o contraseña incorrecto');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), Guid.NewGuid().ToString(), mensaje, true);
                }
            }
            catch (Exception ex)
            {
                div_error.InnerHtml = "Ha ocurrido un error debido a " + ex.Message;
                div_error.Visible = true;
            }

        }
    }
}