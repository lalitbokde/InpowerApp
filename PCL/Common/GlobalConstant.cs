﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Common
{
    public class GlobalConstant
    {
        public static string BaseUrl = "http://154.27.80.52:8005/api/";
        // public static string BaseUrl = "http://localhost:54386/api/";
        public static string BaseUrlSignalR = "http://154.27.80.52:8005";
        public static string TokenURL = "http://154.27.80.52:8005/token";
        public static string AccessToken { get; set; }
        public static string DefaultProfile = "http://d25g1coazea76c.cloudfront.net/default_profile.png";
        public static string DefaultBook = "http://d25g1coazea76c.cloudfront.net/default_Book.png";

        public static string AWS_ACCESS_KEY = "AWS_ACCESS_KEY";
        public static string AWS_SECRET_KEY = "AWS_SECRET_KEY";
        public static string PREF_SHOUT_OUT = "isShoutOut";
        //pref 
        public static bool LoaderShow = true;
        public static bool ContactInsertStart = true;
        public static bool ChatInsertStart = true;



        public static string PREF_USERID = "userId";
        public static string PREF_Password = "password";
        public static string PREF_AccessKEY = "accesskey";
        public static string PREF_Email = "email";
        public struct AccountUrls
        {
            //Post
            public static string RegisterServiceUrl = "AccountApi/Register";
            public static string LoginServiceUrl = "AccountApi/Login";


        }
        public struct CommonUrls
        {
            //Post
            public static string GetInterestServiceUrl = "Common/GetInterest";
            public static string PostInterestServiceUrl = "Common/PostInterestMap";
            public static string PostSuggestInterestServiceUrl = "Common/PostSuggestedInterest";
            public static string PostAndroidTokenServiceUrl = "ChatApi/UpdateAndroidToken";


        }
        public struct SettingUrls
        {
            public static string PostChangePasswordServiceUrl = "SettingApi/changepassword";
            public static string PostDeleteAccountUrl = "SettingApi/DeleteAccount";
            public static string postBlockUser = "Settingapi/BlockUser";
            public static string postUnBlockUserUrl = "SettingApi/Unblock";
            public static string getblockedContacturl = "SettingApi/BLockList";
        }

        public struct ChatUrls
        {
            //Post
            public static string getAllChatServiceUrl = "ChatApi/GetAllChatList";
            public static string PostChat = "ChatApi/PostChat";
            public static string PrivateChatMessage = "ChatApi/GetChatMessagesUpto";



        }

        public struct GroupChatUrls
        {
            //Post
            public static string PostGroupUrl = "GroupApi/CreateGroup";
            public static string GetGroupUrl = "GroupApi/GetGroups";
            public static string PostMessageGroupUrl = "GroupApi/PostMessage";
            public static string GetGroupMessagesUptoUrl = "GroupApi/GetGroupMessagesUpto";



        }
        public struct ContactUrls
        {
            //Post
            public static string getAllContactServiceUrl = "ContactApi/GetAll";
            public static string getGetAllMyContactServiceUrl = "ContactApi/GetAllMyContact";
            public static string getFriendshipContactServiceUrl = "ContactApi/GetAllContact";
            public static string AddContactUrl = "ContactApi/AddContact";


        }

        public struct BookShelfUrls
        {
            //Get
            public static string getAllBooksUrl = "BooksApi/GetBookAll";

            //Post
            public static string PostBookUrl = "BooksApi/UserBookAdd";
            public static string UpdateBookUrl = "BooksApi/UserBookUpdate";
            public static string RemoveBookUrl = "BooksApi/RemoveBook";

        }




        public static string CrashUrl = "CrashReportApi/SendCrash";
    }
}
