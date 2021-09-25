using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
namespace Presentacion.paginas
{
    public partial class clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnAgregar_Click(object sender, EventArgs e)
        //{
        //    DCliente cli = new DCliente();
        //    string sexo = "m";
        //    bool respuesta = cli.ICliente(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, sexo);

        //    if (respuesta == true)
        //    {
        //        Response.Write("Insertado Correctamente");
        //        LimpiarCampos();
        //    }

        //    else
        //    {
        //        Response.Write("No se ha ha insertado");
        //    }
                


        //}

        //public void LimpiarCampos()
        //{
        //    txtNombre.Text = "";
        //    txtDireccion.Text = "";
        //    txtTelefono.Text = "";
        //}
    }
}