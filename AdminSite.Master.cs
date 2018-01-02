using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace com.oli365.prize
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkAdmin();
            }
        }

        private void checkAdmin()
        {


            if (Session["IsAdminLogin"] == "1")
            {
                Response.Write("已經登入");
            }
            else
            {
                Response.Write("還沒登入");
                Response.Redirect("~/Admin/AdminLogin.aspx");
            }

        }


    }
}