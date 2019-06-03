using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class ListTreatments : System.Web.UI.Page
    {
        #region "Libraries"
        GEN_VarSession axVarSes = new GEN_VarSession();
        BD_Treatments treatment = new BD_Treatments();

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
            /*pnError.Visible = false;
            pnOK.Visible = false;
            pnModifyTreatment.Visible = true;
            btncreateTreatment.Visible = false;
            btnSaveTreatment.Visible = true;
            int indice = Convert.ToInt32(e.CommandArgument);
            body.StrCon = axVarSes.Lee<string>("strCon");
            body.BodyPartId = Convert.ToInt32(gvDatos1.Rows[indice].Cells[0].Text);
            
            bool blOpCorrecta = false;
            if (e.CommandName == "modify")
            {
                pnModifyTreatment.Visible = true;
                DataTable dt= body.SeeBodyImage();
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    tbTreatmentName.Text = dr["name"].ToString();
                    tbDesc.Text = dr["desciption"].ToString();
                    /*tbUrl.Text = dr["image_url"].ToString();
                    axVarSes.Escribe("strBodyPartId", body.BodyPartId.ToString());
                    axVarSes.Escribe("strImageId", dr["image_id"].ToString());
                }
            }
            if (blOpCorrecta)
            {
                pnError.Visible = false;
            }
            else
            {
                pnVacio.Focus();
            }
            
    */
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


        protected void btnCreateNewWave_Click(object sender, EventArgs e)
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

        protected void btnCreateNewTreatment_Click(object sender, EventArgs e)
        {
            pnError.Visible = false;
            pnOK.Visible = false;
            pnModifyTreatment.Visible = true;
            btncreateTreatment.Visible = true;
            btnSaveTreatment.Visible = false;
            tbTreatmentName.Text = "";
            tbDesc.Text = "";
            LoadDdlWaves();
        }

        protected void btnSaveWave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateWave_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Waves waves = new DB_Waves();
                waves.StrCon = axVarSes.Lee<string>("strCon");
                waves.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                waves.Name = tbWaveName.Text;
                waves.Frecuency = Convert.ToInt32(tbFrec.Text);
                waves.InternalFrecuency = Convert.ToInt32(tbFrec.Text);
                if (waves.Insert())
                {
                        lblOK.Text = "Datos actualizados satisfactoriamente.";
                        cargarGrid();
                }
                else
                {
                    pnError.Visible = true;
                    lblError.Text = "No se pudieron insertar los datos. " + waves.Message;
                }
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = "No se pudieron actualizar los datos. " + e.ToString();
            }
        }

        protected void btnCancelWave_Click(object sender, EventArgs e)
        {
            pnmodifyWave.Visible = false;
            pnPrincipal.Visible = true;
        }

        protected void btnSaveTreatment_Click(object sender, EventArgs e)
        {

        }

        protected void btncreateTreatment_Click(object sender, EventArgs e)
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

        protected void btnCancelTreatment_Click(object sender, EventArgs e)
        {
            pnModifyTreatment.Visible = false;
            pnPrincipal.Visible = true;
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