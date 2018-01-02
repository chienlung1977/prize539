using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text;
using System.Drawing;

    public class Utility
    {
        public static String GetEncString(String text)
        {

            System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
            byte[] key = Convert.FromBase64String("YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4");
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用
            byte[] data = utf8.GetBytes(text);

            byte[] str3 = Des3.Des3EncodeCBC(key, iv, data);

            String encString = Convert.ToBase64String(str3);
            return encString;
        }



        //取得亂數
        public static string GetRandomString(int Size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < Size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        //取得編號
        public static String GetKeyId(String key) {

            String result = key + DateTime.Now.ToString("yyyyMMdd") + GetRandomString(4);
            return result;

        }


        /// <summary>
        ///  判斷client端是否有設定代理伺服器
        /// </summary>
        /// <returns></returns>
        public static  string GetClientIP()
        {
              
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] == null)
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            else
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }




        public static Color HexColor(String hex)
        {
            //將井字號移除
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;
            int start = 0;

            //處理ARGB字串 
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            // 將RGB文字轉成byte
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }


    }


   


