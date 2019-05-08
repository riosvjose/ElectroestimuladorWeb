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
    // Description: Class refered to database table user_passwords
    public class DB_UserPasswords
    {
        #region Librerias Externas
        GEN_VarSession axSesVar = new GEN_VarSession();
        
        #endregion

        #region Variables Locales

        private string strSql = string.Empty;

        #endregion

        #region attributes
        // Class attributes
        private int _user_id = 0;
        private string _password = string.Empty;
        private int _pwd_status = 0;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter database attributes

        public int UserId { get { return _user_id; } set { _user_id = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public int UpdatedBy { get { return _updated_by; } set { _updated_by = value; } }
        public string UpdatedAt { get { return _updated_at; } set { _updated_at = value; } }
        public int PwdStatus { get { return _pwd_status; } set { _pwd_status = value; } }

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
        public DB_UserPasswords()
        {
            _user_id= 0;
            _password = string.Empty;
            _updated_at = string.Empty;
            _updated_by = 0;
            _pwd_status = 0;
            _message = string.Empty;
            _strcon = string.Empty;
    }

        #endregion

        #region Methods
        public bool Insert()
        {
            bool blDone = false;
            DataTable dt = new DataTable();
            strSql = "insert into user_passwords(user_id, passwd, pwd_status, updated_at, updated_by) " +
                     "values(" + _user_id + ", '" + _password + "', " + "1" + "," +" sysdate(), "+_user_id+")";
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
                blDone = true;
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
            return blDone;
        }

        public bool DisableOldPassword()
        {
            bool blOperacionCorrecta = false;
            DataTable dt = new DataTable();
            strSql = "update user_passwords set pwd_status=0 where user_id= "+_user_id ;
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
                blOperacionCorrecta = true;
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
            return blOperacionCorrecta;
        }
        public bool Delete()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        public DataTable PasswordUpdate()
        {
            string msg = string.Empty, error = string.Empty;
            if (DisableOldPassword())
            {
                DataTable dt = new DataTable();
                strSql = "insert into user_passwords(user_id, password, pwd_status, updated_at, updated_by) " +
                         "values(" + _user_id + ", '" + _password + "', '" + "1" + "', '" + " sysdate(), " + _user_id + ")";
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
                    msg = "Contraseña actudalizada satisfactoriamente.";
                }
                catch (Exception e)
                {
                    error = "1";
                    msg = "Database ERROR. " + e.ToString();
                }
            }
            else
            {
                error = "1";
                msg = "Database ERROR. " + _message;
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
        #endregion
    }
}