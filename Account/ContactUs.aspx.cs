using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CoreLib;
using MySql.Data.MySqlClient;

namespace com.oli365.prize.Account
{
    public partial class ContactUs : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingLoginDefaultData();
            }
        }


        private void bindingLoginDefaultData() {

            Model.User usr = getUser();
            if (usr != null) {
                tbx_name.Text = usr.NICK_NAME;
                tbx_email.Text = usr.EMAIL;
                hid_useruid.Value = usr.USER_UID;
            }


        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

          
            string name = tbx_name.Text.Trim();
            string email = tbx_email.Text.Trim();
            string useruid = hid_useruid.Value.Trim();
            string content = tbx_content.Text.Trim();
            string subject = txt_subject.Text.Trim();
            string feedtype = drp_feedType.SelectedItem.Text ;

            string body = name + "<br/>" + email + "<br/>" + content;

            Mariadb m = new Mariadb(this.CN);
            string sql = "INSERT INTO FEED_BACK(FEED_UID,CREATE_DATE,Q_EMAIL,Q_NICK_NAME,Q_USER_UID,TITLE,FEED_TYPE,CONTENT)" +
                " VALUES(@FEED_UID,@CREATE_DATE,@Q_EMAIL,@Q_NICK_NAME,@Q_USER_UID,@TITLE,@FEED_TYPE,@CONTENT)";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@FEED_UID", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@CREATE_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@Q_EMAIL", email);
            cmd.Parameters.AddWithValue("@Q_NICK_NAME", name);
            cmd.Parameters.AddWithValue("@Q_USER_UID", useruid);
            cmd.Parameters.AddWithValue("@TITLE", subject);
            cmd.Parameters.AddWithValue("@FEED_TYPE", feedtype);
            cmd.Parameters.AddWithValue("@CONTENT", body);


            try
            {

                
                m.ExecuteNonQuery(cmd);
                sendMail(subject, body);

                pan_main.Visible = false;
                pan_result.Visible = true;
            }

            catch (Exception ex) {
                logErr(ex);
            }

          


        }
    }
}