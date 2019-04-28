using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace ElectroestimuladorWeb
{
    public partial class Default : System.Web.UI.Page
    {

        #region "Librerias Externas"

        #endregion

        #region DB classes
        GEN_VarSession axVarSes = new GEN_VarSession();

        #endregion

        #region Variables

        string strConexion = string.Empty;
        string strSql = string.Empty;

        #endregion

        #region Functions

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                Request.Browser.Adapters.Clear();
            if (Page.IsPostBack == false)
            {
                tbUser.Focus();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            DB_Users LibUser = new DB_Users();
            LibUser.StrCon = axVarSes.Lee<string>("StrCon");
            DataTable dt = LibUser.login(tbUser.Text, tbPassword.Text);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                axVarSes.Escribe("strUser", dr["first_name"] +" "+ dr["last_name"]);
                axVarSes.Escribe("strUserAccount", dr["user_account"]);
                axVarSes.Escribe("strPassword", dr["passwd"]);
                axVarSes.Escribe("strUserID", dr["user_id"]);
                Response.Redirect("~/Forms/Index.aspx");
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = LibUser.Message;
            }
        }

        protected void tbPassword_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        protected void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }
    }
}