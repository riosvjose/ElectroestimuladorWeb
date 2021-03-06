﻿using System;
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
    public class DB_Injuries
    {
        #region Libs

        #endregion

        #region Variables

        private string strSql = string.Empty;

        #endregion

        #region attributes
        // Class attributes
        private int _injurie_id = 0;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter database attributes

        public int InjurieId { get { return _injurie_id; } set { _injurie_id = value; } }
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
        public DB_Injuries()
        {
            _injurie_id = 0;
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
            strSql = "insert into injuries ( name, description, updated_at, updated_by) " +
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
            DataTable dt = new DataTable();
            strSql = "update injuries" +
                " set ";
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
            return blOperacionCorrecta;
        }
        public bool Delete()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        public DataTable dtListAll()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT * from injuries order by name";
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
        public string obtenerID()
        {
            bool bldone = false;
            DataTable dt = new DataTable();
            strSql = "select  max(injury_id) as id " +
                      "from injuries where updated_by=" + _updated_by;
            MySqlConnection databaseConnection = new MySqlConnection(StrCon);
            MySqlCommand commandDatabase = new MySqlCommand(strSql, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            MySqlDataAdapter da;
            DataTable ds = new DataTable();
            string aux = "";
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                da = new MySqlDataAdapter(commandDatabase);
                databaseConnection.Close();
                da.Fill(ds);
                aux = ds.Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                _message = "Database ERROR. " + e.ToString();
            }
            return aux;
        }

        #endregion
    }
}