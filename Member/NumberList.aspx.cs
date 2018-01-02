﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using MySql.Data.MySqlClient;

using CoreLib;

namespace com.oli365.prize.Member
{
    public partial class NumberList : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingData();
            }
        }

        private void bindingData() {

            int count = int.Parse( drp_period.SelectedValue);

            Mariadb m = new Mariadb(base.CN);
           
            
            string sql = "SELECT * FROM PRIZE539 ORDER BY PERIOD DESC LIMIT @COUNT" ;
            MySqlCommand cmd = new MySqlCommand(sql );
            cmd.Parameters.AddWithValue("@COUNT", count );
            DataSet ds = m.GetDataset(cmd);
            gv.DataSource = ds;
            gv.DataBind();

            for (int i = 0; i < gv.Rows.Count; i++) {
                if (i !=gv.Rows.Count - 1) {
                    //現有號碼
                    string num1 = gv.Rows[i].Cells[2].Text.Trim();
                    string num2 = gv.Rows[i].Cells[3].Text.Trim();
                    string num3 = gv.Rows[i].Cells[4].Text.Trim();
                    string num4 = gv.Rows[i].Cells[5].Text.Trim();
                    string num5 = gv.Rows[i].Cells[6].Text.Trim();

                    //前一期號碼
                    string pnum1 = gv.Rows[i+1].Cells[2].Text.Trim();
                    string pnum2 = gv.Rows[i+1].Cells[3].Text.Trim();
                    string pnum3 = gv.Rows[i+1].Cells[4].Text.Trim();
                    string pnum4 = gv.Rows[i+1].Cells[5].Text.Trim();
                    string pnum5 = gv.Rows[i+1].Cells[6].Text.Trim();


                    if (num1 ==pnum1 || num1==pnum2 || num1==pnum3 || num1==pnum4 || num1==pnum5 ) {
                        gv.Rows[i].Cells[2].Style.Add("background-color", "#77DDFF");
                    }
                    if (num2 == pnum1 || num2 == pnum2 || num2 == pnum3 || num2 == pnum4 || num2 == pnum5)
                    {
                        gv.Rows[i].Cells[3].Style.Add("background-color", "#77DDFF");
                    }
                    if (num3 == pnum1 || num3 == pnum2 || num3 == pnum3 || num3 == pnum4 || num3 == pnum5)
                    {
                        gv.Rows[i].Cells[4].Style.Add("background-color", "#77DDFF");
                    }
                    if (num4 == pnum1 || num4 == pnum2 || num4 == pnum3 || num4 == pnum4 || num4 == pnum5)
                    {
                        gv.Rows[i].Cells[5].Style.Add("background-color", "#77DDFF");
                    }
                    if (num5 == pnum1 || num5 == pnum2 || num5 == pnum3 || num5 == pnum4 || num5 == pnum5)
                    {
                        gv.Rows[i].Cells[6].Style.Add("background-color", "#77DDFF");
                    }

                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bindingData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                
            

            }
        }


     


    }
}