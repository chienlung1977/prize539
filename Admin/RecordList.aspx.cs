using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using com.oli365.prize.core;

namespace com.oli365.prize.Admin
{
    public partial class RecordList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            /*
            gv.DataSource = RecordUtility.GetAdminList( sdate.Value, edate.Value);
            gv.DataBind();
            */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bindData();
        }

    }
}