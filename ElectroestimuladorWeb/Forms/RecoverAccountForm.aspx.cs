﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class RecoverAccountForm : System.Web.UI.Page
    {
        #region libs
        GEN_VarSession axVarSes = new GEN_VarSession();
        Functions Funci = new Functions();
        DB_Users libuser = new DB_Users();
        #endregion

 

        #region Procedures
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
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
                if (!string.IsNullOrEmpty(axVarSes.Lee<string>("strCon").Trim()))
                {
                    CargarDatosIniciales(axVarSes.Lee<string>("strCon"));
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }            
        }
        #endregion

        protected void btnRecover_Click(object sender, EventArgs e)
        {
            DB_Users libuser = new DB_Users();
            libuser.StrCon = axVarSes.Lee<string>("strCon");
            libuser.FirstName = tbFirstName.Text;
            libuser.LastName = tbLastName.Text;
            libuser.UserAccount = tbemail.Text;
            libuser.Email = tbemail.Text;
            libuser.BirthDate = Convert.ToDateTime(tbBirthDate.Text.Trim()).ToString("dd/MM/yyyy");
            libuser.Status = 1;
            libuser.Kind = 2;
            DataTable dt = libuser.SearchUser();
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                DB_UserPasswords libpassword = new DB_UserPasswords();
                libpassword.UserId = Convert.ToInt32(dr["user_id"]);
                libuser.UserId = Convert.ToInt32(dr["user_id"]);
                libpassword.StrCon = axVarSes.Lee<string>("strCon");
                libpassword.Password = Funci.getMd5Hash(tbPassword.Text);
                if (libuser.ActivateAccount() &&libpassword.DisableOldPassword() && libpassword.Insert())
                {
                    pnOK.Visible = true;
                    lblOK.Text = "Registro exitoso. Ya puede acceder al sistema, su cuenta es la misma que su correo electrónico.";
                    tbBirthDate.Text = "";
                    tbemail.Text = "";
                    tbLastName.Text = "";
                    tbFirstName.Text = "";
                    tbPassword.Text = "";
                    tbpwd.Text = "";
                }
                else
                {
                    libuser.Delete();
                    pnError.Visible = true;
                    lblError.Text = "No se pudo crear actualizar la contraseña, vuelva a intentarlo más tarde. " + libpassword.Message+ " "+libuser.Message;
                }

            }
            else
            {
                libuser.Delete();
                pnError.Visible = true;
                lblError.Text = "Datos incorrectos.";
            }
        }
    }
}