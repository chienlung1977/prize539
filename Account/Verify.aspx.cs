using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;



namespace com.oli365.prize.Account
{ 

    public partial class Verify : BasePage
    {

    protected global::System.Web.UI.WebControls.Label lbl_verifycode;

    protected void Page_Load(object sender, EventArgs e)
        {
        if (!IsPostBack) {
            string email = Request["email"];
            string code = Request["code"];

            Controller.UserController uc = new Controller.UserController();
            if (uc.enableVerifyCode(email, code))
            {
                lbl_verifycode.Text = "帳號已啓用，您可以開始使用了，<a href='Login.aspx'>立即登入</a>";
            }
            else {
                lbl_verifycode.Text = "<font color=red>驗證失敗</font>";
            }  
                
            
            }
        }

      
    }
}