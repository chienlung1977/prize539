using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace com.oli365.prize.core
{

    public class mariasql
    {

        private string _connectionString;
        private MySqlConnection _conneciton;

        public mariasql()
        {
            //this._connectionString = "server=127.0.0.1;port=3306;database=nc;uid=nc_user;password=!qaz2wsx";
            this._connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        
        public string ConnectionString
        {
            get { return this._connectionString; }
        }

        public MySqlConnection Connection {
            get {
                if (this._conneciton == null) {
                    this._conneciton = new MySqlConnection(this._connectionString);
                }
                return this._conneciton;
            }
        }


        public Boolean TestConnection(out string err)
        {

            try
            {
                this.Connection.Open();
                this.Connection.Close();
                err = "";
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                err = ex.ToString();
                return false;
            }

        }


        public DataSet GetDataset(string sqlQuery)
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, this._connectionString );
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;

        }

        public bool Execute(string sql)
        {

            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Connection.Open();
            Boolean result = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return result;

        }

        public bool Execute(MySqlCommand cmd) {
            cmd.Connection.Open();
            Boolean result = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return result;
        }

        public bool Execute(string sql, List<MySqlParameter> parameters)
        {

            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            foreach (MySqlParameter s in parameters)
            {
                cmd.Parameters.Add(s);
            }
            cmd.Connection.Open();
            Boolean result = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return result;
        }

        public DataSet GetDataset(MySqlCommand cmd) {
          
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetDataset(string sqlQuery, List<MySqlParameter> parameters)
        {

            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            foreach (MySqlParameter s in parameters)
            {
                cmd.Parameters.Add(s);
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }



        public object ExecuteScalar(string sql, List<MySqlParameter> parameters)
        {

            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            foreach (MySqlParameter s in parameters)
            {
                cmd.Parameters.Add(s);
            }

            object obj = cmd.ExecuteScalar();
            return obj;


        }

    }

    public class Db : mariasql {


    }



}