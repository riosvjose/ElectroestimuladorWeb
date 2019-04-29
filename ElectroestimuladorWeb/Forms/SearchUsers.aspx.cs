using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class SearchUsers : System.Web.UI.Page
    {
        #region "Libraries"
        GEN_VarSession axVarSes = new GEN_VarSession();
        DB_Users libUser = new DB_Users();

        #endregion

        #region Procedures
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon))
            {
               
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
                CargarDatosIniciales(axVarSes.Lee<string>("strCon"));
            }            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pnError.Visible = false;
            pnOK.Visible = false;
            libUser.StrCon = axVarSes.Lee<string>("strCon");
            gvDatos1.Visible = true;
            gvDatos1.DataSource=libUser.Search(tbSearch.Text);
            gvDatos1.DataBind();
            if (gvDatos1.Rows.Count > 0)
            {
                pnFindedUsers.Visible = true;
            }
            else
            {
                pnError.Visible = true;
                lblError.Text = "No se encontraron coincidencias. ";
            }
        }


        
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            libUser.StrCon = axVarSes.Lee<string>("strCon");
            
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