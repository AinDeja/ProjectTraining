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
    public partial class AdminImges : System.Web.UI.Page
    {
        public int list;
        protected int trpage;
        protected int pageNumber;
        protected int pageMax;
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckAdminLogin();
            B_Admin alist = new B_Admin();
            pageNumber = alist.PageMaxPlan(trpage);
            string id = Context.Request["id"];
            string del = Context.Request["del"];
            if (del == "1")//判断是否执行删除操作
            {
                T_Img dela = new T_Img();
                dela.delPhoto(Convert.ToInt32(id));
                Response.Redirect("AdminImges.aspx");
            }
            //批量删除
            if (Request.HttpMethod.ToLower() == "post")
            {
                string strBoth = Context.Request.Form["chkId"];
                if (string.IsNullOrEmpty(strBoth))
                {
                    Response.Redirect("AdminImges.aspx");
                }
                else
                {
                    T_Img dela = new T_Img();
                    dela.delPhotoAll(strBoth);
                    Response.Redirect("AdminImges.aspx");
                }
            }

            pageNumber = Convert.ToInt32(Context.Request["pageNumber"]);
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            T_Img allImges = new T_Img();
            DataTable allPhotoList = allImges.allPhotoList(pageNumber);
            foreach (DataRow dr in allPhotoList.Rows)
            {

                if ((bool)dr["IsDelete"] == false)
                {
                    string pd = String.Format("{0:yyyy/MM/dd}", dr["CreateTime"]);//格式化时间
                    tTr.Append("<tr class='mtr'>");
                    tTr.Append("<td><input type='checkbox' value='" + dr["ID"] + "' name='chkId'/></td>");
                    tTr.Append("<td>" + dr["ImgType"] + "</td>");
                    tTr.Append("<td>" + dr["ImgMess"] + "</td>");
                    tTr.Append("<td>" + pd + "</td>");
                    tTr.Append("<td><img src='" + dr["ImgPath"] + "'/></td>");
                    //tTr.Append("<td>" + dr["PostClass"] + "</td>");
                    tTr.Append("<td><span><a href='#' onclick='doDel(" + dr["ID"] + ")'>删除</a></span><span><a href='#' onclick=\"turnto('/WebPL/Admin/AdminImges.aspx?arID=" + dr["id"] + "');return false;\">浏览</a></span></td>");
                    tTr.AppendLine("</tr>");
                }

            }
        }
    }
}