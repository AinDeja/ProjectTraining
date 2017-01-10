using LiZhiOSManagement.Model;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// ArticleExcelOutPut 的摘要说明
    /// </summary>
    public class ArticleExcelOutPut : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //获取参数，导出
            string id = context.Request["id"];
            //int idl = id.Split(',').Length;           //id个数
            //string[] idarr = id.Split(',');
            //int[] iditem=new int[idl];
            //for (int i = 0; i < idl;i++ )
            //{
            //    iditem[i] = Convert.ToInt32(idarr[i]);
            //}


            //T_Article.ID,T_Article.IsDelete,T_Article.CreateTime,T_Article.BelongKind,T_Article.Title,T_Article.Content,T_User.UserName
            DataTable dt = SqlHelper.ExecuteDataTable("select T_Article.*,T_User.UserName from T_Article,T_User where T_Article.BelongUser=T_User.ID and T_Article.ID in(" + id + ")", CommandType.Text);
                


                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet1");

                NPOI.SS.UserModel.IRow headerrow = sheet.CreateRow(0);
                ICellStyle style = book.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;

                for (int i = 0; i < dt.Columns.Count-1; i++)                 //最后一列新添加的不能添加
                {
                    ICell cell = headerrow.CreateCell(i);
                    cell.CellStyle = style;
                   
                    if(dt.Columns[i].ColumnName=="BelongUser")
                    {
                        cell.SetCellValue(dt.Columns[9].ColumnName);
                    }
                    else
                    {
                        cell.SetCellValue(dt.Columns[i].ColumnName);
                    }
                    
                }

                //    表头
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    IRow irow = sheet.CreateRow(j + 1);
                    for (int k = 0; k < dt.Columns.Count-1; k++)                     //最后一列新添加的不能添加
                    {
                        if(k==6)
                        {
                            irow.CreateCell(k).SetCellValue(dt.Rows[j][9].ToString());
                        }
                        else
                        {
                            irow.CreateCell(k).SetCellValue(dt.Rows[j][k].ToString());
                        }
                        
                    }
                }




                MemoryStream ms = new MemoryStream();
                book.Write(ms);
                context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", HttpUtility.UrlEncode("hello" + "_" + DateTime.Now.ToString("yyyy-MM-dd"), System.Text.Encoding.UTF8)));
                context.Response.BinaryWrite(ms.ToArray());
                context.Response.End();
                //book = null;
                ms.Close();
                ms.Dispose();

                //context.Response.End();
                dt.Dispose();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}