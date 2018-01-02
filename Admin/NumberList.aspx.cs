using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using MySql.Data.MySqlClient;

using com.oli365.prize.core;

namespace com.oli365.prize.Admin
{
    public partial class NumberList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingData();
            }
        }

        private void bindingData() {

            string period = drp_period.SelectedValue;

            Db db = new Db();
            
            string sql = "SELECT * FROM PRIZE539 ORDER BY LOTTERY_DAY DESC LIMIT @PERIOD" ;
            MySqlCommand cmd = new MySqlCommand(sql,db.Connection );
            MySqlParameter p = new MySqlParameter("@PERIOD", MySqlDbType.Int32);
            p.Value = period;
            cmd.Parameters.Add(p);
            DataSet ds = db.GetDataset(cmd);

            DataTable dt = new DataTable();

            dt.Columns.Add("期數");
            dt.Columns.Add("開獎日期");

            for (int i = 1; i <= 39; i++) {
                dt.Columns.Add(i.ToString().PadLeft(2, '0'));
            }

            for (int x = 0; x < ds.Tables[0].Rows.Count; x++) {
                DataRow irow =  dt.NewRow();
                irow["期數"] = ds.Tables[0].Rows[x]["PERIOD"];
                irow["開獎日期"] = ds.Tables[0].Rows[x]["LOTTERY_DAY"];
                for (int y = 0; y < dt.Columns.Count; y++) {
                    if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x]["NUM1"].ToString())
                    {
                        irow[y] = ds.Tables[0].Rows[x]["NUM1"].ToString();
                    }
                    if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x]["NUM2"].ToString())
                    {
                        irow[y] = ds.Tables[0].Rows[x]["NUM2"].ToString();
                    }
                    if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x]["NUM3"].ToString())
                    {
                        irow[y] = ds.Tables[0].Rows[x]["NUM3"].ToString();
                    }
                    if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x]["NUM4"].ToString())
                    {
                        irow[y] = ds.Tables[0].Rows[x]["NUM4"].ToString();
                    }
                    if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x]["NUM5"].ToString())
                    {
                        irow[y] = ds.Tables[0].Rows[x]["NUM5"].ToString();
                    }
                }

                dt.Rows.Add(irow);
            }


            gv.DataSource = dt;
            gv.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bindingData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Number n = new Number();
            n.Period = tbx_period.Text.Trim();
            n.Date =  tbx_date.Text.Trim();
            n.Num1 = tbx_num1.Text.Trim();
            n.Num2 = tbx_num2.Text.Trim();
            n.Num3 = tbx_num3.Text.Trim();
            n.Num4 = tbx_num4.Text.Trim();
            n.Num5 = tbx_num5.Text.Trim();

            NumberUtility nu = new NumberUtility();
            nu.Add(n);

            bindingData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 2; i <= 40; i++)
                {
                    if (e.Row.Cells[i].Text != "&nbsp;")
                    {
                        e.Row.Cells[i].BackColor = Utility.HexColor("#D2E9FF");
                    }
                }


            }
        }
    }
}