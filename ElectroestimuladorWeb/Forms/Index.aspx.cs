using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectroestimuladorWeb.Forms
{
    public partial class Index : System.Web.UI.Page
    {
        #region "Librerias Externas"

        #endregion
        #region "Clase de tablas de la Base de Datos"
        

        #endregion
        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            CargarLblNotificaHoy();
            CargarLblNotificaPendientes();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
            }
            if (!Page.IsPostBack)
            {
                //CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
            }
        }
        protected void lbSalidas_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_SAL_MenuSalidas.aspx");
        }
        protected void lbTareas_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_TAR_MenuTareas.aspx"); 
        }
        protected void lbProyectos_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_PROY_MenuProyectos.aspx");
        }
        protected void lbControlAulas_Click(object sender, EventArgs e)
        {
            
        }
        protected void CargarLblNotificaHoy()
        {
            string[] tareas = new string[100];
            lblNotificaHoy.Text = "";
            int i = 0;
            while(tareas[i]!=null)
            {
                lblNotificaHoy.Text = lblNotificaHoy.Text + tareas[i] + "<br>";
                i++;
            }
        }
        protected void CargarLblNotificaPendientes()
        {
            lblNotificaPendientes.Text = "";
            string[] tareasPen = new string[100];
            int i = 0;
            while (tareasPen[i] != null)
            {
                lblNotificaPendientes.Text = lblNotificaPendientes.Text  + tareasPen[i] + "<br>";
                i++;
            }
        }
        #endregion
    }
}