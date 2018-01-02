using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Configuration;

namespace com.oli365.prize.core
{

    public static class Helper
    {

        /// <summary>
        /// 連線字串
        /// </summary>
        /// <returns></returns>
        public static string getConnectionString()
        {
            string connstring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            return connstring;
        }





        #region Page使用

        /// <summary>
        /// 警示訊息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void Alert(Page page, string msg)
        {
            //msg = page.Server.HtmlEncode(msg);
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), new Guid().ToString(), "<script>alert('" + msg + "');</script>");

        }

        /// <summary>
        /// 警示訊息後轉址
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void Alert(Page page, string msg, string url)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), new Guid().ToString(), "<script>alert('" + msg + "');location.href='" + url + "'</script>");
        }


        #endregion

    }
}