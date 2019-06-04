using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class ListInjuries: System.Web.UI.Page
    {
        #region "Libraries"
        GEN_VarSession axVarSes = new GEN_VarSession();
        BD_Treatments treatment = new BD_Treatments();
        DB_Injuries injuries = new DB_Injuries();
        #endregion

        #region Procedures
        private void Load_inic(string strCon)
        {
            if ((!string.IsNullOrEmpty(axVarSes.Lee<string>("strUserID")))&&(!string.IsNullOrEmpty(strCon)))
            {
                pnError.Visible = false;
                pnOK.Visible = false;
                treatment.StrCon = axVarSes.Lee<string>("strCon");
                cargarGrid();
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
        
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            pnError.Visible = false;
            pnOK.Visible = false;
            pnModifyInjury.Visible = true;
            btnCreateInjury.Visible = false;
            btnSaveInjury.Visible = true;
            int indice = Convert.ToInt32(e.CommandArgument);
            treatment.StrCon = axVarSes.Lee<string>("strCon");
            //treatment. = Convert.ToInt32(gvDatos1.Rows[indice].Cells[0].Text);
            if (e.CommandName == "modify")
            {
                DataTable dt = treatment.SeeDetails(gvDatos1.Rows[indice].Cells[0].Text);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    tbInjuryName.Text = dr["treatment"].ToString();//******************
                    tbInjuryDesc.Text = dr["description"].ToString();
                    LoadDdlTreatments();
                    ddlTreatment.SelectedValue = dr["treatment_id"].ToString();
                    LoadDdlWaves();
                    ddlWave.SelectedValue= dr["wave_id"].ToString();
                }
            }
        } 
        protected void cargarGrid()
        {
            treatment.StrCon = axVarSes.Lee<string>("strCon");
            gvDatos1.Columns[0].Visible = true;
            gvDatos1.Columns[2].Visible = true;
            gvDatos1.Columns[4].Visible = true;
            gvDatos1.Visible = true;
            gvDatos1.DataSource = treatment.SeeTreatmentInjuryDetails();
            gvDatos1.DataBind();
            gvDatos1.Columns[0].Visible = false;
            gvDatos1.Columns[2].Visible = false;
            gvDatos1.Columns[4].Visible = false;
        }
        #endregion

        protected void btnSaveInjury_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancelInjury_Click(object sender, EventArgs e)
        {
            pnModifyInjury.Visible = false;
            pnPrincipal.Visible = true;
        }

        protected void btnCreateInjury_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Injuries Injury = new DB_Injuries();
                Injury.StrCon = axVarSes.Lee<string>("strCon");
                Injury.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                Injury.Name = tbInjuryName.Text;
                Injury.Description = tbInjuryDesc.Text;
                /*
                if (Injury.Insert())
                {
                    //DataTable dt = Injury.SeeIdByParams();
                    if (dt.Rows.Count>0)
                    {
                        DataRow dr = dt.Rows[0];
                        BD_TreatmentsWaves treatmentWaves = new BD_TreatmentsWaves();
                        treatmentWaves.StrCon = axVarSes.Lee<string>("strCon");
                        treatmentWaves.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                        treatmentWaves.TreatmentId = Convert.ToInt32(dr["treatment_id"].ToString());
                        treatmentWaves.WaveId = Convert.ToInt32(ddlWave.SelectedValue);
                        if (treatmentWaves.Insert())
                        {
                            lblOK.Text = "Datos actualizados satisfactoriamente.";
                            pnPrincipal.Visible = true;
                            pnModifyInjury.Visible = false;
                            cargarGrid();
                        }
                        else
                        {
                            pnError.Visible = true;
                            lblError.Text = "No se pudieron insertar los datos. " + treatmentWaves.Message;
                        }
                    }
                }
                else
                {
                    pnError.Visible = true;
                    lblError.Text = "No se pudieron insertar los datos. " + treatment.Message;
                }*/
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = "No se pudieron actualizar los datos. " + e.ToString();
            }
        }

        public void LoadDdlWaves()
        {
            BD_TreatmentsWaves waves = new BD_TreatmentsWaves();
            waves.StrCon = axVarSes.Lee<string>("strCon");
            waves.TreatmentId=Convert.ToInt32(ddlTreatment.SelectedValue);
            ddlWave.DataSource = waves.SeeByTreatment();
            ddlWave.DataTextField = "name";
            ddlWave.DataValueField = "wave_id";
            ddlWave.DataBind();
        }
        public void LoadDdlTreatments()
        {
            BD_Treatments treatment = new BD_Treatments();
            treatment.StrCon = axVarSes.Lee<string>("strCon");
            ddlTreatment.DataSource = treatment.SeeByName();
            ddlTreatment.DataTextField = "name";
            ddlTreatment.DataValueField = "treatment_id";
            ddlTreatment.DataBind();
        }
        protected void btnSavInjury_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateInjury_Click1(object sender, EventArgs e)
        {

        }

        protected void btnCancelInjury_Click1(object sender, EventArgs e)
        {

        }

        protected void btnCreateNewInjury_Click(object sender, EventArgs e)
        {
            pnError.Visible = false;
            pnOK.Visible = false;
            pnModifyInjury.Visible = true;
            btnCreateInjury.Visible = true;
            btnSaveInjury.Visible = false;
            tbInjuryDesc.Text = "";
            tbInjuryName.Text = "";
            LoadDdlTreatments();
            LoadDdlWaves();
        }
    }
    
}