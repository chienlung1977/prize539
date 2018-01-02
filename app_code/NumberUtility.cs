using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using MySql.Data.MySqlClient;

namespace com.oli365.prize.core
{
    public class NumberUtility
    {

        public Boolean Add(Number item) {


            Db db = new core.Db();
            string sql = "INSERT INTO PRIZE539(PRIZE_UID,CREATE_DATE,PERIOD,LOTTERY_DAY,NUM1,NUM2,NUM3,NUM4,NUM5)" +
                "VALUES(@PRIZE_UID,@CREATE_DATE,@PERIOD,@LOTTERY_DAY,@NUM1,@NUM2,@NUM3,@NUM4,@NUM5)";
            MySqlCommand cmd = new MySqlCommand(sql, db.Connection);
            cmd.Parameters.AddWithValue("@PRIZE_UID",Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@CREATE_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@PERIOD", item.Period);
            cmd.Parameters.AddWithValue("@LOTTERY_DAY", item.Date );
            cmd.Parameters.AddWithValue("@NUM1", item.Num1);
            cmd.Parameters.AddWithValue("@NUM2", item.Num2);
            cmd.Parameters.AddWithValue("@NUM3", item.Num3);
            cmd.Parameters.AddWithValue("@NUM4", item.Num4);
            cmd.Parameters.AddWithValue("@NUM5", item.Num5);
            return db.Execute(cmd);


        }

    }

    public class Number {

        public string Period;
        public string Date;
        public string Num1;
        public string Num2;
        public string Num3;
        public string Num4;
        public string Num5;

    }

}