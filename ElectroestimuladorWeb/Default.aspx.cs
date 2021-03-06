﻿using System;
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
                
                
                LibUser.UserId=Convert.ToInt32(dr["user_id"].ToString());
                if (Convert.ToInt32(axVarSes.Lee<string>("ErrorCounter"))>=3)
                {
                    LibUser.LockAccount();
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Cuenta de usuario bloqueada.";
                }
                else
                {
                    axVarSes.Escribe("strUser", dr["first_name"] + " " + dr["last_name"]);
                    axVarSes.Escribe("strUserAccount", dr["user_account"].ToString());
                    axVarSes.Escribe("strPassword", dr["passwd"].ToString());
                    axVarSes.Escribe("strUserID", dr["user_id"].ToString());
                    axVarSes.Escribe("strUserKind", dr["kind"].ToString());
                    Response.Redirect("~/Forms/Index.aspx");
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = LibUser.Message;
                axVarSes.Escribe("ErrorCounter", (Convert.ToInt16(axVarSes.Lee<string>("ErrorCounter"))+1).ToString());
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