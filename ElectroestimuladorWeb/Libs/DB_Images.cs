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
    // Description: Class refered to database table Images
    public class DB_Images
    {
        #region Libs
        GEN_VarSession axSesVar = new GEN_VarSession();
        
        #endregion

        #region Variables

        private string strSql = string.Empty;

        #endregion

        #region attributes
        // Class attributes
        private int _image_id = 0;
        private string _title = string.Empty;
        private string _image_url = string.Empty;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter table attributes      
        public int ImageId { get { return _image_id; } set { _image_id = value; } }
        public string ImageUrl { get { return _image_url; } set { _image_url = value; } }
        public string ImageTitle { get { return _title; } set { _title = value; } }
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
        public DB_Images()
        {
            _image_id = 0;
            _title = string.Empty;
            _image_url = string.Empty;
            _updated_at = string.Empty;
            _updated_by = 0;

            _message = string.Empty;
            _strcon = string.Empty;
    }

        #endregion

        #region Methods
        public bool Insert()
        {
            string msg = string.Empty;
            bool blDone = false;
            DataTable dt = new DataTable();
            strSql = "insert into images (title, image_url, updated_at, updated_by) " +
                      "values(" +"'"+_title  + "', '" + _image_url  + "', sysdate(),"+_updated_by+")";
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
                msg = "Registro creado satisfactoriamente.";
            }
            catch (Exception e)
            {
                blDone = false;
                msg = "Database ERROR. " + e.ToString();
            }
            return blDone;
        }

        public bool Modify()
        {
            bool blOperacionCorrecta = false;
            string msg = string.Empty, error = string.Empty;
            DataTable dt = new DataTable();
            strSql = "update images set title='" + _title +"', image_url='"+_image_url+"'"+
                      ", updated_at=sysdate(), updated_by=" + _updated_by + " where image_id="+_image_id;
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
                msg = "Registro actualizado satisfactoriamente.";
                blOperacionCorrecta = true;
            }
            catch (Exception e)
            {
                error = "1";
                msg = "Database ERROR. " + e.ToString();
            }
            return blOperacionCorrecta;
        }
        public bool Delete()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        public DataTable See()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT * from images where image_id="+_image_id;
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
        public DataTable SeeByParams()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT * from images where image_url='" + _image_url +"' and title= '"+_title+"'";
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