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
            pnModifyTreatment.Visible = true;
            btncreateTreatment.Visible = false;
            btnSaveTreatment.Visible = true;
            int indice = Convert.ToInt32(e.CommandArgument);
            treatment.StrCon = axVarSes.Lee<string>("strCon");
            treatment.TreatmentId = Convert.ToInt32(gvDatos1.Rows[indice].Cells[0].Text);
            if (e.CommandName == "modify")
            {
                DataTable dt= treatment.SeeTreatmentDetails();
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    tbTreatmentName.Text = dr["treatment"].ToString();
                    tbDesc.Text = dr["desciption"].ToString();
                    LoadDdlWaves();
                    ddlwave.SelectedValue= dr["wave_id"].ToString();
                }
            }
        } 
        protected void cargarGrid()
        {
            treatment.StrCon = axVarSes.Lee<string>("strCon");
            gvDatos1.Columns[0].Visible = true;
            gvDatos1.Visible = true;
            gvDatos1.DataSource = treatment.SeeAll();
            gvDatos1.DataBind();
            gvDatos1.Columns[0].Visible = false;
        }
        #endregion


        protected void btnCreate_Click(object sender, EventArgs e)
        {
            pnError.Visible = false;
            pnOK.Visible = false;
            pnmodifyWave.Visible = true;
            btnCreateWave.Visible = true;
            btnSaveWave.Visible = false;
            tbWaveName.Text = "";
            tbFrec.Text = "";
            tbIntFrec.Text = "";
        }


        protected void btnSaveInjury_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancelInjury_Click(object sender, EventArgs e)
        {
            pnmodifyWave.Visible = false;
            pnPrincipal.Visible = true;
        }

        protected void btnSaveTreatment_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateInjury_Click(object sender, EventArgs e)
        {
            try
            {
                BD_Treatments treatment = new BD_Treatments();
                treatment.StrCon = axVarSes.Lee<string>("strCon");
                treatment.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                treatment.Name = tbWaveName.Text;
                treatment.Description = tbDesc.Text;
                
                if (treatment.Insert())
                {
                    DataTable dt = treatment.SeeIdByParams();
                    if (dt.Rows.Count>0)
                    {
                        DataRow dr = dt.Rows[0];
                        BD_TreatmentsWaves treatmentWaves = new BD_TreatmentsWaves();
                        treatmentWaves.StrCon = axVarSes.Lee<string>("strCon");
                        treatmentWaves.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                        treatmentWaves.TreatmentId = Convert.ToInt32(dr["treatment_id"].ToString());
                        treatmentWaves.WaveId = Convert.ToInt32(ddlwave.SelectedValue);
                        if (treatmentWaves.Insert())
                        {
                            lblOK.Text = "Datos actualizados satisfactoriamente.";
                            pnPrincipal.Visible = true;
                            pnModifyTreatment.Visible = false;
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
                }
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = "No se pudieron actualizar los datos. " + e.ToString();
            }
        }

        public void LoadDdlWaves()
        {
            DB_Waves waves = new DB_Waves();
            waves.StrCon = axVarSes.Lee<string>("strCon");
            ddlwave.DataSource = waves.SeeByName();
            ddlwave.DataTextField = "wave_id";
            ddlwave.DataValueField = "name";
            ddlwave.DataBind();
        }
    }
    
}