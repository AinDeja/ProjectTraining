using InspirationalWeb.BLL;
using InspirationalWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.User
{
    public partial class SetNewArticle : System.Web.UI.Page
    {
        protected System.Text.StringBuilder fatherTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder sonTr = new System.Text.StringBuilder(500);
        protected string arTitle, arAuthor, arContents, arTime;
        protected string lastTitle, lastAuthor, lastContents, lastTime;
        protected string nextTitle, nextAuthor, nextContents, nextTime;
        protected string tip, lnlast, lnnext;
        protected int j;//父类是否被选中
        protected int f, fts;
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();

            fts = Convert.ToInt32(Context.Request["fts"]);
            j=Convert.ToInt32(Context.Request["j"]);
            T_User list = new T_User();
            DataTable father = list.SearchArticleTypeFather();
            DataTable son = list.SearchArticleTypeSon(fts);
            
            //string id = Context.Request["id"];
            if(j==0)
            {
                 fatherTr.Append("<option selected='selected' value='0'>--请选择-- </option> ");
            foreach (DataRow ddf in father.Rows)
            {
                //<option selected="selected" value="0">--请选择-- </option> 
                if ((bool)ddf["IsDelete"] == false)
                {
                    
                    fatherTr.Append("<option onclick=\"turnto('/WebPL/User/SetNewArticle.aspx?fts=" + ddf["ID"] + "&j=1')\" value='" + ddf["ID"] + "' \">" + ddf["TypeName"] + "</option>");
                }
                
            }
            }
            else
            { 
                 foreach (DataRow ddf in father.Rows)
            {
                //<option selected="selected" value="0">--请选择-- </option> 
                if ((bool)ddf["IsDelete"] == false&&Convert.ToInt32(ddf["ID"])==fts)
                {
                    fatherTr.Append("<option selected='selected' onclick=\"turnto('/WebPL/User/SetNewArticle.aspx?fts=" + ddf["ID"] + "&j=1')\" value='" + ddf["ID"] + "' \">" + ddf["TypeName"] + "</option>");
                }
            }
                 foreach (DataRow ddf in father.Rows)
                 {
                     //<option selected="selected" value="0">--请选择-- </option> 
                     if ((bool)ddf["IsDelete"] == false)
                     {
                         fatherTr.Append("<option onclick=\"turnto('/WebPL/User/SetNewArticle.aspx?fts=" + ddf["ID"] + "&j=1')\" value='" + ddf["ID"] + "' \">" + ddf["TypeName"] + "</option>");
                     }
                 }
            }
            //string rFa = Request.Form["FatherType"];
            foreach (DataRow dds in son.Rows)
            {
                if ((bool)dds["IsDelete"] == false &&  Convert.ToInt32( dds["TypeFather"])==fts)
                {
                    sonTr.Append("<option value='" + dds["ID"] + "'>" + dds["TypeName"] + " </option>");
                }
            }

            if (Request.HttpMethod.ToLower() == "post")
            {

                arTitle = Context.Request["arTitle"];
                arContents = Context.Request["txteditor"];
                
                int arAu = 0;//用户名
                int arType = Convert.ToInt32(Request.Form["SonType"]);
                T_User set = new T_User();
                int id=set.SetArticleT(arAu,arType,arTitle,arContents);
                Response.Redirect("ArticleView.aspx?arID="+id+"");
            }



        }
    }
}