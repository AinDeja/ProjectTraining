using InspirationalWeb.DAL;
using InspirationalWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InspirationalWeb.BLL
{
    public class B_Admin
    {
        public LoginResult Login1(string loginId, string password, out string username)
        {
            username = string.Empty;

            T_Admin dal = new T_Admin();
            Seat model = dal.GetModelByLoginId(loginId);
            //根据查询到的信息判断用户登录是否成功！
            if (model != null)
            {
                if (loginId == "")
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
        public int PageMaxPlan(int trpage)
        {

            int pageNumber;
            int pageMax;
            //判断最大页数
            // DataTable postList = Sql.ExecuteDataTable("select*from DS_User order by id");
            T_ArticleSelect pl = new T_ArticleSelect();

            DataTable postList = pl.SelectArticleAll();
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
        //新增文章类
        public void newArticleType(string father)
        {
            if (father.Length != 0)
            {
                T_Admin newFather = new T_Admin();
                newFather.newArticleTypeT(father);
            }
        }
        public void newArticleTypeSon(int father,string son)
        {
            if (son.Length != 0)
            {
                T_Admin newSon = new T_Admin();
                newSon.newArticleTypeSonT(father,son);
            }
        }
    }
}