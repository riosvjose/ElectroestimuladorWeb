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
        #region "Librerias Externas"

        #endregion

        #region "Procedimientos y Funciones Locales"

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(axVarSes.Lee<string>("strConexion").Trim()))
            {
                Response.Redirect("~/Default.aspx");
            }            
            else
            {
                // Desplegar el SideBar de acuerdo a que modulos tiene permisos una persona
                libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                List<string> AccesoObjeto= new List<string>();
                AccesoObjeto = libproc.ListaAccesoObjetoUsuario(); //Lista de todos los objetos a los que tiene permiso el usuario que Inicio Sesión
                if (AccesoObjeto.Contains("ALM_ALM_AdministrarAlmacenes_permitir_acceso"))
                {
                    sbAdminAlmacenes.Visible = true;
                    sbUsuarios.Visible = true;
                }
                if (AccesoObjeto.Contains("ALM_AdministrarPasos_permitir_acceso"))
                    sbAdministrarPermisosPasos.Visible = true;
                if (AccesoObjeto.Contains("ALM_RegistrarIngreso_permitir_acceso"))
                    sbRegIngreso.Visible = true;
                if (AccesoObjeto.Contains("ALM_MED_AdministrarMedidas_permitir_acceso"))
                    sbAdminMedidas.Visible = true;
                if (AccesoObjeto.Contains("ALM_PROV_AdministrarProveedores_permitir_acceso"))
                    sbAdminProveedores.Visible = true;
                if (AccesoObjeto.Contains("ALM_GRU_AdministrarGrupos_permitir_acceso"))
                    sbAdminGrupos.Visible = true;
                if (AccesoObjeto.Contains("ALM_CAT_AdministrarCategorias_permitir_acceso"))
                    sbAdminCategorias.Visible = true;
                if (AccesoObjeto.Contains("ALM_ITEM_AdministrarItems_permitir_acceso"))
                    sbAdminItems.Visible = true;
                //Desplegar los Collapse si una persona tiene permiso al menos a un módulo
                
                // Collapse de Pedidos
                int pedidos = 0;
                if (AccesoObjeto.Contains("ALM_PED_Realizar_permitir_acceso"))
                {
                    lnkbtnRealizarPedido.Visible = true;
                    pedidos++;
                }
                if (AccesoObjeto.Contains("ALM_PED_Autorizar_permitir_acceso"))
                {
                    lnkbtnAutorizarPedido.Visible = true;
                    pedidos++;
                }
                if (AccesoObjeto.Contains("ALM_PED_Entregar_permitir_acceso"))
                {
                    lnkbtnEntregarPedido.Visible = true;
                    pedidos++;
                }
                if (AccesoObjeto.Contains("ALM_TOK_Generar_Token_permitir_acceso"))
                {
                    lnkbtnGenerarToken.Visible = true;
                    pedidos++;
                }
                if (AccesoObjeto.Contains("ALM_PED_Buscar_permitir_acceso"))
                {
                    lnkbtnBuscarItem.Visible = true;
                    pedidos++;
                }
                if (pedidos > 0) //Mostrar sbPedidos en caso de que el usuario tenga acceso a almenos un modulo
                    sbPedidos.Visible = true;

                //Collapse de Salidas
                int salidas = 0;
                if (AccesoObjeto.Contains("ALM_SAL_Registrar_permitir_acceso"))
                {
                    lnkbtnRegistarSalida.Visible = true;
                    salidas++;
                }
                if (AccesoObjeto.Contains("ALM_SAL_Autorizar_permitir_acceso"))
                {
                    lnkbtnAutorizarSalida.Visible = true;
                    salidas++;
                }
                if (salidas > 0)//Mostrar sbSalidas en caso de que el usuario tenga acceso a almenos un modulo
                    sbSalidas.Visible = true;

                //Collapse de Reportes
                int reportes = 0;
                if (AccesoObjeto.Contains("ALM_REP_ItemsEntregados_permitir_acceso"))
                {
                    lnkbtnReporte1.Visible = true;
                    reportes++;
                }
                if (AccesoObjeto.Contains("ALM_REP_ConsumoDepartamento_permitir_acceso"))
                {
                    lnkbtnReporte2.Visible = true;
                    reportes++;
                }
                if (AccesoObjeto.Contains("ALM_REP_ExistenciasItems_permitir_acceso"))
                {
                    lnkbtnReporte3.Visible = true;
                    reportes++;
                }
                if (reportes > 0)
                    sbReportes.Visible = true;
            }
            */
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

        #region "Procedimientos y Funciones Públicos"
        #endregion
        #region "Eventos"
        
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