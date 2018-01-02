using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace com.oli365.prize.Account
{ 

public partial class Login : BasePage
{

    protected global::System.Web.UI.WebControls.TextBox txtAccount;
    protected global::System.Web.UI.WebControls.TextBox txtPwd;
    protected global::System.Web.UI.WebControls.HyperLink HyperLink1;
    protected global::System.Web.UI.WebControls.Button btnSubmit;
    protected global::System.Web.UI.WebControls.Label  lbl_msg;

    protected void Page_Load(object sender, EventArgs e)
        {
         
        }

     

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtAccount.Text.Trim();
            string pwd = txtPwd.Text.Trim();

            Controller.UserController uc = new Controller.UserController();


            if (uc.checkLogin(email,pwd ) == true)
            {
                /*
                if (code == "003") {
                    Response.Redirect("~/Member/LevelSet.aspx");
                }
                */
                Response.Redirect("~/Default.aspx", true);
            }
            else {
            //帳號密碼錯誤

            lbl_msg.Text = "登入失敗！";


               // Page.ClientScript.RegisterStartupScript(Page.GetType(), "LoginFail", "alert('登入失敗，請重新登入!');", true);
        }

        }

      
    }


}