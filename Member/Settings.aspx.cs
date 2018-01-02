using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CoreLib;
using MySql.Data.MySqlClient;
using System.Data;

namespace com.oli365.prize.Member
{
    public partial class LevelSet : BasePage
    {

        protected void Page_PreRender(object sender, EventArgs e)
        {
            setCheckBoxStates(chktype);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

         
            

            if (!IsPostBack) {
                bindingRMScope();
                bindingParameters();
                bindingData();

               
            }

           
        }


        private void bindingRMScope() {

            if (drp_scope_min.Items.Count == 0) {
                for (double i = 1; i <= 30; i++)
                {
                    string itemText = Math.Round((i * 0.1), 1, MidpointRounding.AwayFromZero).ToString("0.0") + "%";
                    string itemValue = Math.Round((i * 0.1), 1, MidpointRounding.AwayFromZero).ToString("0.0");


                    ListItem item = new ListItem(itemText, itemValue);
                    drp_scope_min.Items.Add(item);
                }
            }


            if (drp_scope_max.Items.Count == 0)
            {
                for (double i = 10; i <= 50; i++)
                {
                    string itemText = Math.Round((i * 0.1), 1, MidpointRounding.AwayFromZero).ToString("0.0") + "%";
                    string itemValue = Math.Round((i * 0.1), 1, MidpointRounding.AwayFromZero).ToString("0.0");


                    ListItem item = new ListItem(itemText, itemValue);
                    drp_scope_max.Items.Add(item);
                }
            }



        }

        private void setCheckBoxStates(CheckBoxList cbl)
        {
            if (IsPostBack)
            {
                string cblFormID = cbl.ClientID.Replace("_", "$");
                int i = 0;
                foreach (var item in cbl.Items)
                {
                    string itemSelected = Request.Form[cblFormID + "$" + i];
                    if (itemSelected != null && itemSelected != String.Empty)
                        ((ListItem)item).Selected = true;
                    i++;
                }
            }
        }


        private void bindingParameters() {

            Mariadb m = new Mariadb(this.CN);
            string sql = "SELECT * FROM CALCULATION_TYPE WHERE STATUS='1' ORDER BY CAL_ID ";
            MySqlCommand cmd = new MySqlCommand(sql);
            DataSet ds = m.GetDataset(cmd);
            chktype.DataSource = ds;
            chktype.DataTextField = "CAL_NAME";
            chktype.DataValueField = "CAL_ID";
            chktype.DataBind();

        }

        /// <summary>
        /// 載入已設定的資料
        /// </summary>
        private void bindingData() {

            Mariadb m = new Mariadb(this.CN);
            string sql = "SELECT * FROM USER_BASE WHERE USER_UID=@USER_UID";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
            DataTable dt = m.GetDataset(cmd).Tables[0];
            if (dt.Rows.Count > 0) {
                rdo_issendmail.SelectedValue = dt.Rows[0]["IS_SENDMAIL"].ToString();
                drp_lotto539amount.SelectedValue = dt.Rows[0]["LOTTO539_AMOUNT"].ToString();
                drp_dark539s2_1.SelectedValue = dt.Rows[0]["LN_2S_1_AMOUNT"].ToString();
                drp_dark539s2_2.SelectedValue = dt.Rows[0]["LN_2S_2_AMOUNT"].ToString();
                drp_dark539s3_1.SelectedValue = dt.Rows[0]["LN_3S_1_AMOUNT"].ToString();
                drp_dark539s3_2.SelectedValue = dt.Rows[0]["LN_3S_2_AMOUNT"].ToString();
                drp_dark539s3_3.SelectedValue = dt.Rows[0]["LN_3S_3_AMOUNT"].ToString();
                drp_dark539s4_1.SelectedValue = dt.Rows[0]["LN_4S_1_AMOUNT"].ToString();
                drp_dark539s4_2.SelectedValue = dt.Rows[0]["LN_4S_2_AMOUNT"].ToString();
                drp_dark539s4_3.SelectedValue = dt.Rows[0]["LN_4S_3_AMOUNT"].ToString();
                drp_dark539s4_4.SelectedValue = dt.Rows[0]["LN_4S_4_AMOUNT"].ToString();
                rdo_removenumbers.SelectedValue = dt.Rows[0]["RM_NUMS"].ToString();
                rdo_fliterscope.SelectedValue = dt.Rows[0]["RM_SCOPE"].ToString();

                if (!Convert.IsDBNull(dt.Rows[0]["RM_SCOPE_MAX"])) {
                    /*
                    foreach (ListItem  item in drp_scope_max.Items) {
                        if (item.Value == Math.Round(double.Parse(dt.Rows[0]["RM_SCOPE_MAX"].ToString()), 1, MidpointRounding.AwayFromZero).ToString("0.0").ToString()) {
                            item.Selected = true;
                            break;
                        }
                    }
                    */
                    drp_scope_max.SelectedValue = Math.Round(double.Parse(dt.Rows[0]["RM_SCOPE_MAX"].ToString()), 1, MidpointRounding.AwayFromZero).ToString("0.0").ToString();
                }

                if (!Convert.IsDBNull(dt.Rows[0]["RM_SCOPE_MIN"]))
                {
                    /*
                    foreach (ListItem item in drp_scope_min.Items)
                    {
                        if (item.Value == Math.Round(double.Parse(dt.Rows[0]["RM_SCOPE_MIN"].ToString()), 1, MidpointRounding.AwayFromZero).ToString("0.0").ToString())
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                    */
                     drp_scope_min.SelectedValue = Math.Round(double.Parse(dt.Rows[0]["RM_SCOPE_MIN"].ToString()), 1, MidpointRounding.AwayFromZero).ToString("0.0").ToString();
                }

                if (dt.Rows[0]["L539_STATUS"].ToString() == "1") chk_l539_status.Checked = true;
                if (dt.Rows[0]["L649_STATUS"].ToString() == "1") chk_l649_status.Checked = true;
                if (dt.Rows[0]["SL_STATUS"].ToString() == "1") chk_sl_status.Checked = true;
                if (dt.Rows[0]["D539_STATUS"].ToString() == "1") chk_d539_status.Checked = true;

                drp_l649_count.SelectedValue = dt.Rows[0]["L649_COUNT"].ToString();
                drp_sl_count.SelectedValue = dt.Rows[0]["SL_COUNT"].ToString();
                drp_d539_count.SelectedValue = dt.Rows[0]["D539_COUNT"].ToString();

                drp_l539_his_nums.SelectedValue = dt.Rows[0]["L539_HIS_NUMS"].ToString();
                drp_d539_his_nums.SelectedValue = dt.Rows[0]["D539_HIS_NUMS"].ToString();
                drp_l649_his_nums.SelectedValue = dt.Rows[0]["L649_HIS_NUMS"].ToString();
                drp_sl_his_nums.SelectedValue = dt.Rows[0]["SL_HIS_NUMS"].ToString();

                rdo_is_weighted.SelectedValue = dt.Rows[0]["IS_WEIGHTED"].ToString();

                foreach (var calId in dt.Rows[0]["CAL_IDS"].ToString().Split(','))
                {
                    foreach (ListItem item  in chktype.Items) {
                        if (calId.Trim() == item.Value) {
                            item.Selected = true;
                            break;
                        }
                    }

                }

            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string  RM_SCOPE_MAX = "0";
                string  RM_SCORE_MIN = "0";



                Mariadb m = new Mariadb(this.CN);
                string sql = "UPDATE USER_BASE SET " +
                    "LOTTO539_AMOUNT=@LOTTO539_AMOUNT" +
                    ",LN_2S_1_AMOUNT=@LN_2S_1_AMOUNT" +
                    ",LN_2S_2_AMOUNT=@LN_2S_2_AMOUNT" +
                    ",LN_3S_1_AMOUNT=@LN_3S_1_AMOUNT" +
                    ",LN_3S_2_AMOUNT=@LN_3S_2_AMOUNT" +
                    ",LN_3S_3_AMOUNT=@LN_3S_3_AMOUNT" +
                    ",LN_4S_1_AMOUNT=@LN_4S_1_AMOUNT" +
                    ",LN_4S_2_AMOUNT=@LN_4S_2_AMOUNT" +
                    ",LN_4S_3_AMOUNT=@LN_4S_3_AMOUNT" +
                    ",LN_4S_4_AMOUNT=@LN_4S_4_AMOUNT" +
                    ",IS_SENDMAIL=@IS_SENDMAIL" +
                    ",RM_NUMS=@RM_NUMS" +
                    ",RM_SCOPE=@RM_SCOPE" +
                    ",RM_SCOPE_MAX=@RM_SCOPE_MAX" +
                    ",RM_SCOPE_MIN=@RM_SCOPE_MIN" +
                    ",CAL_IDS=@CAL_IDS" +
                    ",L539_STATUS=@L539_STATUS" +
                    ",L649_STATUS=@L649_STATUS" +
                    ",SL_STATUS=@SL_STATUS" +
                    ",D539_STATUS=@D539_STATUS" +
                    ",L649_COUNT=@L649_COUNT" +
                    ",SL_COUNT=@SL_COUNT" +
                    ",D539_COUNT=@D539_COUNT" +
                    ",L539_HIS_NUMS=@L539_HIS_NUMS" +
                    ",D539_HIS_NUMS=@D539_HIS_NUMS" +
                    ",L649_HIS_NUMS=@L649_HIS_NUMS" +
                    ",SL_HIS_NUMS=@SL_HIS_NUMS" +
                    ",IS_WEIGHTED=@IS_WEIGHTED" +
                    " WHERE USER_UID=@USER_UID";
                MySqlCommand cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
                cmd.Parameters.AddWithValue("@LOTTO539_AMOUNT", drp_lotto539amount.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_2S_1_AMOUNT", drp_dark539s2_1.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_2S_2_AMOUNT", drp_dark539s2_2.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_3S_1_AMOUNT", drp_dark539s3_1.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_3S_2_AMOUNT", drp_dark539s3_2.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_3S_3_AMOUNT", drp_dark539s3_3.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_4S_1_AMOUNT", drp_dark539s4_1.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_4S_2_AMOUNT", drp_dark539s4_2.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_4S_3_AMOUNT", drp_dark539s4_3.SelectedValue);
                cmd.Parameters.AddWithValue("@LN_4S_4_AMOUNT", drp_dark539s4_4.SelectedValue);
                cmd.Parameters.AddWithValue("@IS_SENDMAIL", rdo_issendmail.SelectedValue);

                cmd.Parameters.AddWithValue("@RM_NUMS", rdo_removenumbers.SelectedValue);
                cmd.Parameters.AddWithValue("@RM_SCOPE", rdo_fliterscope.SelectedValue);

                if (rdo_fliterscope.SelectedValue == "2") {
                    RM_SCOPE_MAX = drp_scope_max.SelectedValue;
                    RM_SCORE_MIN = drp_scope_min.SelectedValue;
                }

                cmd.Parameters.AddWithValue("@RM_SCOPE_MAX", RM_SCOPE_MAX);
                cmd.Parameters.AddWithValue("@RM_SCOPE_MIN", RM_SCORE_MIN);

                cmd.Parameters.AddWithValue("@L539_STATUS", (chk_l539_status.Checked ? "1":"0"));
                cmd.Parameters.AddWithValue("@L649_STATUS", (chk_l649_status.Checked ? "1" : "0"));
                cmd.Parameters.AddWithValue("@SL_STATUS", (chk_sl_status.Checked ? "1" : "0"));
                cmd.Parameters.AddWithValue("@D539_STATUS", (chk_d539_status.Checked ? "1" : "0"));
                cmd.Parameters.AddWithValue("@L649_COUNT", drp_l649_count.SelectedValue );
                cmd.Parameters.AddWithValue("@SL_COUNT", drp_sl_count.SelectedValue);
                cmd.Parameters.AddWithValue("@D539_COUNT", drp_d539_count.SelectedValue);

                cmd.Parameters.AddWithValue("@L539_HIS_NUMS", drp_l539_his_nums.SelectedValue);
                cmd.Parameters.AddWithValue("@D539_HIS_NUMS", drp_d539_his_nums.SelectedValue);
                cmd.Parameters.AddWithValue("@L649_HIS_NUMS", drp_l649_his_nums.SelectedValue);
                cmd.Parameters.AddWithValue("@SL_HIS_NUMS", drp_sl_his_nums.SelectedValue);
                cmd.Parameters.AddWithValue("@IS_WEIGHTED",rdo_is_weighted.SelectedValue );

                string calids = "";
                string cblFormID = chktype.ClientID.Replace("_", "$");
                int i = 0;
                foreach (var item in chktype.Items)
                {
                    string itemSelected = Request.Form[cblFormID + "$" + i];
                    if (itemSelected != null && itemSelected != String.Empty)
                        if (calids == "")
                        {
                            calids = itemSelected;
                        }
                        else
                        {
                            calids += "," + itemSelected;
                        }
                    i++;
                }

                /*
                for (int i = 0; i < chktype.Items.Count; i++) {
                    if (chktype.Items[i].Selected) {
                        if (calids == "")
                        {
                            calids = chktype.Items[i].Value;
                        }
                        else
                        {
                            calids += "," + chktype.Items[i].Value;
                        }
                    }
                }
                */


                cmd.Parameters.AddWithValue("@CAL_IDS", calids);
                m.ExecuteNonQuery(cmd);
                Alert("儲存成功");
            }
            catch (Exception ex) {
                logErr(ex);
                Alert("儲存失敗！");
            }
        }
    }
}