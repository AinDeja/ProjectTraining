 <%@ WebHandler Language="C#" Class="imageUp" %>


using System;
using System.Web;
using System.IO;
using System.Collections;

public class imageUp : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        //上传配置
        int size = 2;           //文件大小限制,单位MB                             //文件大小限制，单位MB
        string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };         //文件允许格式


        //上传图片
        Hashtable info = new Hashtable();
        Uploader up = new Uploader();
        
        string pathbase = null;
        int path=Convert.ToInt32( up.getOtherInfo(context, "dir"));
        if (path == 1)
        {
            pathbase = "/WebPL/UserImages/" ;                  
            
        }else{
            pathbase = "/WebPL/UserImages/";
        }
        
        info = up.upFile(context, pathbase, filetype, size);                   //获取上传状态
        
        string title = up.getOtherInfo(context, "pictitle");                   //获取图片描述

        string acb = HttpContext.Current.Session["urlimg"].ToString();
        string userid = HttpContext.Current.Session["Name"].ToString();
        int TYPEimg = Convert.ToInt32(HttpContext.Current.Session["PhotoType"]);
        InspirationalWeb.DAL.T_User unameid = new InspirationalWeb.DAL.T_User();
        int uid=unameid.IDByUserNameSearch(userid);
        
        string oriName = up.getOtherInfo(context, "fileName");                //获取原始文件名
        InspirationalWeb.DAL.T_Img upaaa = new InspirationalWeb.DAL.T_Img();
        upaaa.Up(acb, title, uid,TYPEimg);

        HttpContext.Current.Response.Write("{'url':'" + info["url"] + "','title':'" + title + "','original':'" + oriName + "','state':'" + info["state"] + "'}");  //向浏览器返回数据json数据
        
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}