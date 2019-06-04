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
    // Description: Class refered to database table treatments
    public class BD_Treatments
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
        public BD_Treatments()
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
        public bool Insert()
        {
            bool bldone = false;
            DataTable dt = new DataTable();
            strSql = "insert into treatments ( name, description, updated_at, updated_by) " +
                      "values(" + "'" + _name + "', '" + _description + "', sysdate(),"+_updated_by+")";
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
                bldone = true;
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
            return bldone;
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
        public DataTable SeeAll()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT t.*, t.name as treatment_name, w.*, w.name as wave_name, tw.time_minutes" +
                " from treatments t, waves w, treatments_waves" +
                " tw where t.treatment_id=tw.treatment_id" +
                " and w.wave_id=tw.wave_id" +
                " order by t.name, w.name";
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
                _message= "Database ERROR. " + e.ToString();
            }
            return ds;
        }
        public DataTable SeeByName()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT t.*" +
                " from treatments t" +
                " order by t.name";
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
        public DataTable SeeDetails(string injury_id)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(injury_id)) {
                
                strSql = "select t.name treatment, t.treatment_id, i.name injury, w.name wave, w.wave_id, w.frecuency, w.internal_frec, tw.time_minutes " +
                    "from treatments t, injuries i, waves w, injury_treatment it, treatments_waves tw " +
                    "where t.treatment_id = it.treatment_id" +
                    " and i.injury_id = it.injury_id " +
                    "and t.treatment_id = tw.treatment_id " +
                    "and w.wave_id = tw.wave_id " +
                    "and i.injury_id = " + injury_id +
                    " order by t.name";
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
                    return dt;
                }
            }
            return dt;
        }
        public DataTable SeeTreatmentInjuryDetails()
        {
            DataTable dt = new DataTable();
                strSql = "select t.name treatment, t.treatment_id, i.injury_id, i.name injury, w.name wave, w.wave_id, w.frecuency, w.internal_frec, tw.time_minutes " +
                    "from treatments t, injuries i, waves w, injury_treatment it, treatments_waves tw " +
                    "where t.treatment_id = it.treatment_id" +
                    " and i.injury_id = it.injury_id " +
                    "and t.treatment_id = tw.treatment_id " +
                    "and w.wave_id = tw.wave_id " +
                    " order by t.name";
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
                    return dt;
                }
            return dt;
        }
        public DataTable SeeTreatmentDetails()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(_treatment_id.ToString()))
            {

                strSql = "select t.treatment_id, t.name treatment, t.description, tw.wave_id wave, w.name wave " +
                    "from treatments t, waves w, treatments_waves tw " +
                    "where t.treatment_id = tw.treatment_id" +
                    "and w.wave_id = tw.wave_id " +
                    "and t.treatment_id = " + _treatment_id +
                    " order by t.name";
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
                    da.Fill(dt);
                    
                }
                catch (Exception e)
                {
                    _message = "Database ERROR. " + e.ToString();
                }
            }
            return dt;
        }
        public DataTable SeeIdByParams()
        {
            DataTable dt = new DataTable();
            strSql = "select * from treatments where name='"+_name+"'and description='"+_description+"'";
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