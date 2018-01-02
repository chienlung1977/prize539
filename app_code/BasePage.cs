using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreLib;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

using com.oli365.prize.Controller;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public string CN;
    public string HOST;

    public BasePage()
    {

        if (CN==null || CN.Equals(""))
        {
          // CN=   ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            CN = CoreLib.Config.getConnectionString("CN");
        }

        if (HOST==null || HOST.Equals("")) {
            //  HOST = ConfigurationManager.AppSettings["HOST"];
            HOST = CoreLib.Config.getAppSetting("HOST");
        }

    }


    public void logErr(Exception ex)
    {

        string sql = "INSERT INTO D_LOG(CREATE_DATE,INFO_TYPE,MEMO) VALUES(@CREATE_DATE,@INFO_TYPE,@MEMO)";
        MySqlCommand cmd = new MySqlCommand(sql);
        cmd.Parameters.Add("@CREATE_DATE", MySqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        cmd.Parameters.Add("@INFO_TYPE", MySqlDbType.VarChar).Value = "ERR";
        cmd.Parameters.Add("@MEMO", MySqlDbType.VarChar).Value = ex.ToString();

        CoreLib.Mariadb m = new CoreLib.Mariadb(CN);
        
        m.ExecuteNonQuery(cmd);

        sendMail("程式發生錯誤", "錯誤原因：" + ex.Message);

    }


    /// <summary>
    /// 發送結果email
    /// </summary>
    protected void sendMail(string subject, string body)
    {

        this.sendMail("chienlung1977@gmail.com", subject, body);

    }

    protected void sendMail(string to, string subject, string body)
    {

        MailClient mc = new MailClient("smtp.gmail.com", 587, "nsking365@gmail.com", "vvtfbyuq0416");
        MailContent c = new MailContent();
        c.From = "nsking365@gmail.com";
        c.FromDisplayName = "幸運號碼猜猜看";
        c.To = to;
        c.Subject = subject;
        c.Body = body;
        c.EnableSsl = true;
        c.BodyFormat = MailContent.BODY_FORMAT.HTML;
        mc.Send(c);

    }


    public void Alert(string msg) {

        CoreLib.Web.Alert(this, msg);
        

    }



    #region 使用者區塊

    public Boolean isUserLogin() {

        return User.Identity.IsAuthenticated;
    }

    public Model.User getUser() {

        Model.User usr=null;
        UserController uc = new UserController();

        if (isUserLogin() == true) {

            usr = uc.getUser(User.Identity.Name);

            return usr;
        }

        return usr;

    }


    #endregion

}

