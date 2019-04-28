using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Data;

using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;

namespace ElectroestimuladorWeb
{
    [RoutePrefix("api/ApiService")]
    public class ApiServiceController : ApiController
    {
        #region Variables locales 
        private string strSql = string.Empty;
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strCon = "Server=201.131.41.25; Port=3306; Database=Elec; Uid=ucbtest; Pwd=Catolica.2019;";
        #endregion

        #region Librerias Externas
        Funciones Funciones = new Funciones();
        #endregion

        [HttpPost]
        [Route("SignIn")]
        public DataTable SignIn([FromBody]ApiService ias)
        {
            DB_Users USER = new DB_Users();
            USER.StrCon = strCon;
            DataTable dt2 = USER.login(ias.usr, ias.pwd);
            return dt2;
        }

        [HttpPost]
        [Route("FillUserData")]
        public DataTable IngresarSistema([FromBody]ApiService ias)
        {
            DB_Users USER = new DB_Users();
            USER.StrCon = strCon;
            USER.UserAccount = ias.usr;
            DataTable dt2 = USER.See();
            return dt2;
        }
        [HttpPost]
        [Route("userRegistration")]
        public DataTable userRegistration([FromBody]ApiService ias)
        {
            DB_Users USER = new DB_Users();
            USER.StrCon = strCon;
            JArray jsonUser = ias.jsonUsuario;
            foreach (JObject jsonOp in jsonUser.Children<JObject>())
            {
                USER.UserAccount = jsonOp["email"].ToString();
                USER.FirstName = jsonOp["first_name"].ToString();
                USER.LastName = jsonOp["last_name"].ToString();
                USER.Phone = jsonOp["phone"].ToString();
                USER.Email = jsonOp["email"].ToString();
                USER.BirthDate = jsonOp["birthdate"].ToString();
            }
            DataTable dt2 = USER.Insert();
            return dt2;
        }

    }
}
