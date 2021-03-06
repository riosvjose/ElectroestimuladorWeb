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
    public class DB_BodyParts
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
        private int _body_part_id = 0;
        private string _name = string.Empty;
        private int _image_id = 0;
        private string _updated_at = string.Empty;
        private int _updated_by = 0;

        // Other attributes
        private string _message = string.Empty;
        private string _strcon = string.Empty;

        // getters and setter table attributes      
        public int BodyPartId { get { return _body_part_id; } set { _body_part_id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int ImageId { get { return _image_id; } set { _image_id = value; } }
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
        public DB_BodyParts()
        {
            _body_part_id = 0;
            _name = string.Empty;
            _image_id = 0;
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
            strSql = "insert into body_parts (image_id, name, updated_at, updated_by) " +
                      "values(" + _image_id  + ", '" + _name  + "', sysdate(),"+_updated_by+")";
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
            strSql = "update body_parts set name='"+_name +"'"+
                      ", updated_at=sysdate(), updated_by=" + _updated_by + " where body_part_id="+_body_part_id;
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
        public DataTable SeeAll()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT b.*, i.image_url from body_parts b, images i where b.image_id=i.image_id order by name";
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

        public DataTable SeeBodyImage()
        {
            DataTable dt = new DataTable();
            strSql = "SELECT b.*, i.* from body_parts b, images i where i.image_id=b.image_id and b.body_part_id="+_body_part_id;
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
                string mensaje = "Database ERROR. " + e.ToString();
            }
            return ds;
        }
        #endregion
    }
}