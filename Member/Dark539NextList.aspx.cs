using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;

using MySql.Data.MySqlClient;

using CoreLib;

namespace com.oli365.prize.Member
{
    public partial class Dark539NextList : BasePage
    {

        string period;

        protected void Page_Load(object sender, EventArgs e)
        {

            period = Request["pid"];

            if (!IsPostBack) {
                bindingPeriod();
                bindingData();
            }
        }

        

        private void bindingPeriod() {
            //drp_analysis
            Mariadb m = new Mariadb(this.CN);
            string sql = "SELECT PRIZE_UID,PERIOD FROM PRIZE539 ORDER BY PERIOD DESC LIMIT 60";
            MySqlCommand cmd = new MySqlCommand(sql);
            DataSet ds = m.GetDataset(cmd);

            drp_period.DataSource = ds;
            drp_period.DataTextField = "PERIOD";
            drp_period.DataValueField = "PERIOD";
            drp_period.DataBind();

            if (period != null && period != "") {
                drp_period.SelectedValue = period;
            }


        }

        private void bindingData() {

            Mariadb m = new Mariadb(this.CN);
            //開獎號碼
            string sql = "SELECT * FROM PRIZE539 WHERE PERIOD=@PERIOD";
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@PERIOD", drp_period.SelectedValue);
            DataSet ds = m.GetDataset(cmd);
            nv.DataSource = ds;
            nv.DataBind();

            if (ds.Tables[0].Rows.Count > 0) {
                hid_numbers.Value = ds.Tables[0].Rows[0]["NUM1"].ToString() +
                    "," + ds.Tables[0].Rows[0]["NUM2"].ToString() +
                    "," + ds.Tables[0].Rows[0]["NUM3"].ToString() +
                    "," + ds.Tables[0].Rows[0]["NUM4"].ToString() +
                    "," + ds.Tables[0].Rows[0]["NUM5"].ToString();
            }

            //預測號碼
            sql = "SELECT B.CAL_NAME,A.USER_UID,C.*  FROM USER_FORECAST AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID" +
                "  JOIN PRIZE539_NEXT_NONLEGAL AS C  ON A.FORECAST_UID =C.FORECAST_UID WHERE A.USER_UID=@USER_UID AND C.NEXT_PERIOD=@PERIOD" +
                " ORDER BY C.CAL_ID,C.SORT_NUM";
            cmd = new MySqlCommand(sql );
            cmd.Parameters.AddWithValue("@PERIOD", drp_period.SelectedValue);
            cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name );
            ds = m.GetDataset(cmd);

            gv.DataSource = ds;
            gv.DataBind();


            //號碼出現率百分比

            sql = "SELECT B.CAL_NAME,A.* FROM LOTTO539_ANALYSIS AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID " +
                " JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID" +
                " WHERE A.PERIOD=@PERIOD AND A.LOTTO_TYPE='3' AND C.USER_UID=@USER_UID";
            cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@PERIOD", drp_period.SelectedValue);
            cmd.Parameters.AddWithValue("@USER_UID", User.Identity.Name);
            ds = m.GetDataset(cmd);

            agv.DataSource = ds;
            agv.DataBind();
          
        }



        protected void drp_period_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindingData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                /*
                if (hid_numbers.Value.IndexOf(e.Row.Cells[1].Text) > -1) {
                    e.Row.Cells[1].Style.Add("background-color", "#77DDFF");
                }

                if (hid_numbers.Value.IndexOf(e.Row.Cells[2].Text) > -1)
                {
                    e.Row.Cells[2].Style.Add("background-color", "#77DDFF");
                }

                if (hid_numbers.Value.IndexOf(e.Row.Cells[3].Text) > -1)
                {
                    e.Row.Cells[3].Style.Add("background-color", "#77DDFF");
                }

                if (hid_numbers.Value.IndexOf(e.Row.Cells[4].Text) > -1)
                {
                    e.Row.Cells[4].Style.Add("background-color", "#77DDFF");
                }

                if (hid_numbers.Value.IndexOf(e.Row.Cells[5].Text) > -1)
                {
                    e.Row.Cells[5].Style.Add("background-color", "#77DDFF");
                }

     */
                if (e.Row.Cells[5].Text == "Y")
                {
                    e.Row.Cells[5].Text = "是";
                    e.Row.Cells[5].Style.Add("Color", "blue");
                }
                else {
                    e.Row.Cells[5].Text = "否";
                }

                if (e.Row.Cells[10].Text == "Y")
                {
                    e.Row.Cells[10].Text = "是";
                    e.Row.Cells[10].Style.Add("Color", "blue");
                }
                else
                {
                    e.Row.Cells[10].Text = "否";
                }

                if (e.Row.Cells[16].Text == "Y")
                {
                    e.Row.Cells[16].Text = "是";
                    e.Row.Cells[16].Style.Add("Color", "blue");
                }
                else
                {
                    e.Row.Cells[16].Text = "否";
                }

            }

        }
    }
}