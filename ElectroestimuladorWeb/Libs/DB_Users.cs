using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ElectroestimuladorWeb
{
    // Description: Class refered to database table users
    public class DB_Users
    {
        #region Libs
        GEN_VarSession axSesVar = new GEN_VarSession();
        Functions Funciones = new Functions();
        #endregion

        #region Variables

        private string strSql = string.Empty;

        #endregion

        #region attributes
        // Class attributes
        private int _user_id = 0;
        private string _user_account = string.Empty;
        private string _first_name = string.Empty;
        private string _last_name = string.Empty;
        private string _birthdate = string.Empty;
        private string _email = string.Empty;
        private string _phone = string.Empty;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;
        private int _kind = 0;
        private int _status = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter database attributes

        public int UserId { get { return _user_id; } set { _user_id = value; } }
        public string UserAccount { get { return _user_account; } set { _user_account = value; } }
        public string FirstName { get { return _first_name; } set { _first_name = value; } }
        public string LastName { get { return _last_name; } set { _last_name = value; } }
        public string BirthDate { get { return _birthdate; } set { _birthdate = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public int UpdatedBy { get { return _updated_by; } set { _updated_by = value; } }
        public string UpdatedAt { get { return _updated_at; } set { _updated_at = value; } }
        public int Kind { get { return _kind; } set { _kind = value; } }
        public int Status { get { return _status; } set { _status = value; } }

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
        public DB_Users()
        {
            _user_id= 0;
            _user_account = string.Empty;
            _first_name = string.Empty;
            _last_name = string.Empty;
            _birthdate = string.Empty;
            _email = string.Empty;
            _phone = string.Empty;
            _updated_at = string.Empty;
            _updated_by = 0;
            _kind = 0;
            _status = 0;
            _message = string.Empty;
            _strcon = string.Empty;
    }

        #endregion

        #region Methods
        public bool Insert()
        {
            bool blDone = false;
            DataTable dt = new DataTable();
            strSql = "insert into users(user_account, first_name, last_name, email, phone, birthdate, active, kind, updated_at, updated_by) " +
                     "values( '" + _user_account + "', '" + _first_name + "', '" + _last_name + "', '" + _email + "', '" + _phone + "', " + "STR_TO_DATE('" + _birthdate + "','%d/%m/%Y')" + ", " + _status + ", " + _kind + ", sysdate(), 0)";
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

        public bool Modify()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        public void Delete()
        {
            DataTable dt = new DataTable();
            strSql = "delete from users where user_id=" + _user_id;
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
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
        }
        public DataTable See()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT * from users where user_account='"+_user_account+"'";
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
        public DataTable login(string usr, string pwd)
        {
            DataTable dt = new DataTable();
            if (usr.Trim().Length == 0)
            {
                _message = "El campo Documento de Identidad es obligatorio.";
            }
            if (pwd.Trim().Length == 0)
            {
                _message = "El campo Contraseña es obligatorio.";
            }

            usr = Funciones.EliminarCaracteresEspeciales(usr);
            pwd = Funciones.EliminarCaracteresEspeciales(pwd);
            pwd = Funciones.getMd5Hash(pwd);
            strSql = " select u.*, p.passwd from users u, user_passwords p " +
                     "where u.user_account='" +usr + "'" +
                     " and u.user_id=p.user_id" +
                     " and p.pwd_status=1" +
                     " and p.passwd='" + pwd + "'";

            MySqlConnection databaseConnection = new MySqlConnection(StrCon);
            MySqlCommand commandDatabase = new MySqlCommand(strSql, databaseConnection);
            commandDatabase.CommandTimeout = 120;
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
                if (ds.Rows.Count < 1)
                {
                    _message = "Verifique su usuario y/o Contraseña.";
                }
                else
                {
                    _message = "Bienvenido al sistema.";
                }
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
            return ds;
        }
        public DataTable Search(string paramet)
        {
            DataTable dt = new DataTable();
            paramet = Funciones.EliminarCaracteresEspeciales(paramet);
            strSql = " select u.* from users u " +
                     "where (u.email='" + paramet + "'" +
                     " or u.last_name='" + paramet+"'"+
                     " or u.first_name='" + paramet + "'" +
                     " or concat (u.last_name, '', u.first_name) = '" + paramet +"'"+
                     " or concat (u.first_name, '', u.last_name) = '" + paramet+"')" +
                     " order by u.last_name, u.first_name";

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
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
            return ds;
        }

        public DataTable SearchIfExist()
        {
            DataTable dt = new DataTable();
            strSql = "select * from users where user_account ='" + _user_account+"'";
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
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
            return ds;
        }
        #endregion
    }
}