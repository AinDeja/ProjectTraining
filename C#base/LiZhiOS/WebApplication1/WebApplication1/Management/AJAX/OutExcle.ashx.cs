using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestForNet.DAL;
using WebApplication1.BLL;

namespace WebApplication1.Management.AJAX
{
    /// <summary>
    /// OutExcle 的摘要说明
    /// </summary>
    public class OutExcle : IHttpHandler
    {

        public  void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Fday = context.Request.QueryString["Fday"];
            string Lday = context.Request.QueryString["Lday"];
           // string Path = context.Request.QueryString["Path"];
            //格式转换 .replace
            Fday = Fday.Replace("-", "/");
            Lday = Lday.Replace("-", "/");
            //**********路径获取有问题*************设置默认值，跳出下载窗口自行选择
            string Path = @"H:/新建文件夹/outsign.xlsx";
            //string pathSelf = @"H:/新建文件夹/outsign.xlsx";
            T_SignIN SignTable = new T_SignIN();
            //DataSet selectDateSign = SignTable.outExcle("2016/10/01", "2016/11/01");
            DataSet selectDateSign = SignTable.outExcle(Fday, Lday);
            OutForExcle outxls = new OutForExcle();
            outxls.DataSetToLocalExcel(selectDateSign, Path, false);
            context.Response.Write("ERROR!");
          
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public static string outExcle()
        {
            string tip = "OK!";
            string pathSelf = @"H:/新建文件夹/outsign.xlsx";
            T_SignIN SignTable = new T_SignIN();
            DataSet selectDateSign = SignTable.outExcle("2016/10/01", "2016/11/01");

            OutForExcle outxls = new OutForExcle();
            outxls.DataSetToLocalExcel(selectDateSign, pathSelf, false);
            return tip;
        }
    }
}