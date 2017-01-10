using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InspirationalWeb.DAL;
using InspirationalWeb.Model;
using System.Data;

namespace InspirationalWeb.BLL
{
    public class B_User
    {
    
        public LoginResult Login1(string loginId, string password, out string username)
        {
            username = string.Empty;
            
            T_User dal = new T_User();
            Seat model = dal.GetModelByLoginId(loginId);
            //根据查询到的信息判断用户登录是否成功！
            if (model != null)
            {
                if(loginId=="")
                {
                    return LoginResult.UserNotExists;
                }
                if (password == model.UserPassword)
                {
                    username = model.UserName;
                    return LoginResult.OK;
                }
                else
                {
                    return LoginResult.ErrorPassword;
                }
            }
            else
            {
                return LoginResult.UserNotExists;
            }
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string[] UserMess(string username)
        {
            T_User dal= new T_User();
            Seat model = dal.UserMessSelect(username);
            string UserName, UserPassWord,UserFname,UserEmail,Sex;
            int UserAge;
            Int64 UserQQ,UserPhone;
            DateTime UserBirth;
            bool UserSex;

            UserName = model.UserName;
            UserPassWord = model.UserPassword;
            UserSex=model.UserSex;
            UserAge=model.UserAge;
            UserBirth=model.UserBirth;
            UserQQ=model.UserQQ;
            UserPhone=model.UserPhone;
            UserEmail=model.UserEmail;
            UserFname=model.UserFname;

            if(UserSex)Sex="男";else Sex="女";


            string[] Mess = new string[9];
            Mess[0] = UserName;
            Mess[1] = UserPassWord;
            Mess[2] = Sex;
            Mess[3] = UserAge.ToString();
            Mess[4] = UserBirth.ToShortDateString();
            Mess[5] = UserQQ.ToString();
            Mess[6] = UserPhone.ToString();
            Mess[7] = UserEmail;
            Mess[8] = UserFname;
            return Mess;
        }
        /// <summary>
        /// 用户信息更新
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="sex"></param>
        /// <param name="Fname"></param>
        /// <param name="email"></param>
        /// <param name="age"></param>
        /// <param name="qq"></param>
        /// <param name="phone"></param>
        /// <param name="birth"></param>
        public void UserUpDate(string username,string password,string sex,string Fname,string email,int age,Int64 qq,Int64 phone,DateTime birth)
        {
            T_User dal = new T_User();
            dal.UserUpData(username, password,sex,Fname,email,age,qq,phone,birth);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Register(string name,string password)
        {
            int tip=4;
            if (name != "" && password != "")
            {
                T_User checkUser = new T_User();
                int Check = checkUser.SetCheck(name);
                if (Check == 1)
                {
                    T_User set = new T_User();
                    set.SetUser(name, password);
                    tip = 1;

                }
                else
                {
                    tip = 0;
                }
            }
            else tip = 2;
                return tip;
        }
        /// <summary>
        /// 文章查找
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataTable selectAricle(string UserName)
        {
            T_User ID=new T_User();
            Seat id= ID.UserMessSelect(UserName);
            DataTable articleList = ID.SelectArticle(id.UserID);
            return articleList;
        }
        /// <summary>
        /// 最大页数
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="trpage"></param>
        public int PageMaxPlan(int userid,int trpage)
        {
            
            int pageNumber;
            int pageMax;
            //判断最大页数
            // DataTable postList = Sql.ExecuteDataTable("select*from DS_User order by id");
            T_User pl = new T_User();

            DataTable postList = pl.SelectArticle(userid);
            int pageRemainder = (postList.Rows.Count) % 10;

            if (pageRemainder > 0)
            {
                pageMax = ((postList.Rows.Count) / 10) + 1;
            }
            else
            {
                pageMax = (postList.Rows.Count) / 10;
            }

            //首尾页上下页跳转判断
            if (trpage == 1)
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber = trpage;
                if (pageNumber > pageMax)
                {
                    pageNumber = pageMax;
                }
                else
                {
                    if (pageNumber <= 0)
                    {
                        pageNumber = 1;
                    }
                    else
                    {
                        pageNumber = trpage; //Context.Request["trpage"]; ;
                    }

                }

            }
            return pageNumber;
        }
        /// <summary>
        /// 文章搜索
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public DataTable SearchArticleB(string searchText)
        {
            if(searchText!=""){
            T_User txt=new T_User();
            DataTable searchEnd=txt.SearchArticleT(searchText);
            return searchEnd;
            }
            else
            {
                DataTable searchError = null;
                
                return searchError;
            }
            

        }
        /// <summary>
        /// 文章展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable ArticleViewB(int id)
        {
            T_User VIEW = new T_User();
            DataTable articleList = VIEW.ArticleViewT(id);
            return articleList;
        }
        public string ArticleAuthor(int id)
        {
            T_User name = new T_User();
            string author = name.UserNameSearchByID(id);
            return author;
        }
    }
}