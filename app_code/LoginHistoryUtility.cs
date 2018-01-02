using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace com.oli365.prize.core
{
    public static  class LoginHistoryUtility
    {

        public static  DataSet  GetList(string uid)
        {
            mariasql m = new mariasql();
            string sql = "SELECT A.*,B.NICK_NAME FROM LOGIN_HISTORY AS A INNER JOIN USER AS B ON A.USER_ID=B.USER_ID WHERE A.USER_ID=@USER_ID ORDER BY CREATE_DATE DESC;";
            List<MySqlParameter> l = new List<MySqlParameter>();
            l.Add(new MySqlParameter("@USER_ID", uid));
            return m.GetDataset(sql, l);
        }

        public static DataSet GetList() {
            mariasql m = new mariasql();
            string sql = "SELECT A.*,B.NICK_NAME FROM LOGIN_HISTORY AS A INNER JOIN USER AS B ON A.USER_ID=B.USER_ID  ORDER BY CREATE_DATE DESC;";
            
            return m.GetDataset(sql);
        }
  

    }
}