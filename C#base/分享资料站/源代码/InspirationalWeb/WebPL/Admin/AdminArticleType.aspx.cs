using InspirationalWeb.BLL;
using InspirationalWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.Admin
{
    public partial class AdminArticleType : System.Web.UI.Page
    {
        protected System.Text.StringBuilder fatherTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder sonTr = new System.Text.StringBuilder(500);
        protected int f,fts;

        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckAdminLogin();
            T_User list = new T_User();
            DataTable father = list.SearchArticleTypeFather();
            int id =Convert.ToInt32( Context.Request["id"]);
            string del = Context.Request["del"];
            
            
            if (del == "1")//判断是否执行删除操作
            {

                T_ArticleSelect dela = new T_ArticleSelect();
                
                dela.delArticleF(id);
                Response.Redirect("AdminArticleType.aspx");
            }
            if (del == "2")
            {
                T_ArticleSelect dela = new T_ArticleSelect();
                dela.delArticleS(id);
                Response.Redirect("AdminArticleType.aspx");
            }
            foreach (DataRow ddf in father.Rows)
            {
                if ((bool)ddf["IsDelete"] == false)
                {
                    fatherTr.Append("<dd class='fathertypes' >" + ddf["TypeName"] + "<span><a href='javascript:void(0)' onclick=\"turnto('/WebPL/Admin/AdminArticleType.aspx?fts=" + ddf["ID"] + "')\">子类</a></span><span><a href='javascript:void(0)' onclick='doDelF(" + ddf["ID"] + ")'>删除</a></span></dd> ");
                }
               
            }


            fts = Convert.ToInt32(Context.Request["fts"]);
            
                    DataTable son = list.SearchArticleTypeSon(fts);
                    foreach (DataRow dds in son.Rows)
                    {
                        if ((bool)dds["IsDelete"] == false)
                        {
                            sonTr.Append("<dd>" + dds["TypeName"] + " <span><a href='javascript:void(0)' onclick='doDelS(" + dds["ID"] + ")'>删除</a></span></dd>");
                        }
                    }

                    if (Request.HttpMethod.ToLower() == "post")
                    {
                         B_Admin newT = new B_Admin();
                        string newFather = Context.Request["newFather"];
                        string newSon = Context.Request["newSon"];
                        if (newSon.Length == 0)
                        {

                            newT.newArticleType(newFather);
                        }
                        else
                            newT.newArticleTypeSon(Convert.ToInt32( Session["F"]), newSon);
                        Response.Redirect("AdminArticleType.aspx?fts=" + Convert.ToInt32(Session["F"]) + "");
                    }
                    Session["F"] = fts;
            
        }
    }
}