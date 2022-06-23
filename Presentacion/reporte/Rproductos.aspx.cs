using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades.reporte;
using CrystalDecisions.CrystalReports;




namespace Presentacion.reporte
{
    public partial class Rproductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RPrueba prueba = new RPrueba();
            DataTable dt = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("nombre");
            dt.Columns.Add("profesion");

            dt.Rows.Add("1", "juan", "profesor");
            dt.Rows.Add("2", "pedro", "enfermera");
            dt.Rows.Add("3", "juan carlos", "chofer");
            dt.Rows.Add("4", "javier", "chofer");
            dt.Rows.Add("5", "carlitos", "profesor");

            prueba.Database.Tables[0].SetDataSource(dt);
            
            
            //this.CrystalReportViewer.ReportSource = prueba;
            //this.CrystalReportViewer.DataBind();
        }
    }
}