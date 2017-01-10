using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace NewStart.demo._2014.flashupload
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection files = Request.Files;

            //if (files.Count == 0)
            //{
            //    Response.Write("请勿直接访问本文件");
            //    Response.End();
            //}

            string filePath = Server.MapPath("ImageList");

            // 只取第 1 个文件
            HttpPostedFile file = files[0];

            if (file != null && file.ContentLength > 0)
            {
                // flash 会自动发送文件名到 Request.Form["fileName"]
                string savePath = filePath + "/" + Request.Form["fileName"];
                
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                file.SaveAs(filePath + savePath);
            }

        }
    }
}