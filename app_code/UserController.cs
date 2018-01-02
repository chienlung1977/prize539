using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;

using System.Data;

using MySql.Data.MySqlClient;
using System.Security.Principal;

using Model;
using CoreLib;

namespace com.oli365.prize.Controller {

    public class UserController:BasePage 
    {
        Mariadb m;
        public UserController() {
            if (m == null) {
                m = new Mariadb(base.CN);
            }
        }

        /*
        /// <summary>
        /// 是否有管理者權限(ROLE_ID=ADMIN)
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Boolean CheckAdminLogin(String loginName, String password)
        {

            String encPwd = Utility.GetEncString(password);

            Console.WriteLine("encPwd=" + encPwd);

            String sql = "SELECT COUNT(*) AS NUM FROM USER WHERE ROLE_ID='ADMIN' AND EMAIL=@EMAIL AND NEW_PWD=@PWD";

            Console.WriteLine(sql);

            List<MySqlParameter> l = new List<MySqlParameter>();

            l.Add(new MySqlParameter("@EMAIL", loginName));
            l.Add(new MySqlParameter("@PWD", encPwd));
            mariasql m = new mariasql();




            DataSet ds = m.GetDataset(sql, l);
            String n = ds.Tables[0].Rows[0]["NUM"].ToString();

            return (int.Parse(n) > 0);


        }

        */

        /*
        /// <summary>
        /// 取得會員清單
        /// </summary>
        /// <returns></returns>
    public static DataSet GetUserList()
    {

        mariasql m = new mariasql();
        string sql = "SELECT * FROM USER ORDER BY CREATE_DATE DESC";
        return m.GetDataset(sql);
    }

    */

        /// <summary>
        /// 檢查帳號是否已存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Boolean isExist(string email) {

            string sql = "SELECT COUNT(EMAIL) FROM USERS WHERE EMAIL=@EMAIL";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = email;
            int n =int.Parse( m.ExecuteScalar(cmd).ToString());

            return n > 0;

        }
       
        /// <summary>
        /// 註冊使用者
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public  Boolean   add(User usr)
        {


            try
            {
                if (usr.PWD.Length > 0)
                {
                    usr.PWD = Utility.GetEncString(usr.PWD);
                }


                string sql = "INSERT INTO USERS(USER_UID,EMAIL,PWD,CREATE_DATE,EMAIL_CONFIRM,MEMO,LAST_LOGIN_DATE,ROLE_ID,STATUS,LAST_LOGIN_IP,NICK_NAME) " +
                        " VALUES(@USER_UID,@EMAIL,@PWD,@CREATE_DATE,@EMAIL_CONFIRM,@MEMO,@LAST_LOGIN_DATE,@ROLE_ID,@STATUS,@LAST_LOGIN_IP,@NICK_NAME)";
                MySqlCommand cmd = new MySqlCommand(sql);

                cmd.Parameters.AddWithValue("@USER_UID", usr.USER_UID);
                cmd.Parameters.AddWithValue("@EMAIL", usr.EMAIL);
                cmd.Parameters.AddWithValue("@PWD", usr.PWD);
                cmd.Parameters.AddWithValue("@CREATE_DATE", usr.CREATE_DATE);
                cmd.Parameters.AddWithValue("@EMAIL_CONFIRM", usr.EMAIL_CONFIRM);
                cmd.Parameters.AddWithValue("@MEMO", usr.MEMO);
                cmd.Parameters.AddWithValue("@LAST_LOGIN_DATE", usr.LAST_LOGIN_DATE);
                cmd.Parameters.AddWithValue("@ROLE_ID", usr.ROLE_ID);
                cmd.Parameters.AddWithValue("@STATUS", usr.STATUS);
                cmd.Parameters.AddWithValue("@LAST_LOGIN_IP", usr.LAST_LOGIN_IP);
                cmd.Parameters.AddWithValue("@NICK_NAME", usr.NICK_NAME);
                m.ExecuteNonQuery(cmd);

                //自動新增通知的資料
                sql = "INSERT INTO USER_BASE(EMAIL,USER_UID,LOTTO539_AMOUNT,LN_2S_1_AMOUNT,LN_2S_2_AMOUNT,LN_3S_1_AMOUNT,LN_3S_2_AMOUNT,LN_3S_3_AMOUNT,LN_4S_1_AMOUNT,LN_4S_2_AMOUNT,LN_4S_3_AMOUNT,LN_4S_4_AMOUNT,IS_SENDMAIL)" +
                    " VALUES(@EMAIL,@USER_UID,@LOTTO539_AMOUNT,@LN_2S_1_AMOUNT,@LN_2S_2_AMOUNT,@LN_3S_1_AMOUNT,@LN_3S_2_AMOUNT,@LN_3S_3_AMOUNT,@LN_4S_1_AMOUNT,@LN_4S_2_AMOUNT,@LN_4S_3_AMOUNT,@LN_4S_4_AMOUNT,@IS_SENDMAIL)";
                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@USER_UID", usr.USER_UID);
                cmd.Parameters.AddWithValue("@EMAIL", usr.EMAIL);
                cmd.Parameters.AddWithValue("@LOTTO539_AMOUNT", "3");
                cmd.Parameters.AddWithValue("@LN_2S_1_AMOUNT","3");
                cmd.Parameters.AddWithValue("@LN_2S_2_AMOUNT", "3");
                cmd.Parameters.AddWithValue("@LN_3S_1_AMOUNT", "3");
                cmd.Parameters.AddWithValue("@LN_3S_2_AMOUNT", "3");
                cmd.Parameters.AddWithValue("@LN_3S_3_AMOUNT", "3");
                cmd.Parameters.AddWithValue("@LN_4S_1_AMOUNT", "3");
                cmd.Parameters.AddWithValue("@LN_4S_2_AMOUNT","3");
                cmd.Parameters.AddWithValue("@LN_4S_3_AMOUNT", "3");
                cmd.Parameters.AddWithValue("@LN_4S_4_AMOUNT","3");
                cmd.Parameters.AddWithValue("@IS_SENDMAIL","1");

                m.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex) {
                logErr(ex);
                return false;
            }




        }

        /// <summary>
        /// 驗證碼，每次呼叫皆會重設
        /// </summary>
        /// <param name="email"></param>
        public void sendVerifyCode(string email) {

            string confirmKey = Guid.NewGuid().ToString();
            string sql = "UPDATE USERS SET MEMO=@MEMO WHERE EMAIL=@EMAIL";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@MEMO", confirmKey);

            m.ExecuteNonQuery(cmd);

            string subject = "【幸運號碼猜猜看】註冊驗證確認信";
            string url = base.HOST + "/Account/Verify.aspx?email=" + email + "&code=" + confirmKey;
            string body = "您好,你已註冊【幸運號碼猜猜看】網站，請按此以<a href='" + url + "'>啟用</a>您的帳號";

            base.sendMail(email, subject, body);

        

        }

        /// <summary>
        /// 啟用帳號
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public  bool enableVerifyCode(string email, string code)
        {
            //檢查帳號是否已存在
            if (isExist(email) == false) {
               
                return false;
            }
            
            string sql = "SELECT COUNT(USER_UID) AS NUM FROM USERS WHERE MEMO=@CODE AND EMAIL=@EMAIL";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@CODE", code);

            int n = int.Parse(m.ExecuteScalar(cmd).ToString());

            if (n > 0) {

                sql = "UPDATE USERS SET EMAIL_CONFIRM='1',STATUS='1' WHERE EMAIL=@EMAIL";
                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                m.ExecuteNonQuery(cmd);

                return true;
            }

          

            return false;

        }







        #region 帳號驗證




        /// <summary>
        /// 檢查登入
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool  checkLogin(string email, string password)
        {
            string userUid;
            string roleId;

            string encPwd = Utility.GetEncString(password);
            string sql = "SELECT USER_UID,ROLE_ID,STATUS FROM USERS WHERE  EMAIL=@EMAIL AND PWD=@PWD";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@PWD", encPwd);
            DataSet ds = m.GetDataset(cmd);
            

            if (ds.Tables[0].Rows.Count > 0)
            {

                //先檢查帳號是否已啟用
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() == "0") {
                    Alert("您的帳號尚未EMAIL驗證啟用");
                    return false;
                }

             
                //設定參數
                HttpContext.Current.Session.RemoveAll();
                userUid = ds.Tables[0].Rows[0]["USER_UID"].ToString();
                roleId = ds.Tables[0].Rows[0]["ROLE_ID"].ToString();
                bool isPersistent = false;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                  userUid,
                  DateTime.Now,
                  DateTime.Now.AddDays(3),
                  isPersistent,
                  roleId,
                  FormsAuthentication.FormsCookiePath);

                 string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                
                logLogin(userUid,email);

                return true;
            }


            return false;




        }

        /// <summary>
        /// 登出
        /// </summary>
        public  void Logout()
        {
            string userUid = HttpContext.Current.User.Identity.Name;
            FormsAuthentication.SignOut();
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
        }



        /// <summary>
        /// 新增網站登入記錄
        /// </summary>
        /// <param name="userUid"></param>
        /// <param name="email"></param>
        public void logLogin(string userUid,string email)
        {
            string sql = "INSERT INTO LOGIN_HISTORY(LOGIN_UID,USER_UID,CREATE_DATE,EMAIL,LOGIN_IP) VALUES(@LOGIN_UID,@USER_UID,@CREATE_DATE,@EMAIL,@LOGIN_IP)";
            MySqlCommand cmd = new MySqlCommand(sql);

            //   string clientip = HttpContext.Current.Request.UserHostAddress;
            CoreLib.Web w = new Web();
            string loginIp = w.getClientIP();
            string loginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            cmd.Parameters.AddWithValue("@LOGIN_UID", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@USER_UID", userUid);
            cmd.Parameters.AddWithValue("@CREATE_DATE", loginDate );
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@LOGIN_IP", loginIp);
            m.ExecuteNonQuery(cmd);

            //更新主表的登入記錄
            sql = "UPDATE USERS SET LAST_LOGIN_DATE=@LAST_LOGIN_DATE,LAST_LOGIN_IP=@LAST_LOGIN_IP WHERE USER_UID=@USER_UID";
            cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@USER_UID", userUid);
            cmd.Parameters.AddWithValue("@LAST_LOGIN_DATE", loginDate);
            cmd.Parameters.AddWithValue("@LAST_LOGIN_IP", loginIp );
            m.ExecuteNonQuery(cmd);

        }

        /// <summary>
        /// 重設密碼
        /// </summary>
        /// <param name="email"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static Boolean resetPassword(string email, string oldPassword, string newPassword)
        {
            /*
            string hashOldPwd = getComputeHash(oldPassword);
            string hashNewPwd = getComputeHash(newPassword);
            string sql = "UPDATE STORE SET PASSWORD=@NEWPASSWORD WHERE ID=@ID AND PASSWORD=@OLDPASSWORD";
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(new SqlParameter("@ID", account));
            l.Add(new SqlParameter("@OLDPASSWORD", hashOldPwd));
            l.Add(new SqlParameter("@NEWPASSWORD", hashNewPwd));
            mssql m = new mssql(getConnectionString());
            return m.Execute(sql, l);
            */
            return false;
        }


        public User getUser(string userUid) {

            User u;
            String sql = "SELECT * FROM USERS WHERE USER_UID=@USER_UID";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@USER_UID", userUid);
          
            DataTable dt  = m.GetDataset(cmd).Tables[0];

            if (dt.Rows.Count > 0)
            {
                u = new User();
                u.USER_UID = dt.Rows[0]["USER_UID"].ToString();
                u.CREATE_DATE = dt.Rows[0]["CREATE_DATE"].ToString();
                u.EMAIL = dt.Rows[0]["EMAIL"].ToString();
                u.PWD = dt.Rows[0]["PWD"].ToString();
                u.EMAIL_CONFIRM = dt.Rows[0]["EMAIL_CONFIRM"].ToString();
                u.MEMO = dt.Rows[0]["MEMO"].ToString();
                u.LAST_LOGIN_DATE = dt.Rows[0]["LAST_LOGIN_DATE"].ToString();
                u.ROLE_ID = dt.Rows[0]["ROLE_ID"].ToString();
                u.LAST_LOGIN_IP = dt.Rows[0]["LAST_LOGIN_IP"].ToString();
                u.STATUS = dt.Rows[0]["STATUS"].ToString();
                u.NICK_NAME = dt.Rows[0]["NICK_NAME"].ToString();
            }
            else {
                u = null;
            }

            return u;
        }


        #endregion


    }
}