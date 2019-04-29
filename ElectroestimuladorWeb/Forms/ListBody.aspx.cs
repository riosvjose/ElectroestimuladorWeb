using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class ListBody : System.Web.UI.Page
    {
        #region "Libraries"
        GEN_VarSession axVarSes = new GEN_VarSession();
        DB_BodyParts body = new DB_BodyParts();

        #endregion

        #region Procedures
        private void Load_inic(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon))
            {
                pnError.Visible = false;
                pnOK.Visible = false;
                body.StrCon = axVarSes.Lee<string>("strCon");
                gvDatos1.Visible = true;
                gvDatos1.DataSource = body.SeeAll();
                gvDatos1.DataBind();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        #endregion

        #region "Events"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_inic(axVarSes.Lee<string>("strCon"));
            }            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }


        
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            body.StrCon = axVarSes.Lee<string>("strCon");
            
            bool blOpCorrecta = false;
            if (e.CommandName == "agregar")
            {
                
            }
            if (blOpCorrecta)
            {
                pnError.Visible = false;
            }
            else
            {
                pnVacio.Focus();
            }
            

        } 
        protected void rbIngreso_Click(object sender, EventArgs e)
        {
            
        }

        protected void rbSalida_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

    }
}