using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class UserInjuries : System.Web.UI.Page
    {
        #region "Libraries"
        GEN_VarSession axVarSes = new GEN_VarSession();
        BD_UsersTreatments Usertreatments = new BD_UsersTreatments();

        #endregion

        #region Procedures
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(axVarSes.Lee<string>("strUserID")))
            {
                Usertreatments.StrCon = axVarSes.Lee<string>("strCon"); 
                gvData1.Columns[0].Visible = true;
                gvData1.Columns[2].Visible = true;
                gvData1.Columns[4].Visible = true;
                gvData1.Columns[6].Visible = true;
                Usertreatments.UserId = Convert.ToInt32(axVarSes.Lee<string>("strPersonId"));
                gvData1.Visible = true;
                gvData1.DataSource = Usertreatments.SeeByUser();
                gvData1.DataBind();
                gvData1.Columns[0].Visible = false;
                gvData1.Columns[2].Visible = false;
                gvData1.Columns[4].Visible = false;
                gvData1.Columns[6].Visible = false;
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
        
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument); 
            bool blOpCorrecta = false;
            if (e.CommandName == "ver")
            {
                axVarSes.Escribe("strBodyPartId", gvData1.Rows[indice].Cells[2].Text.ToString());
                axVarSes.Escribe("strBodyPart", gvData1.Rows[indice].Cells[3].Text.ToString());
                axVarSes.Escribe("strInjuryId", gvData1.Rows[indice].Cells[0].Text.ToString());
                axVarSes.Escribe("strInjury", gvData1.Rows[indice].Cells[1].Text.ToString());
                axVarSes.Escribe("strWaveId", gvData1.Rows[indice].Cells[6].Text.ToString());
                axVarSes.Escribe("strWave", gvData1.Rows[indice].Cells[7].Text.ToString());
                axVarSes.Escribe("strTreatmentId", gvData1.Rows[indice].Cells[4].Text.ToString());
                //Response.Redirect("Results.aspx");
                Response.Redirect("InjuryProgress.aspx");
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
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchUsers.aspx");
        }
        #endregion

    }
}