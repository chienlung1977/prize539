using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;

using MySql.Data.MySqlClient;

using CoreLib;
using System.Web.UI.HtmlControls;

namespace com.oli365.prize.Member
{
    public partial class Prize539Next : BasePage 
    {

      //  string forecastPeriod;
      //  string forecastUid;

        protected void Page_Load(object sender, EventArgs e)
        {

        
            if (!IsPostBack) {

                bindingData();
                bindingAdd();

            }
        }

        private void bindingData() {

            Mariadb m = new Mariadb(this.CN);

            string sql = "SELECT FORECAST_UID,NEXT_PERIOD FROM USER_FORECAST WHERE IS_CHECK='0' AND USER_UID=@USER_UID AND LOTTO_TYPE=0 ORDER BY NEXT_PERIOD DESC LIMIT 1  ";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
            DataSet ds = m.GetDataset(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {

                hid_forecastPeriod.Value  = ds.Tables[0].Rows[0]["NEXT_PERIOD"].ToString();
                hid_forecastUid.Value = ds.Tables[0].Rows[0]["FORECAST_UID"].ToString();

                sql = "SELECT A.*,B.CAL_NAME FROM PRIZE539_NEXT AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID" +
            " WHERE A.NEXT_PERIOD=@PERIOD AND A.FORECAST_UID=@FORECAST_UID  ORDER BY A.LOTTO_NUM";

                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@PERIOD", hid_forecastPeriod.Value );
                cmd.Parameters.AddWithValue("@FORECAST_UID", hid_forecastUid.Value );
                ds = m.GetDataset(cmd);
                gv.DataSource = ds;
                gv.DataBind();

                //開獎號碼的分佈率
                sql = "SELECT B.CAL_NAME,A.* FROM LOTTO539_ANALYSIS AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID " +
                    " WHERE A.LOTTO_TYPE=0 AND A.STATUS='1' AND C.USER_UID=@USER_UID ORDER BY PERIOD DESC LIMIT 1 ";
                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
                ds = m.GetDataset(cmd);
                nv.DataSource = ds;
                nv.DataBind();


                //出現率號碼
                //sql = "SELECT A.*,B.CAL_NAME FROM LOTTO539_ANALYSIS AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID WHERE A.PERIOD=(SELECT NEXT_PERIOD FROM USER_FORECAST ORDER BY NEXT_PERIOD DESC LIMIT 1 )";
                sql = "SELECT B.CAL_NAME,A.* FROM LOTTO539_ANALYSIS AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID " +
                 " WHERE A.LOTTO_TYPE=0 AND A.STATUS='1' AND C.USER_UID=@USER_UID ORDER BY PERIOD DESC LIMIT 1 ";
                cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
                ds = m.GetDataset(cmd);
                lv.DataSource = ds;
                lv.DataBind();

            }
            

        }


        private void bindingAdd() {

            bindingAddParameters(N1);
            bindingAddParameters(N2);
            bindingAddParameters(N3);
            bindingAddParameters(N4);
            bindingAddParameters(N5);

        }

        private void bindingAddParameters(DropDownList dp ) {

            dp.Items.Clear();
            for(int i = 1; i <= 39; i++)
            {
                ListItem li = new ListItem(i.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0'));
                dp.Items.Add(li);
            }


        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DEL") {

                int RowIndex = int.Parse(e.CommandArgument.ToString());
                string pk = gv.DataKeys[RowIndex].Value.ToString();

                Mariadb m = new Mariadb(this.CN);
                string sql = "DELETE FROM PRIZE539_NEXT WHERE NEXT_PRIZE_UID=@PK";
                MySqlCommand cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@PK", pk);
                m.ExecuteNonQuery(cmd);

                resetSortNum();
                bindingData();
               

            }
        }

        protected void btnAddSave_Click(object sender, EventArgs e)
        {
            string n1 = N1.SelectedValue;
            string n2 = N2.SelectedValue;
            string n3 = N3.SelectedValue;
            string n4 = N4.SelectedValue;
            string n5 = N5.SelectedValue;

            //檢查號碼不可重覆
            if (n1 == n2 || n1 == n3 || n1 == n4 || n1 == n5) {
                Alert("號碼1與其他號碼重覆");
                return;
            }

            if (n2 == n1 || n2 == n3 || n2 == n4 || n2 == n5)
            {
                Alert("號碼2與其他號碼重覆");
                return;
            }

            if (n3 == n1 || n3 == n2 || n3 == n4 || n3 == n5)
            {
                Alert("號碼3與其他號碼重覆");
                return;
            }

            if (n4 == n1 || n4 == n2 || n4 == n3 || n4 == n5)
            {
                Alert("號碼4與其他號碼重覆");
                return;
            }

            if (n5 == n1 || n5 == n2 || n5 == n3 || n5 == n4)
            {
                Alert("號碼5與其他號碼重覆");
                return;
            }

            Mariadb m = new Mariadb(this.CN);
            string sql = "INSERT INTO PRIZE539_NEXT(NEXT_PRIZE_UID,CREATE_DATE,NEXT_PERIOD,LOTTO_NUM,NUM1,NUM2,NUM3,NUM4,NUM5,CAL_ID,IS_CHECK,FORECAST_UID,EDIT_TYPE)" +
                " VALUES(@NEXT_PRIZE_UID,@CREATE_DATE,@NEXT_PERIOD,@LOTTO_NUM,@NUM1,@NUM2,@NUM3,@NUM4,@NUM5,@CAL_ID,@IS_CHECK,@FORECAST_UID,@EDIT_TYPE)";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@NEXT_PRIZE_UID", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@CREATE_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@NEXT_PERIOD", hid_forecastPeriod.Value );
            cmd.Parameters.AddWithValue("@LOTTO_NUM", 99);
            cmd.Parameters.AddWithValue("@NUM1", n1);
            cmd.Parameters.AddWithValue("@NUM2", n2);
            cmd.Parameters.AddWithValue("@NUM3", n3);
            cmd.Parameters.AddWithValue("@NUM4", n4);
            cmd.Parameters.AddWithValue("@NUM5", n5);
            cmd.Parameters.AddWithValue("@CAL_ID", "03");
            cmd.Parameters.AddWithValue("@IS_CHECK", "0");
            cmd.Parameters.AddWithValue("@FORECAST_UID", hid_forecastUid.Value );
            cmd.Parameters.AddWithValue("@EDIT_TYPE", "1");

            m.ExecuteNonQuery(cmd);
            resetSortNum();
            bindingData();
            Alert("新增成功");
        }

        /// <summary>
        /// 重新排序
        /// </summary>
        private void resetSortNum() {

            Mariadb m = new Mariadb(this.CN);
            string sql = "SELECT * FROM PRIZE539_NEXT WHERE FORECAST_UID=@FORECAST_UID  ORDER BY LOTTO_NUM";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@FORECAST_UID", hid_forecastUid.Value );
            DataTable dt = m.GetDataset(cmd).Tables[0];

            string usql = "";
            for (int i = 0; i < dt.Rows.Count; i++) {
                string nextPrizeUid = dt.Rows[i]["NEXT_PRIZE_UID"].ToString();
                usql += "UPDATE PRIZE539_NEXT SET LOTTO_NUM='" + (i+1).ToString() + "' WHERE NEXT_PRIZE_UID='" + nextPrizeUid + "'; ";
            }
            cmd = new MySqlCommand(usql);
            m.ExecuteNonQuery(cmd);

        }

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
            bindingData();
        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv.EditIndex = e.NewEditIndex;
            bindingData();

            DropDownList dp1 = (DropDownList )gv.Rows[e.NewEditIndex].FindControl("EN1");
            bindingAddParameters(dp1);
            
            HtmlInputHidden hid1 =(HtmlInputHidden) gv.Rows[e.NewEditIndex].FindControl("hidN1");
            dp1.SelectedValue = hid1.Value;

            DropDownList dp2 = (DropDownList)gv.Rows[e.NewEditIndex].FindControl("EN2");
            bindingAddParameters(dp2);

            HtmlInputHidden hid2 = (HtmlInputHidden)gv.Rows[e.NewEditIndex].FindControl("hidN2");
            dp2.SelectedValue = hid2.Value;

            DropDownList dp3 = (DropDownList)gv.Rows[e.NewEditIndex].FindControl("EN3");
            bindingAddParameters(dp3);

            HtmlInputHidden hid3 = (HtmlInputHidden)gv.Rows[e.NewEditIndex].FindControl("hidN3");
            dp3.SelectedValue = hid3.Value;

            DropDownList dp4 = (DropDownList)gv.Rows[e.NewEditIndex].FindControl("EN4");
            bindingAddParameters(dp4);

            HtmlInputHidden hid4 = (HtmlInputHidden)gv.Rows[e.NewEditIndex].FindControl("hidN4");
            dp4.SelectedValue = hid4.Value;

            DropDownList dp5 = (DropDownList)gv.Rows[e.NewEditIndex].FindControl("EN5");
            bindingAddParameters(dp5);

            HtmlInputHidden hid5 = (HtmlInputHidden)gv.Rows[e.NewEditIndex].FindControl("hidN5");
            dp5.SelectedValue = hid5.Value;

        }

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList dp1 = (DropDownList)gv.Rows[e.RowIndex ].FindControl("EN1");
            DropDownList dp2 = (DropDownList)gv.Rows[e.RowIndex].FindControl("EN2");
            DropDownList dp3 = (DropDownList)gv.Rows[e.RowIndex].FindControl("EN3");
            DropDownList dp4 = (DropDownList)gv.Rows[e.RowIndex].FindControl("EN4");
            DropDownList dp5 = (DropDownList)gv.Rows[e.RowIndex].FindControl("EN5");

            string n1 = dp1.SelectedValue;
            string n2 = dp2.SelectedValue;
            string n3 = dp3.SelectedValue;
            string n4 = dp4.SelectedValue;
            string n5 = dp5.SelectedValue;

            //檢查號碼不可重覆
            if (n1 == n2 || n1 == n3 || n1 == n4 || n1 == n5)
            {
                Alert("號碼1與其他號碼重覆");
                return;
            }

            if (n2 == n1 || n2 == n3 || n2 == n4 || n2 == n5)
            {
                Alert("號碼2與其他號碼重覆");
                return;
            }

            if (n3 == n1 || n3 == n2 || n3 == n4 || n3 == n5)
            {
                Alert("號碼3與其他號碼重覆");
                return;
            }

            if (n4 == n1 || n4 == n2 || n4 == n3 || n4 == n5)
            {
                Alert("號碼4與其他號碼重覆");
                return;
            }

            if (n5 == n1 || n5 == n2 || n5 == n3 || n5 == n4)
            {
                Alert("號碼5與其他號碼重覆");
                return;
            }

            string nextPrizeUid = gv.DataKeys[e.RowIndex].Value.ToString();

            string sql = "UPDATE PRIZE539_NEXT SET NUM1=@NUM1,NUM2=@NUM2,NUM3=@NUM3,NUM4=@NUM4,NUM5=@NUM5,EDIT_TYPE='1' WHERE NEXT_PRIZE_UID=@NEXT_PRIZE_UID";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@NUM1", n1);
            cmd.Parameters.AddWithValue("@NUM2", n2);
            cmd.Parameters.AddWithValue("@NUM3", n3);
            cmd.Parameters.AddWithValue("@NUM4", n4);
            cmd.Parameters.AddWithValue("@NUM5", n5);
            cmd.Parameters.AddWithValue("@NEXT_PRIZE_UID", nextPrizeUid);

            Mariadb m = new Mariadb(this.CN);
            m.ExecuteNonQuery(cmd);


            gv.EditIndex = -1;
            bindingData();

        }
    }
}