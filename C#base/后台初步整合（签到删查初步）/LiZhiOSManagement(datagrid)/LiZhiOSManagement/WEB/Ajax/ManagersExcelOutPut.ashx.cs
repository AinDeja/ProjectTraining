using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// OutputExcel 的摘要说明
    /// </summary>
    public class OutputExcel : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["id"];



            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Managers where ID in("+id+")", CommandType.Text);
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            List<SuperManagers> listsm = new List<SuperManagers>();
            List<Managers> listm=new List<Managers>();
            listm = smm.selectM();
            listsm = smm.selectSM();


            //@"C:\Users\lenovo\Desktop\1"
            //string filename = "hello";


            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet1");

            NPOI.SS.UserModel.IRow headerrow = sheet.CreateRow(0);
            ICellStyle style = book.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;

            //    表头
              for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = headerrow.CreateCell(i);
                    cell.CellStyle = style;
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }
            
            

            if(HttpContext.Current.Session["quan"].ToString()=="sm")                        //登陆为超管
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    IRow irow = sheet.CreateRow(j + 1);
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        if(k==4)
                        {
                            if(listsm.Exists(r=>r.UserName==dt.Rows[j][3].ToString()&&r.UserName!=HttpContext.Current.Session["name"].ToString()))
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
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        if (k == 4)
                        {
                            if (listsm.Exists(r => r.UserName == dt.Rows[j][3].ToString() && r.UserName != HttpContext.Current.Session["name"].ToString())||listm.Exists(r=>r.UserName==dt.Rows[j][3].ToString()&&r.UserName!=HttpContext.Current.Session["name"].ToString()))
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
            book = null;
            ms.Close();
            ms.Dispose();

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