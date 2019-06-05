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
    // Description: Class refered to database table users_treatments
    public class BD_UsersTreatments
    {
        #region Libs
        GEN_VarSession axSesVar = new GEN_VarSession();
       
        #endregion

        #region Variables

        private string strSql = string.Empty;

        #endregion

        #region attributes
        // Class attributes
        private int _user_id = 0;
        private int _body_part_id = 0;
        private int _treatment_id = 0;
        private int _wave_id = 0;
        private int _injury_id = 0;
        private int _intensity = 0;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter database attributes

        public int UserId { get { return _user_id; } set { _user_id = value; } }
        public int BodyPartId { get { return _body_part_id; } set { _body_part_id = value; } }
        public int TreatmentId { get { return _treatment_id; } set { _treatment_id = value; } }
        public int WaveId { get { return _wave_id; } set { _wave_id = value; } }
        public int InjuryId { get { return _injury_id; } set { _injury_id = value; } }
        public int Intensity { get { return _intensity; } set { _intensity = value; } }
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

        public BD_UsersTreatments()
        {
            _user_id= 0;
            _body_part_id = 0;
            _wave_id = 0;
            _intensity = 0;
            _treatment_id = 0;
            _updated_at = string.Empty;
            _updated_by = 0;

            _message = string.Empty;
            _strcon = string.Empty;
    }

        #endregion

        #region Methods
        public string Insert()
        {
            string msg = string.Empty, error = string.Empty;
            DataTable dt = new DataTable();
            strSql = "insert into users_treatments (user_id, body_part_id, treatment_id, injury_id, wave_id, intensity, updated_at, updated_by) " +
                      "values(" + _user_id + ", " + _body_part_id + ", " + _treatment_id + ", " + _injury_id + ", " + _wave_id + ", " + _intensity + ", sysdate(),"+_user_id+")";
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
            }
            catch (Exception e)
            {
                msg = "Database ERROR. " + e.ToString();
            }   
            return msg;
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
        public DataTable SeeByUser()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT distinct i.injury_id, i.name as injury, t.treatment_id, t.name as treatment, w.name as wave, w.wave_id, b.body_part_id, b.name as body_part, Max(ut.updated_at)" +
                " from users_treatments ut, injuries i, treatments t, treatments_waves tw, waves w, body_parts b, users u" +
                " where ut.user_id="+_user_id+
                " and ut.user_id=u.user_id"+
                " and ut.treatment_id=t.treatment_id" +
                " and t.treatment_id=tw.treatment_id" +
                " and tw.wave_id=w.wave_id" +
                " and ut.wave_id=tw.wave_id " +
                " and ut.injury_id=i.injury_id" +
                " and b.body_part_id=ut.body_part_id" +
                " group by i.injury_id, i.name, t.treatment_id, t.name, w.name, w.wave_id, b.body_part_id, b.name " +
                " order by max(ut.updated_at)";
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
        public DataTable SeeInjuryProgress()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT ut.*, i.name as injury, w.name as wave, t.name as treatment, DATE_FORMAT(ut.updated_at, '%d-%m-%Y') as date" +
                " from users_treatments ut, injuries i, treatments t, treatments_waves tw, waves w, body_parts b, users u" +
                " where ut.user_id=" + _user_id +
                " and ut.injury_id="+_injury_id+
                " and ut.wave_id="+_wave_id+
                " and ut.treatment_id="+_treatment_id+
                " and ut.body_part_id="+_body_part_id+
                " and ut.user_id=u.user_id" +
                " and ut.treatment_id=t.treatment_id" +
                " and t.treatment_id=tw.treatment_id" +
                " and tw.wave_id=w.wave_id" +
                " and ut.wave_id=tw.wave_id " +
                " and ut.injury_id=i.injury_id" +
                " and b.body_part_id=ut.body_part_id" +
                " order by ut.updated_at";
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