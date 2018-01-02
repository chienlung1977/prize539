using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;

using MySql.Data.MySqlClient;

using com.oli365.prize.core;

namespace com.oli365.prize.Member
{
    public partial class NextNumberRList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingPara();
                bindingData();
            }
        }

        

        private void bindingPara() {
            //drp_analysis
            Db db = new Db();
            string sql = "SELECT PRIZE_UID,PERIOD FROM PRIZE539 ORDER BY PERIOD DESC LIMIT 360";
            DataSet ds = db.GetDataset(sql);

            drp_analysis.DataSource = ds;
            drp_analysis.DataTextField = "PERIOD";
            drp_analysis.DataValueField = "PRIZE_UID";
            drp_analysis.DataBind();

        }

        private void bindingData() {

            //查詢期間
            string period = drp_period.SelectedValue;
            //查詢期數
            string prize_uid = drp_analysis.SelectedValue;
            string prize_period = drp_analysis.SelectedItem.Text;
            
            //先找出要查詢的該筆記錄
            Db db = new Db();




            
            string sql = "SELECT * FROM PRIZE539 WHERE PRIZE_UID=@PRIZE_UID" ;
            MySqlCommand cmd = new MySqlCommand(sql,db.Connection );
            MySqlParameter p = new MySqlParameter("@PRIZE_UID", MySqlDbType.VarChar );
            p.Value = prize_uid;
            cmd.Parameters.Add(p);
            DataSet ds = db.GetDataset(cmd);

            if (ds.Tables[0].Rows.Count == 0) {
                return;
            }

            //開獎號碼
            string ln1 = ds.Tables[0].Rows[0]["NUM1"].ToString();
            string ln2 = ds.Tables[0].Rows[0]["NUM2"].ToString();
            string ln3 = ds.Tables[0].Rows[0]["NUM3"].ToString();
            string ln4 = ds.Tables[0].Rows[0]["NUM4"].ToString();
            string ln5 = ds.Tables[0].Rows[0]["NUM5"].ToString();
            string ldate = ds.Tables[0].Rows[0]["LOTTERY_DAY"].ToString();

            lbl_lottery_num.Text = "本次查詢【" + prize_period + "】期，日期【" + ldate + "】" + "，開獎號碼【" + ln1 + ","  + ln2 + "," + ln3 + "," + ln4 + "," + ln5 + "】";


            //======================最後找出下一期的開獎號碼================
            sql = "SELECT * FROM PRIZE539 WHERE PERIOD>@PERIOD ORDER BY PERIOD ASC LIMIT 1";
            cmd = new MySqlCommand(sql, db.Connection);
            MySqlParameter para = new MySqlParameter("@PERIOD", MySqlDbType.Int32);
            para.Value = prize_period;
            cmd.Parameters.Add(para);
            ds = db.GetDataset(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_next_lottery_num.Text = "開獎結果【" + ds.Tables[0].Rows[0]["PERIOD"] + "】期，日期【" + ds.Tables[0].Rows[0]["LOTTERY_DAY"] + "】，開獎號碼【" + ds.Tables[0].Rows[0]["NUM1"] + "," + ds.Tables[0].Rows[0]["NUM2"] + "," + ds.Tables[0].Rows[0]["NUM3"] + "," + ds.Tables[0].Rows[0]["NUM4"] + "," + ds.Tables[0].Rows[0]["NUM5"] + "】";
                hid_next_lottery_num.Value = ds.Tables[0].Rows[0]["NUM1"] + "," + ds.Tables[0].Rows[0]["NUM2"] + "," + ds.Tables[0].Rows[0]["NUM3"] + "," + ds.Tables[0].Rows[0]["NUM4"] + "," + ds.Tables[0].Rows[0]["NUM5"];
            }
            else
            {
                lbl_next_lottery_num.Text = "尚無下期開獎號碼";
                hid_next_lottery_num.Value = "";
            }

            //======================最後找出下一期的開獎號碼end================


            //查詢清單內容
            sql = "SELECT * FROM PRIZE539 WHERE PERIOD  <= @SPERIOD  ORDER BY PERIOD DESC LIMIT @NUM";
            cmd = new MySqlCommand(sql, db.Connection);
            MySqlParameter  P1 = new MySqlParameter("@SPERIOD", MySqlDbType.Int32);
   //         MySqlParameter P2 = new MySqlParameter("@EPERIOD", MySqlDbType.Int32);
            MySqlParameter P3 = new MySqlParameter("@NUM", MySqlDbType.Int32);
            P1.Value = prize_period;
       //     P2.Value = prize_period;
            P3.Value = period;
            cmd.Parameters.Add(P1);
         //   cmd.Parameters.Add(P2);
            cmd.Parameters.Add(P3);
            ds = db.GetDataset(cmd);


            Dictionary<string, int> numshowtimes = new Dictionary<string, int>();
            Dictionary<string, int> totalshowtimes = new Dictionary<string, int>(); //總出現次數
            double sumtotal = 0;  //總合計
            double sumnum = 0;  //單一號碼合計
            
            ArrayList al = new ArrayList();

            DataTable dt = new DataTable();

            dt.Columns.Add("期數");
            dt.Columns.Add("開獎日期");

            for (int i = 1; i <= 39; i++) {
                dt.Columns.Add(i.ToString().PadLeft(2, '0'));

                //初始化總數號碼
                numshowtimes.Add(i.ToString().PadLeft(2, '0'), 0);

                //總合計號碼初始化
                totalshowtimes.Add(i.ToString().PadLeft(2, '0'), 0);

            }

            //=================號碼1下期出現號碼====================
            DataRow irow1 = dt.NewRow();
            irow1[0] = "S號碼1，當期出現【" + ln1 + "】下期出現號碼";
            dt.Rows.Add(irow1);

            for (int x = 0; x < ds.Tables[0].Rows.Count; x++) {

                if (x > 0) {
                    //目前這期開獎號碼
                    string n1 = ds.Tables[0].Rows[x]["NUM1"].ToString();
                    string n2 = ds.Tables[0].Rows[x]["NUM2"].ToString();
                    string n3 = ds.Tables[0].Rows[x]["NUM3"].ToString();
                    string n4 = ds.Tables[0].Rows[x]["NUM4"].ToString();
                    string n5 = ds.Tables[0].Rows[x]["NUM5"].ToString();

                   

                    if (ln1 == n1 || ln1 == n2 || ln1 == n3 || ln1 == n4 || ln1 == n5) {

                        //排除相同期數的號碼，免得重覆計算
                        al.Add(ds.Tables[0].Rows[x - 1]["PERIOD"]);

                        DataRow irow = dt.NewRow();
                        irow["期數"] = ds.Tables[0].Rows[x-1]["PERIOD"];
                        irow["開獎日期"] = ds.Tables[0].Rows[x-1]["LOTTERY_DAY"];
                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM1"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM1"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), numshowtimes);
                                addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), totalshowtimes);
                                sumnum += 1;
                                sumtotal += 1;
                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM2"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM2"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), numshowtimes);
                                addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), totalshowtimes);
                                sumnum += 1;
                                sumtotal += 1;
                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM3"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM3"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), numshowtimes);
                                addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), totalshowtimes);
                                sumnum += 1;
                                sumtotal += 1;
                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM4"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM4"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), numshowtimes);
                                addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), totalshowtimes);
                                sumnum += 1;
                                sumtotal += 1;
                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM5"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM5"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), numshowtimes);
                                addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), totalshowtimes);
                                sumnum += 1;
                                sumtotal += 1;
                            }
                        }

                        dt.Rows.Add(irow);
                    }
                }

                }

               

            //計算出現次數和機率

            DataRow srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現次數" ;

            for (int i = 0; i < numshowtimes.Count; i++) {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0) {
                    srow[i + 2] = numshowtimes[(i + 1).ToString().PadLeft(2, '0')];
                }
               
            }

            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現機率";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    double result = numshowtimes[(i + 1).ToString().PadLeft(2, '0')] / sumnum * 100;
                    srow[i + 2] = Math.Round(result, 1, MidpointRounding.AwayFromZero) + "%";
                }

            }

            dt.Rows.Add(srow);

            //依出現率排序

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率排序";

            List<KeyValuePair<string, int>> sortList = numshowtimes.ToList();

            var sorted = from entry in numshowtimes orderby entry.Value descending select entry;
            int n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0) {
                    Double sortresult = item.Value / sumnum * 100;
                    srow[n] = Math.Round(sortresult, 1, MidpointRounding.AwayFromZero) + "%" ;

                }

            }


            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率號碼";
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {
                   
                    srow[n] = item.Key;

                }

            }
            dt.Rows.Add(srow);


            //=================號碼2下期出現號碼====================
            //重新初始單一號碼

            sumnum = 0;
            numshowtimes = new Dictionary<string, int>();
            for (int i = 1; i <= 39; i++)
            {
                //初始化總數號碼
                numshowtimes.Add(i.ToString().PadLeft(2, '0'), 0);
            }


            irow1 = dt.NewRow();
            irow1[0] = "S號碼2，當期出現【" + ln2 + "】下期出現號碼";
            dt.Rows.Add(irow1);

            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {

                if (x > 0)
                {
                    //目前這期開獎號碼
                    string n1 = ds.Tables[0].Rows[x]["NUM1"].ToString();
                    string n2 = ds.Tables[0].Rows[x]["NUM2"].ToString();
                    string n3 = ds.Tables[0].Rows[x]["NUM3"].ToString();
                    string n4 = ds.Tables[0].Rows[x]["NUM4"].ToString();
                    string n5 = ds.Tables[0].Rows[x]["NUM5"].ToString();



                    if (ln2 == n1 || ln2 == n2 || ln2 == n3 || ln2 == n4 || ln2 == n5)
                    {

                        //排除相同期數的號碼，免得重覆計算
                        Boolean ispass = true;
                        if (!al.Contains(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString())) {
                            ispass = false;
                            al.Add(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString());
                        }

                        ispass = false;

                        DataRow irow = dt.NewRow();

                        if (ispass==false)
                        {
                            irow["期數"] = ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        else
                        {
                            irow["期數"] = "*" + ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        irow["開獎日期"] = ds.Tables[0].Rows[x - 1]["LOTTERY_DAY"];
                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM1"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM1"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false) {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }
                              

                              

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM2"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM2"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM3"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM3"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }


                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM4"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM4"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM5"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM5"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }
                            }
                        }

                        dt.Rows.Add(irow);
                    }
                }

            }



            //計算出現次數和機率

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現次數";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    srow[i + 2] = numshowtimes[(i + 1).ToString().PadLeft(2, '0')];
                }

            }

            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現機率";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    double result = numshowtimes[(i + 1).ToString().PadLeft(2, '0')] / sumnum * 100;
                    srow[i + 2] = Math.Round(result, 1, MidpointRounding.AwayFromZero) + "%";
                }

            }

            dt.Rows.Add(srow);

            //依出現率排序

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率排序";

            sortList = numshowtimes.ToList();

            sorted = from entry in numshowtimes orderby entry.Value descending select entry;
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {
                    Double sortresult = item.Value / sumnum * 100;
                    srow[n] = Math.Round(sortresult, 1, MidpointRounding.AwayFromZero) + "%";

                }

            }


            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率號碼";
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {

                    srow[n] = item.Key;

                }

            }
            dt.Rows.Add(srow);

            //=================號碼3下期出現號碼====================
            //重新初始單一號碼

            sumnum = 0;
            numshowtimes = new Dictionary<string, int>();
            for (int i = 1; i <= 39; i++)
            {
                //初始化總數號碼
                numshowtimes.Add(i.ToString().PadLeft(2, '0'), 0);
            }


            irow1 = dt.NewRow();
            irow1[0] = "S號碼3，當期出現【" + ln3 + "】下期出現號碼";
            dt.Rows.Add(irow1);

            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {

                if (x > 0)
                {
                    //目前這期開獎號碼
                    string n1 = ds.Tables[0].Rows[x]["NUM1"].ToString();
                    string n2 = ds.Tables[0].Rows[x]["NUM2"].ToString();
                    string n3 = ds.Tables[0].Rows[x]["NUM3"].ToString();
                    string n4 = ds.Tables[0].Rows[x]["NUM4"].ToString();
                    string n5 = ds.Tables[0].Rows[x]["NUM5"].ToString();



                    if (ln3 == n1 || ln3 == n2 || ln3 == n3 || ln3 == n4 || ln3 == n5)
                    {

                        //排除相同期數的號碼，免得重覆計算
                        Boolean ispass = true;
                        if (!al.Contains(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString()))
                        {
                            ispass = false;
                            al.Add(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString());
                        }
                        ispass = false;

                        DataRow irow = dt.NewRow();
                        if (ispass==false)
                        {
                            irow["期數"] = ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        else {
                            irow["期數"] ="*" +  ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        
                        irow["開獎日期"] = ds.Tables[0].Rows[x - 1]["LOTTERY_DAY"];
                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM1"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM1"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false) {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }
                               

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM2"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM2"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM3"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM3"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }


                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM4"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM4"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM5"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM5"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }
                            }
                        }

                        dt.Rows.Add(irow);
                    }
                }

            }



            //計算出現次數和機率

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現次數";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    srow[i + 2] = numshowtimes[(i + 1).ToString().PadLeft(2, '0')];
                }

            }

            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現機率";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    double result = numshowtimes[(i + 1).ToString().PadLeft(2, '0')] / sumnum * 100;
                    srow[i + 2] = Math.Round(result, 1, MidpointRounding.AwayFromZero) + "%";
                }

            }

            dt.Rows.Add(srow);

            //依出現率排序

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率排序";

            sortList = numshowtimes.ToList();

            sorted = from entry in numshowtimes orderby entry.Value descending select entry;
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {
                    Double sortresult = item.Value / sumnum * 100;
                    srow[n] = Math.Round(sortresult, 1, MidpointRounding.AwayFromZero) + "%";

                }

            }


            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率號碼";
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {

                    srow[n] = item.Key;

                }

            }
            dt.Rows.Add(srow);

            //=================號碼4下期出現號碼====================
            //重新初始單一號碼

            sumnum = 0;
            numshowtimes = new Dictionary<string, int>();
            for (int i = 1; i <= 39; i++)
            {
                //初始化總數號碼
                numshowtimes.Add(i.ToString().PadLeft(2, '0'), 0);
            }


            irow1 = dt.NewRow();
            irow1[0] = "S號碼4，當期出現【" + ln4 + "】下期出現號碼";
            dt.Rows.Add(irow1);

            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {

                if (x > 0)
                {
                    //目前這期開獎號碼
                    string n1 = ds.Tables[0].Rows[x]["NUM1"].ToString();
                    string n2 = ds.Tables[0].Rows[x]["NUM2"].ToString();
                    string n3 = ds.Tables[0].Rows[x]["NUM3"].ToString();
                    string n4 = ds.Tables[0].Rows[x]["NUM4"].ToString();
                    string n5 = ds.Tables[0].Rows[x]["NUM5"].ToString();



                    if (ln4 == n1 || ln4 == n2 || ln4 == n3 || ln4 == n4 || ln4 == n5)
                    {

                        //排除相同期數的號碼，免得重覆計算
                        Boolean ispass = true;
                        if (!al.Contains(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString()))
                        {
                            ispass = false;
                            al.Add(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString());
                        }

                        ispass = false;

                        DataRow irow = dt.NewRow();
                        if (ispass==false)
                        {
                            irow["期數"] = ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        else
                        {
                            irow["期數"] = "*" + ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        irow["開獎日期"] = ds.Tables[0].Rows[x - 1]["LOTTERY_DAY"];
                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM1"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM1"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false) {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }
                                



                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM2"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM2"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM3"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM3"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }


                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM4"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM4"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM5"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM5"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }
                            }
                        }

                        dt.Rows.Add(irow);
                    }
                }

            }



            //計算出現次數和機率

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現次數";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    srow[i + 2] = numshowtimes[(i + 1).ToString().PadLeft(2, '0')];
                }

            }

            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現機率";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    double result = numshowtimes[(i + 1).ToString().PadLeft(2, '0')] / sumnum * 100;
                    srow[i + 2] = Math.Round(result, 1, MidpointRounding.AwayFromZero) + "%";
                }

            }

            dt.Rows.Add(srow);

            //依出現率排序

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率排序";

            sortList = numshowtimes.ToList();

            sorted = from entry in numshowtimes orderby entry.Value descending select entry;
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {
                    Double sortresult = item.Value / sumnum * 100;
                    srow[n] = Math.Round(sortresult, 1, MidpointRounding.AwayFromZero) + "%";

                }

            }


            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率號碼";
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {

                    srow[n] = item.Key;

                }

            }
            dt.Rows.Add(srow);


            //=================號碼5下期出現號碼====================
            //重新初始單一號碼

            sumnum = 0;
            numshowtimes = new Dictionary<string, int>();
            for (int i = 1; i <= 39; i++)
            {
                //初始化總數號碼
                numshowtimes.Add(i.ToString().PadLeft(2, '0'), 0);
            }


            irow1 = dt.NewRow();
            irow1[0] = "S號碼5，當期出現【" + ln5 + "】下期出現號碼";
            dt.Rows.Add(irow1);

            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {

                if (x > 0)
                {
                    //目前這期開獎號碼
                    string n1 = ds.Tables[0].Rows[x]["NUM1"].ToString();
                    string n2 = ds.Tables[0].Rows[x]["NUM2"].ToString();
                    string n3 = ds.Tables[0].Rows[x]["NUM3"].ToString();
                    string n4 = ds.Tables[0].Rows[x]["NUM4"].ToString();
                    string n5 = ds.Tables[0].Rows[x]["NUM5"].ToString();



                    if (ln5 == n1 || ln5 == n2 || ln5 == n3 || ln5 == n4 || ln5 == n5)
                    {

                        //排除相同期數的號碼，免得重覆計算
                        Boolean ispass = true;
                        if (!al.Contains(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString()))
                        {
                            ispass = false;
                            al.Add(ds.Tables[0].Rows[x - 1]["PERIOD"].ToString());
                        }
                        ispass = false;

                        DataRow irow = dt.NewRow();
                        if (ispass==false)
                        {
                            irow["期數"] = ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        else {
                            irow["期數"] ="*" +  ds.Tables[0].Rows[x - 1]["PERIOD"];
                        }
                        irow["開獎日期"] = ds.Tables[0].Rows[x - 1]["LOTTERY_DAY"];
                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM1"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM1"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM1"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }



                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM2"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM2"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM2"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM3"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM3"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM3"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }


                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM4"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM4"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM4"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }

                            }
                            if (dt.Columns[y].ColumnName == ds.Tables[0].Rows[x - 1]["NUM5"].ToString())
                            {
                                irow[y] = ds.Tables[0].Rows[x - 1]["NUM5"].ToString();
                                addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), numshowtimes);
                                sumnum += 1;
                                if (ispass == false)
                                {
                                    addNum(ds.Tables[0].Rows[x - 1]["NUM5"].ToString(), totalshowtimes);
                                    sumtotal += 1;
                                }
                            }
                        }

                        dt.Rows.Add(irow);
                    }
                }

            }



            //計算出現次數和機率

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現次數";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    srow[i + 2] = numshowtimes[(i + 1).ToString().PadLeft(2, '0')];
                }

            }

            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現機率";

            for (int i = 0; i < numshowtimes.Count; i++)
            {
                if (numshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    double result = numshowtimes[(i + 1).ToString().PadLeft(2, '0')] / sumnum * 100;
                    srow[i + 2] = Math.Round(result, 1, MidpointRounding.AwayFromZero) + "%";
                }

            }

            dt.Rows.Add(srow);

            //依出現率排序

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率排序";

            sortList = numshowtimes.ToList();

            sorted = from entry in numshowtimes orderby entry.Value descending select entry;
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {
                    Double sortresult = item.Value / sumnum * 100;
                    srow[n] = Math.Round(sortresult, 1, MidpointRounding.AwayFromZero) + "%";

                }

            }


            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率號碼";
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {

                    srow[n] = item.Key;

                }

            }
            dt.Rows.Add(srow);


            //=================所有號碼加總的出現率====================

            //計算出現次數和機率

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);
            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);
            srow = dt.NewRow();
            srow[0] = "S所有號碼出現總機率";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現次數";

            for (int i = 0; i < totalshowtimes.Count; i++)
            {
                if (totalshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    srow[i + 2] = totalshowtimes[(i + 1).ToString().PadLeft(2, '0')];
                }

            }

            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "出現機率";

            for (int i = 0; i < totalshowtimes.Count; i++)
            {
                if (totalshowtimes[(i + 1).ToString().PadLeft(2, '0')] != 0)
                {
                    double result = totalshowtimes[(i + 1).ToString().PadLeft(2, '0')] / sumtotal * 100;
                    srow[i + 2] = Math.Round(result, 1, MidpointRounding.AwayFromZero) + "%";
                }

            }

            dt.Rows.Add(srow);

            //依出現率排序

            srow = dt.NewRow();
            srow[0] = "空白行";
            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率排序";

            sortList = totalshowtimes.ToList();

            sorted = from entry in totalshowtimes orderby entry.Value descending select entry;
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {
                    Double sortresult = item.Value / sumtotal * 100;
                    srow[n] = Math.Round(sortresult, 1, MidpointRounding.AwayFromZero) + "%";

                }

            }


            dt.Rows.Add(srow);

            srow = dt.NewRow();
            srow[0] = "機率號碼";
            n = 1;
            foreach (var item in sorted)
            {
                n += 1;
                if (item.Value > 0)
                {

                    srow[n] = item.Key;

                }

            }
            dt.Rows.Add(srow);


            gv.DataSource = dt;
            gv.DataBind();


           


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bindingData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 2; i <= 40; i++)
                {
                    if (e.Row.Cells[i].Text != "&nbsp;" && e.Row.Cells[0].Text != "出現次數" 
                        && e.Row.Cells[0].Text != "出現機率"
                        && e.Row.Cells[0].Text != "機率排序"
                        && e.Row.Cells[0].Text != "機率號碼")
                    {
                        e.Row.Cells[i].BackColor = Utility.HexColor("#D2E9FF");
                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                    }

                    if (e.Row.Cells[0].Text != "出現次數" || e.Row.Cells[0].Text != "出現機率") {
                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                    }

                    if (e.Row.Cells[0].Text == "機率號碼") {

                       // e.Row.Cells[i].Text = hid_next_lottery_num.Value.IndexOf(e.Row.Cells[i].Text.Trim()).ToString();

                        if (hid_next_lottery_num.Value.IndexOf(e.Row.Cells[i].Text.Trim()) > -1) {
                            e.Row.Cells[i].BackColor = Utility.HexColor("#FFE4B5");
                        }
                    }

                }

                if (e.Row.Cells[0].Text == "空白行")
                {
                    e.Row.Cells[0].ColumnSpan = 41;
                    for (int i = 40; i >=1; i--) {
                        e.Row.Cells.RemoveAt(i);
                    }
                    
                    e.Row.Cells[0].Text = "&nbsp;";
                }

                if (e.Row.Cells[0].Text.Substring(0, 1) == "S") {
                    e.Row.Cells[0].ColumnSpan = 41;
                    for (int i = 40; i >= 1; i--)
                    {
                        e.Row.Cells.RemoveAt(i);
                    }
                    e.Row.Cells[0].Text = e.Row.Cells[0].Text.Replace("S", "");
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }

                if (e.Row.Cells[0].Text == "出現次數" || e.Row.Cells[0].Text == "出現機率"
                    || e.Row.Cells[0].Text == "機率排序" || e.Row.Cells[0].Text == "機率號碼") {
                    e.Row.Cells[0].ColumnSpan = 2;
                    e.Row.Cells.RemoveAt(1);
                   // e.Row.Cells[0].Text = "<center>" + e.Row.Cells[0].Text + "</center>";
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }

            

            }
        }


        //將號碼加入計算內容中
        public  void addNum(string num, Dictionary<string, int> arrlst)
        {
            if (arrlst.ContainsKey(num))
            {
                arrlst[num] += 1;
            }

        }


    }
}