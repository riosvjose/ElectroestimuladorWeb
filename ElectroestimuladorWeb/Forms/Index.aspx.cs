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
        #region Libraries
        GEN_VarSession axVarSes = new GEN_VarSession();
        

        #endregion
        #region Procedures

        private void Load_Ini(string strCon)
        {
            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
            }
            if (!Page.IsPostBack)
            {
                Load_Ini(axVarSes.Lee<string>("strCon"));
            }
        }
        #endregion

        protected void lbLesiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListBody.aspx");
        }

        protected void lbHistClinica_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchUsers.aspx");
        }

        protected void lbTreatments_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListTreatments.aspx");
        }
    }
}