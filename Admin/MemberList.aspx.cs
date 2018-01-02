using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;
using CoreLib;


namespace com.oli365.prize.Admin
{
    public partial class MemberList : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                dataBind();
            }
        }

        private void dataBind() {

            string sql = "SELECT * FROM USERS ORDER BY CREATE_DATE DESC";
            MySqlCommand cmd = new MySqlCommand(sql);
            Mariadb  m = new Mariadb(this.CN);
            DataSet ds = m.GetDataset(cmd);
            gv.DataSource = ds;
            gv.DataBind();
            
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string userUid = this.gv.DataKeys[rowIndex]["USER_UID"].ToString();

            if (e.CommandName == "LOGIN_HISTORY") {
                Response.Redirect("LoginHistoryList.aspx?UID=" + userUid);
            }
            
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*
            if (e.Row.RowType == DataControlRowType.DataRow) {
                if (e.Row.Cells[4].Text == "1") {
                    e.Row.Cells[4].Text = "登入中";
                }
                else {
                    e.Row.Cells[4].Text = "未登入";
                }

                Button btn_account = (Button)e.Row.FindControl("btn_account");
                btn_account.Visible = false;

                if (e.Row.Cells[6].Text == "0")
                {
                    e.Row.Cells[6].Text = "尚未啟用";
                }
                else if (e.Row.Cells[6].Text == "1") {
                    e.Row.Cells[6].Text = "啟用中";
                    btn_account.Visible = true;
                }
                else if (e.Row.Cells[6].Text == "9")
                {
                    e.Row.Cells[6].Text = "<font color=red>停用</font>";
                }
            }
            */
        }
    }
}