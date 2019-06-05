using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ElectroestimuladorWeb.Forms
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        #region libs
        GEN_VarSession axVarSes = new GEN_VarSession();
        #endregion

        #region procedures

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(axVarSes.Lee<string>("strUserID"))) || (string.IsNullOrEmpty(axVarSes.Lee<string>("strCon"))))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (axVarSes.Lee<string>("strUserKind").Equals("1"))
                {
                    sbInjuries.Visible = true;
                    sbTreatments.Visible = true;
                    sbBodyParts.Visible = true;
                  }

            }
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
                if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                {
                    Request.Browser.Adapters.Clear();
                }

            }
        }
        #endregion

        #region "Events"
        
        protected void lnkbtnAlmacen_Click(object sender, EventArgs e)
        {
           Response.Redirect("Index.aspx");
        }

        protected void lnkbtnAutorizarPedido_Click(object sender, EventArgs e)
        {
           Response.Redirect("ALM_PED_Autorizar.aspx");
        }

        protected void lnkbtnRealizarPedido_Click(object sender, EventArgs e)
        {
           Response.Redirect("ALM_PED_Realizar.aspx");
        }

        protected void lnkbtnEntregarPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PED_Entregar1.aspx");
        }

        protected void lnkbtnGenerarToken_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_TOK_GenerarToken.aspx");
        }

        protected void lnkbtnRegistarSalida_Click(object sender, EventArgs e)
        {
           Response.Redirect("ALM_SAL_Registrar.aspx");
        }

        protected void lnkbtnAutorizarSalida_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_SAL_Autorizar.aspx");
        }

        protected void lnkbtnReporte1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ItemsEntregados.aspx");
        }

        protected void lnkbtnReporte2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_ConsumoDepto.aspx");
        }

        protected void lnkbtnReporte3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_REP_Existencias.aspx");
        }

        protected void lnkbtnBuscarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_PED_Buscar.aspx");
        }


        #endregion
    }
}