using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// UsersExcelOutPut 的摘要说明
    /// </summary>
    public class UsersExcelOutPut : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["id"];
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            List<Managers> listm = new List<Managers>();
            List<SuperManagers> listsm = new List<SuperManagers>();
            listm = smm.selectM();
            listsm = smm.selectSM();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_User where ID in(" + id + ")", CommandType.Text);


            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet1");

            NPOI.SS.UserModel.IRow headerrow = sheet.CreateRow(0);
            ICellStyle style = book.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < dt.Columns.Count; i++)                 //最后一列新添加的不能添加
            {
                ICell cell = headerrow.CreateCell(i);
                cell.CellStyle = style;

                cell.SetCellValue(dt.Columns[i].ColumnName);

            }

            //    表头
            if(HttpContext.Current.Session["quan"].ToString()=="sm")                //登陆人：超管
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    IRow irow = sheet.CreateRow(j + 1);
                    for (int k = 0; k < dt.Columns.Count; k++)                     //最后一列新添加的不能添加
                    {
                        if(k==4)
                        {
                            if (listsm.Exists(r => r.UserName == dt.Rows[j][3].ToString() && r.UserName != HttpContext.Current.Session["name"].ToString()))
                            {
                                irow.CreateCell(k).SetCellValue("*****");
                            }
                            else
                            {
                                irow.CreateCell(k).SetCellValue(dt.Rows[j][k].ToString());
                            }
                        }
                        
                        else
                        {
                            irow.CreateCell(k).SetCellValue(dt.Rows[j][k].ToString());
                        }
                        

                    }
                }
            }
            else
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    IRow irow = sheet.CreateRow(j + 1);
                    for (int k = 0; k < dt.Columns.Count; k++)                     //最后一列新添加的不能添加
                    {
                        if(k==4)
                        {
                            if (listsm.Exists(r => r.UserName == dt.Rows[j][3].ToString()) || listm.Exists(r => r.UserName == dt.Rows[j][3].ToString() && r.UserName != HttpContext.Current.Session["name"].ToString()))
                            {
                                irow.CreateCell(k).SetCellValue("*****");
                            }
                            else
                            {
                                irow.CreateCell(k).SetCellValue(dt.Rows[j][k].ToString());
                            }
                        }
                        else
                        {
                            irow.CreateCell(k).SetCellValue(dt.Rows[j][k].ToString());
                        }


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