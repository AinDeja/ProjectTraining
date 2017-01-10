using InspirationalWeb.BLL;
using InspirationalWeb.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace InspirationalWeb.WebPL
{
    public partial class imgup : System.Web.UI.Page
    {

        protected int j;//父类是否被选中
        protected int f, fts;
        protected System.Text.StringBuilder fatherTr = new System.Text.StringBuilder(500);
        protected string aaa, bbb;
        protected void Page_Load(object sender, EventArgs e)
        {

            Distinguish.CheckLogin();
          
            fts = Convert.ToInt32(Context.Request["fts"]);
            Session["PhotoType"] = fts;
            //if (Context.Request["ImgMess"] != null)
            //{
            //    Session["ImgMess"] = Context.Request["ImgMess"];

            //bbb = Context.Request["ImgMess"].ToString();
            //}
                
                aaa = Session["PhotoType"].ToString();
              
            j = Convert.ToInt32(Context.Request["j"]);
            T_Img list = new T_Img();
            DataTable father = list.SearchPhotoType(2);

            //string id = Context.Request["id"];
            if (j == 0)
            {
                fatherTr.Append("<option selected='selected' value='0'>--请选择-- </option> ");
                foreach (DataRow ddf in father.Rows)
                {
                    //<option selected="selected" value="0">--请选择-- </option> 
                    if ((bool)ddf["IsDelete"] == false)
                    {

                        fatherTr.Append("<option onclick=\"turnto('/WebPL/imgup.aspx?fts=" + ddf["ID"] + "&j=1')\" value='" + ddf["ID"] + "' \">" + ddf["AlbumName"] + "</option>");
                    }

                }
            }
            else
            {
                foreach (DataRow ddf in father.Rows)
                {
                    //<option selected="selected" value="0">--请选择-- </option> 
                    if ((bool)ddf["IsDelete"] == false && Convert.ToInt32(ddf["ID"]) == fts)
                    {
                        fatherTr.Append("<option selected='selected' onclick=\"turnto('/WebPL/imgup.aspx?fts=" + ddf["ID"] + "&j=1')\" value='" + ddf["ID"] + "' \">" + ddf["AlbumName"] + "</option>");
                    }
                }
                foreach (DataRow ddf in father.Rows)
                {
                    //<option selected="selected" value="0">--请选择-- </option> 
                    if ((bool)ddf["IsDelete"] == false)
                    {
                        fatherTr.Append("<option onclick=\"turnto('/WebPL/imgup.aspx?fts=" + ddf["ID"] + "&j=1')\" value='" + ddf["ID"] + "' \">" + ddf["AlbumName"] + "</option>");
                    }
                }
            }



            //if (Request.HttpMethod.ToLower() == "post")
            //{

            //    arTitle = Context.Request["arTitle"];
            //    arContents = Context.Request["txteditor"];

            //    int arAu = 0;//用户名
            //    int arType = Convert.ToInt32(Request.Form["SonType"]);
            //    T_User set = new T_User();
            //    int id = set.SetArticleT(arAu, arType, arTitle, arContents);
            //    Response.Redirect("ArticleView.aspx?arID=" + id + "");
            //}

        }
    }
}


        
        //protected void ButtonView_ServerClick(object sender, EventArgs e)
        //{


        
                
            
        //}
        ////protected void btnSubmit_ServerClick(object sender, EventArgs e)
        ////{
        ////    if (fupImage.HasFile)
        ////    {
        ////        Regex regex = new Regex(@".(?i:jpg|jpeg|gif|png)$");
        ////        if (regex.IsMatch(Path.GetExtension(fupImage.FileName)))
        ////        {
        ////            string path = AppDomain.CurrentDomain.BaseDirectory + "uploads";
        ////            if (!Directory.Exists(path))
        ////                Directory.CreateDirectory(path);
        ////            string filePath = fupImage.PostedFile.FileName;  //此处需要处理同名文件

        ////            string filename = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fffffff") + filePath.Substring(filePath.LastIndexOf('.'), filePath.Length - filePath.LastIndexOf('.'));
        ////            //设定上传路径（绝对路径）
        ////            string uppath = Server.MapPath("~/Photo/") + filename;

        ////            fupImage.SaveAs(uppath);
        ////            ImgUp up = new ImgUp();
        ////            up.ImgUploade(0, path + filePath);
        ////            //up.ImgUploade(0,)
        ////            img2.ImageUrl = uppath;
        ////        }
        ////    }
           
        ////}
 
     