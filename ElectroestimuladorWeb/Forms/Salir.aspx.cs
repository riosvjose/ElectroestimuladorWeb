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

        #region Libraries
        GEN_VarSession axVarSes = new GEN_VarSession();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            axVarSes.Escribe("strUser", string.Empty);
            axVarSes.Escribe("strUserAccount", string.Empty);
            axVarSes.Escribe("strPassword", string.Empty);
            axVarSes.Escribe("strUserID", string.Empty);
            //Response.Write(@"<script language='javascript'>window.close();</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}