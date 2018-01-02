using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CoreLib;
using MySql.Data.MySqlClient;
using System.Data;

namespace com.oli365.prize.Member
{
    public partial class AllForecastAnalysis : BasePage 
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack) {

                bindingData();

            }
        }

        

        private  void bindingData() {

            Mariadb m = new Mariadb(this.CN);
            string sql = "SELECT * FROM LOTTO539_ANALYSIS WHERE CAL_ID='03' AND STATUS='1' ORDER BY PERIOD DESC LIMIT 30";
            MySqlCommand cmd = new MySqlCommand(sql);
            DataTable dt = m.GetDataset(cmd).Tables[0];

            gv.DataSource = dt;
            gv.DataBind();

        }

     

    }
}