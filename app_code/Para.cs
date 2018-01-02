using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Data;

namespace com.oli365.prize.core
{
    public class Para
    {
       
        public string Key;
        public string Value;
        public string Value2;
        public string Desc;
        public string Status;
    }


    public class ParaUtility   {


        public static Para GetPara(string key) {

            mariasql m = new core.mariasql();

            Para p=null;
            string sql = "SELECT * FROM  PARA WHERE PARA_ID=@KEY";
            MySqlCommand cmd = new MySqlCommand(sql, m.Connection);
            cmd.Parameters.AddWithValue("@KEY", key);
            DataSet ds = m.GetDataset(cmd);
            if (ds.Tables[0].Rows.Count > 0) {
                p = new core.Para();
              
                p.Key = ds.Tables[0].Rows[0]["PARA_ID"].ToString();
                p.Value = ds.Tables[0].Rows[0]["PARA_VALUE"].ToString();
                p.Value2 = ds.Tables[0].Rows[0]["PARA_VALUE2"].ToString();
                p.Desc  = ds.Tables[0].Rows[0]["PARA_DESC"].ToString();
                p.Status = ds.Tables[0].Rows[0]["FLAG"].ToString();
            }

            return p;
        }

    }


}