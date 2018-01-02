using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using com.oli365.prize.core;
using System.IO;
using System.Text;
using System.Data;

namespace com.oli365.prize.Admin
{
    public partial class FoodList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bindingData();
            }
        }

        private void bindingData() {
            /*
            gv.DataSource = FoodUtility.GetList();
            gv.DataBind();
            */
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            /*
            FoodUtility.Add(txtfoodname.Value.Trim(), txtcalory.Value.Trim(), txtmemo.Value.Trim(),txtperunit.Value.Trim());
            bindingData();
            */
        }

        //載入檔案
        protected void btnLoadFile_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("/Files/Upload/" + DateTime.Now.ToString("yyyyMMdd")+"/") ;
            if (Directory.Exists(path) == false) {
                Directory.CreateDirectory(path);
            }
            String uploadName = fudUpload.FileName;
            String fileName =DateTime.Now.ToString("yyyyMMddHHmmssfff") +  uploadName.Substring(uploadName.LastIndexOf("."));
            String fullName = path + fileName;

            fudUpload.SaveAs(fullName);
            DataTable dt = new DataTable();
            dt.Columns.Add("NUM");
            dt.Columns.Add("FOOD_NAME");
            dt.Columns.Add("PER_UNIT");
            dt.Columns.Add("CALORY");
            dt.Columns.Add("MEMO");
            dt.Columns.Add("STATUS");
            dt.Columns.Add("IS_REPLACE");
            dt.Columns.Add("IS_ADD");

            if (File.Exists(fullName)) {
                string[] lines = System.IO.File.ReadAllLines(fullName,Encoding.UTF8);
                int i = 0;
                foreach (String line in lines) {
                   
                    //第一筆標頭不匯入
                    if (i > 0) {
                        DataRow dr = dt.NewRow();
                        try
                        {
                            
                            string foodname = line.Split(',')[0].Trim();
                            string unit = line.Split(',')[1];
                            string calory = line.Split(',')[2];
                            string memo = line.Split(',')[3];
                            string status = "可匯入";
                            string isreplace = "0";
                            string isadd = "1";

                            //檢查食物名稱是否存在
                            /*
                            if (FoodUtility.IsExistFoodName(foodname)) {
                                status = "已存在";
                                isreplace = "1";
                            }

                            dr["NUM"] = i.ToString();
                            dr["FOOD_NAME"] = foodname;
                            dr["PER_UNIT"] = unit;
                            dr["CALORY"] = calory;
                            dr["MEMO"] = memo;
                            dr["STATUS"] = status;
                            dr["IS_REPLACE"] = isreplace;
                            dr["IS_ADD"] = isadd;
                            */
                           
                        }
                        catch (Exception ex) {
                            dr["NUM"] = i.ToString();
                            dr["FOOD_NAME"] = "";
                            dr["PER_UNIT"] = "";
                            dr["CALORY"] = "";
                            dr["MEMO"] = "";
                            dr["STATUS"] = ex.Message ;
                            dr["IS_REPLACE"] = "0";
                            dr["IS_ADD"] = "0";
                            dt.Rows.Add(dr);
                        }

                        dt.Rows.Add(dr);
                    }
                    i += 1;
                   
                }
            }

            igv.DataSource = dt;
            igv.DataBind();
            
            //檢查新增或替換狀態
            for (int i = 0; i < igv.Items.Count; i++) {
                DataGridItem dg = igv.Items[i];
                if (dg != null) {
                    CheckBox chk = (CheckBox )dg.FindControl("chk");
                    CheckBox chkReplace = (CheckBox)dg.FindControl("chkReplace");
                    string isadd = dg.Cells[8].Text;
                    string isreplace = dg.Cells[9].Text;
                    if (isadd == "1") {
                        chk.Checked = true;
                    }
                    if (isreplace == "1")
                    {
                        chkReplace.Checked = true;
                    }
                    else {
                        chkReplace.Visible   = false;
                    }
                }
            }

            btnConfirmImport.Visible = true;
        }

        protected void btnConfirmImport_Click(object sender, EventArgs e)
        {
            DataGridItem dg;
            int addcount = 0;
            int replacecount = 0;
            string msg ="";
            CheckBox chkAdd;
            CheckBox chkReplace;
            for (int i = 0; i < igv.Items.Count; i++) {
                dg = igv.Items[i];
                if (dg != null) {
                    chkAdd = (CheckBox)dg.FindControl("chk");
                    chkReplace = (CheckBox)dg.FindControl("chkReplace");
                    string foodname = dg.Cells[3].Text;
                    string unit = dg.Cells[4].Text;
                    string calory = dg.Cells[5].Text;
                    string memo = dg.Cells[6].Text;


                    if (chkAdd.Checked ==true && chkReplace.Checked ==true)
                    {
                        /*
                        replacecount += 1;
                        FoodUtility.Update(foodname, unit,calory, memo);
                        */
                    }
                    else if (chkAdd.Checked==true && chkReplace.Checked == false)
                    {
                        /*
                        addcount += 1;
                        FoodUtility.Add(foodname, calory, memo, unit);
                        */
                    }
                }
             

            }

            msg = "合計：新增：" + addcount + "筆，更新：" + replacecount + "筆";
            btnConfirmImport.Visible = false;
            lnkBack.Visible = true;
            lblMsg.Visible = true;
            lblMsg.Text = msg;

            bindingData();
        }
    }
}