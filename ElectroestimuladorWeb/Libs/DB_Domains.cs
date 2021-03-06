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
    // Description: Class refered to database table body_parts
    public class DB_Domains
    {
        #region Libs
        GEN_VarSession axSesVar = new GEN_VarSession();
      
        #endregion

        #region Variables

        private string strSql = string.Empty;

        #endregion

        #region attributes
        // Class attributes
        private string _domain=string.Empty;
        private string _description = string.Empty;
        private int _value = 0;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter table attributes      
        public string Domain { get { return _domain; } set { _domain = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public int Value { get { return _value; } set { _value = value; } }
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
        public DB_Domains()
        {
            _domain = string.Empty;
            _description = string.Empty;
            _value = 0;
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
            strSql = "insert into domains (domain, value, descriptiom, updated_at, updated_by) " +
                      "values(" + "'" + _domain  + "',"+_value+", '" + _description  + "', sysdate(),"+_updated_by+")";
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
        public DataTable SeeDomain()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT * from domains where domain_name='"+_domain+"'";
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

        #endregion
    }
}