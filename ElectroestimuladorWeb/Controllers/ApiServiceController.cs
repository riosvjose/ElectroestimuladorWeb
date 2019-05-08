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
        #region Variables 
        private string strSql = string.Empty;
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strCon = "Server=201.131.41.25; Port=3306; Database=Elec; Uid=ignacio; Pwd=catolica2019;";
        #endregion

        #region Libraries
        Functions Funciones = new Functions();
        #endregion

        [HttpGet]
        [Route("SignIn")]
        public DataTable SignIn([FromBody]ApiService ias)
        {
            DB_Users USER = new DB_Users();
            USER.StrCon = strCon;
            DataTable dt2 = USER.login(ias.usr, ias.pwd);
            DataTable dt = new DataTable();
            if (dt2.Rows.Count >= 1)
            {
                dt = dt2;
            }
            else
            {
                dt.Clear();
                dt.Columns.Add("error");
                dt.Columns.Add("mensaje");
                DataRow row = dt.NewRow();
                row["error"] = "1";
                row["mensaje"] = USER.Message;
                dt.Rows.Add(row);
            }
            return dt;
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
            DataTable dt2 = new DataTable();
            dt2.Clear();
            dt2.Columns.Add("error");
            dt2.Columns.Add("mensaje");
            DataRow row = dt2.NewRow();
            dt2.Rows.Add(row);
            return dt2;
            if (USER.Insert())
            {
                row["error"] = "0";
                row["mensaje"] = "Registro exitoso.";
            }
            else
            {
                row["error"] = "1";
                row["mensaje"] = USER.Message;
            }
            return dt2;
        }

        [HttpPost]
        [Route("ListBody")]
        public DataTable ListBody([FromBody]ApiService ias)
        {
            DB_BodyParts Body = new DB_BodyParts();
            Body.StrCon = strCon;
            DataTable dt2 = Body.SeeAll();
            return dt2;
        }

        [HttpPost]
        [Route("ListInjuries")]
        public DataTable ListInjuries([FromBody]ApiService ias)
        {
            DB_Injuries Injuries = new DB_Injuries();
            Injuries.StrCon = strCon;
            DataTable dt2 = Injuries.dtListAll();
            return dt2;
        }

        [HttpPost]
        [Route("ListTreatments")]
        public DataTable ListTreatments([FromBody]ApiService ias)
        {
            BD_Treatments Treatment = new BD_Treatments();
            Treatment.StrCon = strCon;
            DataTable dt2 = Treatment.SeeAll();
            return dt2;
        }

        [HttpPost]
        [Route("ListTreatmentsDetails")]
        public DataTable ListTreatmentsDetails([FromBody]ApiService ias)
        {
            BD_Treatments Treatment = new BD_Treatments();
            Treatment.StrCon = strCon;
            DataTable dt2 = Treatment.SeeDetails(ias.injury_id);
            return dt2;
        }

    }
}
