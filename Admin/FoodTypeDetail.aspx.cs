using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using com.oli365.prize.core;

using System.Data;

namespace com.oli365.prize.Admin
{
    public partial class FoodTypeDetail : System.Web.UI.Page
    {

        String FOOD_TYPE_UID;
        protected void Page_Load(object sender, EventArgs e)
        {
            FOOD_TYPE_UID = Request["ftid"];
            if (!IsPostBack)
            {
                bindingData();
            }
        }

        private void bindingData()
        {
            /*
            gv.DataSource = FoodUtility.GetList();
            gv.DataBind();

            //顯示目前已有設定的資料
            DataSet ds = FoodTypeLinkUtility.GetListByFoodTypeUid(FOOD_TYPE_UID);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < gv.Items.Count; j++)
                {
                    CheckBox chk = (CheckBox)gv.Items[j].FindControl("chk");
                    String key = gv.DataKeys[j].ToString();
                    if (ds.Tables[0].Rows[i]["FOOD_UID"].ToString() == key)
                    {
                        chk.Checked = true;
                    }
                }
            }
            */

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //先刪除該關連再新增
            /*
            FoodTypeLinkUtility.RemoveByFoodTypeUid(FOOD_TYPE_UID);
            for (int i = 0; i < gv.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)gv.Items[i].FindControl("chk");
                String key = gv.DataKeys[i].ToString();
                if (chk.Checked)
                {
                    FoodTypeLinkUtility.Add(FOOD_TYPE_UID, key, "FOOD TYPE DETAIL ADD");
                }
            }

            Helper.Alert(this, "儲存成功");
            */
        }
    }
}