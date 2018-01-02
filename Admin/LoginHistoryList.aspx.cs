using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;

using System.Data;

using CoreLib;

namespace com.oli365.prize.Admin
{
    public partial class LoginHistoryList : BasePage
    {
         string userUid ;

         protected void Page_Init(object sender, EventArgs e) {
            userUid = Request["UID"];
         }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
               
                bindingData();
            }
        }
        
        private void bindingData() {

            DataSet ds;
            string sql = "";
            Mariadb m = new Mariadb(this.CN);
            MySqlCommand cmd;

            if (userUid == null || userUid == "")
            {
                sql = "SELECT * FROM LOGIN_HISTORY WHERE USER_UID<>'dfc1466f-9dd3-11e7-85b3-0024213c34a9'  ORDER BY CREATE_DATE DESC";
                cmd = new MySqlCommand(sql);
            }
            else {
                sql = "SELECT * FROM LOGIN_HISTORY WHERE USER_UID=@USER_UID  ORDER BY CREATE_DATE DESC";
                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@USER_UID", userUid);
            }

            
            ds = m.GetDataset(cmd);
            gv.DataSource = ds;
            gv.DataBind();


        }
       
    }
}