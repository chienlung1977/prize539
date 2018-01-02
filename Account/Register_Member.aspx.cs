using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace com.oli365.prize.Account { 

    public partial class Register_Member : BasePage 
    {
        protected global::System.Web.UI.WebControls.Panel pan_main;
        protected global::System.Web.UI.WebControls.TextBox tbx_email;
        protected global::System.Web.UI.WebControls.TextBox tbx_nickname;
        protected global::System.Web.UI.WebControls.TextBox tbx_password;
        protected global::System.Web.UI.WebControls.TextBox tbx_cpassword;
        protected global::System.Web.UI.WebControls.Button btnsubmit;
        protected global::System.Web.UI.WebControls.Panel pan_result;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnsubmit_Click(object sender, EventArgs e) 
        {



            Controller.UserController uc = new Controller.UserController();

            string email = tbx_email.Text.Trim().ToLower();
            if (uc.isExist(email)) {
                Alert("Email已經存在，請直接登入網站");
                return;
            }

            Model.User usr = new Model.User(
                 Guid.NewGuid().ToString(),
                 email,
                  tbx_password.Text,
                  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                  "0",
                  "",
                  null,
                  "00",
                  "0",
                  "",
                   tbx_nickname.Text
                );
           

            if (uc.add(usr) == true)
            {
                //送email確認信
                uc.sendVerifyCode(usr.EMAIL);
                pan_main.Visible = false;
                pan_result.Visible = true;
            }
            else {
               // Alert("註冊失敗！");
            }

            

        }
    }
}