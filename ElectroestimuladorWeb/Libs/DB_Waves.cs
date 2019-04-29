using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace ElectroestimuladorWeb
{
    // Description: Class refered to database table users
    public class BD_Waves
    {
        #region Libs
        GEN_VarSession axSesVar = new GEN_VarSession();
        
        #endregion

        #region Variables

        private string strSql = string.Empty;

        #endregion

        #region attributes
        // Class attributes
        private int _treatment_id = 0;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter database attributes

        public int TreatmentId { get { return _treatment_id; } set { _treatment_id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public int UpdatedBy { get { return _updated_by; } set { _updated_by = value; } }
        public string UpdatedAt { get { return _updated_at; } set { _updated_at = value; } }

        // getters and setters other attributes
        public string Message
        {
            get { return _message; }
        }
        public string StrCon
        {
            get { return _strcon; }
            set { _strcon = value; }
        }

        #endregion

        #region Constructor
        public BD_Waves()
        {
            _treatment_id = 0;
            _name = string.Empty;
            _description = string.Empty;
            _updated_at = string.Empty;
            _updated_by = 0;

            _message = string.Empty;
            _strcon = string.Empty;
    }

        #endregion

        #region Methods
        public DataTable Insert()
        {
            string msg = string.Empty, error = string.Empty;
            DataTable dt = new DataTable();
            strSql = "insert into treatments (name, description, updated_at, updated_by) " +
                      "values(" + _name + "', '" + _description + "', sysdate(),"+_updated_by+")";
            MySqlConnection databaseConnection = new MySqlConnection(StrCon);
            MySqlCommand commandDatabase = new MySqlCommand(strSql, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            MySqlDataAdapter da;
            DataTable ds = new DataTable();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                da = new MySqlDataAdapter(commandDatabase);
                databaseConnection.Close();
                error = "0";
                msg = "Registro creado satisfactoriamente.";
            }
            catch (Exception e)
            {
                error = "1";
                msg = "Database ERROR. " + e.ToString();
            }   
            DataTable dt2 = new DataTable();
            dt2.Clear();
            dt2.Columns.Add("error");
            dt2.Columns.Add("mensaje");
            DataRow row = dt2.NewRow();
            row["error"] = error;
            row["mensaje"] = msg;
            dt2.Rows.Add(row);
            return dt2;
        }

        public bool Modify()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        public bool Delete()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        public DataTable SeeByUser(string Uid)
        {
            DataTable dt = new DataTable();
            strSql = "SELECT * from users_treatments where user_id="+Uid;
            MySqlConnection databaseConnection = new MySqlConnection(StrCon);
            MySqlCommand commandDatabase = new MySqlCommand(strSql, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            MySqlDataAdapter da;
            DataTable ds = new DataTable();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                da = new MySqlDataAdapter(commandDatabase);
                databaseConnection.Close();
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                string error = "1";
                string mensaje = "Database ERROR. " + e.ToString();
                DataTable dt2 = new DataTable();
                dt2.Clear();
                dt2.Columns.Add("error");
                dt2.Columns.Add("mensaje");
                DataRow row = dt2.NewRow();
                row["error"] = error;
                row["mensaje"] = mensaje;
                dt2.Rows.Add(row);
                return dt2;
            }
           
        }
        
        #endregion
    }
}