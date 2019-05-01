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
        DB_BodyParts body = new DB_BodyParts();
        DB_Images image = new DB_Images();
        #endregion

        #region Procedures
        private void Load_inic(string strCon)
        {
            if ((!string.IsNullOrEmpty(axVarSes.Lee<string>("strUserID")))&&(!string.IsNullOrEmpty(strCon)))
            {
                pnError.Visible = false;
                pnOK.Visible = false;
                body.StrCon = axVarSes.Lee<string>("strCon");
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
            pnmodify.Visible = true;
            btncreate.Visible = false;
            btnSave.Visible = true;
            int indice = Convert.ToInt32(e.CommandArgument);
            body.StrCon = axVarSes.Lee<string>("strCon");
            body.BodyPartId = Convert.ToInt32(gvDatos1.Rows[indice].Cells[0].Text);
            
            bool blOpCorrecta = false;
            if (e.CommandName == "modify")
            {
                pnmodify.Visible = true;
                DataTable dt= body.SeeBodyImage();
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    tbName.Text = dr["name"].ToString();
                    tbTitle.Text = dr["title"].ToString();
                    tbUrl.Text = dr["image_url"].ToString();
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
            

        } 
        protected void cargarGrid()
        {
            body.StrCon = axVarSes.Lee<string>("strCon");
            gvDatos1.Columns[0].Visible = true;
            gvDatos1.Visible = true;
            gvDatos1.DataSource = body.SeeAll();
            gvDatos1.DataBind();
            gvDatos1.Columns[0].Visible = false;
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                image.StrCon = axVarSes.Lee<string>("strCon");
                image.ImageId = Convert.ToInt32(axVarSes.Lee<string>("strImageId"));
                image.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                body.StrCon = axVarSes.Lee<string>("strCon");
                body.Name = tbName.Text;
                body.BodyPartId = Convert.ToInt32(axVarSes.Lee<string>("strBodyPartId"));
                body.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                image.ImageUrl = tbUrl.Text;
                image.ImageTitle = tbTitle.Text;
                if (body.Modify())
                {
                    if (image.Modify())
                    {
                        pnOK.Visible = true;
                        lblOK.Text = "Datos actualizados satisfactoriamente.";
                        pnmodify.Visible = false;
                        cargarGrid();
                    }
                    else
                    {
                        pnError.Visible = true;
                        lblError.Text = "Los datos se actualizaron parcialmente. " + image.Message;
                    }
                }
                else
                {
                    pnError.Visible = true;
                    lblError.Text = "No se pudieron actualizar los datos. " + body.Message;
                }
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = "No se pudieron actualizar los datos. " + e.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnmodify.Visible = false;
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Images image = new DB_Images();
                image.StrCon = axVarSes.Lee<string>("strCon");
                image.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                body.StrCon = axVarSes.Lee<string>("strCon");
                body.Name = tbName.Text;
                body.UpdatedBy = Convert.ToInt32(axVarSes.Lee<string>("strUserID"));
                image.ImageUrl = tbUrl.Text;
                image.ImageTitle = tbTitle.Text;
                if (image.Insert())
                {
                    DataTable dt=image.SeeByParams();
                    body.ImageId = Convert.ToInt32(dt.Rows[0][0].ToString());
                    if (body.Insert())
                    {
                        pnOK.Visible = true;
                        pnmodify.Visible = false;
                        lblOK.Text = "Datos actualizados satisfactoriamente.";
                        cargarGrid();
                    }
                    else
                    {
                        pnError.Visible = true;
                        lblError.Text = "Los datos se crearon parcialmente. " + body.Message;
                    }
                }
                else
                {
                    pnError.Visible = true;
                    lblError.Text = "No se pudieron actualizar los datos. " + image.Message;
                }
            }
            catch (Exception ex)
            {
                pnError.Visible = true;
                lblError.Text = "No se pudieron actualizar los datos. " + e.ToString();
            }
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            pnError.Visible = false;
            pnOK.Visible = false;
            pnmodify.Visible = true;
            btncreate.Visible = true;
            btnSave.Visible = false;
            tbTitle.Text = "";
            tbName.Text = "";
            tbUrl.Text = "";
        }
    }
    
}