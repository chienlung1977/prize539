using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.oli365.prize.core
{
    public class Settings
    {

        static string mHostName;

        public static string HostName
        {
            get
            {
                if (mHostName == null)
                {
                    mHostName = ParaUtility.GetPara("HOST_NAME").Value;
                }
                return mHostName;
            }
        }
    }

 
}