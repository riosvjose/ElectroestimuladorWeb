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
        [Route("SignIn")]
        public string SignIn([FromBody]ApiService ias)
        {
            DB_Users USER = new DB_Users();
            USER.StrCon = strCon;
            DataTable dt2 = USER.login(ias.usr, ias.pwd);
            DataTable dt = new DataTable();
            JObject obj = new JObject();
            DB_Users user = new DB_Users();
            string error = "0";
            string msg = string.Empty, aux = string.Empty, resp = string.Empty;
            if (dt2.Rows.Count > 0)
            {
                dt = dt2;
                DataRow dr = dt.Rows[0];
                for(int i = 0; i < dt.Columns.Count; i++)
                {
                    aux += dt.Columns[i].ColumnName+tokenAsign+ dr[i].ToString()+token;
                }
            }
            else
            {
                error= "1";
                msg = USER.Message;
            }
            resp = ";Error"+tokenAsign+error + token +"Message"+tokenAsign+ msg + token + aux;
            return resp;
        }

        //[HttpPost]
        //[Route("SignIn")]
        //public JObject SignIn([FromBody]ApiService ias)
        //{
        //    DB_Users USER = new DB_Users();
        //    USER.StrCon = strCon;
        //    DataTable dt2 = USER.login(ias.usr, ias.pwd);
        //    DataTable dt = new DataTable();
        //    JObject obj = new JObject();
        //    DB_Users user = new DB_Users();

        //    if (dt2.Rows.Count >0)
        //    {
        //        dt = dt2;
        //        DataRow dr2 = dt2.Rows[0];        
        //    }
        //    else
        //    {
        //        dt.Clear();
        //        dt.Columns.Add("error");
        //        dt.Columns.Add("mensaje");
        //        DataRow row = dt.NewRow();
        //        row["error"] = "1";
        //        row["mensaje"] = USER.Message;
        //        dt.Rows.Add(row);
        //    }
        //    // List<DB_Users> UserList = new List<DB_Users> { new DB_Users {UserId=Convert.ToInt32(dt.Rows[0]["user_id"].ToString()), FirstName= dt.Rows[0]["first_name"].ToString() } };


        //    //JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    //return serializer.Serialize(UserList);
        //    //obj = JObject.Parse(UserList);
        //    JArray array = new JArray();
        //    //array= JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
        //    string JSONString = string.Empty;
        //    JSONString = JsonConvert.SerializeObject(dt);
        //    DataRow dr = dt.Rows[0];
        //    for(int i=0; i < dt.Columns.Count; i++)
        //    {
        //        array.Add(dr[i].ToString());
        //    }
        //    JObject Jobj = new JObject();
        //    Jobj["usuario"] = JSONString;
        //    return Jobj;
        //}

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
        public string ListBody([FromBody]ApiService ias)
        {
            string resp = ";";
            DB_BodyParts Body = new DB_BodyParts();
            Body.StrCon = strCon;
            DataTable dt2 = Body.SeeAll();
            for (int j = 0; j < dt2.Rows.Count;j++)
            {
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    resp += dt2.Rows[j][i];
                    resp += "*";
                }
                resp += ";";
            }
            return resp;
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
