using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSBBS.HTML
{
    public partial class Publish : System.Web.UI.Page
    {
        protected int PostType;
        protected string PostTitle;
        protected string Temthe;
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            Server.Execute("Head.aspx");
            string pt = Context.Request["postType"];//获取贴子类型



            string TEMP = ckedit.Text;//用户编辑帖子前获取帖子内容


            if (Session["postType"] == null)
            {

                Session["postType"] = pt;
                Session["postPage"] = Context.Request["postPage"].ToString();
            }



            try
            {
            if (Session["isEdit"]==null)
            {
                Session["isEdit"] = Context.Request["isEdit"].ToString();
                
            }
                
                //string isEdit = Context.Request["isEdit"].ToString();//用户编辑个人帖子


                if (Session["isEdit"].ToString() == "true")
                {

                    
                    if (Request.HttpMethod.ToLower() == "post")
                    {
                        //编辑帖子
                        //string page = Context.Request["postPage"].ToString();
                        string TITLE = Request.Form["title"];
                         //TEMP = Request.Form["temp"];
                        string NAME;
                        if (Session["Name"]==null)
                        {
                             NAME = Session["AdminName"].ToString();
                        }
                        else
                        {
                             NAME = Session["Name"].ToString();
                        }
                        
                        int PT = int.Parse(Session["postType"].ToString());
                        DateTime postTime = DateTime.Now;

                        SqlHelper.ExecuteNonQuery("update DS_Post set PostTitle=@PostTitle,PostTheme=@PostTheme,PostType=@PostType,PostDate=@PostDate,PostName=@PostName where id=@page ", new SqlParameter("@PostTitle", TITLE), new SqlParameter("@PostTheme", TEMP), new SqlParameter("@PostType", PT), new SqlParameter("@PostDate", postTime), new SqlParameter("@PostName", NAME), new SqlParameter("@page", Session["postPage"]));
                        Response.Redirect("UserPost.aspx");
                    }
                    else
                    {
                        //展示旧帖内容
                        string ID=Context.Request["postPage"].ToString();
                        DataTable be = SqlHelper.ExecuteDataTable("select*from DS_Post where id=@id", new SqlParameter("@id", ID));
                      DataRow beforEdit = be.Rows[0];
                      PostTitle = beforEdit["PostTitle"].ToString();
                      ckedit.Text = beforEdit["PostTheme"].ToString();

                    }

                }
                else
                {
                    if (Request.HttpMethod.ToLower() == "post")
                    {
                        //获取表单text框内容
                        string TITLE = Request.Form["title"];
                         //TEMP = Request.Form["temp"];
                        string NAME;
                        if (Session["Name"] == null)
                        {
                            NAME = Session["AdminName"].ToString();
                        }
                        else
                        {
                            NAME = Session["Name"].ToString();
                        }
                        
                        int PT = (int)Session["postType"];
                        DateTime postTime = DateTime.Now;

                        SqlHelper.ExecuteNonQuery("Insert into DS_Post(PostTitle,PostTheme,PostType,PostDate,PostName) values(@PostTitle,@PostTheme,@PostType,@PostDate,@PostName)", new SqlParameter("@PostTitle", TITLE), new SqlParameter("@PostTheme", TEMP), new SqlParameter("@PostType", PT), new SqlParameter("@PostDate", postTime), new SqlParameter("@PostName", NAME));
                        Response.Redirect("PostList.aspx?postType=" +PT + "");
                    }
                }
            }
            catch (System.NullReferenceException)
            {

                if (Request.HttpMethod.ToLower() == "post")
                {
                    //获取表单text框内容
                    string TITLE = Request.Form["title"];
                     //TEMP = Request.Form["temp"];
                    string NAME;
                    if (Session["Name"] == null)
                    {
                        NAME = Session["AdminName"].ToString();
                    }
                    else
                    {
                        NAME = Session["Name"].ToString();
                    }
                        
                    int PT = (int)Session["postType"];
                    DateTime postTime = DateTime.Now;

                    SqlHelper.ExecuteNonQuery("Insert into DS_Post(PostTitle,PostTheme,PostType,PostDate,PostName) values(@PostTitle,@PostTheme,@PostType,@PostDate,@PostName)", new SqlParameter("@PostTitle", TITLE), new SqlParameter("@PostTheme", TEMP), new SqlParameter("@PostType", PT), new SqlParameter("@PostDate", postTime), new SqlParameter("@PostName", NAME));
                    Response.Redirect("PostList.aspx?postType=" + PT + "");
                }
            }
        }
    }
}