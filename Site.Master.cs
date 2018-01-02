using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace com.oli365.prize
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected System.Web.UI.WebControls.HyperLink labLogin;
        protected System.Web.UI.WebControls.Label labUserName;
        protected System.Web.UI.WebControls.LinkButton lnkLogout;
        protected System.Web.UI.WebControls.Menu NavigationMenu;


        protected void Page_Load(object sender, EventArgs e)
        {

            InitData();

            if (!IsPostBack) {
              
            }
        }

        private void InitData() {

            HttpContext context = HttpContext.Current;
            if (context.User.Identity.IsAuthenticated)
            {
                labLogin.Visible = false;
                labUserName.Visible = true;
              //  labUserName.Text = UserUtility.GetUser(context.User.Identity.Name).NickName ;
                lnkLogout.Visible = true;
                CheckMenu();
            }
            else {

                labLogin.Visible = true;
                labUserName.Visible = false ;
                lnkLogout.Visible = false;
            }


        }

        private void CheckMenu() {

            HttpContext context = HttpContext.Current;
            //檢查該角色所屬

           


            //一般會員選單
            if (context.User.IsInRole("00") || context.User.IsInRole("10"))
            {

               // MenuItem m = new MenuItem("會員選單");
               // m.Selectable = false;
              //  m.ChildItems.Add(new MenuItem("歷史開獎機率", null, null, "~/Member/NumberList.aspx"));
                //   m.ChildItems.Add(new MenuItem("減重日誌", null, null, "~/Member/RecordList.aspx"));
                //    m.ChildItems.Add(new MenuItem("日誌分析", null, null, "~/Member/RecordList.aspx"));

                //NavigationMenu.Items.Add(m);


            }

            //管理者選單
            if (context.User.IsInRole("10"))
            {
              
                MenuItem a = new MenuItem("系統管理");
                a.Selectable = false;
              
                a.ChildItems.Add(new MenuItem("會員清單", null, null, "~/Admin/MemberList.aspx"));
                a.ChildItems.Add(new MenuItem("登入記錄", null, null, "~/Admin/LoginHistoryList.aspx"));
                a.ChildItems.Add(new MenuItem("錯誤記錄", null, null, "~/Admin/ErrorLog.aspx"));

                /*
              a.ChildItems.Add(new MenuItem("登入記錄", null, null, "~/Admin/LoginHistoryList.aspx"));
              a.ChildItems.Add(new MenuItem("減重日誌", null, null, "~/Admin/RecordList.aspx"));
              a.ChildItems.Add(new MenuItem("錯誤記錄", null, null, "~/Admin/ErrorLog.aspx"));
              a.ChildItems.Add(new MenuItem("食物管理", null, null, "~/Admin/FoodList.aspx"));
              a.ChildItems.Add(new MenuItem("食物分類管理", null, null, "~/Admin/FoodTypeList.aspx"));
              a.ChildItems.Add(new MenuItem("食物關連管理", null, null, "~/Admin/FoodTypeLinkList.aspx"));
               */
                NavigationMenu.Items.Add(a);

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Controller.UserController uc = new Controller.UserController();
            uc.Logout();

        //    UserUtility.Logout();
            InitData();
            Response.Redirect("Default.aspx");
        }
    }

}