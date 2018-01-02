using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model {


    public class User
    {
        public string USER_UID;
        public string EMAIL;
        public string PWD;
        public string CREATE_DATE;
        public string EMAIL_CONFIRM;
        public string MEMO;
        public string LAST_LOGIN_DATE;
        public string ROLE_ID;
        public string STATUS;
        public string LAST_LOGIN_IP;
        public string NICK_NAME;

        public User() {

        }

        public User(string USER_UID,
            string EMAIL,
            string PWD,
            string CREATE_DATE,
            string EMAIL_CONFIRM,
            string MEMO,
            string LAST_LOGIN_DATE,
            string ROLE_ID,
            string STATUS ,
            string LAST_LOGIN_IP,
            string NICK_NAME) {

            this.USER_UID = USER_UID;
            this.EMAIL = EMAIL;
            this.PWD = PWD;
            this.CREATE_DATE = CREATE_DATE;
            this.EMAIL_CONFIRM = EMAIL_CONFIRM;
            this.MEMO = MEMO;
            this.LAST_LOGIN_DATE = LAST_LOGIN_DATE;
            this.ROLE_ID = ROLE_ID;
            this.STATUS = STATUS;
            this.LAST_LOGIN_IP = LAST_LOGIN_IP;
            this.NICK_NAME = NICK_NAME;
        }


    }
}