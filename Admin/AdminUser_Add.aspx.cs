using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using com.oli365.prize.core;

namespace com.oli365.prize.Admin
{
    public partial class AdminUser_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                binding();
            }
        }


        private void binding() {
            /*
            GridView1.DataSource = UserUtility.GetUserList();
            GridView1.DataBind();
            */
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text;
            string pwd = txtPassword.Text ;

           // UserUtility.AddUser(account, pwd);
            binding();

        }
    }
}