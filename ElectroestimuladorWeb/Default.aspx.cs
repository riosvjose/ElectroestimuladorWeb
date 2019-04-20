using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ElectroestimuladorWeb
{
    public partial class Default : System.Web.UI.Page
    {

        #region "Librerias Externas"

        #endregion

        #region "Clase de tablas de la Base de Datos"


        #endregion

        #region "Variables Globales"

        string strConexion = string.Empty;
        string strSql = string.Empty;

        #endregion

        #region "Funciones y Procedimientos"

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                Request.Browser.Adapters.Clear();
            if (Page.IsPostBack == false)
            {
                //axVarSes.Escribe("strMensaje_Inicial_Pagina", string.Empty);
                tbUsuario.Focus();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            /*AutenticacionBD.Login = tbUsuario.Text.Trim();
            AutenticacionBD.Password = tbPassword.Text.Trim();
            AutenticacionBD.Servidor = axVarSes.Lee<string>("Servidor");
            
            AutenticacionBD.Pagina = this.Page;
            AutenticacionBD.MostrarError = false;
            AutenticacionBD.AutenticarSAM();

            axVarSes.Escribe("Servidor", axVarSes.Lee<string>("Servidor"));
            axVarSes.Escribe("StrConexion", AutenticacionBD.StrConexion);
            libmodulos.StrConexion = axVarSes.Lee<string>("StrConexion"); ;
            axVarSes.Escribe("UsuarioNumSec", AutenticacionBD.NumSec.ToString());
            axVarSes.Escribe("NumSecModulo", libmodulos.ObtenerNSModulo().ToString());
            axVarSes.Escribe("UsuarioLogin", AutenticacionBD.Login);
            axVarSes.Escribe("UsuarioCarrera", string.Empty);
            axVarSes.Escribe("UsuarioFacultad", string.Empty);
            axVarSes.Escribe("UsuarioPerfil", "0");
            axVarSes.Escribe("UsuarioPersonaNumSec", AutenticacionBD.Persona_NumSec.ToString());
            axVarSes.Escribe("UsuarioPersonaCI", AutenticacionBD.Persona_CI);
            axVarSes.Escribe("UsuarioPersonaNombre", AutenticacionBD.Persona_Nombre);
            axVarSes.Escribe("UsuarioPersonaTipo", AutenticacionBD.Persona_Tipo.ToString());
            axVarSes.Escribe("usuario_persona_grupo", AutenticacionBD.Persona_Grupo.ToString());
            axVarSes.Escribe("ax_Permitir_Manuales_Todos", "1");
            axVarSes.Escribe("UsuarioNumSecAlmacen", "0");
            axVarSes.Escribe("NumSecItem", "0");
            BD_GEN_Subdeptos_Personas libSubdeptoPersona = new BD_GEN_Subdeptos_Personas();
            libSubdeptoPersona.StrConexion = axVarSes.Lee<string>("StrConexion");
            libSubdeptoPersona.Ver();
            axVarSes.Escribe("strDeptoUsuario", libSubdeptoPersona.NumSecSubdepto.ToString());
            if (AutenticacionBD.Autenticado)
            {
                lblMensaje.Visible = false;
                //axVarSes.Escribe("Path", webForms.Determinar_Path_App());
                Determinar_Path();
                //if (AutenticacionBD.CambioPwd)
                //{
                //    axVarSes.Escribe("UsuarioLogin", "");
                //    axVarSes.Escribe("usuario_login_cambiopwd", AutenticacionBD.Login);
                //    Response.Redirect("~/Forms/SACAD_CambioPassword.aspx");
                //}
                //else
               // {
                    //AutenticacionBD.AutenticarADMSINF();
                    axVarSes.Escribe("UsuarioCodigo", AutenticacionBD.CodigoUsuario);
                    //Revisar_Permisos_Operacion(AutenticacionBD.Persona_NumSec.ToString(),axVarSes.Lee<string>("modulo_ns"), axVarSes.Lee<string>("UsuarioNumSec"), axVarSes.Lee<string>("subunidad_ns"), axVarSes.Lee<string>("strConexion"));
                    Response.Redirect("~/Forms/Index.aspx");
                //}
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = AutenticacionBD.Mensaje;
            }*/
            Response.Redirect("~/Forms/Index.aspx");
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