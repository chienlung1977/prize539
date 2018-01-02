using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CoreLib;
using MySql.Data.MySqlClient;
using System.Data;

namespace com.oli365.prize
{
    public partial class _Default : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingData();
            }
        }


        private void binding539() {


            Mariadb m = new Mariadb(this.CN);
            string sql = "SELECT * FROM PRIZE539 ORDER BY PERIOD DESC LIMIT 10";
            MySqlCommand cmd = new MySqlCommand(sql);
            DataSet ds = m.GetDataset(cmd);

            string period = ds.Tables[0].Rows[0]["PERIOD"].ToString();

            gv_lotto539.DataSource = ds;
            gv_lotto539.DataBind();

            dv_lotto539.DataSource = ds;
            dv_lotto539.DataBind();

        }

        private void bindLotto649() {

            Mariadb m = new Mariadb(this.CN);


            string sql = "SELECT * FROM LOTTO649 ORDER BY PERIOD DESC LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(sql);
            DataSet ds = m.GetDataset(cmd);

            gv_lotto649.DataSource = ds;
            gv_lotto649.DataBind();

            sql = "SELECT D.NICK_NAME,A.*,B.CAL_NAME FROM LOTTO649_NEXT AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID" +
              " JOIN USERS AS D ON C.USER_UID=D.USER_UID WHERE A.IS_WINNING='Y' ORDER BY A.PERIOD DESC,MATCH_NUM DESC LIMIT 15";
            cmd = new MySqlCommand(sql);
            ds = m.GetDataset(cmd);

            dl_lotto649.DataSource = ds;
            dl_lotto649.DataBind();



        }


        private void bindingSuperLotto() {

            Mariadb m = new Mariadb(this.CN);

            string sql = "SELECT * FROM SUPER_LOTTO ORDER BY PERIOD DESC LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(sql);
            DataSet  ds = m.GetDataset(cmd);

            gv_superlotto.DataSource = ds;
            gv_superlotto.DataBind();


            sql = "SELECT D.NICK_NAME,A.*,B.CAL_NAME FROM SUPER_LOTTO_NEXT AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID" +
            " JOIN USERS AS D ON C.USER_UID=D.USER_UID WHERE A.IS_WINNING='Y' ORDER BY A.PERIOD DESC,MATCH_NUM DESC LIMIT 15";
            cmd = new MySqlCommand(sql);
            ds = m.GetDataset(cmd);

            dl_superlotto.DataSource = ds;
            dl_superlotto.DataBind();


        }

        private void bindingData() {

            binding539();
            bindLotto649();
            bindingSuperLotto();

          
        }

        protected void gv_lotto539_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Mariadb m = new Mariadb(this.CN);
                DataList dl = (DataList )e.Item.FindControl("dl");
                if (dl != null) {
                    string period = gv_lotto539.DataKeys[e.Item.ItemIndex].ToString();
                    //今彩539列出有中獎的清單
                    string sql = "SELECT D.NICK_NAME,A.*,B.CAL_NAME FROM PRIZE539_NEXT AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID" +
                        " JOIN USERS AS D ON C.USER_UID=D.USER_UID WHERE A.IS_WINNING='Y' AND A.NEXT_PERIOD=@PERIOD ORDER BY A.NEXT_PERIOD DESC,MATCH_NUM DESC";
                    MySqlCommand  cmd = new MySqlCommand(sql);
                    cmd.Parameters.AddWithValue("@PERIOD", period);
                    DataSet  ds = m.GetDataset(cmd);

                    dl.DataSource = ds;
                    dl.DataBind();
                }


            }
        }

        protected void dv_lotto539_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem )
            {
                Mariadb m = new Mariadb(this.CN);
                DataList dvlist = (DataList)e.Item.FindControl("dvlist");
                if (dvlist != null)
                {
                    string period = dv_lotto539.DataKeys[e.Item.ItemIndex].ToString();
                    //暗彩539列出有中獎的清單
                    string sql = "SELECT D.NICK_NAME,A.*,B.CAL_NAME FROM PRIZE539_NEXT_NONLEGAL AS A JOIN CALCULATION_TYPE AS B ON A.CAL_ID=B.CAL_ID JOIN USER_FORECAST AS C ON A.FORECAST_UID=C.FORECAST_UID JOIN USERS AS D ON C.USER_UID=D.USER_UID WHERE (S2_IS_WINNING='Y' OR S3_IS_WINNING='Y' OR S4_IS_WINNING='Y') AND A.NEXT_PERIOD=@PERIOD   ";
                    MySqlCommand cmd = new MySqlCommand(sql);
                    cmd.Parameters.AddWithValue("@PERIOD", period);
                    DataSet ds = m.GetDataset(cmd);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("NICK_NAME");
                    dt.Columns.Add("CAL_NAME");
                    dt.Columns.Add("NEXT_PERIOD");
                    dt.Columns.Add("STAR_TYPE");
                    dt.Columns.Add("NUMS");
                    dt.Columns.Add("MATCH_NUM");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["S4_IS_WINNING"].ToString() == "Y")
                        {
                            DataRow dr = dt.NewRow();
                            dr["NICK_NAME"] = ds.Tables[0].Rows[i]["NICK_NAME"].ToString();
                            dr["CAL_NAME"] = ds.Tables[0].Rows[i]["CAL_NAME"].ToString();
                            dr["NEXT_PERIOD"] = ds.Tables[0].Rows[i]["NEXT_PERIOD"].ToString();
                            dr["STAR_TYPE"] = "4星";
                            dr["NUMS"] = "(" + ds.Tables[0].Rows[i]["4_STAR_1"].ToString() + ")(" + ds.Tables[0].Rows[i]["4_STAR_2"].ToString() + ")(" + ds.Tables[0].Rows[i]["4_STAR_3"].ToString() + ")(" + ds.Tables[0].Rows[i]["4_STAR_4"].ToString() + ")";
                            dr["MATCH_NUM"] = ds.Tables[0].Rows[i]["S4_MATCH_NUM"].ToString();
                            dt.Rows.Add(dr);
                        }
                        if (ds.Tables[0].Rows[i]["S3_IS_WINNING"].ToString() == "Y")
                        {
                            DataRow dr = dt.NewRow();
                            dr["NICK_NAME"] = ds.Tables[0].Rows[i]["NICK_NAME"].ToString();
                            dr["CAL_NAME"] = ds.Tables[0].Rows[i]["CAL_NAME"].ToString();
                            dr["NEXT_PERIOD"] = ds.Tables[0].Rows[i]["NEXT_PERIOD"].ToString();
                            dr["STAR_TYPE"] = "3星";
                            dr["NUMS"] = "(" + ds.Tables[0].Rows[i]["3_STAR_1"].ToString() + ")(" + ds.Tables[0].Rows[i]["3_STAR_2"].ToString() + ")(" + ds.Tables[0].Rows[i]["3_STAR_3"].ToString() + ")";
                            dr["MATCH_NUM"] = ds.Tables[0].Rows[i]["S3_MATCH_NUM"].ToString();
                            dt.Rows.Add(dr);
                        }
                        if (ds.Tables[0].Rows[i]["S2_IS_WINNING"].ToString() == "Y")
                        {
                            DataRow dr = dt.NewRow();
                            dr["NICK_NAME"] = ds.Tables[0].Rows[i]["NICK_NAME"].ToString();
                            dr["CAL_NAME"] = ds.Tables[0].Rows[i]["CAL_NAME"].ToString();
                            dr["NEXT_PERIOD"] = ds.Tables[0].Rows[i]["NEXT_PERIOD"].ToString();
                            dr["STAR_TYPE"] = "2星";
                            dr["NUMS"] = "(" + ds.Tables[0].Rows[i]["2_STAR_1"].ToString() + ")(" + ds.Tables[0].Rows[i]["2_STAR_2"].ToString() + ")";
                            dr["MATCH_NUM"] = ds.Tables[0].Rows[i]["S2_MATCH_NUM"].ToString();
                            dt.Rows.Add(dr);
                        }
                    }


                    dvlist.DataSource = dt;
                    dvlist.DataBind();
                }


            }
        }
    }

}