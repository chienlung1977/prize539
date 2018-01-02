using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.oli365.prize.core;

namespace com.oli365.prize.Admin
{
    public partial class FoodTypeLinkList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingData();
            }
        }

        private void bindingData()
        {
            /*
            gv.DataSource = FoodTypeLinkUtility.GetList();
            gv.DataBind();
            */
        }


    }
}