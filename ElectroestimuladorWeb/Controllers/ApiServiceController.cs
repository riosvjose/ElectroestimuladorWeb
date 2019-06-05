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
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ElectroestimuladorWeb
{
    [RoutePrefix("api/ApiService")]
    public class ApiServiceController : ApiController
    {
        #region Variables 
        private string strSql = string.Empty, token = ">", tokenAsign = ":";
        GEN_VarSession axVarSes = new GEN_VarSession();
        private string strCon = "Server=201.131.41.25; Port=3306; Database=Elec; Uid=ignacio; Pwd=catolica2019;";
        #endregion

        #region Libraries
        Functions Funciones = new Functions();
        #endregion

         [HttpPost]
         [Route("SignIn2")]
         public DataTable SignIn2([FromBody]ApiService ias)
         {
             DB_Users USER = new DB_Users();
             USER.StrCon = strCon;
             DataTable dt2 = USER.login(ias.usr, ias.pwd);
             DataTable dt = new DataTable();
             JObject obj = new JObject();
             DB_Users user = new DB_Users();

             if (dt2.Rows.Count > 0)
             {
                 dt = dt2;
                 DataRow dr2 = dt2.Rows[0];
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
        [Route("ListTreatmentsDetails")]
        public DataTable ListTreatmentsDetails([FromBody]ApiService ias)
        {
            BD_Treatments Treatment = new BD_Treatments();
            Treatment.StrCon = strCon;
            DataTable dt2 = Treatment.SeeDetails(ias.injury_id);
            return dt2;
        }

        [HttpPost]
        [Route("ListBodyPartDetails")]
        public DataTable ListBodyPartDetails([FromBody]ApiService ias)
        {
            DB_BodyParts BodyPart = new DB_BodyParts();
            BodyPart.StrCon = strCon;
            BodyPart.BodyPartId = Convert.ToInt32(ias.body_part_id);
            DataTable dt2 = BodyPart.SeeBodyImage();
            return dt2;
        }

        [HttpPost]
        [Route("SaveUserTreatment")]
        public string SaveUserTreatment([FromBody]ApiService ias)
        {
            BD_UsersTreatments UserTreatment = new BD_UsersTreatments();
            UserTreatment.StrCon = strCon;
            UserTreatment.Intensity = Convert.ToInt32(ias.intensity);
            UserTreatment.WaveId = Convert.ToInt32(ias.wave_id);
            UserTreatment.TreatmentId = Convert.ToInt32(ias.treatment_id);
            UserTreatment.UserId = Convert.ToInt32(ias.user_id);
            UserTreatment.InjuryId = Convert.ToInt32(ias.injury_id);
            UserTreatment.BodyPartId = Convert.ToInt32(ias.body_part_id);
            return UserTreatment.Insert();
        }

        //[HttpPost]
        //[Route("SignIn")]
        //public string SignIn([FromBody]ApiService ias)
        //{
        //    DB_Users USER = new DB_Users();
        //    USER.StrCon = strCon;
        //    DataTable dt2 = USER.login(ias.usr, ias.pwd);
        //    DataTable dt = new DataTable();
        //    JObject obj = new JObject();
        //    DB_Users user = new DB_Users();
        //    string error = "0";
        //    string msg = string.Empty, aux = string.Empty, resp = string.Empty;
        //    if (dt2.Rows.Count > 0)
        //    {
        //        dt = dt2;
        //        DataRow dr = dt.Rows[0];
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            aux += dt.Columns[i].ColumnName + tokenAsign + dr[i].ToString() + token;
        //        }
        //    }
        //    else
        //    {
        //        error = "1";
        //        msg = USER.Message;
        //    }
        //    resp = ";Error" + tokenAsign + error + token + "Message" + tokenAsign + msg + token + aux;
        //    return resp;
        //}
        //[HttpPost]
        //[Route("userRegistration")]
        //public DataTable userRegistration([FromBody]ApiService ias)
        //{
        //    DB_Users USER = new DB_Users();
        //    USER.StrCon = strCon;
        //    JArray jsonUser = ias.jsonUsuario;
        //    foreach (JObject jsonOp in jsonUser.Children<JObject>())
        //    {
        //        USER.UserAccount = jsonOp["email"].ToString();
        //        USER.FirstName = jsonOp["first_name"].ToString();
        //        USER.LastName = jsonOp["last_name"].ToString();
        //        USER.Phone = jsonOp["phone"].ToString();
        //        USER.Email = jsonOp["email"].ToString();
        //        USER.BirthDate = jsonOp["birthdate"].ToString();
        //    }
        //    DataTable dt2 = new DataTable();
        //    dt2.Clear();
        //    dt2.Columns.Add("error");
        //    dt2.Columns.Add("mensaje");
        //    DataRow row = dt2.NewRow();
        //    dt2.Rows.Add(row);
        //    return dt2;
        //}
    }
}
