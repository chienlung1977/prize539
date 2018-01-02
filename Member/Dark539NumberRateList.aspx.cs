using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using MySql.Data.MySqlClient;

using CoreLib;

namespace com.oli365.prize.Member
{
    public partial class Dark539NumberRateList : BasePage 
    {

        string forecastPeriod;
        string forecastUid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingData();
            }
        }

        private void bindingData() {

            Mariadb m = new Mariadb(this.CN);

            string sql = "SELECT FORECAST_UID,NEXT_PERIOD FROM USER_FORECAST WHERE IS_CHECK='0' AND USER_UID=@USER_UID AND LOTTO_TYPE=3 ORDER BY NEXT_PERIOD DESC LIMIT 1  ";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
            DataSet ds = m.GetDataset(cmd);

            if (ds.Tables[0].Rows.Count > 0) {

                forecastPeriod = ds.Tables[0].Rows[0]["NEXT_PERIOD"].ToString();
                forecastUid = ds.Tables[0].Rows[0]["FORECAST_UID"].ToString();


                //開獎號碼的分佈率
                sql = "SELECT B.CAL_NAME,A.* FROM LOTTO539_ANALYSIS AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID " +
                    " WHERE A.LOTTO_TYPE=3 AND A.STATUS='1' AND C.USER_UID=@USER_UID ORDER BY PERIOD DESC LIMIT 90 ";
                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
                ds = m.GetDataset(cmd);
                nv.DataSource = ds;
                nv.DataBind();


                //出現率號碼
                //sql = "SELECT A.*,B.CAL_NAME FROM LOTTO539_ANALYSIS AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID WHERE A.PERIOD=(SELECT NEXT_PERIOD FROM USER_FORECAST ORDER BY NEXT_PERIOD DESC LIMIT 1 )";
                sql = "SELECT B.CAL_NAME,A.* FROM LOTTO539_ANALYSIS AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID " +
                 " WHERE A.LOTTO_TYPE=3 AND A.STATUS='1' AND C.USER_UID=@USER_UID ORDER BY PERIOD DESC LIMIT 10 ";
                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
                ds = m.GetDataset(cmd);
                lv.DataSource = ds;
                lv.DataBind();

            }



          

        

         



        }


     


    }
}