using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class Secondary : System.Web.UI.MasterPage
    {
        #region libs
        GEN_VarSession axVarSes = new GEN_VarSession();
        #endregion

        #region procedures

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(axVarSes.Lee<string>("strCon")))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {


            }
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
                if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                {
                    Request.Browser.Adapters.Clear();
                }

            }
        }
        #endregion

        #region "Events"
        
      


        #endregion
    }
}