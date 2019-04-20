using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectroestimuladorWeb.Forms
{
    public partial class Salir : System.Web.UI.Page
    {

        #region "Librerias Externas"

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //axVarSes.Escribe("strUsuario", "");
            //axVarSes.Escribe("strPassword", "");
            //axVarSes.Escribe("strConexion", "");
            //axVarSes.Escribe("UsuarioPersonaNumSec", "");
            Response.Write(@"<script language='javascript'>window.close();</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}