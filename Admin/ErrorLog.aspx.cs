using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;

using CoreLib;

namespace com.oli365.prize.Admin
{
    public partial class ErrorLog : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindingData();
            }
        }

        private void BindingData() {

            Mariadb  m = new Mariadb(this.CN);
            string sql = "SELECT * FROM D_LOG ORDER BY CREATE_DATE DESC;";
            gv.DataSource = m.GetDataset(sql);
            gv.DataBind();
        }
    }
}